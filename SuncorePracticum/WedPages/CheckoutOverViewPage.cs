using System;
using OpenQA.Selenium;

namespace SuncorePracticum.WedPages
{

    public class CheckoutOverViewPage
    {
        IWebDriver webDriver;
        public CheckoutOverViewPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public string GetTitle()
        {
            string title = webDriver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span")).Text;
            return title;
        }

        public void ClickFinish()
        {
            IWebElement CartButton = webDriver.FindElement(By.Name("finish"));
            CartButton.Click();
        }
    }
}
