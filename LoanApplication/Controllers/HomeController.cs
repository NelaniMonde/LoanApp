using LoanApplication.Data;
using LoanApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoanApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDataBaseContext _dataBaseContext;   

        public HomeController(ILogger<HomeController> logger, AppDataBaseContext _appDataBaseContext)
        {
            _logger = logger;
           this._dataBaseContext = _appDataBaseContext;
        }

        public IActionResult Index()
        {
            var loanRec = _dataBaseContext.Loans.ToList();

            int rejectedLoans = 0,
                acceptedLoans = 0,
                noOfLOans = 0;

            List<decimal> grantedLoans = new List<decimal>();

            foreach (var loan in loanRec)
            {
                if(loan.LoanStatus== "Granted")
                {
                    acceptedLoans++;
                }
                if(loan.LoanStatus== "Rejected")
                {
                    rejectedLoans++;
                }
                grantedLoans.Add(loan.LoanGranted);
                noOfLOans++;
            }

            TempData["rejectedLoans"]=rejectedLoans;
            TempData["acceptedLoans"]=acceptedLoans;
            TempData["noOfLoans"]=noOfLOans;
            ViewBag.loansAllocated = grantedLoans;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}