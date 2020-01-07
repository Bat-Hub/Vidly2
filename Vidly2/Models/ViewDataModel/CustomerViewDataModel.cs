using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Models.ViewDataModel
{
    public class CustomerViewDataModel
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}