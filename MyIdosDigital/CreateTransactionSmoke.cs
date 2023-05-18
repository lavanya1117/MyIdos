using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using ActionLibrary;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit;
using STContext = NUnit.Framework.TestContext;
using System.IO;
using System.Configuration;

namespace MyIdosDigital
{
    [TestFixture]
    public class CreateTransactionSmoke
    {
        [Test]
        public void Smoke_CreateTrans()
        {
            DataHandler.Instance.InitializeParameter("CreateDropdown", "1");
         //   DataHandler.Instance.InitializeParameter("SelectDate", "Apr 27, 2023");
            DataHandler.Instance.InitializeParameter("Branch", "15");
            DataHandler.Instance.InitializeParameter("Project", "38");
            DataHandler.Instance.InitializeParameter("TypeOfsupply", "1");
            DataHandler.Instance.InitializeParameter("IncomeSource", "Dettol");
            DataHandler.Instance.InitializeParameter("PlaceofSupply", "36");
            DataHandler.Instance.InitializeParameter("ReceiptDetails", "1");
            DataHandler.Instance.InitializeParameter("IncomeItems", "Professional Fee received  ");
            DataHandler.Instance.InitializeParameter("Units", "5");
          


            LoginAction loginSmoke = new LoginAction();
            loginSmoke.IdosLogin();

            CreateTransactionAction TransSmoke = new CreateTransactionAction();
            TransSmoke.Create_TransactionAction();

        }
        [SetUp]
        public void InitializeTrans()
        {
            TestContext Instance = STContext.CurrentContext;
            DataHandler.Instance.InitializeParameter("ResultDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            DataHandler.Instance.ImportData(ConfigurationManager.AppSettings["ParametersPath"] + "Parameters.xml");
            BrowserHandler.InitBrowser();
            BrowserHandler.LoadApplication();
        }

      
    }
}
