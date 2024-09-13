using ExchangeRateBlazorApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRateBlazorApp.Services
{
    public class KursnaListaService
    {
        private readonly HttpClient _httpClient;

        public KursnaListaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<KursnaLista>> GetExchangeRates(string date)
        {
            string url = $"https://www.nbrm.mk/KLServiceNOV/GetExchangeRate?StartDate={date}&EndDate={date}&format=json";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Request URL: {url}");
                Console.WriteLine($"Response Data: {responseData}");

                dynamic data = JsonConvert.DeserializeObject<dynamic>(responseData);
                Console.WriteLine($"Deserialized Response: {data}");

                var rates = JsonConvert.DeserializeObject<List<KursnaLista>>(responseData);

                return rates ?? new List<KursnaLista>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching exchange rates: {ex.Message}");
                return new List<KursnaLista>();
            }
        }
    }
}
