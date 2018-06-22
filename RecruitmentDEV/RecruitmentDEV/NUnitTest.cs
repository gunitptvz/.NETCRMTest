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

    public class NUnitTest
    {
        Queue<IWebDriver> queqe = new Queue<IWebDriver>();

        [SetUp]
        public void OpenCRM()
        {
            queqe.Enqueue(new ChromeDriver());
        }

        [TestFixture]
        public class CandidateTest : NUnitTest
        {
            [Parallelizable]
            [Test]
            public void NumberOfCreatedCandidatesTest()
            {
                int expectedResult = 6;

                Page candidatePage = new CandidatePage(queqe.Dequeue());

                candidatePage
                    .Dynamics365FavIconClick()
                    .MainNavigationTabClick()
                    .RecruitmentTabClick()
                    .CandidateTabClick()
                    .FindRecruitmentEntity();

                Assert.AreEqual(expectedResult, candidatePage.ActualResult, "Actual number of created candidates isn't equal to expected");

                candidatePage.ClosePage();
            }

            [Parallelizable]
            [Test]
            public void ChosenFormTest()
            {
                
            }

            //[Parallelizable]
            //[Test]
            //public void TestMethod2()
            //{

            //}

        }

        [TestFixture]
        public class JobTest : NUnitTest
        {

        }

        /*[TearDown]
        public void CloseCRM()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }*/
    }
}