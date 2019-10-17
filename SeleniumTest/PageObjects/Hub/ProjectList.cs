using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumTest.Common;

namespace SeleniumTest.PageObjects.Hub
{
    public class ProjectList : MainHub
    {
        private string projectFrameId = "projects";

        private IWebElement weProjectFrame = null;
        private ReadOnlyCollection<IWebElement> listProjectWe = null;

        public ProjectList()
        {
            this.InitLocators();
        }

        private void InitLocators()
        {
            weProjectFrame = CTX.driver.FindElement(By.Id(projectFrameId));
            listProjectWe = weProjectFrame.FindElements(By.XPath(".//div[@class='project-item']"));
            
        }

        public void SelectProject(string szProjetName)
        {
            listProjectWe[1].Click();
        }
        
        
    }
}