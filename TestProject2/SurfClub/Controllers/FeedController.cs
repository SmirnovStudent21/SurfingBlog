﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfClub.Helpers;
using SurfClub.Models;
using SurfClub.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace SurfClub.Controllers
{
    public class FeedController : Controller
    {
        private readonly SurfClubDbContext dbContext;

        public FeedController(SurfClubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index()
        {
            var posts = dbContext.Posts.Include(c => c.Author).OrderBy(c => c.PublishDate).ToArray();  //Microsoft.Data.SqlClient.SqlException: "Invalid object name 'Posts'."

            ViewBag.Posts = posts;

            return View();

        }


        [HttpPost]
        public IActionResult AddPost(Post model,IFormFile ImageData)
        {
            if (string.IsNullOrEmpty(model.Text) && ImageData == null)
            { 
                return View("Index", model);  
            }


            if (ImageData != null) 
            { 
                ImageHelper helper = new ImageHelper();
                model.Photo = ImageHelper.UploadImage(ImageData);
            }

            model.PublishDate = DateTime.Now;

            var userId = HttpContext.Session.GetInt32("UserId").Value; // может быть пустым
            var user = dbContext.Users.FirstOrDefault(c => c.Id == userId); // может быть пустым


            model.Author = user;

            dbContext.Posts.Add(model);
            dbContext.SaveChanges();

            var posts1 = dbContext.Posts.Include(c => c.Author).OrderBy(c => c.PublishDate).ToArray();
            ViewBag.Posts = posts1;


            return View("index");
        }





    }
}
