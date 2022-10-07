using OpenQA.Selenium;

namespace SuncorePracticum.WedPages
{
    public class LoginPage
    {
        IWebDriver webDriver;
        public LoginPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }


        public void enterUsername(string user)
        {
            IWebElement userName = webDriver.FindElement(By.Id("user-name"));
            userName.SendKeys(user);
        }

        //Method to enter password
        public void enterPassword(string pass)
        {
            IWebElement password = webDriver.FindElement(By.Id("password"));
            password.SendKeys(pass);
        }

        public void ClickLogIn()
        {
            IWebElement loginClick = webDriver.FindElement(By.Id("login-button"));
            loginClick.Click();
        }

    }
}
