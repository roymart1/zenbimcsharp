using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumTest.Common;
using SeleniumTest.PageObjects.Hub;

namespace SeleniumTest.PageObjects
{
    public class BTHubsTracks
    {
        private string szAddNewHub_id = "btnCreateHub";
        private string szHubs_class = "block-content block-content-full";

        private IWebElement weHubHost = null;
        private ReadOnlyCollection<IWebElement> weHubList = null;     
        
        
        public BTHubsTracks()
        {
            weHubHost = CTX.driver.FindElement(By.XPath(".//div[contains(@class, '" + szHubs_class + "')]"));
            weHubList = weHubHost.FindElements(By.XPath("./a"));
        }

        public ProjectList OpenHubByName(string hubName)
        {
            foreach (var hub in weHubList)
            {
                string title = hub.FindElement(By.XPath(".//p")).Text;
                if (title == hubName)
                {
                    hub.Click();
                    return new ProjectList();
                }
            }
            return null;
        }
        
    }
}