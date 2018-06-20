using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RecruitmentDEV.Pages
{
    abstract class Page
    {
        IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            HomePage homepage = new HomePage(driver);
            homepage.OpenPage();
        }

        //public abstract void TestPage();
    }
}
