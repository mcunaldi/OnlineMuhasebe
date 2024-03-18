using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Queries.GetAllRoles;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;
public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleRequest request)
    {
        CreateRoleResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        GetAllRolesRequest request = new GetAllRolesRequest();
        GetAllRolesResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
    {
        UpdateRoleResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> DeleteRole(string id)
    {
        DeleteRoleRequest request = new DeleteRoleRequest(id);

        DeleteRoleResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
