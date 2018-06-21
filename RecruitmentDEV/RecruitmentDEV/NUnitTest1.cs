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
        Queue<IWebDriver> queqe = new Queue<IWebDriver>();

        [SetUp]
        public void OpenCRM()
        {
            queqe.Enqueue(new ChromeDriver());
        }

        [Parallelizable]
        [Test]
        public void TestMethod1()
        {
            Page candidatePage = new CandidatePage(queqe.Dequeue());
            candidatePage
                .Dynamics365FavIconClick()
                .MainNavigationTabClick()
                .RecruitmentTabClick()
                .CandidateTabClick()
                .ClosePage();
        }

        //[Parallelizable]
        //[Test]
        //public void TestMethod2()
        //{
            
        //}

        //[OneTimeTearDown]
        //public void CloseCRM()
        //{
            
        //}
    }
}