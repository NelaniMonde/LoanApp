using LoanApplication.HelperClasses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanApplication.Models
{
    public class LoanModel
    {
        private static DateTime today = DateTime.Now;

        [Key]         
        public int ID {  get; set; }

        [Required]
        //[DataType(DataType.)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage ="Please enter a name, No Numbers allowed")]
        [DisplayName("Name: ")]
      
        public string Name { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter a surname, No Numbers allowed")]
        [DisplayName("Surname: ")]
        public string Surname { get; set; }
        
        [Required]
        [DisplayName("Gross Salary: ")]
        [Range(0,1000000000000)]
        [ModelBinder(BinderType = typeof(FlexibleDecimalModelBinder))]
        public decimal GrossSalary { get; set; }

       
        [Required]
        [Range(0,1200)]
        [DisplayName("Credit Score: ")]
        public decimal CreditScore { get; set; }

        [Range(0, 1000000000000)]
        [DisplayName("Price Of Property: ")]
        [Required]
        public decimal PriceOfProperty { get; set; }

        [DisplayName("Loan Status: ")]
        [Required]
        public string LoanStatus { get; set;}

        [DisplayName("Maximum Instalment: ")]
        [Required]
        public decimal MaximumInstalment { get; set;}
        [DisplayName("Loan Granted: ")]
        [Required]
        public decimal LoanGranted { get; set;}
        [DisplayName("Deposite Required: ")]
        [Required]
        public decimal DepositeRequired { get; set;}
        [DisplayName("Monthly Instalment: ")]
        [Required]
        public decimal MonthlyInstalment { get; set;}
        [DisplayName("Date Created: ")]
        public string CreatedDateTime { get; set; } = today.ToShortDateString();
    }
}
