using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet]
        public IActionResult Register(RegisterViewModel model)
        {




            return View();
        }





    }
}
