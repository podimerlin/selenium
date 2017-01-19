using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestMethod
{
    public class SeleniumTest
    {
        public static string seleniumFolder = "C:\\Users\\MerC\\Documents\\Codes\\selenium";

        public static void GoogleForSelenium_Firefox()
        {
            IWebDriver driver = new FirefoxDriver();
            GoogleForSelenium(driver);
        }

        public static void GoogleForSelenium_Chrome()
        {
            IWebDriver driver = new ChromeDriver(seleniumFolder);
            GoogleForSelenium(driver);
        }

        public static void GoogleForSelenium_Edge()
        {
            IWebDriver driver = new EdgeDriver(seleniumFolder);
            GoogleForSelenium(driver);
        }

        public static void GoogleForSelenium_InternetExplorer()
        {
            IWebDriver driver = new InternetExplorerDriver(seleniumFolder);
            GoogleForSelenium(driver);
        }

        public static void GoogleForSelenium(IWebDriver driver)
        {
            // Navigate to google
            driver.Navigate().GoToUrl("http://www.google.com");

            // Find the input field for the search query
            IWebElement inputField = driver.FindElement(By.Name("q"));

            // Add some text to the input field
            inputField.SendKeys("Selenium");

            // Submit the search
            inputField.Submit();

            // Google uses JS to render the results page so we need to wait
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(o => o.Title.StartsWith("Selenium", StringComparison.OrdinalIgnoreCase));

            // Use asserts like you would in unit tests
            Assert.IsTrue(driver.Title.StartsWith("Selenium", StringComparison.OrdinalIgnoreCase));

            // close down the browser
            driver.Quit();
        }

        public static void Main(string[] args)
        {
            GoogleForSelenium_Chrome();
            GoogleForSelenium_Edge();
        }
    }

}
