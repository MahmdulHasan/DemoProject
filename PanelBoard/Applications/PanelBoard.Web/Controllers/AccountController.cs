using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PanelBoard.Membership;
using PanelBoard.Membership.Entities;
using PanelBoard.Membership.Managers;
using PanelBoard.Membership.ViewModels;

namespace PanelBoard.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AaaDbContext _context;
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;

        public AccountController(AaaDbContext context, UserManager uManager, SignInManager signInManager)
        {
            _context = context;
            _userManager = uManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, [FromQuery] string returnurl = null)
        {
            if (ModelState.IsValid)
            {
                User user = new User(model.UserName);
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var status = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (status.Succeeded)
                        return RedirectToAction("Index", "Student");
                }


            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, [FromQuery] string returnUrl = null)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var user = await _userManager.FindByNameAsync(model.Username);

                    var status = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (status.Succeeded)
                        return RedirectToAction("Index", "Student");
                }
                catch (Exception ex)
                {

                }
            }

            return View(model);
        }

        [AllowAnonymous]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}