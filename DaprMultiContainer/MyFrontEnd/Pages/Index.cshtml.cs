using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFrontEnd.Models;

namespace MyFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DaprClient _daprClient;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        public async Task OnGet()
        {
            var forecasts = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "MyBackEnd", "WeatherForecast");
            //ViewData.Add("WeatherForecast", forecasts);
            ViewData["WeatherForecastData"] = forecasts;
        }
    }
}