using System;
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
            while (listProjectWe == null || listProjectWe.Count == 0)
            {
                try
                {
                    listProjectWe = weProjectFrame.FindElements(By.XPath(".//div[@class='project-item']"));
                }
                catch(Exception)
                {
                }
            }
            
        }

        public void SelectProject(string szProjetName)
        {
            foreach (var weProject in listProjectWe)
            {
                if (weProject.Text.ToLower() == szProjetName.ToLower())
                {
                    weProject.Click();
                    return;
                }
            }
            throw new Exception("Project provided was not found");
            
//            listProjectWe[0].Click();
        }
        
        
    }
}