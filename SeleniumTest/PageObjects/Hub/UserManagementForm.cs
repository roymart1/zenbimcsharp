using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;

namespace SeleniumTest.PageObjects.Hub
{
    public class UserManagementForm
    {
        private IWebElement weTableHeader = null;
        private IWebElement weTableBody = null;
        // Add the navigation element at the bottom

        private IWebElement weSectionRoot = null;
        
        private enum TABLE_COLUMN
        {
            Check,
            AcceptBtnBegin,
            HubUser, // email
            FirstName,
            LastName,
            Role,
            Projects,
            LastWebLogin,
            LastAddInLogin,
            Company,
            Country,
            Industry,
            JobTitle,
            AcceptBtnEnd
        };


        public UserManagementForm(IWebElement weRoot)
        {
            this.weSectionRoot = weRoot;
        }

        private IWebElement _GetNewUserRowRoot()
        {
            var weNewUser = weSectionRoot.FindElement(
                    By.XPath("//input[@data-testid='validEmailCell']/ancestor::tr"));
            return weNewUser;
        }

        /// <summary>
        /// Retrieve the web element of a specific element from the new user row in the user table and scroll the view
        /// to that element
        /// </summary>
        /// <param name="column">entry in the TABLE_COLUMN enum that point to the expected column index</param>
        /// <returns></returns>
        private IWebElement _GetNewUserCellRoot(TABLE_COLUMN column, bool bScrollToElem = true)
        {
            ReadOnlyCollection<IWebElement> listCells =  _GetNewUserRowRoot().FindElements(By.XPath("./td"));
            IWebElement weCell = listCells[(int) column];
            if (bScrollToElem) WebElementHelper.ScrollToElement(weCell);
            return weCell;
        }
        
        public void GetAllNewElementSections()
        {

            IWebElement userType = _GetNewUserCellRoot(TABLE_COLUMN.Role);

            var divCombo = userType.FindElement(By.XPath("./div"));
            divCombo.Click();

            
            userType.FindElement(By.Id("react-select-19-option-0")).Click();
            Thread.Sleep(2000);

            divCombo.Click();
            userType.FindElement(By.Id("react-select-19-option-1")).Click();
            Thread.Sleep(2000);
            
            divCombo.Click();
            userType.FindElement(By.Id("react-select-19-option-0")).Click();
            
            Console.Out.WriteLine("TEST");
        }

        /// <summary>
        /// This method uses mouse interaction to open a dynamic drop
        /// 
        /// </summary>
        /// <param name="bAdmin"> true if the user is to be created as admin, false otherwise </param>
        private void _SetNewUserRole(bool bAdmin)
        {
            ReadOnlyCollection<IWebElement> listCells =  _GetNewUserRowRoot().FindElements(By.XPath("./td"));
            IWebElement userType = listCells[(int) TABLE_COLUMN.Role];
            
            
            var divCombo = userType.FindElement(By.XPath("./div"));
            divCombo.Click();
            userType.FindElement(By.Id("react-select-19-option-" + (bAdmin ? "0" : "1"))).Click();
        }
        
        
        
        private bool IsInUserAddingMode()
        {
            // TODO: implementation
            return false;
        }

        public bool AddNewUser(BimTrackUser bimUser)
        {
//            IWebElement weTarget = GetRoot().FindElement(By.XPath("//input[@data-testid='validEmailCell']"));
//            weTarget.SendKeys(BimEmailProcessor.EMAILS_PREFIX + szUserSuffix + 
//                              BimEmailProcessor.EMAILS_DOMAIN);    
            var random = new Random();
            Thread.Sleep(random.Next(250, 500));
            _SetNewUserEmail(bimUser.email);
            Thread.Sleep(random.Next(250, 500));
            _SetNewUserRole(bimUser.isAdmin);
            Thread.Sleep(random.Next(250, 500));
            _ClickAddOrCancel(true, false);


            
            //TODO: Replace by ID, dependant on localized resource
            // Wait for a maximum time of x milliseconds for the out of users available message to pop in case the 
            // maximum of users was reached
            const string warning = "You can not choose this plan. The hub user limit is reached.";
            var byElem = By.XPath(".//span[text() ='" + warning + "']");
            var retElem = WebElementHelper.WaitUntilVisible(byElem, 2500);
            
            if (retElem != null)
            {
                return false;    
            }
            else
            {
                return true;
            }
                
            
        }

        public bool RemoveAllUsers(BimTrackUser bimUser)
        {
            
            return false;
        }


        /// <summary>
        /// This method sets the email as HubUser and validates the email is not generating an 'Invalid email address'
        /// warning
        /// 
        /// </summary>
        /// <param name="email">The email to be used as new user identifier</param>
        private void _SetNewUserEmail(string email)
        {
            IWebElement emailSection = _GetNewUserCellRoot(TABLE_COLUMN.HubUser);
            IWebElement emailInput = emailSection.FindElement(By.XPath(".//input[@data-testid='validEmailCell']"));
            emailInput.SendKeys(email);
            _GetNewUserCellRoot(TABLE_COLUMN.FirstName, false).Click();

            
            // Assert the inserted email did not cause issues
            Assert.Null(WebElementHelper.SafeFindElement(emailSection, 
                                By.XPath(".//span[@data-testid='warningLabel']")));
        }


        /// <summary>
        /// Click the button to process the creation of the new user or dismiss changes
        /// 
        /// </summary>
        /// <param name="bAdd">true to create the new user from the information already field or false to
        /// dismiss the creation and delete the new user line entry</param>
        /// <param name="bLeftButtons">choose to click the accept/cancel from the left column of the table
        /// or false to use the button from the last column on the right side</param>
        private void _ClickAddOrCancel(bool bAdd, bool bLeftButtons = true)
        {
            IWebElement btnSection = null;
            btnSection = _GetNewUserCellRoot(bLeftButtons ? TABLE_COLUMN.AcceptBtnBegin:TABLE_COLUMN.AcceptBtnEnd);
            _ClickAddOrCancel(bAdd, btnSection, bLeftButtons);  
        }


        /// <summary>
        /// Click the button to process the creation of the new user or dismiss changes
        /// 
        /// </summary>
        /// <param name="bAdd">true to create the new user from the information already field or false to
        /// dismiss the creation and delete the new user line entry</param>
        /// <param name="btnCell"></param>
        /// <param name="bLeftButtons">choose to click the accept/cancel from the left column of the table
        /// or false to use the button from the last colum on the right side</param>
        private void _ClickAddOrCancel(bool bAdd, IWebElement btnCell, bool bLeftButtons = true)
        {
            ReadOnlyCollection<IWebElement> listBtn = btnCell.FindElements(By.XPath(".//button"));
            
            WebElementHelper.HighlightElement(btnCell);
            
            if (bAdd)
            {
                IWebElement btn = listBtn[0];
                Assert.IsTrue(listBtn[0].Enabled, "UserCreation: Accept user creation button disabled");
                btn.Click();
            }    
            else
            {
                IWebElement btn = listBtn[1];
                Assert.IsTrue(listBtn[1].Enabled, "UserRemoval: Delete user button disabled");
                btn.Click();
            }
        }

        public int RemoveAllUsers()
        {
            WebElementHelper.WaitUntilVisible(By.XPath(".//div[@data-testid='body']"), 3000);
            var tableBody = weSectionRoot.FindElement(By.XPath(".//div[@data-testid='body']"));
            var  tableRows= tableBody.FindElements(By.XPath(".//tr"));
            foreach (var currentRow in tableRows)
            {
                var rowCells = currentRow.FindElements(By.XPath(".//td"));
                _ClickAddOrCancel(false, rowCells[(int) TABLE_COLUMN.AcceptBtnBegin], true);
                
                var elem = WebElementHelper.WaitUntilVisible(By.XPath(".//button[@id='clickDelete']"), 10000);
                while(!WebElementHelper.SafeClickElement(elem))
                    Thread.Sleep(1500);
            }
            
            //TODO Implementation
            return 0;
        }
        
        
        public List<BimTrackUser> GetUserList()
        {

            // TODO: Implementation
            return null;
        }

        
    }
}