﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.Models;
using Thriftshop.Models.ViewModels;

namespace ThriftshopWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _unitOfWork.ShoppingCart.GetAll(u=>u.ApplicationUserId==claim.Value,
                includeProperties:"Product")
            };
            foreach(var cart in ShoppingCartVM.ListCart)
            {
                cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.Product.Price, cart.Product.Price10, cart.Product.Price30);
            }
            return View(ShoppingCartVM);
        }

        private double GetPriceBasedOnQuantity(double quantity, double price, double price10, double price30)
        {
            if (quantity <= 10)
            {
                return price;
            }
            else
            {
                if (quantity <= 30)
                {
                    return price10;
                }
                return price30;
            }
        }
    }
}