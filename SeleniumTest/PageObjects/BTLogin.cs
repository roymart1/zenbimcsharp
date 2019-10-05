using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumTest.Common;

namespace SeleniumTest.PageObjects
{
    public class BTLogin
    {
        private string szlabelUsername_id = "Email";
        private string szlabelPassword_id = "Password";
        
        
        
        private IWebElement weLabelUsername = null;
        private IWebElement weLabelPassword = null;
        private IWebElement weButtonLogIn = null;

        
        
        public BTLogin()
        {
            weLabelUsername = CTX.driver.FindElement(By.Id(szlabelUsername_id));
            weLabelPassword = CTX.driver.FindElement(By.Id(szlabelPassword_id));
//            ReadOnlyCollection<IWebElement> weList = CTX.driver.FindElements(By.XPath(".//button[@type='submit']"));
            weButtonLogIn = CTX.driver.FindElement(By.XPath(".//button[@type='submit']"));
            Console.WriteLine("Hello");
        }

        public void LogIn(string szUsername, string szPassword)
        {
            weLabelUsername.SendKeys(szUsername);
            weLabelPassword.SendKeys(szPassword);
            weButtonLogIn.Click();
        }
    }
}