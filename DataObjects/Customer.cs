using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Customer
    {
        public int CustomerID {  get; set; }
        public string? GivenName {  get; set; }
        public string? FamilyName { get; set;}
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? line1 { get; set; }
        public string? line2 { get; set; }
        public string? zipcode { get; set;}
    }
}
