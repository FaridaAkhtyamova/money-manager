using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyManager.DAL;
using System.Linq;

namespace MoneyManager.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    //List<Category> category = new List<Category>();
        //    //category.Add(new Category(){ CategoryID = 1, CategoryName = "Groseries" });
        //    Category category = new Category(){ CategoryID = 1, CategoryName = "Groseries" };
        //    Record record = new Record();
        //    record.RecordID = 1;
        //    record.IsExpense = true;
        //    record.SpendingDate = DateTime.Today;
        //    record.Sum = 1234.23m;
        //    record.Comment = "test record";
        //    record.CategoryID = 1;
        //    record.Category = category;

        //}

        [TestMethod]

        public void TestTwoSum()
        {
            int[] nums = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 74 };
            int target = 77;
            //int[] nums = new int[] { 3, 3 };
            //int target = 6;

            var result = TwoSum(nums, target);
            Console.WriteLine(result[0] + ", " + result[1]);

        }
        public int[] TwoSum(int[] nums, int target)
        {

            var f = 0;
            var s = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var testlits = nums.ToList();
                var ext = (int)nums.GetValue(i);
                var temp = target - ext;

                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        if (temp == nums[j])
                        {
                            f = i;
                            s = j;
                            break;   
                        }
                        
                    }
                    
                }
            }
            if (f == s)
            {
                throw new OutOfMemoryException("failed");
            }
                
            return new int[] { f, s };
           
            //var originalList = nums.ToList();

            //foreach (var item in originalList)
            //{
            //    var testlist = nums.ToList();
            //    var n = item;

            //    var finished = false;
            //    foreach (var item2 in testlist.Skip(1))
            //    {
            //        if (n + item2 == target)
            //        {
            //            result[0] = originalList.IndexOf(n);
            //            result[1] = originalList.IndexOf(item2);
            //            finished = true;
            //            break;
            //        }


            //    }
            //    testlist.Remove(item);
            //    testlist.Add(n);

            //    if (finished) 
            //        break;
            //}


        }

    }
}
