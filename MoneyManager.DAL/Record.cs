using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyManager.DAL
{
    public class Record
    {
        public int RecordID { get; set; }
        [Display(Name = "Expense")]
        public bool IsExpense { get; set; }
        [DataType(DataType.Currency)]
        public decimal Sum { get; set; }

        [Display(Name = "Spending Date")]
        public DateTime SpendingDate { get; set; }
        public string Comment { get; set; }
        //public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}