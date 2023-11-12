using System.Text.Json.Serialization;

namespace API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Vocation
    {
        Knight = 1,
        Mage = 2,
        Paladin = 3,
        Druid = 4,
    }
}
