using NewInventory.Data;
using NewInventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewInventory.Models
{
    public class SqlInventoryData : IInventoryData
    {
        private NewInventoryDbContext _context;

        public SqlInventoryData(NewInventoryDbContext context)
        {
            _context = context;
        }
        public Inventory Add(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            _context.SaveChanges();
            return inventory;
        }

        public Inventory Get(int ID)
        {
            return _context.Inventory.FirstOrDefault(r => r.ID==ID);
        }

        public List<Inventory> Delete(int ID)
        {
            var del=_context.Inventory.FirstOrDefault(r => r.ID == ID);
            _context.Inventory.Remove(del);
            _context.SaveChanges();
            return _context.Inventory.ToList();
        }
        public IEnumerable<Inventory> GetAll()
        {
            return _context.Inventory.OrderBy(r=>r.ID);
        }

       
    }
}
