using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;

namespace com.Aviva.Assessment.Utilities
{
    public class CommonFunctions
    {
        // Getting browser instance and initiating the driver
        public static IWebDriver driver;
        public static void GetBrowserInstance(string browser)
        {
            if (browser.Equals("Chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browser.Equals("IE"))
            {
                driver = new InternetExplorerDriver();
            }
            else if (browser.Equals("FF"))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                Console.WriteLine("Driver is not initialized");
            }

            driver.Manage().Window.Maximize();
        }


        // Wait operation
        public void Wait(int timeseconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeseconds));
        }


        // Navigate to the URL (Here URL is set in app.config)
        public void GotoURL()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
        }

        // Method for Submit operation          
        public void SubmitElement(IWebElement element)
        {
            element.Submit();
        }


        // Method for SendKeys operation
        public void SendValue(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        // Method to highlight element during assertions
        public void Highlight(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)driver;
            var field = element;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { field });
        }

        // Method to capture screenshot and save it in the specified folder
        public void TakeScreenshot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }

        // Method to close the browser session
        public void closeSession()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
