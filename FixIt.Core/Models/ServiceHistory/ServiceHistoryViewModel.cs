using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.Service;
using FixIt.Core.Models.Technician;

namespace FixIt.Core.Models.ServiceHistory
{
    public class ServiceHistoryViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public CustomerViewModel User { get; set; } = null!;
        public int ServiceId { get; set; }
        public int TechnicianId { get; set; }
        public CarViewModel Car { get; set; } = null!;
        public ServiceViewModel Service { get; set; } = null!;
        public TechnicianViewModel Technician { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Mileage => Car.Mileage;
        public decimal Price => Service.Price;
    }
}
