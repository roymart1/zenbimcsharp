using OpenQA.Selenium;

namespace SeleniumTest.Common
{
    public class CTX
    {
        // used to contextualize the view component to the appropriate user options
        public enum enumUserType {administrator, guest};
        
        public static IWebDriver driver;
        public static enumUserType userType = enumUserType.administrator;

        
        




    }
}