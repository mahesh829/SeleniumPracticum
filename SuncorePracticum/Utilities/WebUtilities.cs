using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace SuncorePracticum.Utilities
{
    public class WebUtilities
    {
        IWebDriver webDriver;
        public WebUtilities(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public void WaitFortheControl(int waitTime)
        {
            WebDriverWait enterMail = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTime));
        }

        public List<string> ReadCSVFile(string path)
        {
            var itemlist = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.Contains("Items"))
                    {
                        continue;
                    }
                    var values = line.Split(',');
                    itemlist.Add(values[0]);
                }
            }
            return itemlist;
        }


    }

}
