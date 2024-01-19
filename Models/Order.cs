using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models
{
    public class Order
    {
        [Key] public int orderId { get; set; }

        public int customerDrivingId { get; set; }

        public int carId { get; set; }

        public required Customer customer { get; set; }
        public required Car car { get; set; }
    }
}
