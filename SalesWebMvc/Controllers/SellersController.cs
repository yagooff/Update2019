﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController (SellerService serllerService)
        {
            _sellerService = serllerService;
        }
        public IActionResult Index()
        {
            var list =_sellerService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof (Index));
        }
    }
}
