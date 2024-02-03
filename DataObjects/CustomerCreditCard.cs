using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class CustomerCreditCard
    {
        public int CustomerID { get; set; }
        public string? CreditCardNumber {  get; set; }
        public string? zipcode { get; set; }
        public string? cvv { get; set; }
        public string? dateOfExpiration { get; set; }
        public string? nameOnTheCard { get; set; }
    }
}
