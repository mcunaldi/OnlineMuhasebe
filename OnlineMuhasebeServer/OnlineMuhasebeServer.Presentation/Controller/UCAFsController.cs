using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;
public sealed class UCAFsController : ApiController
{
    public UCAFsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateUCAF(CreateUCAFCommand request)
    {
        CreateUCAFCommandResponse response =  await _mediator.Send(request);
        return Ok(response);    
    }
}
