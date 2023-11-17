using API.Data;
using API.DTOs.CharacterDTO;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public CharacterService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterResponse>>> GetAllCharacters()
        {
            var dbCharacters = await _context.Characters.ToListAsync();

            var ServiceResponse = new ServiceResponse<List<GetCharacterResponse>>
            {
                Data = _mapper.Map<List<GetCharacterResponse>>(dbCharacters)
            };
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponse>> GetCharacterById(Guid id)
        {
            Character? character = await _context.Characters.FindAsync(id);
            var ServiceResponse = new ServiceResponse<GetCharacterResponse>
            {
                Data = _mapper.Map<GetCharacterResponse>(character)
            };

            return ServiceResponse;
        }

        public async Task AddCharacter(AddCharacterRequest character)
        {
            Character _character = _mapper.Map<Character>(character);

            _context.Characters.Add(_character);

            await _context.SaveChangesAsync();
        }

        public async Task<ServiceResponse<GetCharacterResponse>> UpdateCharacter(Guid id, UpdateCharacterRequest character)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponse>();

            try
            {
                Character? _character = await _context.Characters.FindAsync(id);

                if (_character == null)
                {
                    throw new Exception($"Character with id {id} was not found.");
                }

                _character.Name = character.Name;
                _character.Attack = character.Attack;
                _character.Defense = character.Defense;
                _character.Intelligence = character.Intelligence;
                _character.HitPoints = character.HitPoints;
                _character.Vocation = character.Vocation;


                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterResponse>(_character);

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Error = true;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Guid?>> DeleteCharacter(Guid id)
        {
            var serviceResponse = new ServiceResponse<Guid?>();

            try
            {
                Character? _character = await _context.Characters.FindAsync(id);

                if (_character == null)
                {
                    throw new Exception($"Character with id {id} was not found.");
                }


                _context.Characters.Remove(_character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = id;

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Error = true;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
    }
}
