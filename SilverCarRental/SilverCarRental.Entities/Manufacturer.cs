using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Make { get; set; }

        public CarModel Model { get; set; }

    }
}
