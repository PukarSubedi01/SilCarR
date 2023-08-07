﻿namespace SilverCarRental.Entities
{
    public class RentalCar
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public double Rate { get; set; }
        public DateTime ReturnDate { get; set; }
        public User User { get; set; }
        public string insurance { get; set; }
        public string Location { get; set; }
        public bool isAvailable { get; set; }
    }
}