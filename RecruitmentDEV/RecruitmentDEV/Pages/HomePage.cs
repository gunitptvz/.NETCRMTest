using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RecruitmentDEV.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RecruitmentDEV.Pages
{
    /// <summary>
    /// Specifies crm homepage members and methods
    /// </summary>
    class HomePage
    {
        #region Data

        IWebDriver driver;
        ConfigDataModel data = new ConfigDataModel();
        MapJsonAPI mapAPI = new MapJsonAPI();
        string dataSource = "https://raw.githubusercontent.com/gunitptvz/.NETCRMTest/master/JsonFiles/config.json";
        string inlineDialogFrame = "InlineDialog_Iframe";

        [FindsBy(How = How.Id, Using = "buttonClose")]
        IWebElement closeHelloWindowButton = null;

        #endregion

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Opens dynamics crm homepage
        /// </summary>
        public IWebDriver OpenPage()
        {
            data = mapAPI.GetData<ConfigDataModel>(dataSource);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(data.Seconds);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(data.Seconds);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(data.Seconds);
            driver.Url = "http://" + data.Login + ":" + data.Password + "@" + data.Url;
            driver.SwitchTo().Frame(inlineDialogFrame);
            closeHelloWindowButton.Click();

            return driver;
        }

        /// <summary>
        /// Closes dynamics crm homepage
        /// </summary>
        public void ClosePage()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
