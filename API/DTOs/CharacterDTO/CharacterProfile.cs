using API.Models;
using AutoMapper;

namespace API.DTOs.CharacterDTO
{
    public class CharacterProfile : Profile
    {

        public CharacterProfile()
        {
            CreateMap<Character, GetCharacterResponse>();
            CreateMap<AddCharacterRequest, Character>();
        }
    }
}
