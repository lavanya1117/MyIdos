using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using CoreLibrary;


namespace PageObjectLibrary
{
 
    public class CreateTransactionPO
    {
        IWebDriver driver = null;

        public CreateTransactionPO()
        {
            driver = BrowserHandler.Driver;
        }
        public IWebElement elementOption => driver.FindElement(By.XPath("//a[contains(text(),'Option')]"));
        public IWebElement elementTransaction => driver.FindElement(By.XPath("//a[@class='close-option' and contains(text(),'Transactions')]"));
        public IWebElement elementCreateTransaction => driver.FindElement(By.XPath("//button[@id='newExpenseButton']"));
        //public IWebElement elementDropdown => driver.FindElement(By.XPath("//select[@id='whatYouWantToDo']//option[text()='Sell on cash & collect payment now']"));
        public IWebElement elementDropdown => driver.FindElement(By.XPath("//select[@id='whatYouWantToDo']"));
        //public IWebElement elementSelectDate => driver.FindElement(By.XPath("//input[@class='txnBackDate hasDatepicker']"));
        public IWebElement elementBranch => driver.FindElement(By.XPath("//select[@id='soccpnTxnForBranches']"));
        public IWebElement elementProject => driver.FindElement(By.XPath("//select[@id='allTxnProjectPurposeData']"));
        public IWebElement elementTypeofSupply => driver.FindElement(By.XPath("//select[@id='soccpnTypeOfSupply']"));
        public IWebElement elementCustSource => driver.FindElement(By.XPath("//span[@id='select2-soccpnCustomer-container']"));
        public IWebElement elementPlaceofSupply => driver.FindElement(By.XPath("//select[@id='soccpnPlaceOfSply']"));
        public IWebElement elementMode => driver.FindElement(By.XPath("//select[@id='socpnreceiptdetail']"));
        public IWebElement elementIncomeItems => driver.FindElement(By.XPath("//span[text()='Select an item']"));

        public IWebElement elementUnit => driver.FindElement(By.XPath("//input[@id='soccpnunits']"));
        public IWebElement elementSubmit => driver.FindElement(By.XPath("//button[@id='soccpnsubmitForApproval']"));



    }
}
