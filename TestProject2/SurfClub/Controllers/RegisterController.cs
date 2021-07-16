using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurfClub.Models;
using SurfClub.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurfClub.Models.DbModels;
using SurfClub.Helpers;
using System;

namespace SurfClub.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SurfClubDbContext dbContext;
        public RegisterController(SurfClubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User model, IFormFile ImageData)
        {

            if (ModelState.IsValid)
            {


                if (ImageData != null)
                {
                    ImageHelper helper = new ImageHelper();
                    model.Photo = ImageHelper.UploadImage(ImageData);
                }
                else
                {
                    ImageHelper helper = new ImageHelper();
                    model.Photo = ImageHelper.UploadImage(ImageData);
                }


                var NickCheck = dbContext.Users.FirstOrDefault(c => c.Nickname == model.Nickname); //Data is Null. This method or property cannot be called on Null values.
                if (NickCheck != null)
                {
                    ModelState.AddModelError("Nickname", "Такой псевдоним уже занят");
                    return View("Index", model);
                }

                var mailCheck = dbContext.Users.FirstOrDefault(c => c.Email == model.Email);
                if (mailCheck != null)
                {
                    ModelState.AddModelError("Email", "Такая почта уже зарегистрирована");
                    return View("Index", model);
                }

                //var passCheck = dbContext.Users.FirstOrDefault(model.ConfirmPassword == model.Password);
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("Password", "Пароли не совпадают");
                    return View("Index", model);
                }

                dbContext.Users.Add(model);
                dbContext.SaveChanges();

                var claims = new List<Claim>

                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, model.Id.ToString())
                    };

                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, model.Id.ToString());
                }


                var authProp = new AuthenticationProperties();
                authProp.IsPersistent = true;
                authProp.ExpiresUtc = DateTime.UtcNow.AddHours(2);

                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                       ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                // установка аутентификационных куки
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), authProp);
                HttpContext.Session.SetString("NickName", model.Nickname);
                HttpContext.Session.SetString("Photo", model.Photo.ToString());
                HttpContext.Session.SetInt32("UserId", model.Id);


                return RedirectToAction("Index", "Feed");

            }

            // dbContext.Users.Add(model);
            // dbContext.SaveChanges();

            return View("Index");

            // return RedirectToAction("Index", "Feed");









        }
    }
}