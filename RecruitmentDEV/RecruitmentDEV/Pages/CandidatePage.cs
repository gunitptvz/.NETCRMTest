using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RecruitmentDEV.Pages
{
    /// <summary>
    /// Specifies crm candidate page members and methods
    /// </summary>
    class CandidatePage : Page
    {
        IWebDriver driver;

        public CandidatePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #region Data
        [FindsBy(How = How.Id, Using = "TabnavTabLogoTextId")]
        IWebElement dynamics365ButtonID;

        [FindsBy(How = How.Id, Using = "TabSFA")]
        IWebElement navtabbuttonID;


        #endregion

        // Click on dynamics 365 favicon
        public CandidatePage Dynamics365FavIconClick()
        {
            driver.SwitchTo().DefaultContent();
            dynamics365ButtonID.Click();
            return this;
        }

        // Click on main navigation tab
        public CandidatePage MainNavigationTabClick()
        {
            navtabbuttonID.Click();
            return this;
        }

    }
}
