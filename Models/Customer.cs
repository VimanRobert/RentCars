using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RentCars.Models
{
    public class Customer
    {
        [Key] public int customerDrivingId { get; set; }
        public required string customerName { get; set; }
        public DateTime customerBirthDate { get; set; }
        public required string customerCounty { get; set; }
        public required string customerAdress { get; set; }

        public ICollection<OrderCar> Orders { get; set; }
    }
}
