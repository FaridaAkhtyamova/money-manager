using System.Collections.Generic;

namespace MoneyManager.DAL
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}