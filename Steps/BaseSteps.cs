using AutomationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SNOW.Steps
{
    public class BaseSteps
    {
        public static WebDriverPlant Snow;
        private readonly ScenarioContext _scenarioContext;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public void InitWebDriver()
        {
            var client = new WebClient(TestSettings.Options);
            Snow = new WebDriverPlant(client);
            _scenarioContext["driver"] = Snow;
        }

    }
}
