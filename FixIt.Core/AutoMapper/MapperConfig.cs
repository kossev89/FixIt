using AutoMapper;
using FixIt.Core.Models.Car;
using FixIt.Infrastructure.Data.Models;

namespace FixIt.Core.Profiles
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<Car, CarDetailedViewModel>();
            CreateMap<Car, CarFormModel>();
        }
    }
}
