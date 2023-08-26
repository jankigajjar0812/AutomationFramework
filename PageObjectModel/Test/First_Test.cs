using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObjectModel.Test
{
    public class First_Test
    {
        //Initialize Driver
        private IWebDriver _driver;
   

        [SetUp]
        public void InitScript()
        {
            //Automatically download new version of ChromeDriver
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver=new ChromeDriver();
        }
        [Test]
        public void SearchBook()
        {
            //Create object of HomePage
            HomePage hp = new HomePage(_driver);

            //Create object of Configuration Page
            Configuration config = new Configuration(_driver);

            //Create variable to fetch data from InputFile menthod in Configuration Page
            var test = config.InputFile();

            //Open URL
            _driver.Navigate().GoToUrl(test["url"]);

            //Maximize Window
            _driver.Manage().Window.Maximize();

            //To search string pass string to Search method in HomePage
            hp.Search(test["Search1"]);

            //To Assert Result Pass Expected Values
            hp.TestResult(test["ABN"], test["status"]);   
            
            //Close Window
            _driver.Close();

        }
        

    }
}
