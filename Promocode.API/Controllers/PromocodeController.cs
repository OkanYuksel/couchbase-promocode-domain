using MediatR;
using Microsoft.AspNetCore.Mvc;
using Promocode.Application.Commands.CreatePromocode.Dtos;

namespace Promocode.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PromocodeController : ControllerBase
{

    private readonly ILogger<PromocodeController> _logger;
    private readonly IMediator _mediator;

    public PromocodeController(IMediator mediator, ILogger<PromocodeController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost(Name = "Create")]
    public async Task<ActionResult> Create()
    {
        var response = await _mediator.Send(new CreatePromocodeCommand());
        return Ok(response);
    }
}