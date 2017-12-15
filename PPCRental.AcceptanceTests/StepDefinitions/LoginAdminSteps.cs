using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;



namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class US03_LoginAdminSteps
    {
        public IWebDriver _driver = new ChromeDriver();
        [Given(@"I am loginpage")]
        public void GivenIAmLoginpage()
        {
            _driver.Url = "http://localhost:2884/Admin/Login";
        }
        
        [When(@"I input account and click button Login")]
        public void WhenIInputAccountAndClickButtonLogin()
        {
            _driver.FindElement(By.Id("username")).SendKeys("admin");
            _driver.FindElement(By.Id("password")).SendKeys("admin");
            _driver.FindElement(By.XPath("//*[@class='btn btn-lg btn-success btn-block']")).Click();
        }
        
        [When(@"I input invalid account and click button Login")]
        public void WhenIInputInvalidAccountAndClickButtonLogin()
        {
            _driver.FindElement(By.Id("username")).SendKeys("admin");
            _driver.FindElement(By.Id("password")).SendKeys("123456");
            _driver.FindElement(By.XPath("//*[@class='btn btn-lg btn-success btn-block']")).Click();
        }
        
        [When(@"I input only username and click button Login")]
        public void WhenIInputOnlyUsernameAndClickButtonLogin()
        {
            _driver.FindElement(By.Id("username")).SendKeys("admin");
            _driver.FindElement(By.Id("password")).SendKeys("");
            _driver.FindElement(By.XPath("//*[@class='btn btn-lg btn-success btn-block']")).Click();
        }
        
        [Then(@"I am admin page")]
        public void ThenIAmAdminPage()
        {
            _driver.FindElement(By.XPath("//*[@id='page-wrapper']"));
            _driver.Close();
        }
        
        [Then(@"I see the red line:Account does not exist")]
        public void ThenISeeTheRedLineAccountDoesNotExist()
        {
            _driver.FindElement(By.XPath("//*[@class='validation-summary-errors alert alert-danger']"));
            _driver.Close();
        }
    }
}
