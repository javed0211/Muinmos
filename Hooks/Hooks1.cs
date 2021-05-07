using SNOW.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SNOW.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("driver").Close();
        }
    }
}
