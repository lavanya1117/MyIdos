using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using PageObjectLibrary;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace ActionLibrary
{
    public class VendorAction
    {
        IWebDriver driver;
        VendorPO vendorlink;
        
        public VendorAction()
        {
            driver = BrowserHandler.Driver;
            vendorlink = new VendorPO();

        }
        public void WaitforVendorPage()
        {
            int count = 0;
            while(count<10)
            {
                try
                {
                    if (vendorlink.elementVendor.Displayed)
                        break;
                }
                catch
                {

                }
                Thread.Sleep(1000);
                count++;
            }
        }
        public void CreateVendor()
        {
            WaitforVendorPage();
            vendorlink.elementOption.Click();
            Thread.Sleep(1000);
            vendorlink.elementVendor.Click();
            Thread.Sleep(1000);
            ClickButtonInVendors();
           // vendorlink.elementDownloadVendor.Click();

        }

        public void Add_Vendor()
        {
            try
            {
                vendorlink.elementOption.Click();
                Thread.Sleep(500);
                vendorlink.elementVendor.Click();

                WaitforVendorPage();

                ClickButtonInVendors();
                Thread.Sleep(1000);

                vendorlink.elementBranch.Click();
                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//li[contains(text(),'" + DataHandler.Instance.GetParam("Branch") + "')]/input[@id='vendorBranchCheck']")).Click();
                vendorlink.elementBranch.Click(); 
                Thread.Sleep(1000);
                SelectElement eleGroup = new SelectElement(vendorlink.elementVendorGroup);
                eleGroup.SelectByValue(DataHandler.Instance.GetParam("VendorGroup"));
                Thread.Sleep(500);

                vendorlink.elementVendorName.SendKeys(DataHandler.Instance.GetParam("vendName"));
                Thread.Sleep(1000);

                vendorlink.elementVendorEmail.SendKeys(DataHandler.Instance.GetParam("vendoremail"));
                Thread.Sleep(1000);

                SelectElement eleGst = new SelectElement(vendorlink.elementVendorGst);
                eleGst.SelectByValue(DataHandler.Instance.GetParam("IsVendorGSTRegistered"));
                Thread.Sleep(500);

                SelectElement eleType = new SelectElement(vendorlink.elementVendorType);
                eleType.SelectByValue(DataHandler.Instance.GetParam("VendorType"));
                Thread.Sleep(1000);
                vendorlink.elementAddress.Click();
                Thread.Sleep(500);
                vendorlink.elementAddress.SendKeys(DataHandler.Instance.GetParam("Address"));
                Thread.Sleep(500);
                SelectElement eleCountry = new SelectElement(vendorlink.elementCountry);
                eleCountry.SelectByValue(DataHandler.Instance.GetParam("Country"));
                Thread.Sleep(500);

                SelectElement eleState = new SelectElement(vendorlink.elementState);
                eleState.SelectByValue(DataHandler.Instance.GetParam("State"));
                Thread.Sleep(500);

                vendorlink.elementLocation.SendKeys(DataHandler.Instance.GetParam("Location"));

                SelectElement eleCountcode = new SelectElement(vendorlink.elementCountryCode);
                eleCountcode.SelectByValue(DataHandler.Instance.GetParam("CountryCode"));
                Thread.Sleep(500);
                vendorlink.elementPhone1.SendKeys(DataHandler.Instance.GetParam("Phone1"));

                Thread.Sleep(500);
                vendorlink.elementPhone2.SendKeys(DataHandler.Instance.GetParam("Phone2"));
                Thread.Sleep(500);

                vendorlink.elementPhone3.SendKeys(DataHandler.Instance.GetParam("Phone3"));
                Thread.Sleep(500);

                vendorlink.elementTDSsetUp.Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='"+DataHandler.Instance.GetParam("TDSSetup") +"']/preceding-sibling::input[contains(@style,'display:inline-block')]")).Click();
                Thread.Sleep(1000);

                SelectElement eleCash = new SelectElement(vendorlink.elementCash);
                eleCash.SelectByValue(DataHandler.Instance.GetParam("CashCredit"));
                Thread.Sleep(500);

                vendorlink.elementPan.SendKeys(DataHandler.Instance.GetParam("PANNO"));
                Thread.Sleep(500);

                SelectElement eleNature = new SelectElement(vendorlink.elementNatureofVendor);
                eleNature.SelectByValue(DataHandler.Instance.GetParam("NatureOfVendor"));

                vendorlink.elementAddBtn.Click();



            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                throw new Exception();
            }

        }

        public void ClickButtonInVendors()
        {
            driver.FindElement(By.XPath("//button[@title='"+ DataHandler.Instance.GetParam("VendorButtons") + "']")).Click();
           


        }
        public void ValidationVendor()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='vendorTable']//td[text()='" + DataHandler.Instance.GetParam("VendorValidation") + "']")).Displayed);
        }
    }
}
