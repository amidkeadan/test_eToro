using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    public class WebDriverFactory
    {

        private static IniParser parser = new IniParser();
        private static String browsertype = parser.GetSetting("appsettings", "browser");

       //private static String browsertype = "CHROME";

        public static IWebDriver getWebDriver()
        {
            IWebDriver driver = null;

            switch (browsertype)
            {
                case "CHROME":
                    driver = new ChromeDriver(@"C:\AmidVS\NUnit.Tests1\webdrivers");
                    break;
                case "FIREFOX":
                    driver = new FirefoxDriver(@"C:\AmidVS\NUnit.Tests1\webdrivers");
                    break;
                case "IE":
                    driver = new InternetExplorerDriver(@"C:\AmidVS\NUnit.Tests1\webdrivers");
                    break;
            }


            return driver;
        }
    }
}
