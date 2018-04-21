using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyManager.DAL
{
    public class Record
    {
        public int RecordID { get; set; }
        [Display(Name = "Expense")]
        public bool IsExpense { get; set; } = true;
        public decimal Sum { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Spending Date")]
        public DateTime SpendingDate { get; set; }
        public string Comment { get; set; }
        public virtual Category Category { get; set; }

    }
}