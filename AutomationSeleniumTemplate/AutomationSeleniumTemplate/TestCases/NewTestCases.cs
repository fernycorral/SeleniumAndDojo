using AutomationSeleniumTemplate.Browser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumTemplate.TestCases
{
    
    class NewTestCases
    {
        SeleniumBrowser browser;

        [SetUp]
        public void Setup()
        {
            browser = new SeleniumBrowser();
            browser.GoToURL("http://dojo.nearsoft.com/");
        }

        [Test]
        public void IsPageFullyLoaded()
        {
            var loadedEle = browser.FindElement("//body[@class='home page-template-default page page-id-546']");
            Assert.NotNull(loadedEle);
        }
        [Test]
        public void IsTitleLoaded()
        {
            Assert.NotNull(browser.GetPageTitle());
        }

        [Test]
        public void IsFooterLoaded()
        {
            Assert.NotNull(browser.FindElement("//footer"));
        }

        [Test]
        [Category("looking for video")]
        public void LookForJohnsVideo()
        {
            browser.SetTextUsingId("s", "John sonmez");
            browser.DoClickById("searchsubmit");
            browser.DoClickByXPath("//div/h2/a[contains(text(),'John Sonmez')]");
            browser.SwitchToFrame(browser.FindElement("//iframe"));
            var clickeablDiv = browser.FindElements("//div[@id='player']/div[contains(@class,'unstarted-mode')]").First();
            browser.Click(clickeablDiv);
            System.Threading.Thread.Sleep(1500);
            clickeablDiv = browser.FindElements("//div[@id='player']/div[contains(@class,'playing-mode')]").First();
            browser.Click(clickeablDiv);
            System.Threading.Thread.Sleep(1500);
            string classVal = browser.FindElement("//div[@id='player']/div").GetAttribute("class");
            Assert.IsTrue(classVal.Contains("paused-mode"));


        }

        [TearDown]
        public void TearDown()
        {
            browser.Close();
        }
        
    }
}
