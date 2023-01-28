using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommie.Data;
using ECommie.Models;
using ECommie.Utility;
using Microsoft.EntityFrameworkCore;

namespace ECommie.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
      
        //GET Checkout actioin method

        public IActionResult Checkout()
        {
            return View();
        }
      
        //POST Checkout action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if(products!=null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails=new OrderDetails();
                    orderDetails.PorductId = product.Id;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }

            anOrder.OrderNo = GetOrderNo();
            anOrder.OrderDate = DateTime.Now;
            _db.Orders.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Products>());
            return View();
        }


        public string GetOrderNo()
        {
            int rowCount = _db.Orders.ToList().Count()+1;
            return rowCount.ToString("000");
        }

        public IActionResult OrdersByEmail(string email)
        {
            ViewBag.Email = email;
            var orders = _db.Orders.Where(o => o.Email == email).ToList();
            return View(orders);
        }

        public IActionResult OrderDetails(int id)
        {
            var orderDetails = _db.OrderDetails.Include(od => od.Product).Where(od => od.OrderId == id);
            return View(orderDetails);
        }

    }
}
