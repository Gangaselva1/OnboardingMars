using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OnboardingSpecflowProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnboardingSpecflowProject.Pages
{
    internal class Login_Page : Hook
    {
        public void LoginSteps()
        {
            IWebElement siginbutton = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
            siginbutton.Click();
            Thread.Sleep(1000);

            try
            {
                IWebElement emailaddressTextbox = driver.FindElement(By.Name("email"));
                emailaddressTextbox.SendKeys("gangagowriselva@gmail.com");

            }
            catch (Exception ex)

            {
                Assert.Fail("Confirm your email  ", ex.Message);
            }
            IWebElement passwordTextBox = driver.FindElement(By.Name("password"));
            passwordTextBox.SendKeys("Welcomegniga@1");
            IWebElement loginbutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginbutton.Click();
            Thread.Sleep(1000);
        }

    }   
}
