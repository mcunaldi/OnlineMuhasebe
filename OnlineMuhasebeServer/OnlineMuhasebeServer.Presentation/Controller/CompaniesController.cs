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
    public async Task<IActionResult> Create(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        CreateCompanyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> MigrateCompanyDataBases()
    {
        MigrateCompanyDatabasesCommand request = new();
        MigrateCompanyDatabasesCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
