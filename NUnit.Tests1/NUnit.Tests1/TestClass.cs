using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using OpenQA.Selenium.IE;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        public IWebDriver driver;
        public String baseUrl;
        public String mystr="";

        //The browser type to be used should be provided in a configuration file named config.ini in the
        //IniParser parser = new IniParser(@"C:\AmidVS\NUnit.Tests1\NUnit.Tests1\config.ini");
        IniParser parser = new IniParser();
        
        //String browsertype = parser.GetSetting("appsettings", "browser");

        String browsertype = "CHROME";

        //2.	Perform login with your user credentials.
        [Test, Order(1)]
        public void LogIn()
        {
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

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.etoro.com/login ");
            IWebElement username = driver.FindElement(By.Id("username"));
            IWebElement password = driver.FindElement(By.Id("password"));
            IWebElement signIn = driver.FindElement(By.XPath("//div[@class='w-login-btn-wrapp']"));

            setText(username, "test12345j");
            setText(password, "aa112233");
            clickObject(signIn);


        }
        //3.	On the “My Watchlist” page: click “BTC”
        //4.	On the “BTC” page, click “Trade” button

        [Test, Order(2)]
        public void BTC_Traid_TC3()
        {
            IWebElement BTC = driver.FindElement(By.XPath("//div[@class='user-info']/span[text()='BTC']"));
            clickObject(BTC);

            IWebElement TradeButton = driver.FindElement(By.XPath("//button//span[text()='Trade']"));
            clickObject(TradeButton);

        }

        //5.	On the “Trade” page, use the “+” button, to bring the value of “stop loss” to be less than $1000.
        [Test, Order(3)]
        public void TC_5()
        {

            IWebElement plusButton = driver.FindElement(By.XPath(".//*[@class='stepper-plus']//span"));
            IWebElement stoplosstabtitlevalue = driver.FindElement(By.XPath(".//*[@data-etoro-automation-id='execution-stop-loss-tab-title-value']"));

            double val = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));

            do
            {
                if (val < -1000) break;

                clickObject(plusButton);
                val = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));
            }
            while (val > -1000);


        }

        // 6.	Still on the “Trade” page, click the “-“ button until “Minimum position size for BTC is $xxx” message is shown.
        // 7.	Verify that the minimum amount value is $250.

        [Test, Order(4)]
        public void TC_6()
        {

            IWebElement minusButton = driver.FindElement(By.XPath(".//*[@class='stepper-minus']//span"));
            IWebElement amount = driver.FindElement(By.XPath(".//*[@data-etoro-automation-id='input']"));

            IWebElement stoplosstabtitlevalue = driver.FindElement(By.XPath(".//*[@data-etoro-automation-id='execution-stop-loss-tab-title-value']"));
            double stopVal = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));
            double val;
            do
            {
                val = stopVal;
                clickObject(minusButton);
                stopVal = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));
            }
            while (stopVal != val);

            Assert.AreEqual(stopVal, -100.00);


        }
    


        [Test , Order(7)]
        public void closeBrowser()
        {
            driver.Quit();
        }
        

        public void setText(IWebElement field ,String str)
        {
            field.Clear();
            field.SendKeys(str);
          //  Thread.Sleep(1000);
        }

        public void clickObject(IWebElement button)
        {
            button.Click();
          //  Thread.Sleep(2000);
        }

    }
}
