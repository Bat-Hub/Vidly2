using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Dto
{
    public class RentalDto
    {
        public List<int> MovieIds { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}