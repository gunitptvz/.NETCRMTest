using System;
using NUnit.Framework;
using OpenQA.Selenium;

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

        }

        [TearDown]
        public void CloseCRM()
        {

        }
    }
}