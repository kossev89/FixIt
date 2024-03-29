using AutoMapper;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.Service;
using FixIt.Core.Models.ServiceHistory;
using FixIt.Core.Models.Technician;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace FixIt.Core.Profiles
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<Car, CarDetailedViewModel>();
            CreateMap<Car, CarFormModel>();
            CreateMap<Appointment, AppointmentViewModel>();
            CreateMap<Service, ServiceViewModel>();
            CreateMap<ServiceHistory, ServiceHistoryViewModel>();
            CreateMap<Technician, TechnicianViewModel>();
            CreateMap<IdentityUser, CustomerViewModel>();
        }
    }
}
