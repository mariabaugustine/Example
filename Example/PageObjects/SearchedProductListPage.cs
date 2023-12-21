using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.PageObjects
{
    internal class SearchedProductListPage
    {
        IWebDriver? driver;
        public SearchedProductListPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'new-grid search-grid')]//following::div[contains(@data-product-handle,'ghee-rice-250g')])[position()=1]")]
        private IWebElement? GheeRice { get; set; }

        public ProductPage ClickGheeRice()
        {
            GheeRice?.Click();
            return new ProductPage(driver);
        }
        
    }
}
