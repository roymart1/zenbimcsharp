using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;
using SeleniumTest.PageObjects.Project;

namespace SeleniumTest
{
    class SeleniumRunner
    {

        static void Main(string[] args)
        {
            SeleniumRunner test = new SeleniumRunner();
            //test.startBrowser();
            test.startBimTrack();
            Console.WriteLine("Hello World!");
        }

        private void startBrowser()
        {
            CTX.driver = new ChromeDriver("/Users/martin-pierreroy/Devl/tools/");
            CTX.driver.Url = "http://www.google.com";


            IWebElement weElem = CTX.driver.FindElement(By.Name("q"));
            weElem.SendKeys("zentelia" + Keys.Enter);
            
            Thread.Sleep(4500);
            CTX.driver.Close();
        }

        private void startBimTrack()
        {
            ChromeOptions cOptions = new ChromeOptions();
            cOptions.AddExcludedArgument("enable-automation");
            cOptions.AddAdditionalCapability("useAutomationExtension", false);
            
            cOptions.AddUserProfilePreference("credentials_enable_service", false);
            cOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            
            CTX.driver = new ChromeDriver("/Users/martin-pierreroy/Devl/tools/", cOptions);
            CTX.driver.Url = "http://bimtrackapp.co";

            BTLogin login = new BTLogin();
            login.LogIn("zenteliatest@gmail.com", "Z3nt3l1499!");
            
            BTHubsTracks btHubsTracks = new BTHubsTracks();
            ProjectList prjList = btHubsTracks.OpenHubByName("ZenyTestB");
            
            prjList.SelectProject("");
            
            MainProject mainProject = new MainProject();

            mainProject.GetAllMenuOptions();
            
            Thread.Sleep(60000);
            CTX.driver.Close();
            
        }


    }
}