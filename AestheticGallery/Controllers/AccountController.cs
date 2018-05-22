using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AestheticGallery.Models;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Infrastucure;

namespace AestheticGallery.Controllers
{
    
    public class AccountController : Controller
    {
        
        IClientProfileService clientSevice;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        public AccountController(IClientProfileService servC)
        {
            clientSevice = servC;
        }

        
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClientProfileDto userDto = new ClientProfileDto { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await clientSevice.Authenticate(userDto);

                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");  
                }
                    
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
              
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClientProfileDto clientDto = new ClientProfileDto
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.UserName,
                    UserName = model.UserName,
                };

                OperationDetails operationDetails = await clientSevice.CreateUser(clientDto);
                if (operationDetails.Succedeed)
                {
                    ClaimsIdentity claim = await clientSevice.Authenticate(clientDto);
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}