using System;
using OpenQA.Selenium;

namespace SeleniumTest.Common
{
    public class WebElementHelper
    {

        public static IWebElement SafeFindElement(IWebElement elem, By byStatement)
        {
            try
            {
                return elem.FindElement(byStatement);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
    }
}