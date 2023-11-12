using API.Models;

namespace API.DTOs.CharacterDTO
{
    public class UpdateCharacterRequest
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Attack { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public Vocation Vocation { get; set; } = Vocation.Knight;
    }
}
