using OpenQA.Selenium;
using System;
using System.Threading;

namespace NUnit.Tests1
{
    public class Login
    {

        private static ActionBot bot;
        private IWebDriver driver;
        private static By usernameInput = By.Id("username");
        private static By passwordInput = By.XPath(".//input[@id='password']");
        private static By signInBtn = By.XPath(".//div[@class='w-login-btn-wrapp']");

        public Login(IWebDriver driver)
        {
            bot = new ActionBot(driver);
            this.driver = driver;
        }

        public Login NavigateToUrl(String URL)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL); 
            return this;
        }

        public Login SetUserName(String userName)
        {
            IWebElement username = driver.FindElement(By.Id("username"));
            bot.WriteToElementBy(usernameInput, userName);
            return this;
        }

        public Login SetPassword(String paswword)
        {
            bot.WriteToElementBy(passwordInput, paswword);
            return this;
        }

        public MyWatchlist ClickSignIn()
        {
            bot.ClickOnelement(signInBtn);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@class='inmplayer-popover-close-button']")).Click();
            Thread.Sleep(5000);
            return (new MyWatchlist(driver));
        }


    }
}
