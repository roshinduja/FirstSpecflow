using com.Aviva.Assessment.PageObjects;
using com.Aviva.Assessment.Utilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace com.Aviva.Assessment.StepDefinitions
{
    [Binding]
    public class AvivaTestStepsDefinition : CommonFunctions
    {

        GoogleHomePage ghPage;
        SearchResultsPage srPage;

        [BeforeScenario]       
        public void Initialize()
        {
            ghPage = new GoogleHomePage();
            srPage = new SearchResultsPage();
        }


        [Given(@"I launch Google homepage on the web browser")]
        public void GivenILaunchGoogleHomepageOnTheWebBrowser()
        {
            GotoURL();
            ghPage.Asserting();
        }

        [When(@"I enter '(.*)' in the searchbox")]
        public void WhenIEnterInTheSearchbox(string keyWord)
        {
            ghPage.EnterSearchText(keyWord);
            ScenarioContext.Current["keyword"] = keyWord;
        }

        [When(@"hit search button")]
        public void WhenHitSearchButton()
        {
            ghPage.ClickSearchButton();
        }

        [Then(@"suitable results should be displayed")]
        public void ThenSuitableResultsShouldBeDisplayed()
        {
            var keyWord = (string)ScenarioContext.Current["keyword"];
            srPage.AssertResults(keyWord,"Aviva");      
        }

        [Then(@"I should be able to display all links and print fifth link")]
        public void ThenIShouldBeAbleToDisplayAllLinksAndPrintFifthLink()
        {
            var keyWord = (string)ScenarioContext.Current["keyword"];
            srPage.VerifyLink(keyWord);
        }

        [When(@"I enter keyword in the searchbox")]
        public void WhenIEnterKeywordInTheSearchbox(Table table)
        {
            var searchKeyword = table.CreateInstance<SearchKey>();
            ghPage.EnterSearchText(searchKeyword.keyword);
            ScenarioContext.Current["keyword"] = searchKeyword.keyword;
        }

        [Then(@"suitable error message should be displayed")]
        public void ThenSuitableErrorMessageShouldBeDisplayed()
        {
            var keyWord = (string)ScenarioContext.Current["keyword"];
            srPage.GetErrorText(keyWord);
        }
     
    }
}
