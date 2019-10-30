using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using SeleniumTest.Common;

namespace SeleniumTest
{
       
        
    public class NewUserActivationForm
    {
        private string previousURL = null;

        private By by_firstName = By.Id("FirstName");
        private By by_lastName = By.Id("LastName");
        private By by_email = By.Id("Email");
        private By by_company = By.Id("Company");
        private By by_jobTitle = By.Id("JobTitle");
        private By by_industry = By.Id("Industry");
        private By by_country = By.Id("Country");
        private By by_password = By.Id("Password");
        private By by_passwordConfirm = By.Id("Password2");
        private By by_checkTerms = By.Id("terms");
        private By by_btnSignUp = By.Id("btnSignUp");
        
        
        // error makers
        private By by_error_FirstName = By.Id("FirstName-error");
        private By by_error_LastName = By.Id("LastName-error");
        private By by_error_Company = By.Id("Company-error");
        private By by_error_JobTitle = By.Id("JobTitle-error");
        private By by_error_Industry = By.Id("Industry-error");
        private By by_error_Password = By.Id("Password-error");
        private By by_error_PasswordConfirm = By.Id("Password2-error");
        
        
        Dictionary<string,string> dictIndustry = new Dictionary <string,string> ()
        {
            {"Architecture", "1"},
            {"BIM Consulting", "2"},
            {"Construction manager", "3"},
            {"Education", "4"},
            {"Engineering", "5"},
            {"General contractor - Building Operation and Maintenance", "6"},
            {"Manufacturing", "7"},
            {"Owner", "8"},
            {"Quality control consulting", "9"},
            {"Software vendor", "11"},
            {"Trades and sub-contractors", "10"},
            {"Urban planning", "12"},
            {"Other", "13"}
        };

        private Dictionary<string, string> dictCountries = new Dictionary<string, string>()
        {
            {"Afghanistan",  "AF"},
            {"Åland Islands",  "AX"},
            {"Albania",  "AL"},
            {"Algeria",  "DZ"},
            {"American Samoa",  "AS"},
            {"Andorra",  "AD"},
            {"Angola",  "AO"},
            {"Anguilla",  "AI"},
            {"Antigua and Barbuda",  "AG"},
            {"Argentina",  "AR"},
            {"Armenia",  "AM"},
            {"Aruba",  "AW"},
            {"Australia",  "AU"},
            {"Austria",  "AT"},
            {"Azerbaijan",  "AZ"},
            {"Bahamas",  "BS"},
            {"Bahrain",  "BH"},
            {"Bangladesh",  "BD"},
            {"Barbados",  "BB"},
            {"Belarus",  "BY"},
            {"Belgium",  "BE"},
            {"Belize",  "BZ"},
            {"Benin",  "BJ"},
            {"Bermuda",  "BM"},
            {"Bhutan",  "BT"},
            {"Bolivia",  "BO"},
            {"Bonaire, Sint Eustatius and Saba",  "BQ"},
            {"Bosnia and Herzegovina",  "BA"},
            {"Botswana",  "BW"},
            {"Brazil",  "BR"},
            {"British Indian Ocean Territory",  "IO"},
            {"British Virgin Islands",  "VG"},
            {"Brunei",  "BN"},
            {"Bulgaria",  "BG"},
            {"Burkina Faso",  "BF"},
            {"Burundi",  "BI"},
            {"Cabo Verde",  "CV"},
            {"Cambodia",  "KH"},
            {"Cameroon",  "CM"},
            {"Canada",  "CA"},
            {"Caribbean",  "029"},
            {"Cayman Islands",  "KY"},
            {"Central African Republic",  "CF"},
            {"Chad",  "TD"},
            {"Chile",  "CL"},
            {"China",  "CN"},
            {"Christmas Island",  "CX"},
            {"Cocos (Keeling) Islands",  "CC"},
            {"Colombia",  "CO"},
            {"Comoros",  "KM"},
            {"Congo",  "CG"},
            {"Congo (DRC",  "CD"},
            {"Cook Islands",  "CK"},
            {"Costa Rica",  "CR"},
            {"Côte d’Ivoire",  "CI"},
            {"Croatia",  "HR"},
            {"Cuba",  "CU"},
            {"Curaçao",  "CW"},
            {"Cyprus",  "CY"},
            {"Czech Republic",  "CZ"},
            {"Denmark",  "DK"},
            {"Djibouti",  "DJ"},
            {"Dominica",  "DM"},
            {"Dominican Republic",  "DO"},
            {"Ecuador",  "EC"},
            {"Egypt",  "EG"},
            {"El Salvador",  "SV"},
            {"Equatorial Guinea",  "GQ"},
            {"Eritrea",  "ER"},
            {"Estonia",  "EE"},
            {"Ethiopia",  "ET"},
            {"Europe",  "150"},
            {"Falkland Islands",  "FK"},
            {"Faroe Islands",  "FO"},
            {"Fiji",  "FJ"},
            {"Finland",  "FI"},
            {"France",  "FR"},
            {"French Guiana",  "GF"},
            {"French Polynesia",  "PF"},
            {"Gabon",  "GA"},
            {"Gambia",  "GM"},
            {"Georgia",  "GE"},
            {"Germany",  "DE"},
            {"Ghana",  "GH"},
            {"Gibraltar",  "GI"},
            {"Greece",  "GR"},
            {"Greenland",  "GL"},
            {"Grenada",  "GD"},
            {"Guadeloupe",  "GP"},
            {"Guam",  "GU"},
            {"Guatemala",  "GT"},
            {"Guernsey",  "GG"},
            {"Guinea",  "GN"},
            {"Guinea-Bissau",  "GW"},
            {"Guyana",  "GY"},
            {"Haiti",  "HT"},
            {"Honduras",  "HN"},
            {"Hong Kong SAR",  "HK"},
            {"Hungary",  "HU"},
            {"Iceland",  "IS"},
            {"India",  "IN"},
            {"Indonesia",  "ID"},
            {"Iran",  "IR"},
            {"Iraq",  "IQ"},
            {"Ireland",  "IE"},
            {"Isle of Man",  "IM"},
            {"Israel",  "IL"},
            {"Italy",  "IT"},
            {"Jamaica",  "JM"},
            {"Japan",  "JP"},
            {"Jersey",  "JE"},
            {"Jordan",  "JO"},
            {"Kazakhstan",  "KZ"},
            {"Kenya",  "KE"},
            {"Kiribati",  "KI"},
            {"Korea",  "KR"},
            {"Kosovo",  "XK"},
            {"Kuwait",  "KW"},
            {"Kyrgyzstan",  "KG"},
            {"Laos",  "LA"},
            {"Latin America",  "419"},
            {"Latvia",  "LV"},
            {"Lebanon",  "LB"},
            {"Lesotho",  "LS"},
            {"Liberia",  "LR"},
            {"Libya",  "LY"},
            {"Liechtenstein",  "LI"},
            {"Lithuania",  "LT"},
            {"Luxembourg",  "LU"},
            {"Macao SAR",  "MO"},
            {"Macedonia, FYRO",  "MK"},
            {"Madagascar",  "MG"},
            {"Malawi",  "MW"},
            {"Malaysia",  "MY"},
            {"Maldives",  "MV"},
            {"Mali",  "ML"},
            {"Malta",  "MT"},
            {"Marshall Islands",  "MH"},
            {"Martinique",  "MQ"},
            {"Mauritania",  "MR"},
            {"Mauritius",  "MU"},
            {"Mayotte",  "YT"},
            {"Mexico",  "MX"},
            {"Micronesia",  "FM"},
            {"Moldova",  "MD"},
            {"Monaco",  "MC"},
            {"Mongolia",  "MN"},
            {"Montenegro",  "ME"},
            {"Montserrat",  "MS"},
            {"Morocco",  "MA"},
            {"Mozambique",  "MZ"},
            {"Myanmar",  "MM"},
            {"Namibia",  "NA"},
            {"Nauru",  "NR"},
            {"Nepal",  "NP"},
            {"Netherlands",  "NL"},
            {"New Caledonia",  "NC"},
            {"New Zealand",  "NZ"},
            {"Nicaragua",  "NI"},
            {"Niger",  "NE"},
            {"Nigeria",  "NG"},
            {"Niue",  "NU"},
            {"Norfolk Island",  "NF"},
            {"North Korea",  "KP"},
            {"Northern Mariana Islands",  "MP"},
            {"Norway",  "NO"},
            {"Oman",  "OM"},
            {"Pakistan",  "PK"},
            {"Palau",  "PW"},
            {"Palestinian Authority",  "PS"},
            {"Panama",  "PA"},
            {"Papua New Guinea",  "PG"},
            {"Paraguay",  "PY"},
            {"Peru",  "PE"},
            {"Philippines",  "PH"},
            {"Pitcairn Islands",  "PN"},
            {"Poland",  "PL"},
            {"Portugal",  "PT"},
            {"Puerto Rico",  "PR"},
            {"Qatar",  "QA"},
            {"Réunion",  "RE"},
            {"Romania",  "RO"},
            {"Russia",  "RU"},
            {"Rwanda",  "RW"},
            {"Saint Barthélemy",  "BL"},
            {"Saint Kitts and Nevis",  "KN"},
            {"Saint Lucia",  "LC"},
            {"Saint Martin",  "MF"},
            {"Saint Pierre and Miquelon",  "PM"},
            {"Saint Vincent and the Grenadines",  "VC"},
            {"Samoa",  "WS"},
            {"San Marino",  "SM"},
            {"São Tomé and Príncipe",  "ST"},
            {"Saudi Arabia",  "SA"},
            {"Senegal",  "SN"},
            {"Serbia",  "RS"},
            {"Seychelles",  "SC"},
            {"Sierra Leone",  "SL"},
            {"Singapore",  "SG"},
            {"Sint Maarten",  "SX"},
            {"Slovakia",  "SK"},
            {"Slovenia",  "SI"},
            {"Solomon Islands",  "SB"},
            {"Somalia",  "SO"},
            {"South Africa",  "ZA"},
            {"South Sudan",  "SS"},
            {"Spain",  "ES"},
            {"Sri Lanka",  "LK"},
            {"St Helena, Ascension, Tristan da Cunha",  "SH"},
            {"Sudan",  "SD"},
            {"Suriname",  "SR"},
            {"Svalbard and Jan Mayen",  "SJ"},
            {"Swaziland",  "SZ"},
            {"Sweden",  "SE"},
            {"Switzerland",  "CH"},
            {"Syria",  "SY"},
            {"Taiwan",  "TW"},
            {"Tajikistan",  "TJ"},
            {"Tanzania",  "TZ"},
            {"Thailand",  "TH"},
            {"Timor-Leste",  "TL"},
            {"Togo",  "TG"},
            {"Tokelau",  "TK"},
            {"Tonga",  "TO"},
            {"Trinidad and Tobago",  "TT"},
            {"Tunisia",  "TN"},
            {"Turkey",  "TR"},
            {"Turkmenistan",  "TM"},
            {"Turks and Caicos Islands",  "TC"},
            {"Tuvalu",  "TV"},
            {"U.S. Outlying Islands",  "UM"},
            {"U.S. Virgin Islands",  "VI"},
            {"Uganda",  "UG"},
            {"Ukraine",  "UA"},
            {"United Arab Emirates",  "AE"},
            {"United Kingdom",  "GB"},
            {"United States",  "US"},
            {"Uruguay",  "UY"},
            {"Uzbekistan",  "UZ"},
            {"Vanuatu",  "VU"},
            {"Venezuela",  "VE"},
            {"Vietnam",  "VN"},
            {"Wallis and Futuna",  "WF"},
            {"World",  "001"},
            {"Yemen",  "YE"},
            {"Zambia",  "ZM"},
            {"Zimbabwe",  "ZW"}
        };

        private void NavigateToMagicLink(string magicLink)
        {
            previousURL = CTX.driver.Url;
            CTX.driver.Url = magicLink;
        }

        public void FillNewUserForm(string firstName, string lastName, string company, string jobtitle,
                                        string industry, string country, string password, string passwordConfirm)
        {
            this.FillEditField(by_firstName, firstName);
            this.FillEditField(by_lastName, lastName);
            this.FillEditField(by_company, company);
            this.FillEditField(by_jobTitle, jobtitle);
            // Fill the passwords fields
            this.FillEditField(by_password, password, false);
            this.FillEditField(by_passwordConfirm, password, false);
            WebElementHelper.ChooseSelectItem(CTX.driver.FindElement(by_industry), dictIndustry[industry]);
            WebElementHelper.ChooseSelectItem(CTX.driver.FindElement(by_country), dictCountries[country]);

            
            By by_temp = By.XPath("//input[@id='terms']/..");
            IWebElement chkbox = CTX.driver.FindElement(by_temp);

            String szAtt = chkbox.GetAttribute("Tag");
            
            CTX.driver.FindElement(By.XPath("//*[@id='terms']/ancestor::label")).Click();

            CTX.driver.FindElement(by_btnSignUp).Click();
            
            Console.Out.WriteLine("END");
//            CTX.driver.FindElement(by_btnSignUp).Click();
        }
        
        /// <summary>
        /// This is an isolated method for purpose of character set testing and input reflection
        /// 
        /// </summary>
        /// <param name="byElem"></param>
        /// <param name="textEntry"></param>
        /// <param name="bCompare"></param>
        /// <returns>true if the edit content reflects the input text or false otherwise</returns>
        private bool FillEditField(By byElem, string textEntry, bool bCompare = true)
        {
            CTX.driver.FindElement(byElem).SendKeys(textEntry);
            if (bCompare)
                return CTX.driver.FindElement(byElem).Text.Equals(textEntry);    
            else
                return true;
        }
        


            

        
    }
}