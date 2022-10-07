using OpenQA.Selenium;

namespace SuncorePracticum.WedPages
{

    public class DashBoardPage
    {
        IWebDriver webDriver;
        public DashBoardPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }


        public string GetHeading()
        {
            string head = webDriver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span")).Text;
            return head;
        }

        public void AddItemsToThecart(string[] Items)
        {
            string itemName = "";
            foreach (string Item in Items)
            {
                switch (Item)
                {
                    case "Sauce Labs Backpack":
                        itemName = "add-to-cart-sauce-labs-backpack";
                        break;
                    case "Sauce Labs Bike Light":
                        itemName = "add-to-cart-sauce-labs-bike-light";
                        break;
                    case "Sauce Labs Bolt T-Shirt":
                        itemName = "add-to-cart-sauce-labs-bolt-t-shirt";
                        break;
                    case "Sauce Labs Fleece Jacket":
                        itemName = "add-to-cart-sauce-labs-fleece-jacket";
                        break;
                    case "Sauce Labs Onesie":
                        itemName = "add-to-cart-sauce-labs-onesie";
                        break;
                }
                IWebElement addToCart = webDriver.FindElement(By.Name(itemName));
                addToCart.Click();
            }
        }

        public bool VerifyThatItemAddedToCart(string Item)
        {
             string itemName = "";
            switch (Item)
                {
                    case "Sauce Labs Backpack":
                        itemName = "remove-sauce-labs-backpack";
                        break;
                    case "Sauce Labs Bike Light":
                        itemName = "remove-sauce-labs-bike-light";
                        break;
                    case "Sauce Labs Bolt T-Shirt":
                        itemName = "remove-sauce-labs-bolt-t-shirt";
                        break;
                    case "Sauce Labs Fleece Jacket":
                        itemName = "remove-sauce-labs-fleece-jacket";
                        break;
                    case "Sauce Labs Onesie":
                        itemName = "remove-sauce-labs-onesie";
                        break;
                }
                string text = webDriver.FindElement(By.Name(itemName)).Text;
                return text == "REMOVE";
        }


        public void RemoveItemsFromcart(string[] Items)
        {
            string itemName = "";
            foreach (string Item in Items)
            {
                switch (Item)
                {
                    case "Sauce Labs Backpack":
                        itemName = "remove-sauce-labs-backpack";
                        break;
                    case "Sauce Labs Bike Light":
                        itemName = "remove-sauce-labs-bike-light";
                        break;
                    case "Sauce Labs Bolt T-Shirt":
                        itemName = "remove-sauce-labs-bolt-t-shirt";
                        break;
                    case "Sauce Labs Fleece Jacket":
                        itemName = "remove-sauce-labs-fleece-jacket";
                        break;
                    case "Sauce Labs Onesie":
                        itemName = "remove-sauce-labs-onesie";
                        break;
                }
                IWebElement removeCart = webDriver.FindElement(By.Name(itemName));
                removeCart.Click();
            }
        }

        public void ClickCartIcon()
        {
            IWebElement CartButton = webDriver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a"));
            CartButton.Click();
        }

    }

    }
