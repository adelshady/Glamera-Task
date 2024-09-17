
namespace GlameraTask.Application.Services.Implementation
{
    public class ReportService : IReportService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<BookingReportDto>>> GetAppointmentReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string status)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var query = await _unitOfWork.Repository<Booking>()
           .GetAllAsync(
               filter: b => b.BookingDate >= startDate && b.BookingDate <= endDate,
               includes: q => q
                   .Include(b => b.Branch)
                   .Include(b => b.BookingServices).ThenInclude(bs => bs.Service)
           );

                if (branchId.HasValue)
                {
                    query = query.Where(b => b.BranchId == branchId.Value);
                }

                if (serviceId.HasValue)
                {
                    query = query.Where(b => b.BookingServices.Any(bs => bs.ServiceId == serviceId.Value));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(b => b.Status == status);
                }

                var bookingReports = query.Select(b => new BookingReportDto
                {
                    BookingId = b.BookingId,
                    BranchName = b.Branch.Name,
                    BookingDate = b.BookingDate,
                    Status = b.Status,
                    Services = b.BookingServices.Select(bs => bs.Service.Name).ToList()
                }).ToList();

                return new ApiResponse<IEnumerable<BookingReportDto>>
                {
                    Data = bookingReports,
                    Succeeded = true,
                    Message = "Booking report retrieved successfully"
                };
            }
            catch (Exception ex)
            {
               await  _unitOfWork.RollbackTransactionAsync();
                throw new CustomException("In GetAppointment Report Service = {e.Message}", ex);
            }
       
        }

        public async Task<ApiResponse<IEnumerable<CustomerDemographicsDto>>> GetCustomerDemographicsReport(DateTime startDate, DateTime endDate, int? branchId, string gender)
        {
            try
            {
                Expression<Func<Client, bool>> baseFilter = c => c.Bookings.Any(b => b.BookingDate >= startDate && b.BookingDate <= endDate);

                var query = await _unitOfWork.Repository<Client>()
                    .GetAllAsync(
                        filter: baseFilter,
                        includes: q => q
                            .Include(c => c.Bookings)
                            .ThenInclude(b => b.Branch)
                    );

                if (branchId.HasValue)
                {
                    query = query.Where(c => c.Bookings.Any(b => b.BranchId == branchId.Value));
                }

                if (!string.IsNullOrEmpty(gender))
                {
                    query = query.Where(c => c.Gender == gender);
                }

                var customerDemographics = query.Select(c => new CustomerDemographicsDto
                {
                    CustomerId = c.ClientId,
                    FullName = $"{c.FirstName} {c.LastName}",
                    Gender = c.Gender,
                    RegistrationDate = c.Bookings.Select(x => x.BookingDate).FirstOrDefault(),
                    BranchName = c.Bookings
                        .Select(b => b.Branch.Name)
                        .FirstOrDefault()
                }).ToList();

                return new ApiResponse<IEnumerable<CustomerDemographicsDto>>
                {
                    Data = customerDemographics,
                    Message = "Customer demographics retrieved successfully",
                    Succeeded = true
                };
            }
            catch (Exception ex)
            {
                throw new CustomException("In GetCustomer Demographics Report Serivce = {e.Message}", ex);
            }
         
        }

        public async Task<ApiResponse<RevenueReportDto>> GetRevenueReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string paymentMethod)
        {
            try
            {
                var query = await _unitOfWork.Repository<Transaction>()
                .GetAllAsync(
                    filter: t => t.PaymentDate >= startDate && t.PaymentDate <= endDate,
                    includes: query => query
                        .Include(t => t.Booking)
                        .ThenInclude(b => b.Branch)
                        .Include(t => t.Booking)
                        .ThenInclude(b => b.BookingServices
                ));
                if (branchId.HasValue)
                {
                    query = query.Where(t => t.Booking.BranchId == branchId.Value);
                }

                if (serviceId.HasValue)
                {
                    query = query.Where(t => t.Booking.BookingServices.Any(bs => bs.ServiceId == serviceId.Value));
                }

                if (!string.IsNullOrEmpty(paymentMethod))
                {
                    query = query.Where(t => t.PaymentMethod == paymentMethod);
                }
                double sum = 0;
                foreach (var item in query)
                {
                    sum += (double)item.Amount;
                }


                return new ApiResponse<RevenueReportDto>
                {
                    Data = new RevenueReportDto
                    {
                        TotalRevenue = sum
                    },
                    Message = "Revenue report generated successfully",
                    Succeeded = true
                };
            }catch(Exception ex)
            {
                throw new CustomException("In GetRevenue Report Serivce = {e.Message}", ex);
            }
      
        }
    }
}
