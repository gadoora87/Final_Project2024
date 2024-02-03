using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class CustomerTransaction
    {
        public int customerId {  get; set; }
        public int productId {  get; set; }
        public string? price { get; set; }
        public string? dateOfBuy { get; set; }
    }
}
