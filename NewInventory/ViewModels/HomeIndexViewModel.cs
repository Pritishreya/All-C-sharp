using NewInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewInventory.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Inventory> Inventory { get; set; }
        public string CurrentMessage { get; set; }
    }
}
