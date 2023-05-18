using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using PageObjectLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace ActionLibrary
{
   public class AdminProjAction
    {
        IWebDriver driver;
        AdminProjectPO addProj;

        public AdminProjAction()
        {
            driver = BrowserHandler.Driver;
            addProj = new AdminProjectPO();
        }

        public void waitForPage()
        {
            int count = 0;
            while(count<0)
            {
                try
                {
                    if (addProj.elementProjName.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(500);
                count++;
            }
        }
        public void Add_Project_smoke()
        {
            try
            {
                waitForPage();
                addProj.elementAdminOption.Click();
                Thread.Sleep(500);
                addProj.elementAdminProj.Click();
                Thread.Sleep(500);
                addProj.elementAdminNewProj.Click();
                Thread.Sleep(500);
                addProj.elementProjName.SendKeys(DataHandler.Instance.GetParam("ProjectName"));
                Thread.Sleep(500);
                addProj.elementProjNum.SendKeys(DataHandler.Instance.GetParam("ProjectNumber"));
                Thread.Sleep(500);

                addProj.elementProjStartDD.Click();
                Thread.Sleep(500);

                SelectElement eleStartMon = new SelectElement(addProj.elementProjStartMonth);
                eleStartMon.SelectByValue(DataHandler.Instance.GetParam("StartMonth"));
                Thread.Sleep(500);
                SelectElement eleStartYear = new SelectElement(addProj.elementProjStartYear);
                eleStartYear.SelectByValue(DataHandler.Instance.GetParam("StartYear"));
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//td/a[text()='" + DataHandler.Instance.GetParam("SelectDate") + "']")).Click();
                Thread.Sleep(500);
                addProj.elementProjEndDD.Click();
                Thread.Sleep(500);
                SelectElement eleEndMonth = new SelectElement(addProj.elementProjEndMonth);
                eleEndMonth.SelectByValue(DataHandler.Instance.GetParam("EndMonth"));
                Thread.Sleep(500);
                SelectElement eleEndYear = new SelectElement(addProj.elementProjEndYear);
                eleEndYear.SelectByValue(DataHandler.Instance.GetParam("EndYear"));
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//td/a[text()='" + DataHandler.Instance.GetParam("EndSelectDate") + "']")).Click();
                Thread.Sleep(500);
                SelectElement eleCountry = new SelectElement(addProj.elementProjCountry);
                eleCountry.SelectByValue(DataHandler.Instance.GetParam("Projcountry"));
                Thread.Sleep(500);
                addProj.elementProjLocation.SendKeys(DataHandler.Instance.GetParam("Location"));
                Thread.Sleep(500);
                //addProj.elementProjBranch.Click();
                //addProj.elementProjBranchSearch.SendKeys(DataHandler.Instance.GetParam("BranchSearch"));
                //Thread.Sleep(500);
                addProj.elementProjDirectorName.SendKeys(DataHandler.Instance.GetParam("DirectorName"));
                Thread.Sleep(500);

                addProj.elementProjManagerName.SendKeys(DataHandler.Instance.GetParam("ManagerName"));
                Thread.Sleep(500);

                SelectElement eleManagerCont = new SelectElement(addProj.elementProjManagerCont);
                eleManagerCont.SelectByValue(DataHandler.Instance.GetParam("ManagerContName"));
                Thread.Sleep(500);

                addProj.elementProjPhone1.SendKeys(DataHandler.Instance.GetParam("Phone1"));
                Thread.Sleep(500);

                addProj.elementProjPhone2.SendKeys(DataHandler.Instance.GetParam("Phone2"));
                Thread.Sleep(500);


                addProj.elementProjPhone3.SendKeys(DataHandler.Instance.GetParam("Phone3"));
                Thread.Sleep(500);

                addProj.elementAdminNewProj.Click();
            }
            catch(Exception e)
            {
                string s = e.ToString();
                throw new Exception();
            }





        }
    }
}
