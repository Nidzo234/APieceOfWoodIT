using APieceOfWoodIT.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APieceOfWoodIT.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Orders
        public ActionResult Index()
        {
            List<Order> orders = db.Orders.ToList();
            List<Order> rez = new List<Order>();
            foreach (Order order in orders)
            {
                if(order.UserId.Equals(User.Identity.GetUserId()))
                {
                    rez.Add(order);
                }
            }
            return View(rez);
        }


        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>();
            List<OrderProduct> orders = db.OrderProducts.ToList();
            foreach(OrderProduct order in orders)
            {
                if(order.OrderId==id)
                {
                    Product p = db.Products.Where(x => x.ProductId == order.ProductId).FirstOrDefault();
                    products.Add(p);
                }
            }
            db.SaveChanges();
            return View(products);
        }
    }
}