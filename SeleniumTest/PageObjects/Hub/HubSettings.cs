using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumTest.Common;

namespace SeleniumTest.PageObjects.Hub
{
    public class HubSettings
    {
        
        private string hubSettings_root_id = "hubSettings-component";


        private IWebElement GetRoot()
        {
            return CTX.driver.FindElement(By.Id(hubSettings_root_id));
        }

        public void clickButtonAddUser()
        {
            ReadOnlyCollection<IWebElement> listButton = GetRoot().FindElements(By.TagName("button"));
            IWebElement iElement = GetRoot().FindElement(By.XPath("//*[@id='hubSettings-component']/div[1]/div[1]/div/div[2]/div[1]/button"));
            iElement.Click();
            iElement = GetRoot().FindElement(By.XPath("//input[@data-testid='validEmailCell']"));
            iElement.SendKeys("mpr@gmail.com");
            
        }
        
    }
}