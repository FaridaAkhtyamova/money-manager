namespace MoneyManager.Migrations
{
    using DAL;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MoneyManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MoneyManager.Models.MoneyManagerContext";
        }

        protected override void Seed(MoneyManagerContext context)
        {
            context.Categories.AddOrUpdate(
              c => c.CategoryName,
              new Category { CategoryName = "Rent" },
              new Category { CategoryName = "Grocery" },
              new Category { CategoryName = "Transport" }
            );
            context.SaveChanges();
        }
    }
}
