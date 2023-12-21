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
    internal class ProductPage
    {
       
        IWebDriver? driver;

        public ProductPage(IWebDriver? driver)

        {

            this.driver = driver ?? throw new ArgumentException(nameof(driver));

            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//label[@class='variant__button-label' and text()='Pack 1']")]

        private IWebElement? Size { get; set; }

        [FindsBy(How = How.Name, Using = "add")]

        private IWebElement? AddtoCartButton { get; set; }


        [FindsBy(How = How.Name, Using = "checkout")]

        private IWebElement? CheckOutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"HeaderCart\"]/div/form/div[1]/div[1]/div/div/div[2]/div[2]/div[1]/div[1]/button[1]/svg")]

        private IWebElement? Remove { get; set; }

        public void ClickSize()

        {

            Size?.Click();

        }

        public void ClickAddtoCartButton()

        {

            AddtoCartButton?.Click();

        }

        public PaymentPage ClickCheckoutButton()

        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            CheckOutButton?.Click();

            return new PaymentPage(driver);

        }

        public void ClickRemove()

        {

            Remove?.Click();

        }
    }
}
