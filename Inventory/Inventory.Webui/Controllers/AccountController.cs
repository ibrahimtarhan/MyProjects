using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Inventory.Webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Webui.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<User> _userManager;

        //bu da cookie olaylarını yonetecek

        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//get ve post taki tokenları karsılastırır

        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "bu kullanicı adı kaydı yok");
                return View(model);
            }


            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            // burda 3. parametre false ise tarayıcı kapanırsa cookie silinir 4. parametre is yanlıs bilgi girdiginde onu kısıtlama startup ta belirtmistik

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Admin");
                
            }

            ModelState.AddModelError("", "bu kullanicı adı veya parola yanlıs");

            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//get ve post taki tokenları karsılastırır
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Name = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
                //password u burda almıyoruz cunku verilen password hash lenip tutuldugundan dolayı
                //onu usermanager ile alırız.

            };

            var result = await _userManager.CreateAsync(user, model.Password);//passwordu burda alıyoruz
            if (result.Succeeded)//bu islem sonucunda bir kullanici olusturlmussa diyoruz yani
            {
                  
                return RedirectToAction("Login", "Account");//kullanici kaydi tamam git giris yap 
            }

            
            return View(model);//burası data annotation kosulları başarılı fakat kayıt islemleri(identity) basarısız ise calısır
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();//cookie yi sil
            return Redirect("~/");//home index e git
        }


    }
}
