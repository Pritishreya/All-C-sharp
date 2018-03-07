using NewInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewInventory.Services
{
    public interface IInventoryData
    {
        IEnumerable<Inventory> GetAll();
        Inventory Get(int ID);
        Inventory Add(Inventory inventory);
        List<Inventory> Delete(int ID);
    }
}
