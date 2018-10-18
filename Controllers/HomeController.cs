using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
 
         // here we can "inject" our context service into the constructor
        public HomeController (Context context)
        {
            dbContext = context;
        }
        public ViewResult Index()
        {
            List<User>AllUsers = dbContext.User.OrderByDescending(a=>a.id).ToList();
            // ViewBag.users = AllUsers;
            return View(AllUsers);
        }

        [HttpGet("new")]
        public ViewResult New()
        {
            return View();
        }
        [HttpPost("make_dish")]
        public IActionResult Make(User user)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("{id}")]
        public ViewResult Profile(int id)
        {
            List<User> user = dbContext.User.Where(a => a.id == id).ToList();
            ViewBag.user = user;
            return View(user);
        }

        [HttpGet("delete/{id}")]
        public RedirectToActionResult Delete(int id)
        {
            User retrievedUser = dbContext.User.SingleOrDefault(a => a.id == id);
            dbContext.User.Remove(retrievedUser);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public ViewResult Edit(int id)
        {
            List<User> user = dbContext.User.Where(a => a.id == id).ToList();
            return View(user[0]);
        }
        [HttpPost("edit_dish/{id}")]
        public IActionResult Edit_dish(User user, int id)
        {
            if(ModelState.IsValid)
            {
                User RetrievedUser = dbContext.User.FirstOrDefault(a => a.id == id);
                RetrievedUser.name = user.name;
                RetrievedUser.dish = user.dish;
                RetrievedUser.calories = user.calories;
                RetrievedUser.tastiness = user.tastiness;
                RetrievedUser.description = user.description;
                dbContext.SaveChanges();
                return RedirectToAction("Profile");
            }
            else
            {
                return View("Edit", user);
            }
        }
    }
}
