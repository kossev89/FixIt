using FixIt.Core.Models.Car;
using FixIt.Core.Models.Service;
using System.ComponentModel.DataAnnotations;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;
using FixIt.Infrastructure.Data.Constants;

namespace FixIt.Core.Models.Appointment
{
    public class AppointmentFormModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string UserId { get; init; } = string.Empty;

        public int CarId { get; init; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        public IEnumerable<CarViewModel> CarList { get; set; } = new List<CarViewModel>();

        public int ServiceId { get; init; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        public IEnumerable<ServiceViewModel> ServiceList { get; set; } = new List<ServiceViewModel>();

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime DateAndTime { get; set; }
    }
}
