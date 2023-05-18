using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using ActionLibrary;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using STContext = NUnit.Framework.TestContext;
using System.IO;

namespace MyIdosDigital
{
    [TestFixture]
    public class LoginSmoke
    {
        [Test]

        public void smoke_login()
        {
            LoginAction loginSmoke = new LoginAction();
            loginSmoke.IdosLogin();
        }
        [SetUp]
        public void Initialize()
        {
            TestContext Instance = STContext.CurrentContext;
            DataHandler.Instance.InitializeParameter("ResultDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            DataHandler.Instance.ImportData(ConfigurationManager.AppSettings["ParametersPath"] + "Parameters.xml");
            BrowserHandler.InitBrowser();
            BrowserHandler.LoadApplication();
        }

    }
}
