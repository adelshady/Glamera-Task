namespace Glamera_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }   
        [HttpGet("appointments")]
        public async Task<IActionResult> GetAppointmentReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int? branchId, [FromQuery] int? serviceId, [FromQuery] string status)
        {
            var appointmentData = await _reportService.GetAppointmentReport(startDate, endDate, branchId, serviceId, status);
            if (appointmentData.Succeeded)
                return Ok(appointmentData);
            else if (!appointmentData.Succeeded)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, appointmentData);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, appointmentData);
        }

        [HttpGet("demographics")]
        public async Task<IActionResult> GetCustomerDemographicsReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int? branchId, [FromQuery] string gender)
        {
            var demographicsData = await _reportService.GetCustomerDemographicsReport(startDate, endDate, branchId, gender);
            if (demographicsData.Succeeded) 
                return Ok(demographicsData);
            else if (!demographicsData.Succeeded)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, demographicsData);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, demographicsData);
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int? branchId, [FromQuery] int? serviceId, [FromQuery] string paymentMethod)
        {
            var revenueData = await _reportService.GetRevenueReport(startDate, endDate, branchId, serviceId, paymentMethod);
            if (revenueData.Succeeded)
                return Ok(revenueData);
            else if (!revenueData.Succeeded)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, revenueData);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, revenueData);
        }

    }
}
