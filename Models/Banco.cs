using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Banco
    {
        [JsonPropertyName("ispb")]
        public string Ispb;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("code")]
        public int Code;

        [JsonPropertyName("fullName")]
        public string FullName;
    }
}
