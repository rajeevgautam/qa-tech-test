using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using qa_tech_test.PageObjects;
using Xunit;

namespace qa_tech_test
{
    using Xbehave;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;

    public class EcsArrayChallangeFeature
    {
        private IWebDriver driver = new EdgeDriver( Path.Combine(Environment.CurrentDirectory, @"..\..\EdgeDriver"));
        private ArrayChallengePage arrayChallengePage;

        [Background]
        public void BeforeScenario()
        {
            "Given browser is working"
                .x(() => arrayChallengePage = new ArrayChallengePage(driver))
                .Teardown(() => driver.Close());
        }

        [Scenario]
        public void ArrayChallenge()
        {
            "Given I am on the challenge home page"
                .x(() => arrayChallengePage.RenderToChallenge());

            "When I submit answers for array challenge"
                .x(() => arrayChallengePage.SubmitAnswers(""));

            "Then I get success message"
                .x(() => Assert.True(arrayChallengePage.VerifySuccessPopup()));

        }
    }
}