using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AMC_Tracker.Models
{
    public class Contract
    {
        [Key]
        [Required]
        [DisplayName("Contract Number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Contract Number")]
        public int ContractNumber { get; set; }



        [Required]
        [DisplayName("Vendor Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string VendorName { get; set; }


        [DisplayName("Vendor Telephone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Correct Mobile Number")]
        public string VendorTelephoneNumber { get; set; }



        [Required]
        [DisplayName("Vendor Mobile Number")]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Correct Mobile Number")]
        public string VendorMobileNumber { get; set; }


        [Required]
        [DisplayName("Vendor Email Id")]

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        public string VendorEmailId { get; set; }





        [Required]
        [DisplayName("Date Of Contract")]

        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public string DateOfContract { get; set; }


        [DisplayName("Start Date")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public string StartDate { get; set; }



        [Required]
        [DisplayName("End Date")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]

        public string EndDate { get; set; }


        [Required]
        [DisplayName("Original Amount")]

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Amount")]
        public string OriginalAmount { get; set; }





        [Required]
        [DisplayName("Revised Amount")]

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Amount")]
        public string RevisedAmount { get; set; }


        [DisplayName("AMC Type")]

        public string AmcType { get; set; }


        [DisplayName("Budget Type")]

        public string BudgetType { get; set; }
        [DisplayName("Payment Type")]
        public string PaymentType { get; set; }
        [DisplayName("Service Type")]
        public string ServiceType { get; set; }
    }
}