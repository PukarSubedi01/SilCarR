using SilverCarRental.Entities;

namespace SilverCarRental.TempDatabase
{
    public static class SilverCarDatabase
    {
        public static List<Car> GetCars()
        {
            var listOfCars = new List<Car>
            {
                new Car {
                    Id = 1,
                    Color = "Red",
                    Year = "2001",
                    Mileage = 40,
                    Make = new Manufacturer{
                        Id =1,
                        Make = "Toyota",
                        Model = new CarModel
                        {
                            Id = 1,
                            Model = "Camry"
                        }
                    }},
                 new Car {
                    Id = 2,
                    Color = "White",
                    Year = "2011",
                    Mileage = 40,
                    Make = new Manufacturer{
                        Id =1,
                        Make = "Toyota",
                        Model = new CarModel
                        {
                            Id = 1,
                            Model = "Camry"
                        }
                    }},
                  new Car {
                    Id = 3,
                    Color = "Red",
                    Year = "2001",
                    Mileage = 40,
                    Make = new Manufacturer{
                        Id =1,
                        Make = "Toyota",
                        Model = new CarModel
                        {
                            Id = 1,
                            Model = "Camry"
                        }
                    }},
                   new Car {
                    Id = 4,
                    Color = "Red",
                    Year = "2001",
                    Mileage = 40,
                    Make = new Manufacturer{
                        Id =1,
                        Make = "Toyota",
                        Model = new CarModel
                        {
                            Id = 1,
                            Model = "Camry"
                        }
                    }},
                    new Car {
                    Id = 5,
                    Color = "Red",
                    Year = "2001",
                    Mileage = 40,
                    Make = new Manufacturer{
                        Id =1,
                        Make = "Toyota",
                        Model = new CarModel
                        {
                            Id = 1,
                            Model = "Camry"
                        }
                    }},
                     new Car {
                    Id = 6,
                    Color = "Red",
                    Year = "2001",
                    Mileage = 40,
                    Make = new Manufacturer{
                        Id =1,
                        Make = "Toyota",
                        Model = new CarModel
                        {
                            Id = 1,
                            Model = "Camry"
                        }
                    }}
            };
            return listOfCars;
        }
    }
}
