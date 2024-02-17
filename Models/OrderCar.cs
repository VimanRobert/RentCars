using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models
{
    public class OrderCar
    {
        [Key] public int orderId { get; set; }

        public int carId { get; set; }

        public DateTime OrderDate { get; set; }

        public required Customer customer { get; set; }
        public required Car car { get; set; }

        //public required int customerDrivingId { get; set; }
    }
}
