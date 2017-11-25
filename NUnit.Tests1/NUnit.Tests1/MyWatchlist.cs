using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    public class MyWatchlist
    {

        public ActionBot bot;
        private IWebDriver driver;

        private static By markitname;
        private static By TradeBtn = By.XPath("//button//span[text()='Trade']");


        public MyWatchlist(IWebDriver driver)
        {
            this.driver = driver;
            bot = new ActionBot(driver);
        }


        public MyWatchlist SelectMarkits(String markets)
        {
            markitname = By.XPath("//div[@class='user-info']/span[text()='"+ markets + "']");
            bot.ClickOnelement(markitname);
            return this;
        }

        public Trade ClickTradButton()
        {
            bot.ClickOnelement(TradeBtn);
            return new Trade(driver);
        }



    }
}
