namespace FixIt.Core.Models.Car
{
    /// <summary>
    /// Detailed Model View for Car Entity
    /// </summary>
    public class CarDetailedViewModel
    {
        public int Id { get; set; }
        public string Make { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public int Year { get; init; }
        public string PlateNumber { get; init; } = string.Empty;
        public string? Vin { get; init; }
        public int Mileage { get; set; }
        public string? ImageUrl { get; init; }
    }
}
