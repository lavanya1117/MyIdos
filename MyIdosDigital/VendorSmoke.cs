using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using ActionLibrary;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit;
using NUnit.Framework;
using STContext = NUnit.Framework.TestContext;
using System.IO;
using System.Configuration;

namespace MyIdosDigital
{
    [TestFixture]
    public class VendorSmoke
    {
        [Test]

        public void Vendor_Create()
        {
          
            DataHandler.Instance.InitializeParameter("VendorButtons", "Create Vendor");

            LoginAction action = new LoginAction();
            action.IdosLogin();

            VendorAction vendorcreate = new VendorAction();
            vendorcreate.CreateVendor();
        }
        [Test]
        public void Smoke_AddVendor()
        {
            DataHandler.Instance.InitializeParameter("VendorButtons", "Create Vendor");
            DataHandler.Instance.InitializeParameter("Branch", "Raipur");
            DataHandler.Instance.InitializeParameter("VendorGroup", "9");
            DataHandler.Instance.InitializeParameter("vendName", "luxes");
            DataHandler.Instance.InitializeParameter("vendoremail", "luxes@gmail.com");
            DataHandler.Instance.InitializeParameter("IsVendorGSTRegistered", "0");
            DataHandler.Instance.InitializeParameter("VendorType", "1"); 
            DataHandler.Instance.InitializeParameter("Address", "plotno52");
            DataHandler.Instance.InitializeParameter("Country", "101");
            DataHandler.Instance.InitializeParameter("State", "37");
            DataHandler.Instance.InitializeParameter("Location", "Hyderabad");
            DataHandler.Instance.InitializeParameter("CountryCode", "+91");
            DataHandler.Instance.InitializeParameter("Phone1", "232");
            DataHandler.Instance.InitializeParameter("Phone2", "456");
            DataHandler.Instance.InitializeParameter("Phone3", "2345");
            DataHandler.Instance.InitializeParameter("TDSSetup", "Professional Fees paid");
            DataHandler.Instance.InitializeParameter("CashCredit", "1");
            DataHandler.Instance.InitializeParameter("PANNO", "APGML7756P");
            DataHandler.Instance.InitializeParameter("NatureOfVendor", "1");

            #region Class Initilization
            LoginAction action = new LoginAction();
            VendorAction addvendor = new VendorAction();
            #endregion


            action.IdosLogin();            
            addvendor.Add_Vendor();

            //Validation one
            DataHandler.Instance.InitializeParameter("VendorValidation", "Santoor");
            addvendor.ValidationVendor();

            //Validation 2
            DataHandler.Instance.InitializeParameter("VendorValidation", "HYDERABAD");
            addvendor.ValidationVendor();

            //validation 3
            DataHandler.Instance.InitializeParameter("VendorValidation", "lux@abc.com");
            addvendor.ValidationVendor();
        }

        [SetUp]

        public void InitializeVendor()
        {
            TestContext Instance = STContext.CurrentContext;
            DataHandler.Instance.InitializeParameter("ResultDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            DataHandler.Instance.ImportData(ConfigurationManager.AppSettings["ParametersPath"] + "Parameters.xml");
            BrowserHandler.InitBrowser();
            BrowserHandler.LoadApplication();
        }
       
    }
}
