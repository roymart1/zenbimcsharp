using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumTest.Common;

namespace SeleniumTest.PageObjects.ScreenDecorator
{
    public class SideBarMenu
    {
        private string sideBarClass = "sidebar-content";
        private string sideBarSubSectionHeadingClass = "nav-main-heading";

        private List<MenuOption> listMenuOptions = null;
        
        /// <summary>
        /// Return a list of all options available in the left pane menu 
        /// </summary>
        /// <returns>
        /// Return the list of all available options on the left side bar menu
        /// </returns>
        public List<MenuOption> GetAllMenuOptions()
        {
            listMenuOptions = new List<MenuOption>();
            
            IWebElement mainSideBar = CTX.driver.FindElement(By.XPath(".//div[@class='" + sideBarClass + "']"));
            ReadOnlyCollection<IWebElement> listMenuOptionsWe =
                mainSideBar.FindElements(By.XPath(".//span[@class='sidebar-mini-hidden']"));

            foreach (var elem in listMenuOptionsWe)
            {
                IWebElement weParent = WebElementHelper.SafeFindElement(elem, By.XPath(".."));
                // Assumes that a span with an A parent is a header
                if (weParent.GetAttribute("tagName").ToUpper() == "A")
                {
                    listMenuOptions.Add(new MenuOption(elem.Text, elem));
                }
            }
            return listMenuOptions;
        }
        
        public Boolean ClickMenuItem(string szMenuOption)
        {
            // Make sure the menu items are loaded
            if (listMenuOptions == null) GetAllMenuOptions();
            // 
            foreach (var option in listMenuOptions)
            {
                if (option.name != szMenuOption) continue;
                option.weElement.Click();
                return true;

            }
            return false;
        }
        
    }
}