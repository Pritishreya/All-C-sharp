using NewInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewInventory.Services
{
    public class InMemoryInventoryData :IInventoryData
    {
        
        public InMemoryInventoryData()
        {
            _inventory = new List<Inventory>
            { 
                new Inventory { ID = 1, name = "potato", price = 10, quantity = 10, type = "Awesome" },
                new Inventory { ID = 2, name = "chips", price = 11, quantity = 20, type = "good" },
                new Inventory{ID = 3, name="pumpkin",price= 30,quantity= 30, type= "Marrow"},
                new Inventory {ID = 4,name= "cauliflower", price=20 ,quantity=100, type= "Cruciferous"},
                new Inventory  {ID = 5,name= "zucchini",price= 20 ,quantity=50, type= "marrow"},
                new Inventory {ID = 6, name="yam", price=30,quantity= 50,type=  "Root"},
                new Inventory { ID = 7, name = "chipsrrr", price = 11, quantity = 20, type = "good" },
            };
    }
       

        public IEnumerable<Inventory> GetAll()
        {
            return _inventory.OrderBy(r => r.ID);
        }

        public Inventory Get(int ID)
        {
            return _inventory.FirstOrDefault(r=>r.ID==ID);
        }
        public Inventory Add(Inventory inventory)
        {
            inventory.ID = _inventory.Max(r => r.ID) + 1;
            _inventory.Add(inventory);
            return inventory;
        }

        public List<Inventory> Delete(int ID)
        {
            var model = _inventory.FirstOrDefault(r => r.ID==ID);
            _inventory.Remove(model);
            return _inventory.ToList();
        }

        List<Inventory> _inventory;
}
}
