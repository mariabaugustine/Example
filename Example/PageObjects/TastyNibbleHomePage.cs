using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Example.PageObjects
{
    internal class TastyNibbleHomePage
    {
        IWebDriver? driver;

        public TastyNibbleHomePage(IWebDriver? driver)

        {

            this.driver = driver ?? throw new ArgumentException(nameof(driver));

            PageFactory.InitElements(driver, this);

        }

        //Arrange

        [FindsBy(How = How.XPath, Using = "(//input[@class='site-header__search-input'])[position()=1]")]

        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[position()=1]")]

        private IWebElement? SearchButton { get; set; }


        [FindsBy(How = How.XPath, Using = "(//a[@href='/products/copy-of-samudra-sadhya-pack-1'])[1]")]

        private IWebElement? BuyNowButton { get; set; }

        //Act

        public void ClickSearchInput(string searchinput)

        {

            SearchInput?.SendKeys(searchinput);

        }

        public SearchedProductListPage ClickSearchButton()

        {

            SearchButton?.Click();

            return new SearchedProductListPage(driver);

        }

        public ProductPage ClickBuyNowButton()

        {

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", BuyNowButton);

            return new ProductPage(driver);

        }
    }
}
