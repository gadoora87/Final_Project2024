using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Products
    {
        public int ProductId {get; set;}
        public string? ProductName { get; set;}
        public string? Type { get; set;}
        public string? Size { get; set; }
        public string? Price { get; set; }
    }
}
