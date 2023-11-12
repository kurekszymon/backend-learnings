using API.DTOs.CharacterDTO;
using API.Models;
using API.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetCharacterResponse>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetCharacterResponse>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterRequest character)
        {
            await _characterService.AddCharacter(character);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<GetCharacterResponse>> UpdateCharacter(UpdateCharacterRequest character)
        {
            var response = await _characterService.UpdateCharacter(character);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
