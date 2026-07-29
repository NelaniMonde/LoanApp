using LoanApplication.Data;
using LoanApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplication.Controllers
{
    public class LoanController : Controller
    {
        private readonly AppDataBaseContext _dataBase;

        public LoanController (AppDataBaseContext _dataBase)
        {
            this._dataBase = _dataBase;
        }



        public IActionResult LoanView(string message, string deleteMSG, string updateMSG)
        {
          var loanObjList = _dataBase.Loans.ToList();

            if (message != null)
            {
                TempData["Success"]=message;
            }

            if (deleteMSG != null)
            {
                TempData["Error"]=deleteMSG;
            }

            if (updateMSG !=null)
            {
                TempData["Warning"]=updateMSG;
            }
            return View(loanObjList);
        }

        //To return the view 
        public IActionResult GetLoaner()
        {

            return View();   

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetLoaner(LoanModel loanObj)
        {


            string messageNotif = "";
        


                loanObj = UtilityMethod(loanObj);

            _dataBase.Loans.Add(loanObj);
            _dataBase.SaveChanges();

            messageNotif = "Loan Application for: " + loanObj.Name + " " + loanObj.Surname
                + "\n With a loan Status of " + loanObj.LoanStatus + "\nhas been Successfully Created!!!";

            return RedirectToAction("LoanView",new {message =messageNotif});
            

            
            
        }



        public IActionResult Update(int? id)
        {
            if(id == null && id==0)
            {
                return NotFound();
            }
            var loanObj = _dataBase.Loans.Find(id);
            
            
            
            return View(loanObj);

        }

        [HttpPost]
        public IActionResult Update(LoanModel loanObj)
        {
            string messageNotif = "";

            loanObj = UtilityMethod(loanObj);
          _dataBase.Loans.Update(loanObj);
            _dataBase.SaveChanges();



            messageNotif = "Loan Application for: " + loanObj.Name + " " + loanObj.Surname
                + "\n With a loan Status of " + loanObj.LoanStatus + "\nhas been Successfully Updated!!!";

            return RedirectToAction("LoanView", new { updateMSG = messageNotif});

          
        }


        //Get method for delete
        public IActionResult Delete(int? id) 
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var loanObj = _dataBase.Loans.Find(id);
            return View(loanObj);
        }

        [HttpPost]
        public IActionResult Delete(LoanModel loanObj)
        {
            string messageNotif = "";

            loanObj = UtilityMethod(loanObj);
            _dataBase.Loans.Remove(loanObj);
            _dataBase.SaveChanges();

            messageNotif = "Loan Application for: " + loanObj.Name + " " + loanObj.Surname
    + "\n With a loan Status of " + loanObj.LoanStatus + "\nhas been Successfully Deleted!!!";

            return RedirectToAction("LoanView", new { deleteMSG =messageNotif});

          
        }

        public IActionResult Details(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var loanObj = _dataBase.Loans.Find(id);
            return View(loanObj);
        }


       


       // Utility method
        public LoanModel UtilityMethod(LoanModel loanObj)
        {
            decimal maximumInst = 0;
            decimal loanGranted = 0;
            decimal deposite = 0;
            decimal monthlyInstall = 0;
            
            

            //100% loan
            if (loanObj.CreditScore >= 800)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(100);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);


                if (monthlyInstall > loanObj.GrossSalary)
                {
                    loanObj.LoanStatus = "Rejected";
                    loanGranted = 0;
                }




            }
            //97.5 loan
            else if (loanObj.CreditScore >= 750 && loanObj.CreditScore <= 799)
            {
                
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal((decimal)97.5);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);

                if (monthlyInstall > loanObj.GrossSalary)
                {
                    loanObj.LoanStatus = "Rejected";
                    loanGranted = 0;
                }


            }
            //95% loan
            else if (loanObj.CreditScore >= 700 && loanObj.CreditScore <= 749)
            {

                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(95);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);

                if (monthlyInstall > loanObj.GrossSalary)
                {
                    loanObj.LoanStatus = "Rejected";
                    loanGranted = 0;
                }

            }

            //90% loan
            else if (loanObj.CreditScore >= 650 && loanObj.CreditScore <= 699)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);
                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(90);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);

                if (monthlyInstall > loanObj.GrossSalary)
                {
                    loanObj.LoanStatus = "Rejected";
                    loanGranted = 0;
                }


            }
            //85% loan
            else if (loanObj.CreditScore >= 600 && loanObj.CreditScore <= 649)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);

                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(85);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);

                if (monthlyInstall > loanObj.GrossSalary)
                {
                    loanObj.LoanStatus = "Rejected";
                    loanGranted = 0;
                }


            }
            //80% loan
            else if (loanObj.CreditScore >= 550 && loanObj.CreditScore <= 599)
            {
                maximumInst = MaximumInstalCal(loanObj.GrossSalary);

                loanObj.LoanStatus = "Granted";
                loanGranted = loanGrantedCal(80);
                deposite = DepositeReqCal(loanObj.PriceOfProperty, loanGranted);
                monthlyInstall = MonthlyInstalCal(loanObj.PriceOfProperty, deposite);

                if (monthlyInstall > loanObj.GrossSalary)
                {
                    loanObj.LoanStatus = "Rejected";
                    loanGranted = 0;
                }

            }
            //No loan
            else if (loanObj.CreditScore <= 549 )
            {
                maximumInst = 0;
                loanObj.LoanStatus = "Rejected";
                loanGranted = 0;
                deposite = 0;
                monthlyInstall = 0;
            }

            loanObj = new LoanModel
            {
                ID = loanObj.ID,
                Name = loanObj.Name,
                Surname = loanObj.Surname,
                GrossSalary = loanObj.GrossSalary,
                CreditScore = loanObj.CreditScore,
                PriceOfProperty = loanObj.PriceOfProperty,
                LoanStatus = loanObj.LoanStatus,
                MaximumInstalment = maximumInst,
                LoanGranted = loanGranted,
                DepositeRequired = deposite,
                MonthlyInstalment = monthlyInstall


            };

            return loanObj;

        }

        //change this to set the status to Rejected 
        //and other elements to zero 
        public void isMonthlyInstalmentLess(string status, decimal loanGranted )
        {
            
            
                
                status = "Rejected";
                loanGranted = 0;
              
            

            

        }

        public decimal MaximumInstalCal(decimal grossSalary)
        {
            decimal maxInstal = grossSalary * 30 / 100;

            return maxInstal;
        }

        public decimal loanGrantedCal(decimal loangrant)
        {
            decimal loanGranted = (decimal)(loangrant);
            return loanGranted;
        }
    

        public decimal DepositeReqCal(decimal priceOfPropery,decimal loanGranted)
        {
            decimal deposite = priceOfPropery - (priceOfPropery * loanGranted/100);

            return deposite;
        }
        public decimal MonthlyInstalCal(decimal priceOfproperty, decimal deposite)
        {
            decimal monthlyInstall = (decimal)((priceOfproperty - deposite) * ((decimal)0.00785));

            return monthlyInstall;
        }
    }
}
