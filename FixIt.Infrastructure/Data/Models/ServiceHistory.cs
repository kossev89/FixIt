using Microsoft.EntityFrameworkCore;

namespace FixIt.Infrastructure.Data.Models
{
    [Comment("Table for the ServiceHistory")]
    public class ServiceHistory
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } 
    }

//Id(Primary Key)
//CarId(Foreign Key to associate the service history record with the car)
//ServiceId(Foreign Key to specify the type of service)
//TechnicianId(Foreign Key to specify the technician who performed the service)
//Date
//Mileage
//Price
//AdditionalDetails(e.g., Notes about the service)
}