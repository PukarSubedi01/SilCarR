namespace SilverCarRental.Entities
{
    public class Car
    {
       
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Year { get; set; }
        public int Mileage { get; set; }    
        public string Color { get; set; }

        public virtual CarModel Model { get; set; }

    }
}
