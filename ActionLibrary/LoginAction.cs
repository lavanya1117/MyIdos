using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using PageObjectLibrary;
using CoreLibrary;

namespace ActionLibrary
{
    public class LoginAction
    {
        IWebDriver driver;
        LoginPO loginpo;

        public LoginAction()
        {
            driver = BrowserHandler.Driver;
            loginpo = new LoginPO();
        }

        public void waitForLoginpage()
        {
            int count = 0;
            while(count<10)
            {
                try
                {
                    if (loginpo.elementUserName.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1000);
                count++;
            }
        }

        public void IdosLogin()
        {
            try
            {
                waitForLoginpage();
                loginpo.elementUserName.SendKeys(DataHandler.Instance.GetParam("Username"));
                Thread.Sleep(1000);
                loginpo.elementPassword.SendKeys(DataHandler.Instance.GetParam("Password"));
                Thread.Sleep(1000);
                driver.SwitchTo().Frame(0);
                Thread.Sleep(1000);
                loginpo.elementCaptcha.Click();
                  Thread.Sleep(1000);
                driver.SwitchTo().DefaultContent();
                loginpo.elementLoinButton.Click();
                Thread.Sleep(1000);
                loginpo.elementVerify.Click();
            }
            catch(Exception ex)
            {
                string s = ex.ToString();
            }
        }
        private void Wait_VerifyPAge()
        {
            int count = 0;
            while(count<10)
            {
                try
                {
                    if (loginpo.elementVerify.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1000);
                count++;
            }
        }
    }
}
