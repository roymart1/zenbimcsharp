using System;
using System.Collections.Generic;
using System.Net.Mail;
using NUnit.Framework.Constraints;
using S22.Imap;

namespace SeleniumTest.Common
{
    /// <summary>
    /// 
    /// This class is responsible to retrieve and process emails sent from the BIMTrack platform. Email as the
    /// Activation email is an example. This class retrieve the activation email and extract the activation link
    /// for other class to pursue the activation. 
    ///
    /// The email implementation relies on the IMAP protocol. The current implementation is used for Gmail processing
    /// and relies on IMAP over SSL. This requires the target account to have the IMAP protocol enabled and in the
    /// Google setting of the account under security, the option 'Less secure app access' needs to be turned on.
    ///  
    /// </summary>
    public class BimEmailProcessor
    {
        public static string EMAILS_PREFIX = "bimoneauto+";
        public static string EMAILS_DOMAIN = "@gmail.com";

        private string hostname = "imap.gmail.com";
        private string username = "bimoneauto";
        private string password = "B1m0n3 Rules 99!";

        // This string is used to locate the activation link within the activation email sent by BimTrack
        private const string emailLinkPrefix = "Activate my account ";


        public void GetAllUnread()
        {
            // The default port for IMAP over SSL is 993.
            using (ImapClient client = new ImapClient(hostname, 993, username, password, AuthMethod.Login, true))
            {
                Console.WriteLine("We are connected!");
                IEnumerable<uint> uids = client.Search( SearchCondition.Unseen() );
                IEnumerable<MailMessage> messages = client.GetMessages(uids);

                foreach (var mailMessage in messages)
                {    
                    Console.WriteLine("Message --> " + mailMessage.Subject);
                }
                    
            
            }
        }


        public string GetLatestActivationForUser(String user)
        {
            var bTest = false;
            
            // The default port for IMAP over SSL is 993.
            using (ImapClient client = new ImapClient(hostname, 993, username, password, AuthMethod.Login, true))
            {
                Console.WriteLine("We are connected!");
                IEnumerable<uint> uids = null;

                // Set the filtering filters to retrieve emails (either only unread or all for a defined user)
                if (bTest)
                {
                    uids = client.Search(SearchCondition.To((EMAILS_PREFIX + user + EMAILS_DOMAIN)));
                }
                else
                {
                    uids = client.Search(SearchCondition.To((EMAILS_PREFIX + user + EMAILS_DOMAIN)).
                            And(SearchCondition.Unseen()));
                }
                
                // Retrieve emails matching filters previously set
                IEnumerable<MailMessage> messages = client.GetMessages(uids);

                // Once 
                foreach (var mailMessage in messages)
                {
                    string szText = mailMessage.Body;
                    int nLinkStart = szText.IndexOf(emailLinkPrefix, StringComparison.Ordinal);
                    if (nLinkStart != -1)
                    {
                        nLinkStart += emailLinkPrefix.Length;
                        int nLinkEnd = szText.IndexOf("\n\n", nLinkStart + 1, StringComparison.Ordinal);
                        string szLink = szText.Substring(nLinkStart, nLinkEnd - nLinkStart);
                    
                        // decode the link  
                        szLink = szLink.Replace("=3D", "=").Replace("=\n", "");
                    
                    
                        Console.WriteLine("Messages -->  " + mailMessage.Body);
                        return szLink;
                    } 
                }
            }
            return null;
        }
        
        
    }
}