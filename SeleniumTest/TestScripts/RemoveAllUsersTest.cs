using System;
using System.Threading;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;
using SeleniumTest.PageObjects.Project;
using SeleniumTest.PageObjects.ScreenDecorator;

namespace SeleniumTest
{
    public class RemoveAllUsersTest : SeleniumTestBase
    {
        public void RemoveAllUsers()
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

            UserManagementForm userForm = new UserManagementForm(hubSettings.GetRoot());
            userForm.RemoveAllUsers();
       
            CTX.driver.Close();   
        }
    }
}