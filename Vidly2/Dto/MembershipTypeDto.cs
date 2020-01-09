using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Dto
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}