using System.ComponentModel.DataAnnotations;

namespace RentCars.Models.LibraryViewModels
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int CarCount { get; set; }

    }
}
