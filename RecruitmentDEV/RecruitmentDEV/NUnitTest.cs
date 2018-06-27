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
        Queue<IWebDriver> drivers = new Queue<IWebDriver>();

        [SetUp]
        public void OpenCRM()
        {
            drivers.Enqueue(new ChromeDriver());
        }

        [TestFixture]
        public class CandidateTest : NUnitTest
        {
            [Parallelizable]
            [Test]
            public void NumberOfCreatedCandidatesTest()
            {
                int expectedResult = 6;

                Page candidatePage = new CandidatePage(drivers.Dequeue());

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
                string expectedResult1 = "CANDIDATE : CDV CANDIDATES";
                int expectedResult2 = 13;

                Page candidatePage = new CandidatePage(drivers.Dequeue());

                candidatePage
                    .Dynamics365FavIconClick()
                    .MainNavigationTabClick()
                    .RecruitmentTabClick()
                    .CandidateTabClick()
                    .FindRecruitmentEntity()
                    .FoundEntityClick();

                Assert.AreEqual(expectedResult1, candidatePage.ActualResult, "Chosen form is different from expected");
                Assert.AreEqual(expectedResult2, candidatePage.NumberOfEntityTabs, "Number of candidate tabs isn't equal to expected number");

                candidatePage.ClosePage();
            }

            [Parallelizable]
            [Test]
            public void FirstName_LastName_Owner_FieldsTest()
            {
                int expectedResult1 = 3;

                Page candidatePage = new CandidatePage(drivers.Dequeue());

                candidatePage
                    .Dynamics365FavIconClick()
                    .MainNavigationTabClick()
                    .RecruitmentTabClick()
                    .CandidateTabClick()
                    .FindRecruitmentEntity()
                    .FoundEntityClick();

                Assert.AreEqual(expectedResult1, candidatePage.NumberofFirstLastNameOwnerField, "Number of first name, last name and owner fields isn't equal to expected number");
                CollectionAssert.AreEqual(candidatePage.ExpectedResultList, candidatePage.FirstLastNameOwnerFieldVal, "Actual result list isn't equal to expected result list");

                candidatePage.ClosePage();
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

        //[TearDown]
        //public void CloseCRM()
        //{
        //    Thread.Sleep(3000);
        //}
    }
}