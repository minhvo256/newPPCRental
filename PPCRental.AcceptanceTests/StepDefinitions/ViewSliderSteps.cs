using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class US04_ViewSliderSteps
    {
        public IWebDriver _driver = new ChromeDriver();
        [Given(@"Homepage")]
        public void GivenHomepage()
        {
            _driver.Url = "http://localhost:2884/HomePage/Index";
        }
        
        [When(@"I")]
        public void WhenI()
        {
            _driver.Url = "http://localhost:2884/HomePage/Index";
        }
        
        [When(@"I click slider i want see")]
        public void WhenIClickSliderIWantSee()
        { 
           _driver.FindElement(By.XPath("//*[@class='carousel-control-prev-icon']")).Click();
        }
        
        [Then(@"I see first slider")]
        public void ThenISeeFirstSlider()
        {
            //fix. 
            
        _driver.FindElement(By.XPath("//*[@class='carousel-inner']"));
        _driver.Close();
        }
        
        [Then(@"I see this sider")]
        public void ThenISeeThisSider()
        {
            //fix. 
            _driver.FindElement(By.XPath("//*[@class='carousel-inner']"));
            _driver.Close();
          
        }
    }
}
