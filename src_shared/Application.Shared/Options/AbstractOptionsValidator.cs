using FluentValidation;
using Microsoft.Extensions.Options;

namespace Application.Shared.Options;

public abstract class AbstractOptionsValidator<T> : AbstractValidator<T>, IValidateOptions<T>
    where T : class
{
    public virtual ValidateOptionsResult Validate(string? name, T options)
    {
        var validateResult = this.Validate(options);
        return validateResult.IsValid ? ValidateOptionsResult.Success : ValidateOptionsResult.Fail(validateResult.Errors.Select(x => x.ErrorMessage));
    }
}
