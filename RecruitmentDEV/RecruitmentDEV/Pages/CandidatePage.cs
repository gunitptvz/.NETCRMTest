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
    public class CandidatePage : Page
    {
        #region Data

        IWebDriver driver;
        string contentFrame0 = "contentIFrame0";
        DataModel data = new DataModel();
        MapJsonAPI mapAPI = new MapJsonAPI();
        string dataSource = "https://raw.githubusercontent.com/gunitptvz/.NETCRMTest/master/JsonFiles/config.json";

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

        [FindsBy(How = How.XPath, Using = ".//*[@id='crmGrid_divDataArea']//tbody//tr")]
        List<IWebElement> listOfCandidates = null;

        #endregion

        public CandidatePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public int FindedCandidatesCount { get; private set; }

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
            driver.SwitchTo().Frame(contentFrame0);
            searchforrecordsID.Clear();
            searchforrecordsID.SendKeys("");
            searchforrecordsID.Submit();
            FindedCandidatesCount = listOfCandidates.Count;
            return this;
        }

        public override void ClosePage()
        {
            base.ClosePage();
        }

        
        
    }
}
