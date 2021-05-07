using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SNOW.Steps;
using AutomationLib;

namespace SNOW.Steps
{
    [Binding]
    public sealed class IncidentManagementSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public IncidentManagementSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on '(.*)' portal")]
        public void GivenIAmOnPortal(string portal)
        {
            BaseSteps baseSteps = new BaseSteps(_scenarioContext);
            baseSteps.InitWebDriver();
            Uri URL = new Uri("https://self-signed.badssl.com/");
            _scenarioContext.Get<WebDriverPlant>("driver").OnlineLogin.Login(URL);
            
        }

        [When(@"I impersonate as '(.*)' with '(.*)' user")]
        public void WhenIImpersonateAsWithUser(string role, string user)
        {
            BaseSteps.Snow.Configurations.ImpersonateUser(user);
        }

        [When(@"I click on '(.*)' from application tree")]
        public void WhenIClickOnFromApplicationTree(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select (.*)")]
        public void WhenISelect(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter Incident details")]
        public void WhenIEnterIncidentDetails()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I submit the changes")]
        public void WhenISubmitTheChanges()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
