using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using OpenQA.Selenium;

namespace PageObjectLibrary
{
   public class VendorPO
    {
        IWebDriver driver = null;

        public VendorPO()
        {
            driver = BrowserHandler.Driver;

        }

        public IWebElement elementOption => driver.FindElement(By.XPath("//a[contains(text(),'Option')]"));
        public IWebElement elementVendor => driver.FindElement(By.XPath("//a[@id='vendorSetupId']"));
        // public IWebElement elementAddVendor => driver.FindElement(By.XPath("//button[@id='newVendorform-container']"));
        // public IWebElement elementCreateVendorGroup => driver.FindElement(By.XPath("//button[@id='newVendorGroupform-container']"));
        public IWebElement elementDownloadVendor => driver.FindElement(By.XPath("//a[contains(@onClick,'downloadOrganizationVendorTemplate')]"));
        public IWebElement elementBranch => driver.FindElement(By.XPath("//button[@id='vendorBranchDropdownBtn']")); //Dropdown
        public IWebElement elementVendorGroup => driver.FindElement(By.XPath("//select[@id='vendorGroup']"));  //Dropdown
        public IWebElement elementVendorName => driver.FindElement(By.XPath("//input[@id='vendName']"));  //input

        public IWebElement elementVendorEmail => driver.FindElement(By.XPath("//input[@name='vendoremail']"));  //input

        public IWebElement elementVendorGst => driver.FindElement(By.XPath("//select[@id='vendorRegisteredOrUnReg']"));

        public IWebElement elementVendorType => driver.FindElement(By.XPath("//select[@id='vendBusinessIndividual']"));  //dropdown
        public IWebElement elementAddress => driver.FindElement(By.XPath("//textarea[@id='vendorAddress']")); //input

        public IWebElement elementCountry => driver.FindElement(By.XPath("//select[@id='vendorcountry']")); //dropdown
        public IWebElement elementState => driver.FindElement(By.XPath("//select[@id='vendorState']"));  //dropdown
        public IWebElement elementLocation => driver.FindElement(By.XPath("//input[@id='location']"));  // input
        public IWebElement elementCountryCode => driver.FindElement(By.XPath("//select[@id='vendorPhnNocountryCode']"));  //dropdown
        public IWebElement elementPhone1 => driver.FindElement(By.XPath("//input[@id='vendorphone1']")); //input
        public IWebElement elementPhone2 => driver.FindElement(By.XPath("//input[@id='vendorphone2']")); //input
        public IWebElement elementPhone3 => driver.FindElement(By.XPath("//input[@id='vendorphone3']")); //input

        public IWebElement elementTDSsetUp => driver.FindElement(By.XPath("//button[@id='vendTdsdropdown']"));
        //span[text()='Professional Fees paid']/preceding-sibling::input[contains(@style,'display:inline-block')]
        public IWebElement elementCash => driver.FindElement(By.XPath("//select[@id='futurePayment']"));
        public IWebElement elementPan => driver.FindElement(By.XPath("//input[@id='panNoVend']"));
        public IWebElement elementNatureofVendor => driver.FindElement(By.XPath("//select[@id='natureOfVend']"));

        public IWebElement elementAddBtn => driver.FindElement(By.XPath("//button[@id='addVendBtn']"));











    }
}
