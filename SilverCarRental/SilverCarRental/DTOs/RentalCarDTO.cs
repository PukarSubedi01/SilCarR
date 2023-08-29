using SilverCarRental.Entities;

namespace SilverCarRental.DTOs
{
    public class RentalCarDTO
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public double Rate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BookDate { get; set; }
        public string Insurance { get; set; }
        public string Location { get; set; }
    }
}
