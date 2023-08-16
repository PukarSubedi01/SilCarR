using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SilverCarRental.Entities
{
    public class CarModelRequestDTO
    {
        public int ManufacturerId { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }
        
    }
}
