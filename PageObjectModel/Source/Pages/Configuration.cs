using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Source.Pages
{
    public class Configuration
    {
        private IWebDriver _driver;

        public Configuration(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public Dictionary<string,string> InputFile()
        {
            return new Dictionary<string, string>
            {
                { "url","https://abr.business.gov.au/" },
                { "Search1","Automic PTY LTD" },
                { "ABN","152 260 814" },
                { "status","Active" },
                {"Search2","MARIO BROS PTY LTD" },
                {"ABN2","93 118 220 920" },
                {"ABN_Name","The Trustee for MAURO BROTHERS SENIOR SUPER FUND" }

            };
        }
        
       
    }
}
