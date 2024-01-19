using System.ComponentModel.DataAnnotations;

namespace RentCars.Models
{
    public class Made
    {
        
        [Key] public int carId { get; set; }
        public required string carBrand { get; set; }

        public required string carModel { get; set; }
        public required double carEngine { get; set; }

        public required double carMadeYear { get; set; }

        public required string carFuelType { get; set; }
    }
}
