using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using Inventory.Webui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Webui.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private IItemRepository _itemRepository;
        private IUserRepository _userRepository;
        // GET: AdminController

        public AdminController(IItemRepository itemRepository, IUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }
        

        public ActionResult Index()
        {
            var useritemListModel = new UserItemListModel
            {
                items = _itemRepository.GetAll(),
                users = _userRepository.GetAll()
            };



            return View(useritemListModel);
        }
        public IActionResult AddItem()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddItem(ItemModel item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _itemRepository.AddItem(item.Type, item.Amount);

            TempData["message"] = $"{item.Type} tipinde {item.Amount} tane Item eklendi.";

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var item = _itemRepository.GetById(id);
            _itemRepository.Delete(item);

            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
                
            }
            var item = _itemRepository.GetById((int)id);
            if(item==null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string UserName)
        {
            _userRepository.Additem(UserName, id);
            TempData["additem"] = $" Item sahibi değiştirildi";
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: AdminController/Delete/5
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
