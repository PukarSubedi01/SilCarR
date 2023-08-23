namespace SilverCarRental.Entities
{
    public class RentalCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        
        public DateTime ReturnDate { get; set; }
        public DateTime BookDate { get; set; }
        public string Insurance { get; set; }
        public string Location { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
        public double Rate { get; set; }
    }
}