using APIMVC.Models;
using System.Text.Json;

namespace APIMVC.Data
{
    public class GuruRepository : IGuru
    {
        private List<string> guruList = new List<string>();

     
        public async Task<List<string>> GetPartners()
        {
            Guru guru = new Guru();
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://api.apis.guru/v2/providers.json");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                guru = JsonSerializer.Deserialize<Guru>(result);

                foreach (var provider in guru.data)
                {
                    guruList.Add(provider);
                }

                return guruList;
            }
            else
            {
                return null;
            }

        }
    }
}
