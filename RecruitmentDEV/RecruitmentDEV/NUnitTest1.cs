using System;
using NUnit.Framework;
using OpenQA.Selenium;
using RecruitmentDEV.Data;

namespace RecruitmentDEV
{
    [TestFixture]
    public class NUnitTest1
    {
        [SetUp]
        public void OpenCRM()
        {
            IWebDriver crm = null;
        }

        [Test]
        public void TestMethod1()
        {
            MapJsonAPI data = new MapJsonAPI();
            data.GetData("https://raw.githubusercontent.com/gunitptvz/.NETCRMTest/master/JsonFiles/config.json");
        }

        [TearDown]
        public void CloseCRM()
        {

        }
    }
}