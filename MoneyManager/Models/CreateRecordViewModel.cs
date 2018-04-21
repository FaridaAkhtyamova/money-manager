using MoneyManager.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace MoneyManager.Models
{
    public class CreateRecordViewModel
    {
        public int RecordID { get; set; }
        public bool IsExpense { get; set; } = true;

        public decimal Sum { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Spending Date")]
        public DateTime SpendingDate { get; set; } = DateTime.Today.Date;
        public string Comment { get; set; }

        [DisplayName("Spending Category")]
        public string SelectedCategoryID { get; set; }
        public List<Category> Categories { get; set; }

    }
}