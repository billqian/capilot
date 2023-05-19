using FluentValidation;
using Syntop.Pilot.Application.WeatherForecasts.Commands.CreateWeatherForecast;

namespace Syntop.Pilot.Dto.WeatherForecasts;

internal class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    public CreateWeatherForecastCommandValidator()
    {
        RuleFor(v => v.Date)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
    }
}