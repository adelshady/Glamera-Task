
namespace GlameraTask.Application.Services.Interfaces
{

    public interface IReportService
    {
        Task<ApiResponse<IEnumerable<BookingReportDto>>> GetAppointmentReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string status);
        Task<ApiResponse<IEnumerable<CustomerDemographicsDto>>> GetCustomerDemographicsReport(DateTime startDate, DateTime endDate, int? branchId, string gender);
        Task<ApiResponse<RevenueReportDto>> GetRevenueReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string paymentMethod);
    }
}
