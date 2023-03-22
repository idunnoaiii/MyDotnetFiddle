using Microsoft.AspNetCore.Mvc;

namespace TestCompletionSource.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    public static TaskCompletionSource<int> CompletionSource = new TaskCompletionSource<int>();

    [HttpGet("ask")]
    public async Task<IActionResult> Ask()
    {
        var result = await CompletionSource.Task;
        return Ok(result);
    }

    [HttpGet("tell/{num}")]
    public async Task<IActionResult> Tell([FromRoute] int num)
    {
        CompletionSource.SetResult(num);
        return Ok();
    }
}