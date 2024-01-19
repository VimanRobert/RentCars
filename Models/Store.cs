using RentCars.Models;
using System.ComponentModel.DataAnnotations;

namespace RentCars.Data
{
    public class Store
    {
        [Key] public int itemId { get; set; }
        public int carId { get; set; }
        public required string carBrand { get; set; }
        public required string carModel { get; set; }
        public required bool isRented { get; set; }

        public required Car car { get; set; }
    }
}
