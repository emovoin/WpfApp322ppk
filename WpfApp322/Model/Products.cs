using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp322.Model
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int CartId { get; set; }
        
    }
}
