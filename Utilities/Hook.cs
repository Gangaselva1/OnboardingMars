using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnboardingSpecflowProject.Utilities
{
    internal class Hook :CommonDriver
    {
        //public static IWebDriver driver;
        [Before]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        [After]
        public void Cleanup()
        {
           driver.Quit();
        }
        
    }
}
