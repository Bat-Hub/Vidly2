using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Vidly2.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        [Display(Name = "Date of Birth")]

        // [CustomerCustomValidation]
        public DateTime? Birthdate { get; set; }
    }
}