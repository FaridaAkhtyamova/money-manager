using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MoneyManager.DAL;

namespace MoneyManager.DAL
{
    public class MoneyManagerContext : DbContext, IMMDataSource
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MoneyManagerContext() : base("name=MoneyManagerContext")
        {
        }

        public DbSet<Record> Records { get; set; }

        public DbSet<Category> Categories { get; set; }

        IQueryable<Record> IMMDataSource.Records
        {
            get
            {
                return Records;
            }

        }

        IQueryable<Category> IMMDataSource.Categories
        {
            get
            {
                return Categories;
            }

            
        }
    }
}
