using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Core.DomainModel
{
    public class RentalCarModel
    {
        public int Id { get; set; }
        public string Manufacturuer { get; set; }
        public string Model { get; set; }

        public DateTime BookedDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public string Insurance { get; set; }

        public string Location { get; set; }


    }
}