using ClientApi.Common;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IReportService _reportService;

        public ValuesController(IBackgroundJobClient backgroundJobClient, IReportService reportService)
        {
            _backgroundJobClient = backgroundJobClient;
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var reportModel = new ReportModel() { Name = name };
            var jobId = _backgroundJobClient.Enqueue(() => _reportService.Generate(5, reportModel));
            var result = await _reportService.Generate(5, reportModel);
            return Ok(new { jobId, result });
        }
    }
}
