using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using OpenQA.Selenium;
using PageObjectLibrary;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace ActionLibrary
{
    public class CreateTransactionAction

    {
        IWebDriver driver;
        CreateTransactionPO createTrans;

        public CreateTransactionAction()
        {
            driver = BrowserHandler.Driver;
            createTrans = new CreateTransactionPO();
        }
    
        public void waitForCreateTrans()
        {
            int count = 0;
            while(count<0)
            {
                try
                {
                    if (createTrans.elementOption.Displayed)
                        break;
                }
                catch
                {
                    Thread.Sleep(1000);


                    count++;
                }
            }
        }
        public void Create_TransactionAction()
        {
            try
            {
                waitForCreateTrans();
                createTrans.elementOption.Click();
                Thread.Sleep(800);
                createTrans.elementTransaction.Click();
                Thread.Sleep(800);

                createTrans.elementCreateTransaction.Click();
                Thread.Sleep(800);

                SelectElement drp = new SelectElement(createTrans.elementDropdown);
                drp.SelectByValue(DataHandler.Instance.GetParam("CreateDropdown"));
                Thread.Sleep(800);

                // createTrans.elementDropdown.Click();
              //  createTrans.elementSelectDate.Click();                

               // createTrans.elementSelectDate.Clear();
                

               // createTrans.elementSelectDate.SendKeys(DataHandler.Instance.GetParam("SelectDate"));
               // Thread.Sleep(800);

                SelectElement BranchDrp = new SelectElement(createTrans.elementBranch);
                BranchDrp.SelectByValue(DataHandler.Instance.GetParam("Branch"));
                Thread.Sleep(800);

                SelectElement ProjDrp = new SelectElement(createTrans.elementProject);
                ProjDrp.SelectByValue(DataHandler.Instance.GetParam("Project"));
                Thread.Sleep(800);

                SelectElement TypeDrp = new SelectElement(createTrans.elementTypeofSupply);
                TypeDrp.SelectByValue(DataHandler.Instance.GetParam("TypeOfsupply"));
                Thread.Sleep(800);

                createTrans.elementCustSource.Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//li[text()='" + DataHandler.Instance.GetParam("IncomeSource") + "']")).Click();
                Thread.Sleep(800);

                SelectElement Placedrp = new SelectElement(createTrans.elementPlaceofSupply);Thread.Sleep(1000);
                Placedrp.SelectByValue(DataHandler.Instance.GetParam("PlaceofSupply"));
                Thread.Sleep(800);

                SelectElement Modedrp = new SelectElement(createTrans.elementMode);
                Modedrp.SelectByValue(DataHandler.Instance.GetParam("ReceiptDetails"));
                Thread.Sleep(800);

                createTrans.elementIncomeItems.Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//li[text()='" + DataHandler.Instance.GetParam("IncomeItems") + "']")).Click();
                Thread.Sleep(800);

                createTrans.elementUnit.SendKeys(DataHandler.Instance.GetParam("Units"));
                Thread.Sleep(800);

                createTrans.elementSubmit.Click();
                



            }
            catch(Exception ex)
            {
                string s = ex.ToString();
                throw new Exception();
            }
        }
    }

}

  

