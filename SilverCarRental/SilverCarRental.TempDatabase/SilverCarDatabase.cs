using SilverCarRental.Entities;

namespace SilverCarRental.TempDatabase
{
    public static class SilverCarDatabase
    {
       private static List<Car> listOfCars = new List<Car>();
    

        public static List<Car> GetCars()
        {
/*            listOfCars = new List<Car>
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
            };*/
            return listOfCars;
        }

        public static void AddCar(Car car)
        {
            listOfCars.Add(car);
        }

        public static void DeleteCar(int id)
        {

          
        }

        public static void UpdateCar(int id, Car car) {
            listOfCars.ForEach(x =>
            {
                if(x.Id == id) {
                    x.Id = id;
                    x.Color = car.Color;
                    x.Year = car.Year;
                    x.Make = car.Make;
                    x.Mileage = car.Mileage;
                }
            });
       
        }
    }
}
