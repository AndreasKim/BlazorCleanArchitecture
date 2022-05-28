using BlazorCA.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCA.Server.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet(nameof(GetWeatherForecast))]
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery()); 
    }
}
