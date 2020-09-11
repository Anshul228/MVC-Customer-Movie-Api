using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMVCwithAuth.Models
{
    public class Customer
    {   
        public int Id { get; set; }
        [Required(ErrorMessage ="Naam likh bhai")]
        [StringLength(30,ErrorMessage ="bs 30 kay ander likho")]
       // [Min18Mem]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public int MembershipTypeId { get; set; }
    }
}