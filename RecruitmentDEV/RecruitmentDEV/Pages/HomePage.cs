using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        IWebDriver driver;
        DataModel data = new DataModel();
        MapJsonAPI mapAPI = new MapJsonAPI();
        string dataSource = "https://raw.githubusercontent.com/gunitptvz/.NETCRMTest/master/JsonFiles/config.json";
        string inlineDialogFrame = "InlineDialog_Iframe";

        [FindsBy(How = How.Id, Using = "buttonClose")]
        IWebElement closeHelloWindowButton;

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
            data = mapAPI.GetData(dataSource);
            driver.Manage().Window.Maximize();
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
            driver.Quit();
        }
    }
}
