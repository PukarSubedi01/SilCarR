namespace SilverCarRental.Entities
{
    public class RentalCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public double Rate { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public string Insurance { get; set; }
        public string Location { get; set; }
        public bool IsAvailable { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }
    }
}