﻿namespace FixIt.Core.Models.Car
{
    /// <summary>
    /// Model View for Car Entity
    /// </summary>
    public class CarViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public string PlateNumber { get; init; } = string.Empty;
        public int Mileage { get; set; }
        public string? ImageUrl { get; set; }
    }
}


