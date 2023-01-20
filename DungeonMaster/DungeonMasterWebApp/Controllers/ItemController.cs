using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DungeonMasterWebApp.Models;
using DungeonMasterDomain;
using DungeonMasterDTO;

namespace DungeonMasterWebApp.Controllers
{
    public class ItemController : Controller
    {
        private DungeonItemInteractor _interactor;

        public ItemController()
        {
            _interactor = new DungeonItemInteractor();
        }
        // GET: ItemController
        public ActionResult Index()
        {
            List<ItemViewModel> items = new List<ItemViewModel>();
            // Using LINQ 
            // _interactor.GetAllItems().ForEach(item => items.Add(ItemViewModel.ViewModelMapper(item)));

            List<Item> dbItems = _interactor.GetAllItems();
            foreach (Item item in dbItems)
            {
                ItemViewModel viewItem = ItemViewModel.ViewModelMapper(item);
                items.Add(viewItem);
            }

            return View(items);
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
