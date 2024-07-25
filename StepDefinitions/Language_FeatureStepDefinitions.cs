using System;
using OnboardingSpecflowProject.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OnboardingSpecflowProject.Utilities;
using System.Reflection.Emit;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace OnboardingSpecflowProject.StepDefinitions
{
    [Binding]
    internal class Language_FeatureStepDefinitions : CommonDriver
    {
        //driver = new ChromeDriver();
        Login_Page loginPageObj = new Login_Page();
        Language_Page languagetabobj = new Language_Page();

        [Given(@"User Logs into Mars portal and navigates to language tab")]
        public void GivenUserLogsIntoMarsPortalAndNavigatesToLanguageTab()
        {
            loginPageObj.LoginSteps();
        }

        [Given(@"Clean the data before test")]
        public void GivenCleanTheDataBeforeTest()
        {          
            languagetabobj.Clear_Data();
        }

        // TC_01 Add new language and level record

        [When(@"User tries to add new language and level '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddNewLanguageAndLevel(string language, string level)
        {
           languagetabobj.AddLanguage_Level(language, level);
        }
        [Then(@"The new language  record added successfully '([^']*)' '([^']*)'")]
        public void ThenTheNewLanguageRecordAddedSuccessfully(string language, string level)
        {
            languagetabobj.Assert_AddLanguageAndLevel(language, level);
        }



        //TC_02,03 and TC_04 User cannot able to create record without needed info
        [When(@"User creates a record without language name '([^']*)' and level '([^']*)'")]
        public void WhenUserCreatesARecordWithoutLanguageNameAndLevel(string language, string level)
        {
            languagetabobj.AddLanguage_Level(language, level);
        }
        [Then(@"""([^""]*)""-> Error message should be displayed")]
        public void Then_ErrorMessageShouldBeDisplayed(string ex_Message)

        {

            //languagetabobj.Empty_ErrorMessage();
            languagetabobj.GetEmpty_DataMessage();
            //GetEmpty_DataMessage
        }

        //TC_04  Verify user cannot add existing data
        [When(@"User tries to create Language  which is already existed in the table '([^']*)' '([^']*)'")]
        public void WhenUserTriesToCreateLanguageWhichIsAlreadyExistedInTheTable(string language, string level)
        {
            languagetabobj.AddLanguage_Level(language, level);
        }

        [Then(@"""([^""]*)""->   message should be displayed")]
        public void Then_MessageShouldBeDisplayed(string message)
        {
            languagetabobj.DuplicateData_ErrorMessage();
            //languagetabobj.GetErrorMessage_Existingdata();
        }


        //TC_07 Edit and Update the record
        [When(@"User edits language record '([^']*)' and '([^']*)'")]
        public void WhenUserEditsLanguageRecordAnd(string language, string level)
        {
            languagetabobj.Update_Language(language,level);
        }

       
        [Then(@"'([^']*)' has been updated to your languages")]
        public void ThenHasBeenUpdatedToYourLanguages(string language)
        {
            languagetabobj.Assert_UpdateLanguageAndLevel(language);
        }

        //Updation error message

        [Then(@"""([^""]*)"" message should be displayed")]
        public void ThenMessageShouldBeDisplayed(string p0)
        {
            languagetabobj.Updation_ErrorMessage();
        }


        //TC_08 Verify user is able to add multiple number of languages in the table
        [When(@"User tries to add number of records <Language> and <Level>")]
        public void WhenUserTriesToAddNumberOfRecordsLanguageAndLevel(Table table)
        {
            foreach (var row in table.Rows)
            {
                string languages = row["Language"];
                string levels = row["Level"];
                languagetabobj.AddLanguage_Level(languages, levels);
            }
        }
        [Then(@"All Language record should be created successfully <Language> and <Level>")]
        public void ThenAllLanguageRecordShouldBeCreatedSuccessfullyLanguageAndLevel(Table table)
        {
            var expectedLanguages = table.Rows.Select(row => row["Language"]).ToArray();
            var expectedLevels = table.Rows.Select(row => row["Level"]).ToArray();
            languagetabobj.AssertMultipleLanguages_Level(expectedLanguages, expectedLevels);

        }



        //TC_09 Delete the record from the list
        [When(@"User tries to delete an existing record in the list '([^']*)'")]
        public void WhenUserTriesToDeleteAnExistingRecordInTheList(string language)
        {
            languagetabobj.Delete_language(language);
        }
        [Then(@"'([^']*)' Langugae  has been deleted successfully")]
        public void ThenLangugaeHasBeenDeletedSuccessfully(string language)
        {
            languagetabobj.Assert_Deletelanguage(language);
        }
        //Using Cancel button
        [When(@"User tries to delete an existing record in the list '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToDeleteAnExistingRecordInTheListAnd(string language, string level)
        {
            languagetabobj.Cancel(language, level);
        }
        [Then(@"Cancel  Langugae  has been  successfully done")]
        public void ThenCancelLangugaeHasBeenSuccessfullyDone()
        {
            Console.WriteLine("Record Creation Cancelled");
        }

    }
}
