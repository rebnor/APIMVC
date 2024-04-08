using APIMVC.Models;
using System.Text.Json;

namespace APIMVC.Data
{
    public class ColorRepository : IColor
    {
        private List<CDatum> colors = new List<CDatum>();
        public async Task GetConnectedToAPI()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://reqres.in/api/unknown");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var color = JsonSerializer.Deserialize<Color>(result);


                foreach (var item in color.data)
                {
                    var dogPic = await GetDogPicture();
                    item.message = dogPic.message;
                    colors.Add(item);
                }

            }
        }

        public async Task<List<CDatum>> GetAllColors()
        {
            await GetConnectedToAPI();
            return colors;
        }


        public async Task<DogPicture> GetDogPicture()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://dog.ceo/api/breeds/image/random");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var dogPicture = JsonSerializer.Deserialize<DogPicture>(result);

                return dogPicture;

            }
            return null;

        }
    }
}
