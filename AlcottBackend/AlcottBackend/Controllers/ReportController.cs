using AlcottBackend.ClientData;
using AlcottBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AlcottBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ReportService _service;

    public ReportController(ReportService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<ReportResponse> GetDailyReport()
    {
        return Ok(_service.GetDailyReport());
    }
}