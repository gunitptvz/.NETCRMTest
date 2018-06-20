using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RecruitmentDEV.Data;
using RecruitmentDEV.Pages;
using System.Collections.Generic;

namespace RecruitmentDEV
{
    [TestFixture]
    public class NUnitTest1
    {
        //Queue<IWebDriver> queqe = new Queue<IWebDriver>();
        //HomePage homepage1 = null;
        //HomePage homepage2 = null;

        [SetUp]
        public void OpenCRM()
        {
            //queqe.Enqueue(new ChromeDriver());
        }

        [Parallelizable]
        [Test]
        public void TestMethod1()
        {
            
            //homepage1 = new HomePage(queqe.Dequeue());
            //homepage1.OpenPage();
        }

        [Parallelizable]
        [Test]
        public void TestMethod2()
        {
            //homepage2 = new HomePage(queqe.Dequeue());
            //homepage2.OpenPage();
        }

        [OneTimeTearDown]
        public void CloseCRM()
        {
            //Thread.Sleep(5000);
            //homepage1.ClosePage();
            //homepage2.ClosePage();
        }
    }
}