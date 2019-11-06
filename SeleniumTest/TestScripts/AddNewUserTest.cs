using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;
using SeleniumTest.PageObjects.Project;
using SeleniumTest.PageObjects.ScreenDecorator;

namespace SeleniumTest
{
    class AddNewUserTest : SeleniumTestBase
    {
        
        /*
           Environnement:
            DEV: https://dev.bimtrack.co/en/Login
            QA: https://qa.bimtrack.co/en/Login
            PROD: https://bimtrackapp.co/en/Login (edited) 
         */
        
        public void startBimTrack()
        {
//            CTX.driver.Url = "http://bimtrackapp.co";
            CTX.driver.Url = "https://qa.bimtrack.co/";

            BTLogin login = new BTLogin();
            login.LogIn("zenteliatest@gmail.com", "Z3nt3l1499!");
            
            BTHubsTracks btHubsTracks = new BTHubsTracks();
            ProjectList prjList = btHubsTracks.OpenHubByName("ZenyTest");
            
            prjList.SelectProject("ZENPROJECT001");
            
            MainProject mainProject = new MainProject();

            SideBarMenu sideBarMenu = mainProject.GetSidebarMenu();
            sideBarMenu.ClickMenuItem("Hub Settings");
            HubSettings hubSettings = new HubSettings();
            UserManagementForm userForm = hubSettings.ClickButtonAddUser();

            var emailSuffix = BimTrackUser.GetNewUserSuffix();
            var email = BimTrackUser.GetUniqueUserEmail(emailSuffix);
            userForm.AddNewUser(new BimTrackUser(email, true));

            // PROCESS EMAIL
            BimEmailProcessor proc = new BimEmailProcessor();
            string szLink = null;
            while (szLink == null)
            {
                szLink = proc.GetLatestActivationForUser(emailSuffix);    
                Console.Out.WriteLine("Loop waiting");
                Thread.Sleep(1500);
            }
            
            Console.Out.WriteLine("SzLink == " + szLink);
            CTX.driver.Close();  
            
            // Complete the user creation
            new CompleteUserFormTest().ActivateUser(szLink);
            
            //hubSettings.FillNewUserInformation(userSuffix, true);

            Thread.Sleep(1500);
            CTX.driver.Close();   
        }
    }
}