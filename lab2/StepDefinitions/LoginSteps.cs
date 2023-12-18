using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace YourProjectNamespace
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        public int num;

        public LoginSteps()
        {
            // Ініціалізуємо драйвер у конструкторі
            driver = new ChromeDriver(); // Ви можете вибрати інший драйвер за потребою
            loginPage = new LoginPage(driver);
            num = 0;
        }

        [Given(@"I am on the banking website")]
        public void GivenIAmOnTheBankingWebsite()
        {
            loginPage.OpenLoginPage("https://www.globalsqa.com/angularJs-protractor/BankingProject"); // Замініть URL на реальний URL вашого веб-сайту
        }

        [When(@"I select ""Login as Bank Manager"" option")]
        public void WhenISelectLoginAsBankManagerOption()
        {
            loginPage.ClickLoginAsBankManager();
        }

        [Then(@"I click ""Add Customer""")]
        public void AddCustomer()
        {
            loginPage.clickAddCustomer();
        }

        [Then(@"I enter data about person and add customer")]
        public void EnterCustomers()
        {
            loginPage.enterCustomer("John", "Peterson", "E44566");
        }

        [Then(@"I click OK on alert")]
        public void ClickOKAlert()
        {
            string res = loginPage.clickOk();
            Assert.AreEqual(res, "Customer added successfully with customer id :6", "No match with alert msg");
        }

        [When(@"I click ""Customers""")]
        public void ClickCustomers() {
            loginPage.ClickCustomers();
        }

        [Then(@"I should see a newly added person")]
        public void checkFirstPerson()
        {
            List<IWebElement> res = loginPage.checkNewlyAddedPerson(out num);
            Assert.AreEqual(res[0].Text, "John","First names don't match");
            Assert.AreEqual(res[1].Text, "Peterson", "Last names don't match");
            Assert.AreEqual(res[2].Text, "E44566", "Postcodes don't match");
            Assert.AreEqual(res[3].Text, "", "Account numbers don't match");
        }

        [Then(@"I click ""Add Customer"" once more")]
        public void AddCustomerAgain()
        {
            loginPage.clickAddCustomer();
        }

        [Then(@"I enter data about the same person and click ""add customer""")]
        public void EnterSecondCustomer()
        {
            loginPage.enterCustomer("John", "Peterson", "E44566");
        }

        [Then(@"I should see alert that it's duplicate")]
        public void ClickOKAlertWithDuplicate()
        {
            string res = loginPage.clickOk();
            Assert.AreEqual(res, "Please check the details. Customer may be duplicate.", "No match with alert msg");
        }

        [When(@"I click ""Customers"" again")]
        public void ClickCustomersAgain()
        {
            loginPage.ClickCustomers();
        }

        [Then(@"I shouldn't see duplicate")]
        public void checkSecondPerson()
        {
            int n = loginPage.checkCountCustomers();
            Assert.AreEqual(n, num, "Duplicate is added");
        }

        [Then(@"I should close Chrome")]
        public void CloseChrome()
        {
            loginPage.CloseDriver();
        }
    }
}
