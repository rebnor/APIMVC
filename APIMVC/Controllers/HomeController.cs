using APIMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace APIMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var sun = await GetSunInfo();
            var joke = await GetRandomJoke();
            sun.setup = joke.setup;
            sun.punchline = joke.punchline;
            return View(sun);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<Sun> GetSunInfo()
        {
            Sun sun = new Sun();
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://api.sunrise-sunset.org/json?lat=59.329380&lng=18.068710&date=today");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                sun = JsonSerializer.Deserialize<Sun>(result);

                return sun;
            }
            else
            {
                return null;
            }
        }

        public async Task<Joke> GetRandomJoke()
        {
            Joke joke = new Joke();
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://official-joke-api.appspot.com/random_joke");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                joke = JsonSerializer.Deserialize<Joke>(result);

                return joke;
            }
            else
            {
                return null;
            }
        }



    }
}
