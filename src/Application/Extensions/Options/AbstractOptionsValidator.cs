using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.Extensions.Options;

public abstract class AbstractOptionsValidator<T> : AbstractValidator<T>, IValidateOptions<T>
    where T : class
{
    public virtual ValidateOptionsResult Validate(string? name, T options)
    {
        var validateResult = this.Validate(options);
        return validateResult.IsValid ? ValidateOptionsResult.Success : ValidateOptionsResult.Fail(validateResult.Errors.Select(x => x.ErrorMessage));
    }
}
