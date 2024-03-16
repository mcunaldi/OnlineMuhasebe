using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.MigrateCompanyDatabases;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;
public sealed class CompaniesController : ApiController
{
    public CompaniesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyRequest request)
    {
        CreateCompanyResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> MigrateCompanyDataBases()
    {
        MigrateCompanyDatabasesRequest request = new();
        MigrateCompanyDatabasesResponse response = await _mediator.Send(request);
        return Ok(response);
    }

}
