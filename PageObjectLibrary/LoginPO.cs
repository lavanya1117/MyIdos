using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using OpenQA.Selenium;


namespace PageObjectLibrary
{
    public class LoginPO
    {
       IWebDriver driver = null;

        public LoginPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementUserName => driver.FindElement(By.Id("loginuser"));
        public IWebElement elementPassword => driver.FindElement(By.Id("pass"));
        public IWebElement elementLoinButton => driver.FindElement(By.Id("loginButton"));
        public IWebElement elementCaptcha => driver.FindElement(By.Id("recaptcha-anchor"));
        public IWebElement elementVerify => driver.FindElement(By.Id("verifyButton"));
    }
}
