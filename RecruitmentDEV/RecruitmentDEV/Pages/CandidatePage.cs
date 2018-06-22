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
        string dataSource = "https://raw.githubusercontent.com/gunitptvz/.NETCRMTest/master/JsonFiles/candidate.json";
        CandidateDataModel data = new CandidateDataModel();
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

        #endregion

        public CandidatePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public override object ActualResult { get; protected set; }

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
            searchforrecordsID.SendKeys(Keys.Tab);
            IJavaScriptExecutor createdOnFilterCliker = driver as IJavaScriptExecutor;
            createdOnFilterCliker.ExecuteScript("arguments[0].click();", createdOnXPath);
            createdOnFilterCliker.ExecuteScript("arguments[0].click();", createdOnXPath);
            ActualResult = listOfCandidates.Count;
            return this;
        }

    }
}
