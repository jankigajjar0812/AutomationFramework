using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Source.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;

        //store xpath value in webelement(if xpath value change than also this code works as it automatically replace new xpath value
        [FindsBy(How = How.XPath, Using = "//input[@id='SearchText']")]
        private IWebElement _searchtxtbox;
        [FindsBy(How = How.XPath, Using = "//input[@id='MainSearchButton']")]
        private IWebElement _searchbtn;
        [FindsBy(How = How.XPath, Using = "//tbody/tr[2]/td[1]/a[1]")]
        private IWebElement _actual;
        [FindsBy(How = How.XPath, Using = "//tbody/tr[2]/td[1]/span[1]")]
        private IWebElement _Active_actual;
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='93 118 220 920']")]
        private IWebElement _ABN;
        [FindsBy(How = How.XPath, Using = "//td[normalize-space()='The Trustee for MAURO BROTHERS SENIOR SUPER FUND']")]
        private IWebElement Actual_ABN;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void Search(string searchtext)
        {
            _searchtxtbox.SendKeys(searchtext);
            _searchbtn.Click();
        }
        public void TestResult(string expected, string Active_expected)
        {
            //wait for 3 sec
            System.Threading.Thread.Sleep(3000);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;

            //scroll window till webelement found
            jse.ExecuteScript("arguments[0].scrollIntoView();", _actual);

            //find substring from string
            string actual = _actual.Text.Substring(3, 11);
            Assert.AreEqual(expected, actual);
            string Active_actual = _Active_actual.Text;

            //Assert actual and expected value
            Assert.That(Active_actual, Is.EqualTo(Active_expected));

        }
        public void SecondTestResult(string expected1, string ABN_Name)
        {
            System.Threading.Thread.Sleep(3000);
            IJavaScriptExecutor jse=(IJavaScriptExecutor)_driver;

            jse.ExecuteScript("window.scroll(0,document.body.scrollHeight)");
            System.Threading.Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//input[@value='2']")).Click();
            System.Threading.Thread.Sleep(3000);
            jse.ExecuteScript("window.scroll(0,document.body.scrollHeight)");
            System.Threading.Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//input[@value='3']")).Click();

            System.Threading.Thread.Sleep(3000);

            //scroll window till webelement found
            jse.ExecuteScript("arguments[0].scrollIntoView();", _ABN);

            string ABN_actual = Actual_ABN.Text;

            //Assert actual and expected value
            Assert.AreEqual(ABN_actual, ABN_Name);
            System.Threading.Thread.Sleep(3000);
        }

    }
}
