﻿namespace SilverCarRental.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public Manufaturer Make { get; set; }
        public CarModel Model { get; set; }
        public string Year { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }

    }
}
