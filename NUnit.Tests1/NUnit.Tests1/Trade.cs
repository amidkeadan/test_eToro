using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    public class Trade
    {

        private IWebDriver driver;
        private ActionBot bot;

        

        public Trade(IWebDriver driver)
        {
            bot = new ActionBot(driver);
            this.driver = driver;

        }

        public void IncreaseTheValueToStopLoss(double num)
        {

            IWebElement plusButton = driver.FindElement(By.XPath(".//*[@class='stepper-plus']//span"));
            IWebElement stoplosstabtitlevalue = driver.FindElement(By.XPath(".//*[@data-etoro-automation-id='execution-stop-loss-tab-title-value']"));

            double val = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));

            do
            {
                if (val < num) break;
                bot.clickObject(plusButton);
                Thread.Sleep(1000);
                val = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));
            }
            while (val > num);
        }


        public void decreaseTheValueToMinStopLoss(double minValue)
        {
            IWebElement minusButton = driver.FindElement(By.XPath(".//*[@class='stepper-minus']//span"));
            IWebElement amount = driver.FindElement(By.XPath(".//*[@data-etoro-automation-id='input']"));

            IWebElement stoplosstabtitlevalue = driver.FindElement(By.XPath(".//*[@data-etoro-automation-id='execution-stop-loss-tab-title-value']"));

            IWebElement notivecation = driver.FindElement(By.XPath(".//*[@id='open-position-view']//div[@data-ng-message='depositRequiredForOpenTrade']"));
            double stopVal = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));
            double val;

             //Regex.Match(str, @"(\D)([.\d,]+)").Value
            //Match match = Regex.Match(str, @"(\d+)")

            do
            {
                val = stopVal;
                bot.clickObject(minusButton);
                Thread.Sleep(1000);
                stopVal = Double.Parse(stoplosstabtitlevalue.Text.Replace("$", ""));
            }
            while (stopVal != val);

            Assert.AreEqual(stopVal, minValue);


        }


    }
}
