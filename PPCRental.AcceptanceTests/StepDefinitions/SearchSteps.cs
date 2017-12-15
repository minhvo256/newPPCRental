using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
     public class SearchSteps
    {
        public IWebDriver _driver = new ChromeDriver();
        [Given(@"I access to PPC Rental Website")]
        public void GivenIAccessToPPCRentalWebsite()
        {
            _driver.Url = "http://localhost:2884/HomePage/Index";
        }

        [Given(@"I press search button")]
        public void GivenIPressSearchButton()
        {
            _driver.FindElement(By.XPath("//*[@id='topsearch-btn']")).Click();
        }

        [When(@"I search for projects by the keyword '(.*)'")]
        public void WhenISearchForProjectsByTheKeyword(string p0)
        {
            _driver.FindElement(By.Id("ha")).SendKeys("Top");
            _driver.FindElement(By.XPath("//*[@id='he']")).Click();
        }

        [Then(@"the list of found projects should contain only: '(.*)'")]
        public void ThenTheListOfFoundProjectsShouldContainOnly(string p0)
        {
            _driver.FindElement(By.XPath("/html/body/main/main/section/div[2]/div/div/div/h1")).Text.Contains("Top");
            _driver.Close();
        }
        [When(@"I search for projects by the name '(.*)'")]
        public void WhenISearchForProjectsByTheName(string p0)
        {
            _driver.FindElement(By.XPath("//*[@id='ha']")).SendKeys("nm");
            _driver.FindElement(By.XPath("//*[@id='he']")).Click();
        }

        [Then(@"note : '(.*)'")]
        public void ThenNote(string p0)
        {
            _driver.FindElement(By.XPath("/html/body/main/main/section/div[2]/p")).Text.CompareTo("No Property found");
            _driver.Close();
        }


    }
}
