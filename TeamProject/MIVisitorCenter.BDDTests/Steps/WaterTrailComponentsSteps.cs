using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MIVisitorCenter.BDDTests.Steps
{
    [Binding]
    public sealed class WaterTrailComponentsSteps
    {
        private readonly ScenarioContext _ctx;
        private string _hostBaseName = @"https://localhost:5001/";
        private readonly IWebDriver _driver;


        public WaterTrailComponentsSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _ctx = scenarioContext;
            _driver = driver;

        }

        // -------------------------- GIVEN -------------------------

        [Given(@"I am on the '(.*)' page")]
        public void WhenIAmOnThePage(string pageName)
        {
            if (pageName.Equals("Home"))
            {
                _driver.Navigate().GoToUrl(_hostBaseName);
            }
            else
            {
                ScenarioContext.StepIsPending();
            }
        }

        // -------------------------- THEN -------------------------

        [Then(@"I will not see a link to the Manage Page in the navbar")]
        public void ThenIWillNotSeeALinkToTheManagePageInTheNavbar()
        {
            IEnumerable<string> navLinks = _driver.FindElement(By.ClassName("uk-nav"))
                            .FindElements(By.TagName("li"))
                            .Select(n => n.Text);
            
            foreach (string str in navLinks)
            {
                 Assert.That(str != "Manage Website Content");
            }
        }

    }
}