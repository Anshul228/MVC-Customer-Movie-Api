using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace MovieCustomerMVCwithAuth.Models
{
    public class Min18Mem:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId==1)
            {
                return ValidationResult.Success;
            }
            if (String.IsNullOrWhiteSpace(customer.Name))
            {
                return new ValidationResult("Naam likho");
            }
            var n = customer.Name;
            return (n.Length > 0 ? ValidationResult.Success : new ValidationResult("Er msg ---blank"));
          //  return base.IsValid(value, validationContext);
        }
    }
}