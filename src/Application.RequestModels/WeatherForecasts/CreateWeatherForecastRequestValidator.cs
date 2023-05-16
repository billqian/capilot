using FluentValidation;

namespace Syntop.Pilot.Dto.WeatherForecasts;

internal class CreateWeatherForecastRequestValidator : AbstractValidator<CreateWeatherForecastRequest>
{
    public CreateWeatherForecastRequestValidator()
    {
        RuleFor(v => v.Date)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
    }
}