using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumTest.PageObjects.ScreenDecorator
{
    /// <summary>
    /// The MenuOption class is used to interact with the options
    /// </summary>
    public class MenuOption
    {

        public string name { get; }
        public string section { get; }
        public IWebElement weElement { get; }

        public MenuOption(string option_name, string section_name, IWebElement weOption)
        {
            name = option_name;
            section = section_name;
            weElement = weOption;
        }
            
            

    }


    
}