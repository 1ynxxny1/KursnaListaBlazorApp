using Newtonsoft.Json;

namespace ExchangeRateBlazorApp.Models
{
    public class KursnaLista
    {
        [JsonProperty("Drzava")]
        public string Country { get; set; }

        [JsonProperty("Oznaka")]
        public string Currency { get; set; }

        [JsonProperty("Sreden")]
        public string MiddleRate { get; set; }
    }
}
