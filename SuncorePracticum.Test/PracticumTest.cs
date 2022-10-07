using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using SuncorePracticum.WedPages;
using SuncorePracticum.Utilities;

namespace SuncorePracticum
{


    [TestClass]
    public class PracticumTest
    {
        IWebDriver webDriver;

        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }

        [TestInitialize]
        public void InitailSetup()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            webDriver = new ChromeDriver(@"C:\Github\SuncorePracticum\SuncorePracticum.Test\TestData\", chromeOptions);

            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            webDriver.Manage().Window.Maximize();
            WebDriverWait waitForControl = new WebDriverWait(webDriver, TimeSpan.FromSeconds(100));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem(@"testdata\data.csv"), TestMethod]
        public void Scenario1()
        {
            string userName = TestContext.DataRow["UserName"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            Console.WriteLine($"Testing login for {userName}");
            LoginPage login = new LoginPage(webDriver);
            WebUtilities webutil = new WebUtilities(webDriver);
            DashBoardPage dashboard = new DashBoardPage(webDriver);

            login.enterUsername(userName);
            login.enterPassword(password);
            login.ClickLogIn();

            webutil.WaitFortheControl(60);

            string heading = dashboard.GetHeading();
            Console.WriteLine(heading);
            Assert.AreEqual("PRODUCTS", heading, "LogIn Successfull.");
        }



        [TestMethod]
        public void Scenario2()
        {
            LoginPage login = new LoginPage(webDriver);
            WebUtilities webutil = new WebUtilities(webDriver);
            DashBoardPage dashboard = new DashBoardPage(webDriver);
            PurchasePage purchase = new PurchasePage(webDriver);

            CheckoutPage checkout = new CheckoutPage(webDriver);
            CheckoutOverViewPage checkoutover = new CheckoutOverViewPage(webDriver);
            OrderCompletePage completePage = new OrderCompletePage(webDriver);

            login.enterUsername("standard_user");
            login.enterPassword("secret_sauce");
            login.ClickLogIn();

            webutil.WaitFortheControl(60);

            string title = dashboard.GetHeading();
            Assert.AreEqual("PRODUCTS", title, "LogIn Successfull.");

            webutil.WaitFortheControl(60);

            dashboard.AddItemsToThecart(new string[] { "Sauce Labs Onesie", "Sauce Labs Bike Light" });

            Assert.IsTrue(dashboard.VerifyThatItemAddedToCart("Sauce Labs Onesie"));
            Assert.IsTrue(dashboard.VerifyThatItemAddedToCart("Sauce Labs Bike Light"));
            dashboard.ClickCartIcon();

            title = purchase.GetTitle();
            Assert.AreEqual("YOUR CART", title, "Selected items are not added to cart.");

            purchase.ClickCheckout();

            title = checkout.GetTitle();
            Assert.AreEqual("CHECKOUT: YOUR INFORMATION", title, "Selected items are not added to cart.");

            checkout.EnterFirstName("Satya");
            checkout.EnterLastName("Kukkala");
            checkout.EnterPostalCode("T2Z 0R8");
            checkout.ClickContinue();

            title = checkoutover.GetTitle();
            Assert.AreEqual("CHECKOUT: OVERVIEW", title, "Customer information is not able to added.");

            checkoutover.ClickFinish();

            title = completePage.GetTitle();
            Assert.AreEqual("CHECKOUT: COMPLETE!", title, "Order is not completed.");

        }

        [TestMethod]
        public void Scenario3()
        {
            string path = @"C:\Github\SuncorePracticum\SuncorePracticum.Test\TestData\Items.csv";
            Console.WriteLine(Environment.CurrentDirectory);
            LoginPage login = new LoginPage(webDriver);
            WebUtilities webutil = new WebUtilities(webDriver);
            DashBoardPage dashboard = new DashBoardPage(webDriver);
            PurchasePage purchase = new PurchasePage(webDriver);

            CheckoutPage checkout = new CheckoutPage(webDriver);
            CheckoutOverViewPage checkoutover = new CheckoutOverViewPage(webDriver);
            OrderCompletePage completePage = new OrderCompletePage(webDriver);

            login.enterUsername("standard_user");
            login.enterPassword("secret_sauce");
            login.ClickLogIn();

            webutil.WaitFortheControl(60);

            string heading = dashboard.GetHeading();
            Assert.AreEqual("PRODUCTS", heading, "LogIn Successfull.");

            webutil.WaitFortheControl(60);

            string[] ItemsCollection = webutil.ReadCSVFile(path).ToArray();
            dashboard.AddItemsToThecart(ItemsCollection);

            foreach(string ItemToVerify in ItemsCollection)
            {
                Assert.IsTrue(dashboard.VerifyThatItemAddedToCart(ItemToVerify));
            }

            dashboard.ClickCartIcon();

            string title = purchase.GetTitle();
            Assert.AreEqual("YOUR CART", title, "Selected items are not added to cart.");

            purchase.ClickCheckout();

            title = checkout.GetTitle();
            Assert.AreEqual("CHECKOUT: YOUR INFORMATION", title, "Selected items are not added to cart.");

            webutil.WaitFortheControl(60);

            checkout.EnterFirstName("Satya");
            checkout.EnterLastName("Kukkala");
            checkout.EnterPostalCode("T2Z 0R8");
            checkout.ClickContinue();

            webutil.WaitFortheControl(60);

            title = checkoutover.GetTitle();
            Assert.AreEqual("CHECKOUT: OVERVIEW", title, "Customer information is not able to added.");

            checkoutover.ClickFinish();


            title = completePage.GetTitle();
            Assert.AreEqual("CHECKOUT: COMPLETE!", title, "Order is not completed.");

        }

        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Quit();
        }
    }
}