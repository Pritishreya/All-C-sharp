using Microsoft.AspNetCore.Mvc;
using NewInventory.Services;
using NewInventory.Models;
using NewInventory.ViewModels;

namespace NewInventory.Controllers
{
    public class HomeController:Controller
    {
        private IInventoryData _inventoryData;
        private IGreeter _greeter;

        public HomeController(IInventoryData inventoryData,
            IGreeter greeter)
        {
            _inventoryData = inventoryData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Inventory = _inventoryData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            return View(model);
        }
        public IActionResult Details(int ID)
        {
            var model = _inventoryData.Get(ID);
            if(model==null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Inventory model)
        {
            var newInventory = new Inventory();
            newInventory.name = model.name;
            newInventory.price = model.price;
            newInventory.quantity = model.quantity;
            newInventory.type = model.type;
            newInventory = _inventoryData.Add(newInventory);

            return RedirectToAction(nameof(Index),new { ID = newInventory.ID });
        }
        [HttpGet]
        public IActionResult Update(int ID)
        {
            var std = _inventoryData.Get(ID);
            if (std == null)
            {
                return RedirectToAction("Index");
            }
            return View(std);
        }
        [HttpPost]
        public IActionResult Update(Inventory std)
        {
            var newInventory = new Inventory();
            var model = _inventoryData.Delete(std.ID);
            newInventory.name = std.name;
            newInventory.price = std.price;
            newInventory.quantity = std.quantity;
            newInventory.type = std.type;
            newInventory = _inventoryData.Add(newInventory);
            model.Add(newInventory);

            return RedirectToAction(nameof(Index), model);
        }
        public IActionResult Delete(int ID)
        {
                var model=_inventoryData.Delete(ID);
                return RedirectToAction("Index",model);
           
        }
    }
}
