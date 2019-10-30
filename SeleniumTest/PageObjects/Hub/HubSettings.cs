using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
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

        
 

        /// <summary>
        /// Find the add button in the HubSettings page and click on it
        /// 
        /// </summary>
        public UserManagementForm ClickButtonAddUser()
        {
            // TODO: Requires to have an ID assigned to the button of a close locator

            var weRoot = GetRoot();
            IWebElement iElement = weRoot.FindElement(
             By.XPath("//*[@id='hubSettings-component']/div/div[1]/div[2]/div[2]/div/div[1]/div/div[2]/div[1]/button"));

            while (WebElementHelper.SafeFindElement(weRoot, 
                       By.XPath(".//input[@data-testid='validEmailCell']")) == null)
            {
                iElement.Click();    
            }
            
            Thread.Sleep(1000);
            
            
            return new UserManagementForm(weRoot);

//            //background-image: url("/Scripts/react/prod/dc3cae90d0e353eef3ad6c94a893f3c2.jpg");
//            ReadOnlyCollection<IWebElement> listElements = GetRoot().FindElements(
//                By.XPath("*[contains(@style,'background-image: url(')]"));
//            IWebElement wButton = listElements[0].FindElement(By.XPath(".//div[2]/div[1]/button"));
        }

        public void FillNewUserInformation(string szUserSuffix, bool bAdmin)
        {
            IWebElement weTarget = GetRoot().FindElement(By.XPath("//input[@data-testid='validEmailCell']"));
            weTarget.SendKeys(BimEmailProcessor.EMAILS_PREFIX + szUserSuffix + 
                              BimEmailProcessor.EMAILS_DOMAIN);
        }
        
        
        
        
        
    }
}