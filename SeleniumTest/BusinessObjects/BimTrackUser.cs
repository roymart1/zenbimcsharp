using System;
using System.Collections.Generic;
using SeleniumTest.Common;

namespace SeleniumTest.BusinessObjects
{
    public class BimTrackUser
    {
        public string email { get; set; }
        public bool isAdmin { get; set; }
        public List<string> projectList = null;

        public BimTrackUser(string szEmail, bool bAdmin)
        {
            email = szEmail;
            isAdmin = bAdmin;
        }

        /// <summary>
        /// Provide a user suffix to be used for the user creation and the email activation processing
        /// 
        /// </summary>
        /// <returns>
        ///    String with the pattern {MONTH 2 digits}{DAY 2 digits}_{HOUR 24h 2 digits}{MIN 2 digits}{SEC 2 digits}
        /// </returns>
        public static string GetNewUserSuffix()
        {
            string id = "";
            id += DataGen.GenerateRandomChar();
            id += DataGen.GenerateRandomChar();
            return id + DateTime.Now.ToString("MMdd_hhmmss");  
        }


        public static string GetUniqueUserEmail(string emailsuffix)
        {
            return BimEmailProcessor.EMAILS_PREFIX  + emailsuffix + BimEmailProcessor.EMAILS_DOMAIN;
        }
        

    }
}