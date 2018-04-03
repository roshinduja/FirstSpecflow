using com.Aviva.Assessment.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace com.Aviva.Assessment.PageObjects
{
    class GoogleHomePage : CommonFunctions

    {
        // Initializing driver object using InitElements method of PageFactory class
        public GoogleHomePage()
        {
            PageFactory.InitElements(CommonFunctions.driver, this);
        }

        // Identifying elements using Page Factory annotations
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement Searchbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Google Search']")]
        public IWebElement searchbutton { get; set; }

        // Enter search text
        public void EnterSearchText(string key)
        {
            SendValue(Searchbox, key);
            Console.WriteLine("Entered text is " + key);
        }

        // Click on Googlesearch button
        public void ClickSearchButton()
        {
            SubmitElement(searchbutton);
        }

        // Asserting if the user is on google homepage
        public void Asserting()
        {
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Assertion successful, user is on Google Homepage");
        }
    }
}
