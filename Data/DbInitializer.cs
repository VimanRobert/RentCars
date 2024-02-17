using Microsoft.EntityFrameworkCore;
using RentCars.Models;

namespace RentCars.Data
{
    public class DbInitializer
    {
        private const double renaultEngine = 1.4;
        private const double vwEngine = 1.6;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new
           LibraryContext(serviceProvider.GetRequiredService
            <DbContextOptions<LibraryContext>>()))
            {
                if (context.Car.Any())
                {
                    return; // BD a fost creata anterior
                }
                context.Car.AddRange(
                new Car
                {
                    carId = 1,
                    carBrand = "Skoda",
                    carPrice = 230.00
                },

                new Car
                {
                    carId = 2,
                    carBrand = "Volkswagen",
                    carPrice = 200.00
                },

                new Car
                {
                    carId = 3,
                    carBrand = "Dacia",
                    carPrice = 250.00

                });


                context.Customers.AddRange(
                    new Customer
                    {
                        customerDrivingId = 11524345,
                        customerName = "Viman Robert",
                        customerBirthDate = DateTime.Parse("2000-11-04"),
                        customerCounty = "Salaj",
                        customerAdress = "Str. Principala, nr. 172"

                    },

                    new Customer
                    {
                        customerDrivingId = 12443523,
                        customerName = "Itu Daria",
                        customerBirthDate = DateTime.Parse("2001 - 02 - 16"),
                        customerCounty = "Cluj",
                        customerAdress = "Str. Bistritei, nr. 11",
                    },

                    new Customer
                    {
                        customerDrivingId = 12443523,
                        customerName = "Oprea Stefan",
                        customerBirthDate = DateTime.Parse("1985 - 06 - 26"),
                        customerCounty = "Cluj",
                        customerAdress = "Aleea Baisoare, bloc. 8A, nr. 04",
                    },

                    new Customer
                    {
                        customerDrivingId = 12443523,
                        customerName = "Coman Ana-Maria",
                        customerBirthDate = DateTime.Parse("1999 - 11 - 20"),
                        customerCounty = "Satu Mare",
                        customerAdress = "Mihai Viteazul, bloc. C, nr. 12",
                    });

                context.Made.AddRange(
					new Made
                    { 
                        carId = 1,
                        carBrand = "Skoda",
                        carModel = "Octavia 2",
                        carEngine = vwEngine,
                        carMadeYear = 2012,
                        carFuelType = "Diesel"
                    },

                    new Made
                    {
                        carId = 2,
                        carBrand = "Volkswagen",
                        carModel = "Passat",
                        carEngine = vwEngine,
                        carMadeYear = 2011,
                        carFuelType = "Diesel"
                    },

                    new Made
                    {
                        carId = 3,
                        carBrand = "Dacia",
                        carModel = "Stepway",
                        carEngine = renaultEngine,
                        carMadeYear = 2015,
                        carFuelType = "Benzin"
                    },
                    new Made
                    {
                        carId = 4,
                        carBrand = "Renault",
                        carModel = "Megane 3",
                        carEngine = renaultEngine+0.5,
                        carMadeYear = 2011,
                        carFuelType = "Diesel"
                    },
                    new Made
                    {
                        carId = 5,
                        carBrand = "Dacia",
                        carModel = "Spring",
                        carEngine = renaultEngine + 0.1,
                        carMadeYear = 2022,
                        carFuelType = "Full-Electric"
                    });

                /*context.Store.AddRange(
                    new Store
                    { 
                        itemId = 101,
                        carId = 1,
                        carBrand = "Skoda",
                        carModel = "octavia 2",
                        isRented = true,
                    },

                    new Store
                    {
                        itemId = 102,
                        carId = 2,
                        carBrand = "Volkswagen",
                        carModel = "Passat",
                        isRented = true,
                    },

                    new Store
                    {
                        itemId = 103,
                        carId = 3,
                        carBrand = "Dacia",
                        carModel = "Stepway",
                        isRented = false,
                    }
                    );*/

                context.SaveChanges();
            }
        }
    }
}
