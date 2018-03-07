using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewInventory.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }

    }
}
