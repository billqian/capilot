namespace Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

internal class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    public CreateWeatherForecastCommandValidator()
    {
        RuleFor(v => v.Date)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
    }
}
