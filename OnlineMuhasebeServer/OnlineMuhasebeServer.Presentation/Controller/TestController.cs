using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;
public sealed class TestController : ApiController
{
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Api çalışıyor");
    }
}
