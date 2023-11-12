using API.DTOs.CharacterDTO;
using API.Models;
using AutoMapper;

namespace API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;

        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character{Id = 1, Name = "sam"},
        };

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterResponse>>> GetAllCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterResponse>>
            {
                Data = _mapper.Map<List<GetCharacterResponse>>(characters)
            };
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponse>> GetCharacterById(int id)
        {
            Character? character = characters.FirstOrDefault(c => c.Id == id);
            var ServiceResponse = new ServiceResponse<GetCharacterResponse>
            {
                Data = _mapper.Map<GetCharacterResponse>(character)
            };

            return ServiceResponse;
        }

        public async Task AddCharacter(AddCharacterRequest character)
        {
            var characterId = characters.Max(c => c.Id) + 1;
            Character _character = _mapper.Map<Character>(character);
            _character.Id = characterId;

            await Task.Run(() => characters.Add(_character));
        }

        public async Task<ServiceResponse<GetCharacterResponse>> UpdateCharacter(UpdateCharacterRequest character)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponse>();

            try
            {
                Character? _character = characters.FirstOrDefault(c => c.Id == character.Id);

                if (_character == null)
                {
                    throw new Exception($"Character with id {character?.Id} was not found.");
                }

                _character.Name = character.Name;
                _character.Attack = character.Attack;
                _character.Defense = character.Defense;
                _character.Intelligence = character.Intelligence;
                _character.HitPoints = character.HitPoints;
                _character.Vocation = character.Vocation;

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
    }
}
