using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Entities
{
    public class CarRequestDTO
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Year { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }

    }
}
