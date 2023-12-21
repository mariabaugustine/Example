using BDD.Hooks;
using BDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BDD.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions:CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;

        [When(@"User will type the '([^']*)' in the search box")]
        public void WhenUserWillTypeTheInTheSearchBox(string searchtext)
        {
            AllHooks.test = AllHooks.extent.CreateTest("Add to cart");

            IWebElement? searchInput = driver.FindElement(By.XPath("(//input[@class='site-header__search-input'])[position()=1]"));
            searchInput?.SendKeys(searchtext);
            Log.Information("Typed search text " + searchtext);
            AllHooks.test.Info("Typed search text " + searchtext);
            searchInput?.SendKeys(Keys.Enter);
        }

        [Then(@"The Title should have '([^']*)'")]
        public void ThenTheTitleShouldHave(string searchtext)
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Title, Does.Contain(searchtext));

                AllHooks.test.Info("Title Test Success");

                //Write below "LogTestResult" only at last try block
                LogTestResult("Add to cart", "Add to cart Test success");
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(ss);

            }
            catch (AssertionException ex)
            {
                LogTestResult("Title Test", "Title Test Failed", ex.Message);
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(ss);
                AllHooks.test.Info("Title Test Failed");
            }
        }
    }
}
