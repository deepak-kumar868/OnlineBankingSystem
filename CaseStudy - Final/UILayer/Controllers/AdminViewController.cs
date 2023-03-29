using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class AdminViewController : Controller
    {
        public IActionResult AllServices()
        {
            return View();
        }
        public IActionResult CustomerServices()
        {
            return View();
        }

        public IActionResult AccountServices()
        {
            return View();
        }
        public IActionResult LoanServices()
        {
            return View();
        }
        public IActionResult TransactionServices()
        {
            return View();
        }
    }
}
