using API.DTOs.CharacterDTO;
using API.Models;

namespace API.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponse>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterResponse>> GetCharacterById(int id);
        Task AddCharacter(AddCharacterRequest character);
        Task<ServiceResponse<GetCharacterResponse>> UpdateCharacter(UpdateCharacterRequest character);
    }
}
