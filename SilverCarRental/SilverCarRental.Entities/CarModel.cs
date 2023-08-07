using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
