using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using ActionLibrary;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using STContext = NUnit.Framework.TestContext;
using System.IO;
using System.Configuration;

namespace MyIdosDigital
{
    [TestFixture]
    public class AdminProjectSmoke
    {
        [Test]
        public void AddProject_Smoke()
        {
            LoginAction act = new LoginAction();
            act.IdosLogin();

            

            DataHandler.Instance.InitializeParameter("ProjectName", "project5");
            DataHandler.Instance.InitializeParameter("ProjectNumber", "p05");
            DataHandler.Instance.InitializeParameter("StartMonth", "0");
            DataHandler.Instance.InitializeParameter("StartYear", "2023");
            DataHandler.Instance.InitializeParameter("SelectDate", "15");
            DataHandler.Instance.InitializeParameter("EndMonth", "1");
            DataHandler.Instance.InitializeParameter("EndYear", "2023");
            DataHandler.Instance.InitializeParameter("EndSelectDate", "25");
            DataHandler.Instance.InitializeParameter("Projcountry", "101");
            DataHandler.Instance.InitializeParameter("Location", "Hyderabad");
            //DataHandler.Instance.InitializeParameter("BranchSearch", "Raipur");
            DataHandler.Instance.InitializeParameter("DirectorName", "GangaPrasad");
            DataHandler.Instance.InitializeParameter("ManagerName", "vijay");
            DataHandler.Instance.InitializeParameter("ManagerContName", "+91");
            DataHandler.Instance.InitializeParameter("Phone1", "999");
            DataHandler.Instance.InitializeParameter("Phone2", "999");
            DataHandler.Instance.InitializeParameter("Phone3", "9999");

            AdminProjAction adminProj = new AdminProjAction();
            adminProj.Add_Project_smoke();




        }
        [SetUp]

        public void InitializeProject()
        {
            TestContext Instance = STContext.CurrentContext;
            DataHandler.Instance.InitializeParameter("ResultDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            DataHandler.Instance.ImportData(ConfigurationManager.AppSettings["ParametersPath"] + "Parameters.xml");
            BrowserHandler.InitBrowser();
            BrowserHandler.LoadApplication();
        }
    }
}
