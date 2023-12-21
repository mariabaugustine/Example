using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.PageObjects
{
    internal class PaymentPage
    {
        IWebDriver? driver;
        public PaymentPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement? ContactInput { get; set; }

        public void ClickContactInput(string email)
        {
            ContactInput?.SendKeys(email);
            ContactInput?.SendKeys(Keys.Enter);
        }

        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement? FirstName { get; set; }

        public void ClickFirstNameInput(string firstName)
        {
            FirstName?.SendKeys(firstName);
            FirstName?.SendKeys(Keys.Enter);
        }

        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement? LastName { get; set; }
        public void ClickLastNameInput(string lastName)
        {
            LastName?.SendKeys(lastName);
            LastName?.SendKeys(Keys.Enter);
        }

        [FindsBy(How = How.Name, Using = "address1")]
        private IWebElement? Address { get; set; }

        public void ClickAddressInput(string address)
        {
            Address?.SendKeys(address);
            Address?.SendKeys(Keys.Enter);
        }

        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement? City { get; set; }

        public void ClickCityInput(string city)
        {
            City?.SendKeys(city);
            City?.SendKeys(Keys.Enter);
        }
        [FindsBy(How = How.Id, Using = "Select1")]
        private IWebElement? StateDropdown { get; set; }

        public void ClickStateDropdown()
        {
            StateDropdown?.Click();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Select1\"]/option[17]")]
        private IWebElement? ParticularState { get; set; }

        public void ClickParticularState()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ParticularState?.Click();
        }

        [FindsBy(How = How.Name, Using = "postalCode")]
        private IWebElement? Pincode { get; set; }

        public void ClickPincodeInput(string pincode)
        {
            Pincode?.SendKeys(pincode);
            Pincode?.SendKeys(Keys.Enter);
        }

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement? PhoneNumber { get; set; }

        public void ClickPhoneNumberInput(string phoneNumber)
        {
            PhoneNumber?.SendKeys(phoneNumber);
            PhoneNumber?.SendKeys(Keys.Enter);
        }
    }
}
