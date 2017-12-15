using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Linq;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class US05_RegistrationAccountStepsSteps
    {
        public IWebDriver _driver = new ChromeDriver();
        [Given(@"I am at home page")]
        public void GivenIAmAtHomePage()
        {
            _driver.Url = "http://localhost:2884/HomePage/Index";
        }
        
        [Given(@"I click registration button")]
        public void GivenIClickRegistrationButton()
        {
            _driver.FindElement(By.XPath("//*[@class='shop-menu-ttl']")).Click();
        }
        
        [When(@"I input full valid informatinon")]
        public void WhenIInputFullValidInformatinon()
        {
            _driver.FindElement(By.Id("Email")).SendKeys("testtesttesttest@vanlanguni.vn");
            _driver.FindElement(By.Id("Password")).SendKeys("123456");
            _driver.FindElement(By.Id("FullName")).SendKeys("Duy Khau");
            _driver.FindElement(By.Id("Phone")).SendKeys("01889310481");
            _driver.FindElement(By.Id("Address")).SendKeys("HCM");
        }

        [When(@"i click button register")]
        public void WhenIClickButtonRegister()
        {
            _driver.FindElement(By.XPath("//*[@class='btn btn-default']")).Click();
        }
        
        [When(@"I input one or full empty informatinon")]
        public void WhenIInputOneOrFullEmptyInformatinon()
        {
            _driver.FindElement(By.Id("Email")).SendKeys("admin");
            _driver.FindElement(By.Id("Password")).SendKeys("");
            _driver.FindElement(By.Id("FullName")).SendKeys("");
            _driver.FindElement(By.Id("Phone")).SendKeys("");
            _driver.FindElement(By.Id("Address")).SendKeys("");
        }
        
        [When(@"i click buuton register")]
        public void WhenIClickBuutonRegister()
        {
            _driver.FindElement(By.XPath("//*[@class='btn btn-default']")).Click();
        }
        
        [When(@"I inputemail exist")]
        public void WhenIInputemailExist()
        {
            _driver.FindElement(By.Id("Email")).SendKeys("lythihuyenchau@gmail.com");
            _driver.FindElement(By.Id("Password")).SendKeys("123456");
            _driver.FindElement(By.Id("FullName")).SendKeys("AdminAdmin");
            _driver.FindElement(By.Id("Phone")).SendKeys("123456");
            _driver.FindElement(By.Id("Address")).SendKeys("admin");
        }
        
        [Then(@"I see message Successful Register")]
        public void ThenISeeMessageSuccessfulRegister()
        {
            _driver.FindElement(By.ClassName(" label-success"));
            _driver.Close();
        }

        [Then(@"I see message This field is required at empty informatinon")]
        public void ThenISeeMessageThisFieldIsRequiredAtEmptyInformatinon()
        {
            _driver.FindElement(By.XPath("//*[@class='text-danger field-validation-error']"));
            _driver.Close();
        }


        [Then(@"I see message Email already exist")]
        public void ThenISeeMessageEmailAlreadyExist()
        {
            _driver.FindElement(By.ClassName(" label-danger"));
            _driver.Close();
        }
    }
}
