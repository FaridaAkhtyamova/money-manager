using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Tests
{
    [TestClass]
    public class test
    {
        List<string> domains = new List<string>() { "intanet", "partners" };
        List<string> groupType = new List<string>() { "SG", "DL" };
        List<string> groupScope = new List<string>() { "Local", "Global", "Universal" };
        [TestMethod]
        public void GenerateGroups()
        {
            foreach (var domain in domains)
            {
                ProcessDomain(domain);
            }
        
        }

        public void ProcessDomain(string domain)
        {
            if (domain == "intranet")
            {
                CreateGroups(groupType, groupScope);
            }
            else if (domain == "partners")
            {
                CreateGroups("SG", groupScope);
            }
        }

        private object CreateGroups(object types, object scopes)
        {
            throw new NotImplementedException();
        }
    }
}
