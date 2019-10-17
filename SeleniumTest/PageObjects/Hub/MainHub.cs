using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Transactions;
using OpenQA.Selenium;
using SeleniumTest.Common;
using SeleniumTest.PageObjects.ScreenDecorator;

namespace SeleniumTest.PageObjects.Hub
{
    public class MainHub : SideBarMenu
    {
        public MainHub()
        {
            this.InitLocators();
        }

        private void InitLocators()
        {
            
        }
    }
}