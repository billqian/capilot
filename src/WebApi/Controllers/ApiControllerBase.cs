using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Syntop.Pilot.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _sender;

    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
