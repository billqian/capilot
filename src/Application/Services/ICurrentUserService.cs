using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Application.Services;

public interface ICurrentUserService
{
    Guid? UserId { get; }
}
