using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebOdevim.Models;

namespace WebOdevim.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController:Controller
    {
        private UserManager<UserDetails> _userManager;
        private SignInManager<UserDetails> _signInManager;
 
        public AccountController(UserManager<UserDetails> userManager,SignInManager<UserDetails> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;

        }
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {   
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user==null)
            {
                ModelState.AddModelError("","Bu kullanıcı adı ile daha önce hesap oluşturulmamış");
                return View(model);
            } 


            var result = await _signInManager.PasswordSignInAsync(user,model.Password,true,false);

            if(result.Succeeded) 
            {
                return Redirect(model.ReturnUrl??"~/");
            }

            ModelState.AddModelError("","Girilen kullanıcı adı veya parola yanlış");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new UserDetails()
            {
                UserRealName  = model.FirstName,
                UserSurname = model.LastName,
                UserSanalName = model.UserName,
                Email = model.Email    
            };           


                
                return RedirectToAction("Login","Account");
                     

      
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
          ViewBag("message", new AlertMessage()
            {
                Title="Oturum Kapatıldı.",
                Message="Hesabınız güvenli bir şekilde kapatıldı.",
                AlertType="warning"
            });
            return Redirect("~/");
        }

        
    }
}