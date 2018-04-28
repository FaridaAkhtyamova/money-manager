using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyManager.DAL;
using System.Linq;
using MoneyManager.Controllers;
using System.Web.Mvc;
using MoneyManager.Models;

namespace MoneyManager.Tests
{
    [TestClass]
    public class CategoriesControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new RecordsController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestDetails()
        {
            var controller = new RecordsController();
            var result = controller.Details(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateIncome()
        {
            var controller = new RecordsController();
            var model = new CreateIncomeViewModel() { RecordID = 1000, IsExpense = true, SpendingDate = DateTime.Today, Comment = "Comment", Sum = 1200, SelectedCategoryID = "1" };
            var result = controller.CreateIncome(model);

        }
        
    }
}
