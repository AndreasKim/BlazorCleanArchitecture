using BlazorCA.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using BlazorCA.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCA.Server.Controllers;

public class WeatherForecastController : ApiControllerBase
{

    [HttpGet(Name = nameof(WeatherForecastGet))]
    public async Task<IEnumerable<WeatherForecast>> WeatherForecastGet()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery()); 
    }
}
