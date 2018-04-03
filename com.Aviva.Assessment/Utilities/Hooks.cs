using TechTalk.SpecFlow;

namespace com.Aviva.Assessment.Utilities
{
    [Binding]
    public class Hooks : CommonFunctions
    {

        // Initializing browser and driver before scenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            GetBrowserInstance("Chrome");
            Wait(10);
        }
                
        // Closing browser session post scenario completion
        [AfterScenario]
        public void AfterScenario()
        {
            closeSession();
        }

        // Capturing screenshot after each step
        [AfterStep]
        public void Screenshot()
        {
            TakeScreenshot();            
        }

    }
}
