using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using qa_tech_test.Utils;


namespace qa_tech_test.PageObjects
{
    class ArrayChallengePage
    {
        String test_url = "http://localhost:3000";

        private IWebDriver driver;
        private WebDriverWait wait;

        public ArrayChallengePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }


        private IWebElement RenderChallengeButton
        {
            get
            {
                return this.driver.FindElement(By.Id("renderChallengeButton"));
            }
        }

        private IWebElement SubmitAnswerButton
        {
            get
            {
                return this.driver.FindElement(By.Id("submitAnswerButton"));
            }
        }

        private IWebElement SubmitAnswerText(int number) 
        {
            return this.driver.FindElement(By.Id(string.Format("submitAnswer{0}Text",number )));
            
        }


        private IReadOnlyCollection<IWebElement> ChallengeTableRows
        {
            get
            {
                return this.driver.FindElements(By.Name("challengeTableRow"));
            }
        }
       

        private IWebElement PopupElement
        {
            get{
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                
                return this.driver.FindElement(By.ClassName("dialog")); 
            }
        }

        private List<int>[] ReadChallegeRows()
        {
            List<int>[] challengeArrays = new List<int>[ChallengeTableRows.Count];
            int challengeNumber = 0;
            foreach (IWebElement row in ChallengeTableRows)
            {
                challengeArrays[challengeNumber] = new List<int>();
                IReadOnlyCollection<IWebElement> tableElements = row.FindElements(By.TagName("td"));

                foreach (IWebElement tableDate in tableElements)
                {
                    challengeArrays[challengeNumber].Add(Convert.ToInt32(tableDate.Text));

                }

                challengeNumber++;
            }

            return challengeArrays;

        }



        // Go to the designated page
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        // Returns the Page Title
        public String GetPageTitle()
        {
            return driver.Title;
        }

        public void SubmitAnswers(String username ="TestUser")
        {
            List<int>[] challengeArrays = ReadChallegeRows();
            for (int arrayIndex = 0; arrayIndex < challengeArrays.Length; arrayIndex++)
            {
                SubmitAnswerText(arrayIndex+1).SendKeys(ArrayIndexUtils.GetIndexWhereArrayIsBalanced(challengeArrays[arrayIndex].ToArray())?.ToString());
            }

            SubmitAnswerText(challengeArrays.Length + 1).SendKeys(username);
            SubmitAnswerButton.Click();
        }

        
        public void RenderToChallenge()
        {
            this.GoToPage();
            this.RenderChallengeButton.Click();
        }

        public bool VerifySuccessPopup()
        {
            wait.Until(d => PopupElement.Text.Contains("Congratulations"));
            Console.Write(PopupElement.Text);
            return PopupElement.Text.Contains("Congratulations you have succeeded");
        }
    }
}