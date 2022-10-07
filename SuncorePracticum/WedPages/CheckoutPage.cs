using System;
using OpenQA.Selenium;

namespace SuncorePracticum.WedPages
{

    public class CheckoutPage
    {
        IWebDriver webDriver;
        public CheckoutPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public string GetTitle()
        {
            string title = webDriver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span")).Text;
            return title;
        }

        public void EnterFirstName(string user)
        {

            IWebElement userName = webDriver.FindElement(By.XPath("//*[@id=\"first-name\"]"));
            userName.SendKeys(user);
        }

        public void EnterLastName(string pass)
        {
            IWebElement password = webDriver.FindElement(By.Name("lastName"));
            password.SendKeys(pass);
        }

        public void EnterPostalCode(string postalCode)
        {
            IWebElement password = webDriver.FindElement(By.Name("postalCode"));
            password.SendKeys(postalCode);
        }

        public void ClickContinue()
        {
            IWebElement CartButton = webDriver.FindElement(By.Name("continue"));
            CartButton.Click();
        }
    }

}
