using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OnboardingSpecflowProject.Utilities;
using OpenQA.Selenium.DevTools.V124.Debugger;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Reflection.Emit;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace OnboardingSpecflowProject.Pages
{
    internal class Language_Page : CommonDriver 
    {
        private string e_message = "//div[@class='ns-box-inner']";
        //private static IWebElement Language_name = driver.FindElement(By.Name("name"));
        //public static IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
        //public static IWebElement Level_option = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
        //private static IWebElement Level_option = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='Basic']"));
        //private IWebElement language = driver.FindElement(By.XPath("e_language"));
        //private string e_language = "//div[@data-tab='first']//tbody[(last)/tr/td[3]/span[1]/i";
        public void AddLanguage_Level(String language,String level)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target' and @data-tab='first']//div[contains(@class, 'ui teal button') and text()='Add New']")));
            IWebElement AddNewTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewTab.Click();
            IWebElement Language_name = driver.FindElement(By.Name("name"));
            Language_name.SendKeys(language);
            //Thread.Sleep(1000);
            IWebElement Level_selection = driver.FindElement(By.XPath("//select[@name='level']"));
            Level_selection.Click();
            IWebElement Level_option = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='{level}']"));
            Level_option.Click();
            //Thread.Sleep(1000);            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")));
            IWebElement Add_Button = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            Add_Button.Click();
            Thread.Sleep(2000);
        }
        
        public void Assert_AddLanguageAndLevel(String language,String level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement newlanguage = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newlevel = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            Assert.That(newlanguage.Text == language, "Language has not been created. Test failed!");
            Assert.That(newlevel.Text == level, "Level has not been created. Test failed!");

        }
        public void AssertMultipleLanguages_Level(string[] languages, string[] levels)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            for (int i = 0; i < languages.Length; i++)
            {
                string language = languages[i];
                string level = levels[i];
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]")));
                IWebElement languageElement = driver.FindElement(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]"));
                IWebElement levelElement = driver.FindElement(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[2]"));
                string actualLanguageText = languageElement.Text.Trim();
                string actualLevelText = levelElement.Text.Trim();
                if (!string.Equals(actualLanguageText, language, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected language '{language}' at row {i + 1}, but found '{actualLanguageText}'. Test failed!");
                }
                if (!string.Equals(actualLevelText, level, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected level '{level}' at row {i + 1}, but found '{actualLevelText}'. Test failed!");
                }
            }
        }

        public string GetEmpty_DataMessage()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 3);
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter language and level')]"));
            //IWebElement errorMessage = driver.FindElement(By.XPath("//div[contains(text(), 'Please enter language and level')]"));
            return errorMessage.Text;
            /*string ex_Message = "Please enter language and level";
            Assert.That(errorMessage.Text == e_message, "Record has not been created. Test failed!");*/
        }
        /*public void Empty_ErrorMessage()
        {
            // Error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter language and level')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter language and level')]"));
            
        }*/
        /*public void GetErrorMessage_Existingdata()
        {
            // Error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already exist in your language list.')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already exist in your language list.')]"));
            string ex_Message = "This language is already exist in your language list.";
            Assert.That(errorMessage.Text == ex_Message, "Record has not been created. Test failed!");
        }*/

        public string DuplicateData_ErrorMessage()
        {

            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already exist in your language list.')]"));
            return errorMessage.Text;


        }
        
        public void Update_Language(String language, String level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")));
            IWebElement edit_Button = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
            edit_Button.Click();
            IWebElement edit_language = driver.FindElement(By.Name("name"));
            edit_language.Clear();
            edit_language.SendKeys(language);
            // Select Level 
            IWebElement Level_selection = driver.FindElement(By.XPath("//select[@name='level']"));
            Level_selection.Click();
            // Enter code
            IWebElement Level_option = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='{level}']"));
            Level_option.Click();
            //Click update
            IWebElement update_Button = driver.FindElement(By.XPath("//input[@value='Update']"));
            update_Button.Click();
            Thread.Sleep(1000);
        }
        public void Assert_UpdateLanguageAndLevel(String language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement newlanguage = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            //IWebElement newlevel = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            Assert.That(newlanguage.Text == language, "language has not been created. Test failed!");
            //Assert.That(newlevel.Text == level, "New language has not been created. Test failed!");
        }
        public string Updation_ErrorMessage()
        {
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already added to your language list.')]"));
            return errorMessage.Text;
        }
        public void Clear_Data()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            while (true)
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));

                    // Find the delete button for the last record
                    IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
                    deleteButton.Click();
                    Thread.Sleep(1000);
                }
                catch (NoSuchElementException)
                {
                    // Break the loop if no more delete buttons are found
                    break;
                }
                catch (WebDriverTimeoutException)
                {
                    // Break the loop if the delete button is not found within the wait time
                    break;
                }
            }


        }
        public void Delete_language(string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));
            IWebElement languageToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            string temp_language = languageToBeDeleted.Text.Trim();
            if (language == temp_language)
            {
                //Click on delete button on a selected record
                IWebElement delete_button = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
                delete_button.Click();
            }
            else
            {
                Assert.Fail("Record to deleted has not been found.");
            }
                      
        }
       
        public void Assert_Deletelanguage(string language)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement editlanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(editlanguage.Text == language, "New Skills has not been deleted. Test failed!");
        }
    public void Cancel(string language,string level)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target' and @data-tab='first']//div[contains(@class, 'ui teal button') and text()='Add New']")));
            IWebElement AddNewTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewTab.Click();
            IWebElement Language_name = driver.FindElement(By.Name("name"));
            Language_name.SendKeys(language);
            Thread.Sleep(1000);
            IWebElement Level_selection = driver.FindElement(By.XPath("//select[@name='level']"));
            Level_selection.Click();
            IWebElement Level_option = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='{level}']"));
            Level_option.Click();
            Thread.Sleep(1000);
            IWebElement Cancel_button = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
            Cancel_button.Click();

        }  
    }
}

    


