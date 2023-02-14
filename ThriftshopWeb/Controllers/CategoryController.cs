﻿using Microsoft.AspNetCore.Mvc;
using ThriftshopWeb.Data;
using ThriftshopWeb.Models;

namespace ThriftshopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        public IActionResult Create()
        {
            return View();
        }
    }
}
