using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using System.Threading;
using System.IO;

namespace CoreLibrary
{
   public class BrowserHandler
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;
        private static object syncRoot = new Object();




        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    //string s = "";
                    try
                    {
                        throw new Exception();
                    }
                    catch { }
                }
                return driver;
            }
            private set
            {
                driver = value;
            }
        }



        public static string IERootPath()
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")));



            string rpath = Path.Combine(di.FullName, @"packages\");



            string[] IEPaths = Directory.GetFiles(rpath, "IEDriverServer.exe", SearchOption.AllDirectories);



            string latestIEPath = IEPaths[IEPaths.Length - 1];



            string[] x = latestIEPath.Split(new string[] { "IEDriverServer.exe" }, StringSplitOptions.None);



            return x[0];
        }



        public static string ChRootPath()
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")));



            string rpath = Path.Combine(di.FullName, @"packages\");



            string[] IEPaths = Directory.GetFiles(rpath, "chromedriver.exe", SearchOption.AllDirectories);



            string latestIEPath = IEPaths[IEPaths.Length - 1];



            string[] x = latestIEPath.Split(new string[] { "chromedriver.exe" }, StringSplitOptions.None);



            return x[0];
        }

        public static string EdgeRootPath()
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")));



            string rpath = Path.Combine(di.FullName, @"packages\");



            string[] IEPaths = Directory.GetFiles(rpath, "msedgedriver.exe", SearchOption.AllDirectories);



            string latestIEPath = IEPaths[IEPaths.Length - 1];




            string[] x = latestIEPath.Split(new string[] { "msedgedriver.exe" }, StringSplitOptions.None);



            return x[0];
        }
        public static void InitBrowser(string browserName = "Chrome")
        {
            browserName = DataHandler.Instance.GetParam("Browser");
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {



                    }
                    break;



                case "IE":
                    if (driver == null)
                    {
                        lock (syncRoot)
                        {
                            if (driver == null)
                            {
                                Drivers.Remove("IE");
                                driver = new InternetExplorerDriver(IERootPath());
                                if (Drivers.ContainsKey("IE"))
                                    Drivers.Add("IE", Driver);




                                // driver = new InternetExplorerDriver(@"C:\T\packages\Selenium.WebDriver.IEDriver.3.141.0\driver\");
                                // Drivers.Add("IE", Driver);
                            }
                        }
                    }
                    break;



                case "Chrome":
                    if (driver == null)
                    {
                        lock (syncRoot)
                        {
                            if (driver == null)
                            {
                                ChromeOptions options = new ChromeOptions();
                                options.SetLoggingPreference(LogType.Browser, LogLevel.All);
                                options.Proxy = null;
                                driver = new ChromeDriver(ChRootPath(), options);
                                if (Drivers.ContainsKey("Chrome"))
                                    Drivers.Add("Chrome", Driver);
                            }
                        }
                    }
                    break;



                case "Edge":
                    if (driver == null)
                    {
                        lock (syncRoot)
                        {
                            if (driver == null)
                            {
                                var msedgedriverExe = @"msedgedriver.exe";
                                var service = EdgeDriverService.CreateDefaultService(EdgeRootPath(), msedgedriverExe);



                                driver = new EdgeDriver(service);
                                // driver = new EdgeDriverService(EdgeRootPath(),msedgedriverExe);
                                //  if(Drivers.ContainsKey("Chrome"))
                                if (Drivers.ContainsKey("Edge"))
                                    Drivers.Add("Edge", Driver);



                            }
                        }
                    }
                    break;



                default:
                    if (driver == null)
                    {
                        lock (syncRoot)
                        {
                            if (driver == null)
                            {
                                driver = new InternetExplorerDriver();
                                Drivers.Add("IE", Driver);
                            }
                        }
                    }
                    break;



            }



        //    driver.Manage().Cookies.DeleteAllCookies();
        }
        




public static void LoadApplication(string url = "http://idosqa1.centralindia.cloudapp.azure.com:9000/signIn#logindiv")

        {

            // driver.Manage().Cookies.DeleteAllCookies();

            Thread.Sleep(2000);

            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(140));

            try

            {

                driver.Navigate().GoToUrl(DataHandler.Instance.GetParam("URL"));

            }

            catch

            {

                driver.Navigate().GoToUrl(DataHandler.Instance.GetParam("URL"));

            }

            Driver.Manage().Window.Maximize();



        }



        public static void CloseAllDrivers()

        {

            int len = driver.WindowHandles.Count;

            if (len > 1)

            {

                //for (int i = 0; i <= driver.WindowHandles.Count - 1; i++)

                //{

                //    driver.SwitchTo().Window(driver.WindowHandles[0]).Close(); Thread.Sleep(600);

                //}



                while (1 < driver.WindowHandles.Count)

                {

                    driver.SwitchTo().Window(driver.WindowHandles[0]).Close(); Thread.Sleep(600);

                }

            }

            driver.SwitchTo().Window(driver.WindowHandles[0]).SwitchTo();

        }



        //It should call at the end of all script execution

        //Not in [TearDown]

        public static void CloseAll()

        {

            int count = driver.WindowHandles.Count - 1;

            for (int i = 0; i <= count; i++)

            {

                driver.SwitchTo().Window(driver.WindowHandles[0]).Close(); Thread.Sleep(600);

            }



            foreach (var key in Drivers.Keys)

            {

                Drivers[key].Close();

                Drivers[key].Quit();

            }



            driver = null;

        }



        public static void Read_BrowserLog()

        {

            var entries = driver.Manage().Logs.GetLog(LogType.Browser);

            foreach (var vs in entries)

            {

                var vet = vs;

            }

        }



        public static void ClearDriver()

        {

            Thread.Sleep(1500);

            driver = null;

        }



        



    }

}









    

