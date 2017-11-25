using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    class eToroTest
    {
        public IWebDriver driver = WebDriverFactory.getWebDriver();
        public Login eToroLogin;
        public MyWatchlist myWatchlist;
        public Trade myTrade;

        [Test, Order(1)]
        public void LogIn() 
        {
            Login eToroLogin = new Login(driver);
            eToroLogin
                .NavigateToUrl("https://www.etoro.com/login")
                .SetUserName("test12345j")
                .SetPassword("aa112233");
            myWatchlist = eToroLogin.ClickSignIn(); 
        }

        [Test, Order(2)]
        public void MarkitList()
        {
            myWatchlist.SelectMarkits("BTC");
            myTrade = myWatchlist.ClickTradButton();

        }

        [Test , Order(3)]
        public void IncreaseTrade()
        {
            myTrade.IncreaseTheValueToStopLoss(-1000);
        }

        [Test, Order(4)]
        public void DecreaseTrade()
        {
            myTrade.decreaseTheValueToMinStopLoss(-100);
        }

        [Test, Order(5)]
        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
