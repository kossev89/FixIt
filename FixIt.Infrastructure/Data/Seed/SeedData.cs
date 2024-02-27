using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Seed
{
    internal class SeedData
    {
        public SeedData()
        {
            SeedUsers();
            SeedCars();
            SeedServices();
            SeedTechnicians();
            SeedServiceHistories();
        }

        public IdentityUser AdminUser { get; set; }
        public IdentityUser CustomerUser { get; set; }
        public Car FirstCar { get; set; }
        public Car SecondCar { get; set; }
        public Service TireRotation { get; set; }
        public Service OilChange { get; set; }
        public Service Diagnostics { get; set; }
        public Service EngineRepair { get; set; }
        public Service SuspensionRepair { get; set; }
        public Service BodyRepair { get; set; }
        public Service Paint { get; set; }
        public ServiceHistory FirstCarHistory { get; set; }
        public Technician FirstTechnician { get; set; }
        public Technician SecondTechnician { get; set; }
        public Technician ThirdTechnician { get; set; }

        private void SeedUsers()
        {

        }
        private void SeedCars()
        {

        }
        private void SeedServices()
        {

        }
        private void SeedServiceHistories()
        {

        }
        private void SeedTechnicians()
        {

        }


    }
}