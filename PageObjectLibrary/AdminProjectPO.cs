using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using CoreLibrary;

namespace PageObjectLibrary
{
    public class AdminProjectPO
    {
        IWebDriver driver = null;

        public AdminProjectPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementAdminOption => driver.FindElement(By.XPath("//a[text()='Option']"));
        public IWebElement elementAdminProj => driver.FindElement(By.XPath("//a[@id='projectSetupId']"));
        public IWebElement elementAdminNewProj => driver.FindElement(By.XPath("//button[@id='newProjectform-container']"));


        public IWebElement elementProjName =>driver.FindElement(By.XPath("//input[@id='projectname']"));
        public IWebElement elementProjNum => driver.FindElement(By.XPath("//input[@id='projectnumber']"));
        public IWebElement elementProjStartDD => driver.FindElement(By.XPath("//input[@id='projectstartdate']"));
        public IWebElement elementProjStartMonth => driver.FindElement(By.XPath("//div[@id='ui-datepicker-div' and contains(@style,'display: block')]//select[@class='ui-datepicker-month']"));
        public IWebElement elementProjStartYear => driver.FindElement(By.XPath("//div[@id='ui-datepicker-div' and contains(@style,'display: block')]//select[@class='ui-datepicker-year']"));
        public IWebElement elementProjEndDD => driver.FindElement(By.XPath("//input[@id='projectenddate']"));
        public IWebElement elementProjEndMonth => driver.FindElement(By.XPath("//div[@id='ui-datepicker-div' and contains(@style,'display: block')]//select[@class='ui-datepicker-month']"));
        public IWebElement elementProjEndYear => driver.FindElement(By.XPath("//div[@id='ui-datepicker-div' and contains(@style,'display: block')]//select[@class='ui-datepicker-year']"));

        public IWebElement elementProjBranch => driver.FindElement(By.XPath("//span[@class='multiselect-native-select']//span[text()='None selected']//ancestor::div[@class='btn-group']/preceding-sibling::select[@id='projectBranch']"));
        public IWebElement elementProjDirectorName => driver.FindElement(By.XPath("//input[@id='projectdirectorname']"));
        //public IWebElement elementCountryCode => driver.FindElement(By.XPath("//select[@id='projectdirectorcountryPhnCode']"));
        public IWebElement elementProjManagerName => driver.FindElement(By.XPath("//input[@id='projectmanagername']"));
        public IWebElement elementProjManagerCont => driver.FindElement(By.XPath("//select[@id='projectmanagercountryPhnCode']"));
        public IWebElement elementProjPhone1 => driver.FindElement(By.XPath("//input[@id='projectmanagerphnumber1']"));
        public IWebElement elementProjPhone2 => driver.FindElement(By.XPath("//input[@id='projectmanagerphnumber2']"));
        public IWebElement elementProjPhone3 => driver.FindElement(By.XPath("//input[@id='projectmanagerphnumber3']"));
        public IWebElement elementProjBranchSearch => driver.FindElement(By.XPath("//input[contains(@class,'form-control')]"));

        public IWebElement elementProjCountry => driver.FindElement(By.XPath("//select[@id='projectCountry']"));
        public IWebElement elementProjLocation => driver.FindElement(By.XPath("//input[@id='projectlocation']"));
        public IWebElement elementProjAddProj => driver.FindElement(By.XPath("//button[@id='createProject']"));

    }
}
