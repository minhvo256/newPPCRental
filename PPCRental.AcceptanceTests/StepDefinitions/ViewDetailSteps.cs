using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class US02_ViewDetailSteps
    {
        public IWebDriver _driver = new ChromeDriver();
        [Given(@"I am homepage")]
        public void GivenIAmHomepage()
        {
            _driver.Url = "http://localhost:2884/HomePage/Index";
          
        }
        
        [When(@"I click button detail")]
        public void WhenIClickButtonDetail()
        {
            _driver.FindElement(By.XPath("//*[@class = 'btn btn-default']")).Click();
        }
        
        [When(@"I ckick picture of project")]
        public void WhenICkickPictureOfProject()
        {
        _driver.FindElement(By.XPath("//*[1]/div[@class='posts-i-info']")).Click();
        }
        
        [When(@"I click infomation line")]
        public void WhenIClickInfomationLine()
        {
            _driver.FindElement(By.XPath("//*[1]/div[@class='posts-i-info']/a")).Click();
        }
        
        [Then(@"I see detail project")]
        public void ThenISeeDetailProject()
        {
            _driver.FindElement(By.XPath("//*[@class='prod-cont-txt']"));
            _driver.Close();
    }
        
        [Then(@"I see the detail project")]
        public void ThenISeeTheDetailProject()
        { 
            _driver.FindElement(By.XPath("//*[@class='prod-cont-txt']"));
            _driver.Close();
        }
    }
}
