using Example.PageObjects;
using Example.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TestScripts
{
    internal class SearchProductAndAddToCart:CoreCodes
    {
        [Test, Category("End to End Testing"), Order(1)]
        public void SearchingAndAddToCartTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            test = extent.CreateTest("Add to cart test");


            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();


            var homePage = new TastyNibbleHomePage(driver);
            if (!driver.Url.Contains("https://www.tastynibbles.in/"))
            {
                driver.Navigate().GoToUrl("https://www.tastynibbles.in/");
            }

            Log.Information("Searching And Add To Cart Test Started");
            test.Info("Searching And Add To Cart Test Started");
            ScrollIntoView(driver, driver.FindElement(By.XPath("(//a[@href='/products/copy-of-samudra-sadhya-pack-1'])[1]")));
            var productPage = homePage.ClickBuyNowButton();
            Log.Information("Clicked on Buy Now Button on Home Page");
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("samudra-sadhya"));
                Log.Information("Product Page Loaded Successfully");
                test.Info("Product Page Loaded Successfully");
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(ss);

        
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Product Page. \n Exception: {ex.Message}");
                //test = extent.CreateTest("Product Page");

                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(ss);
                test.Info("Product Page Loading failed");
            }
            productPage.ClickAddtoCartButton();
            test.Info("Clicked on Add to cart Button");
            Log.Information("Clicked on Add to cart Button");
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("samudra-sadhya"));
                Log.Information("Product Added Successfully");
                test.Info("Product Added Successfully");
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(ss);
                test.Pass("Product Added Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Adding Product to Cart. \n Exception: {ex.Message}");
                test.Info("Product adding failed");
                test.Fail("Product Adding failed");
            }
        }
    }
}
