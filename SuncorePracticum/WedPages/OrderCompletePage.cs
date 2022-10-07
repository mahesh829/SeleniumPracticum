using System;
using OpenQA.Selenium;

namespace SuncorePracticum.WedPages
{
    public class OrderCompletePage
    {
        IWebDriver webDriver;
        public OrderCompletePage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public string GetTitle()
        {
            string title = webDriver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span")).Text;
            return title;
        }
    }
}
