using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    public class ActionBot
    {

        private IWebDriver driver;

        public ActionBot(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WriteToElementBy(By by, String text)
        {
            IWebElement element = driver.FindElement(by);
            element.Clear();
            this.setText(element, text);
            
        }

        public void ClickOnelement(By by)
        {
            IWebElement element = driver.FindElement(by);
            this.clickObject(element);
            
           
        }

        public void setText(IWebElement field, String text)
        {
            field.Clear();
            field.SendKeys(text);
            Console.WriteLine("set text :" + text);
        }

        public void clickObject(IWebElement button)
        {
            button.Click();          
            Console.WriteLine("click botton");
        }
    }
}
