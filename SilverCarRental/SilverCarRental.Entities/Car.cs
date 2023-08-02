namespace SilverCarRental.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public Manufacturer Make { get; set; }
        public string Year { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }

    }
}
