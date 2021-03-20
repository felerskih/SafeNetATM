using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeNetWebATM.Models;
using SafeNetATM;

namespace SafeNetWebATM.Controllers
{
    //This class controls the Web UI and refers calls to a static
    //instance of Manager.
    //Author: Henry Felerski
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Manager man = new Manager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Withdraw")]
        public ActionResult Index(string amt)
        {
            string[] canCounts = new string[6];

            canCounts = man.MakeWithdrawal(amt);
            DisplayAllCounts(canCounts);

            return View("Index");
        }

        //Not Working fully, think its a problem with DisplayCounts
        [ActionName("Inquire")]
        public ActionResult Index(bool hundred, bool fifty, bool twenty, 
                                  bool ten, bool five, bool one)
        {
            bool[] parms = new bool[6];
            string[] cansList;
            string[] canCounts;

            parms[0] = hundred;
            parms[1] = fifty;
            parms[2] = twenty;
            parms[3] = ten;
            parms[4] = five;
            parms[5] = one;

            cansList = man.ParseCannisters(parms);
            canCounts = man.InquireCannisters(cansList);
            DisplayCounts(parms, canCounts);

            return View("Index");
        }

        public ActionResult Restock()
        {
            string[] canCounts;

            canCounts = man.Restock();
            DisplayAllCounts(canCounts);

            return View("Index");
        }

        private void DisplayAllCounts(string[] canCounts)
        {
            //Alert if canCounts returns error
            ViewBag.hundred = canCounts[0];
            ViewBag.fifty = canCounts[1];
            ViewBag.twenty = canCounts[2];
            ViewBag.ten = canCounts[3];
            ViewBag.five = canCounts[4];
            ViewBag.one = canCounts[5];
        }

        private void DisplayCounts(bool[] parms, string[] canCounts)
        {
            int count = 0;
            if (parms[0])
                ViewBag.hundred = canCounts[count++];
            if (parms[1])
                ViewBag.fifty = canCounts[count++];
            if (parms[2])
                ViewBag.twenty = canCounts[count++];
            if (parms[3])
                ViewBag.ten = canCounts[count++];
            if (parms[4])
                ViewBag.five = canCounts[count++];
            if (parms[5])
                ViewBag.one = canCounts[count++];
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
