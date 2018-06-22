using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;

namespace RecruitmentDEV.Pages
{
    /// <summary>
    /// Specifies crm page members and methods
    /// </summary>
    public abstract class Page
    {
        IWebDriver driver;

        protected Page(IWebDriver driver)
        {
            this.driver = driver;
            HomePage homepage = new HomePage(driver);
            homepage.OpenPage();
        }

        /// <summary>
        /// Gets object with test actual result
        /// </summary>
        public virtual object ActualResult { get; protected set; }

        /// <summary>
        /// Click on dynamics 365 favicon
        /// </summary>
        /// <returns>Current page object</returns>
        public abstract Page Dynamics365FavIconClick();

        /// <summary>
        /// Click on main navigation tab
        /// </summary>
        /// <returns>Current page object</returns>
        public abstract Page MainNavigationTabClick();

        /// <summary>
        /// Click on Recruitment navigation tab
        /// </summary>
        /// <returns>Current page object</returns>
        public abstract Page RecruitmentTabClick();

        /// <summary>
        /// Find any entity (candidate, job or application)
        /// </summary>
        /// <returns>Current page object</returns>
        public abstract Page FindRecruitmentEntity();

        /// <summary>
        /// Click on Candidate navigation tab
        /// </summary>
        /// <returns>Current page object</returns>
        public virtual Page CandidateTabClick() { return this; }

        /// <summary>
        /// Closes dynamics crm page
        /// </summary>
        public virtual void ClosePage()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
