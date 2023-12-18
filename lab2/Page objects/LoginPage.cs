using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq.Expressions;
using System.Threading;

public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    // Метод для відкриття сторінки в браузері
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для вибору опції "Login as Bank Manager"
    public void ClickLoginAsBankManager()
    {
        // Знайдіть елемент кнопки "Bank Manager Login" за допомогою селектора і натисніть на неї
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='Bank Manager Login']")));
        loginButton.Click();
    }

    public void clickAddCustomer()
    {
        IWebElement addcustomer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[contains(text(),'Add Customer')]")));
        addcustomer.Click();
    }

    public void ClickCustomers()
    {
        IWebElement customers = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[contains(text(),'Customers')]")));
        customers.Click();
    }

    public void enterCustomer(string firstname, string lastname, string postcode)
    {
        //searchInput.Clear();
        Thread.Sleep(1000);
        IWebElement firstNameInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//input[@placeholder='First Name']")));
        firstNameInput.SendKeys(firstname);
        IWebElement lastNameInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//input[@placeholder='Last Name']")));
        lastNameInput.SendKeys(lastname);
        IWebElement postCodeInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//input[@placeholder='Post Code']")));
        postCodeInput.SendKeys(postcode);
        IWebElement addCustomer = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[@type='submit']")));
        Thread.Sleep(3000);
        addCustomer.Click();
    }
    public List<IWebElement> checkNewlyAddedPerson(out int n)
    {
        Thread.Sleep(3000);
        IList<IWebElement> customers = driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
        IWebElement person = customers[customers.Count - 1];
        n = customers.Count;
        return person.FindElements(By.TagName("td")).ToList<IWebElement>();
    }

    public string clickOk()
    {
        Thread.Sleep(3000);
        IAlert alert = driver.SwitchTo().Alert();
        string res = alert.Text;
        alert.Accept();
        return res;
    }

    public int checkCountCustomers()
    {
        Thread.Sleep(3000);
        return driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).Count;
    }

    public void CloseDriver()
    {
        driver.Quit();
    }

}
