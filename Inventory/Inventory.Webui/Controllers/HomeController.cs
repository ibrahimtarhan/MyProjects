using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Inventory.Webui.Models;
using data.Abstract;
using Entity;

namespace Inventory.Webui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IItemRepository _itemRepository;
        private IUserRepository _userRepository;

       

        public HomeController(ILogger<HomeController> logger, IItemRepository itemRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var itemViewModel = new ItemViewModel()
            {
                items = _itemRepository.GetAll()
            };



            return View(itemViewModel);
        }
        
        public IActionResult ItemList()
        {
            List<Item> list = _itemRepository.GetAll(); 
            return View(list);
        }
       

        

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
