using System;

namespace SeleniumTest.Common
{
    public class DataGen
    {

        public static char GenerateRandomChar(bool bLower = true)
        {
            // A 65 to Z 90 -- a 97 to z 122 
            var random = new Random();    
            return (char) random.Next(bLower?97:65, bLower?122:90);
        }
            
    }
}