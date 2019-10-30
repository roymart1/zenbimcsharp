using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;
using SeleniumTest.PageObjects.Project;
using SeleniumTest.PageObjects.ScreenDecorator;

namespace SeleniumTest 
{
    public class CompleteUserFormTest : SeleniumTestBase
    {
        /*
         * Environnement:
            DEV: https://dev.bimtrack.co/en/Login
            QA: https://qa.bimtrack.co/en/Login
            PROD: https://bimtrackapp.co/en/Login (edited) 
         */
        
        public void ActivateUser(string newUserLink)
        {
            CTX.driver.Url = newUserLink;
            
            CTX.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            NewUserActivationForm form = new NewUserActivationForm();
            form.FillNewUserForm("Johnny", "Gallo", "Acme Construction", 
                                "Architect", "Manufacturing", "Canada", 
                                "Quebec2019!", "Quebec2019!");
            
                
        }


    }        
}