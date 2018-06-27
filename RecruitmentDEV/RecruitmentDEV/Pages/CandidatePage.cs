using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RecruitmentDEV.Data;

namespace RecruitmentDEV.Pages
{
    /// <summary>
    /// Specifies crm candidate page members and methods
    /// </summary>
    class CandidatePage : Page
    {
        #region Data

        IWebDriver driver;
        string contentFrame0 = "contentIFrame0";
        string contentFrame1 = "contentIFrame1";
        string dataSource = "https://raw.githubusercontent.com/gunitptvz/.NETCRMTest/master/JsonFiles/candidate.json";
        List<string> firstNameLastNameOwnerFieldsValCollect = null;
        CandidateDataModel data;
        MapJsonAPI mapAPI = new MapJsonAPI();

        [FindsBy(How = How.Id, Using = "TabnavTabLogoTextId")]
        IWebElement dynamics365ButtonID = null;

        [FindsBy(How = How.Id, Using = "TabSFA")]
        IWebElement navtabbuttonID = null;

        [FindsBy(How = How.Id, Using = "cdv_Recruitment")]
        IWebElement recruitmentNavTabButtonID = null;

        [FindsBy(How = How.Id, Using = "cdv_CandidatesSubArea")]
        IWebElement candidatesNavTabButtonID = null;

        [FindsBy(How = How.Id, Using = "crmGrid_findCriteria")]
        IWebElement searchforrecordsID = null;

        [FindsBy(How = How.XPath, Using = ".//a[@title='Sort by Created On']")]
        IWebElement createdOnXPath = null;

        [FindsBy(How = How.XPath, Using = ".//*[@id='crmGrid_divDataArea']//tbody//tr")]
        IList<IWebElement> listOfCandidates = null;

        [FindsBy(How = How.XPath, Using = ".//*[@id='header_crmFormSelector']/nobr/span")]
        IWebElement candidateFormXPATH = null;

        [FindsBy(How = How.XPath, Using = ".//*[@id='crmFormTabContainer']/div")]
        IList<IWebElement> numberOfCandidateTabs = null;

        [FindsBy(How = How.XPath, Using = ".//*[@id='HeaderTilesWrapperLayoutElement']//div[@class='ms-crm-ReadField-Normal ms-crm-FieldLabel-LeftAlign']")]
        IList<IWebElement> numberOfFirstLastNameOwnerField = null;

        [FindsBy(How = How.XPath, Using = ".//*[@id='HeaderTilesWrapperLayoutElement']//div[@class='ms-crm-Field-Data-Print']")]
        IList<IWebElement> firstNameLastNameOwnerFieldsValXPATH = null;

        #endregion

        public CandidatePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public override object ActualResult { get; protected set; }

        public override List<string> ExpectedResultList
        {
            get
            {
                List<string> list = new List<string>() { data.FirstName, data.LastName, data.Owner };
                return list;
            }
        }

        public override int NumberOfEntityTabs { get { return numberOfCandidateTabs.Count; } }

        public override int NumberofFirstLastNameOwnerField { get { return numberOfFirstLastNameOwnerField.Count; } }

        public override List<string> FirstLastNameOwnerFieldVal
        {
            get
            {
                firstNameLastNameOwnerFieldsValCollect = new List<string>();
                foreach (IWebElement item in firstNameLastNameOwnerFieldsValXPATH) { firstNameLastNameOwnerFieldsValCollect.Add(item.Text); }
                return firstNameLastNameOwnerFieldsValCollect;
            }
        }

        public override Page Dynamics365FavIconClick()
        {
            driver.SwitchTo().DefaultContent();
            dynamics365ButtonID.Click();
            return this;
        }

        public override Page MainNavigationTabClick()
        {
            navtabbuttonID.Click();
            return this;
        }

        public override Page RecruitmentTabClick()
        {
            recruitmentNavTabButtonID.Click();
            return this;
        }

        public override Page CandidateTabClick()
        {
            candidatesNavTabButtonID.Click();
            return this;
        }

        public override Page FindRecruitmentEntity()
        {
            data = mapAPI.GetData<CandidateDataModel>(dataSource);
            driver.SwitchTo().Frame(contentFrame0);
            searchforrecordsID.Clear();
            searchforrecordsID.SendKeys(data.Name);
            searchforrecordsID.SendKeys(Keys.Enter);
            IJavaScriptExecutor createdOnFilterCliker = driver as IJavaScriptExecutor;
            createdOnFilterCliker.ExecuteScript("arguments[0].click();", createdOnXPath);
            createdOnFilterCliker.ExecuteScript("arguments[0].click();", createdOnXPath);
            ActualResult = listOfCandidates.Count;
            return this;
        }

        public override Page FoundEntityClick()
        {
            IWebElement activeCandidateNameLinkText = driver.FindElement(By.LinkText(data.Name));
            IJavaScriptExecutor activeCandidateClicker = driver as IJavaScriptExecutor;
            activeCandidateClicker.ExecuteScript("arguments[0].click();", activeCandidateNameLinkText);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(contentFrame1);
            ActualResult = candidateFormXPATH.Text;
            return this;
        }
    }
}
