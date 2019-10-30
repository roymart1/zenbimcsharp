using OpenQA.Selenium.Chrome;

namespace SeleniumTest.Common
{
    public class SeleniumTestBase
    {
        public SeleniumTestBase()
        {
            ChromeOptions cOptions = new ChromeOptions();
            cOptions.AddExcludedArgument("enable-automation");
            cOptions.AddAdditionalCapability("useAutomationExtension", false);
            
            cOptions.AddUserProfilePreference("credentials_enable_service", false);
            cOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            
            CTX.driver = new ChromeDriver("/Users/martin-pierreroy/Devl/tools/", cOptions);
        }
    }
}