using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

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
            catch (Exception)
            {
                return null;
            }
        }

        public static IWebElement SafeFindElement(By byStatement)
        {
            try
            {
                return CTX.driver.FindElement(byStatement);
            }
            catch (Exception)
            {
                return null;
            }
        }

        
        public static void ChooseSelectItem(IWebElement weSelectControl, string itemValueToChoose)
        {
            SelectElement select = new SelectElement(weSelectControl);
            select.SelectByValue(itemValueToChoose);
        }
     
        public static bool SafeClickElement(IWebElement elem)
        {
            try
            {    
                elem.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool ScrollToElement(IWebElement elem)
        {
            try
            {
                CTX.driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", elem);
                return true;
            }            
            catch (Exception)
            {
                return false;
            }
        }
        
        
        public static void HighlightElement(IWebElement element) {
            HighlightElement(element, 200, 3, "yellow");
        }

        public static void HighlightElement(IWebElement element, int speed, int nbrFlash, String color) {
            String oldStyle = element.GetAttribute("style");
            if (CTX.driver != null) {
                try {
                    for (int i = 0; i < nbrFlash; i++) {
                        Thread.Sleep(speed / 2);
                        CTX.driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", 
                            element, oldStyle + "color: " + color + "; border: 2px solid " + color + ";");
                        Thread.Sleep(speed);
                        CTX.driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", element, oldStyle);
                    }
                } catch (Exception) {
                    // do nothing...
                }
            }
        }
        
        
        
        
    }
}