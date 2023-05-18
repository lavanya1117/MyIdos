using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CoreLibrary;

namespace MyIdosDigital
{
    [TestFixture]
    public class Environment
    {
        [Test]

        public void IdosLogin_parameters()
        {
            DataHandler.Instance.InitializeParameter("URL", @"http://idosqa1.centralindia.cloudapp.azure.com:9000/signIn#logindiv");
            DataHandler.Instance.InitializeParameter("Environment", "QA");
            DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "admin@abc.com");
            DataHandler.Instance.InitializeParameter("Password", "1dosP@ssw0rd1");
        }
        [TearDown]
        public void MyTestCleanUp()
        {
            DataHandler.Instance.BulkExport("xml");
            DataHandler.Instance.ClearDictionary();
        }
    }
}
