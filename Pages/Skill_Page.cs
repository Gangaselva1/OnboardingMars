using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OnboardingSpecflowProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.Debugger;
using OpenQA.Selenium.Support.UI;

namespace OnboardingSpecflowProject.Pages
{
    internal class Skill_Page : CommonDriver
    {
        private string e_message = "//div[@class='ns-box-inner']";
        public void Add_Skills(String skill, String level)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement skill_tab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill_tab.Click();
            IWebElement Add_NewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            Add_NewButton.Click();
            //AddSkill Text
            IWebElement AddSkillTextbox = driver.FindElement(By.Name("name"));
            AddSkillTextbox.SendKeys(skill);
            //SkillLevelDropDown            
            IWebElement SkillDropDownButton = driver.FindElement(By.XPath("//select[@name='level']"));
            //driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));                      
            SkillDropDownButton.Click();
            IWebElement SkillLevelOption = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='{level}']"));
            SkillLevelOption.Click();
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            AddButton.Click();
            Thread.Sleep(1000);
        }
        public void AssertAddnewskill(String skill, String level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newlevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            Assert.That(newSkill.Text == skill, "New Skills has not been created. Test failed!");
            Assert.That(newlevel.Text == level, "New level has not been created. Test failed!");
        }
        // Get the error message displayed
        public void Skill_ErrorMessage(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This skill is already exist in your skill list.')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This skill is already exist in your skill list.')]"));
            string errorMessageText = errorMessage.Text;
            string ex_Message = "This skill is already exist in your skill list.";
            Assert.That(errorMessage.Text == ex_Message, "Record has not been created. Test failed!");
        }

        public void Clearthelist()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement Skilltab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            Skilltab.Click();
            while (true)
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));

                    // Find the delete button for the last record
                    IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
                    deleteButton.Click();
                    Thread.Sleep(3000);
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
       
        public void AssertMultipleSkills(string[] skills, string[] levels)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            for (int i = 0; i < skills.Length; i++)
            {
                string skill = skills[i];
                string level = levels[i];
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]")));
                IWebElement skillElement = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]"));
                IWebElement levelElement = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[2]"));
                string actualSkillText = skillElement.Text.Trim();
                string actuallevelText = levelElement.Text.Trim();
                if (!string.Equals(actualSkillText, skill, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected skills '{skill}' at row {i + 1}, but found '{actualSkillText}'. Test failed!");
                }
                if (!string.Equals(actuallevelText, level, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected levels '{level}' at row {i + 1}, but found '{actuallevelText}'. Test failed!");
                }
            }


        }

        public void ErrorMessage()
        {
            // Error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter skill and experience level')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter skill and experience level')]"));
            string ex_Message = "Please enter skill and experience level";
            Assert.That(errorMessage.Text == ex_Message, "Record has not been created. Test failed!");
        }
        public void ErrorMessage_Existingdata()
        {
            // Error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This skill is already exist in your skill list.')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This skill is already exist in your skill list.')]"));
            string ex_Message = "This skill is already exist in your skill list.";
            Assert.That(errorMessage.Text == ex_Message, "Record has not been created. Test failed!");
        }
        public string ErrorMessage_Duplicatedata()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 3);
            //IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Duplicated data')]"));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Duplicated data')]"));
            return errorMessage.Text;
            Assert.That(errorMessage.Text == e_message, "Record has not been created. Test failed!");
        }
        public void Delete_Skill(string skill)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement Skilltab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            Skilltab.Click();
            IWebElement skillElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            string actualSkillText = skillElement.Text.Trim();
            while (true)
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));
                    if (actualSkillText == skill)
                    {
                        // Find the delete button for the last record
                        IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
                        deleteButton.Click();
                        break;
                        // Thread.Sleep(3000);
                    }
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
        public void Assert_DeleteSkills(string skill)
        {
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement editSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(editSkill.Text == skill, "New Skills has not been deleted. Test failed!");
        }

        public void EditSkillRecord(String oldSkill, String newSkill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement Skilltab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            Skilltab.Click();
            IWebElement lastrowButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td"));
            lastrowButton.Click();
            Thread.Sleep(1000);
            
            IWebElement recordToBeEdited = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (recordToBeEdited.Text == oldSkill)
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
                
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited has not been found.");
            }


            try
            {
                //Edit the code details
                IWebElement ccodeTextbox = driver.FindElement(By.Name("name"));
                ccodeTextbox.Clear();
                ccodeTextbox.SendKeys(newSkill);
            }
            catch (Exception ex)
            {
                Assert.Fail("Edit button isn't working", ex.Message);
            }

            //Click update
            IWebElement UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[4]/tr/td/div/span/input[1]"));
            UpdateButton.Click();
            Thread.Sleep(1500);                     
        }
        public void AssertEditSkillRecord(String newCode)
        {
            // Check if new Time record has been created successfully

            IWebElement lastrowButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td"));
            lastrowButton.Click();

            IWebElement code = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Assert.That(code.Text == newCode, "New time record has not been created. Test failed!");
        }
        public string Geterrorpopupmessage()
        {
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This skill is already added to your skill list.')]"));
            return errorMessage.Text;
        }

    }
}   


