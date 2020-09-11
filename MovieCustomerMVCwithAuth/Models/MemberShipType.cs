using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMVCwithAuth.Models
{
    public class MemberShipType
    {
        [Key]
        public int MembershipTypeId { get; set; }
        [Required]     
        public string Name { get; set; }
        public short SignUp { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}