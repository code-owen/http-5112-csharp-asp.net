using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandyStore.Controllers
{
    public class CandyController : Controller
    {
        // GET: localhost:53318/Candy
        public ActionResult Index()
        {
            return View();
        }

        // GET: localhost:xx/Candy/Order
        public ActionResult Order()
        {
            return View();
        }

        //GET: localhost:53318/Candy/Checkout
        public ActionResult Checkout(string OrderName, string CandySize)
        {
            //we can receive the order name and output to the server log

            ViewData["OrderName"] = OrderName;
            ViewData["CandySize"] = CandySize;

            decimal OrderTotal = 0;
            if(CandySize == "S")
            {
                OrderTotal = 9.99M;
            }
            else if(CandySize =="M")
            {
                OrderTotal = 13.99M;
            }


            return View();
        }
    }
}