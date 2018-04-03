using com.Aviva.Assessment.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Aviva.Assessment.PageObjects
{
    class SearchResultsPage : CommonFunctions
        {

             

        // Method to assert & highlight the aviva keyword displayed on the search results page
            public void AssertResults(string keyword, string expectedText)
            {
                IWebElement avivaText = CommonFunctions.driver.FindElement(By.XPath("//span[text() = '" + keyword + "']"));
                string actualText = avivaText.Text;
                Console.WriteLine("Actual text is " +actualText);
                Assert.IsTrue(actualText.Contains(expectedText));
                Console.WriteLine("Aviva search results are displayed");
                Highlight(avivaText);
            }

        // Method to verify & print the all links displayed on the search results page and fetch the 5th one
            public void VerifyLink(string keyword)
            {
              IList<IWebElement> links = CommonFunctions.driver.FindElements(By.XPath("//a[contains(text(),'" + keyword + "')]"));
              Wait(10);            
                Console.WriteLine("Results Obtained are:");
                foreach (IWebElement link in links)
                {
                    Console.WriteLine(link.Text);
                }
                
                Console.WriteLine("5th Link: " + links.ElementAt(4).Text);                
            }

        // Method to get error message while searching for invalid data
           public void GetErrorText(string keyword)
        {
            
            IWebElement errorMessage = CommonFunctions.driver.FindElement(By.XPath("//*[text() = '" + keyword + "']/parent::p[1]"));
            if (errorMessage.Displayed)
            {
                Console.WriteLine(errorMessage.Text);
            }
            Highlight(errorMessage);
            }
                
     }
}
