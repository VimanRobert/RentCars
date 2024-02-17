using System.ComponentModel.DataAnnotations;

namespace RentCars.Models
{
    public class Car
    {
        [Key] public int carId {  get; set; }
        public required string carBrand { get; set; }
        public double carPrice { get; set; }
        public ICollection<OrderCar> Orders { get; set; }
    }
}
