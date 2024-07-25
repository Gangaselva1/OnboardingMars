using System;
using OnboardingSpecflowProject.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OnboardingSpecflowProject.Utilities;

namespace OnboardingSpecflowProject.StepDefinitions
{
    [Binding]
    internal class Skills_FeatureStepDefinitions : Hook
    {
        //IWebDriver driver = new ChromeDriver();
        Login_Page loginPageObj = new Login_Page();
        Skill_Page skillstabobj = new Skill_Page();

        [Given(@"User Logs into Mars portal and navigates")]
        public void GivenUserLogsIntoMarsPortalAndNavigates()
        {
            loginPageObj.LoginSteps();
        }

        [Given(@"delete all the data  before test")]
        public void GivenDeleteAllTheDataBeforeTest()
        {
            skillstabobj.Clearthelist();
        }

        [When(@"User tries to add new skill '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewSkillAnd(string skill, string level)
        {
            skillstabobj.Add_Skills(skill,level);
        }
        [Then(@"The new skill  record has been added successfully '([^']*)' and '([^']*)'")]
        public void ThenTheNewSkillRecordHasBeenAddedSuccessfullyAnd(string skill, string level)
        {
            skillstabobj.AssertAddnewskill(skill, level);
        }
        //TC_02 Multiple data at the same time
        [When(@"User add a multiple skill and level at the same time <Skill> and <Level>")]
        public void WhenUserAddAMultipleSkillAndLevelAtTheSameTimeSkillAndLevel(Table table)
        {
            foreach (var row in table.Rows)
            {
                string Skills = row["Skill"];
                string levels = row["Level"];
                skillstabobj.Add_Skills(Skills,levels);
            }

        }
        [Then(@"All record has been added successfully <Skill> and <Level>")]
        public void ThenAllRecordHasBeenAddedSuccessfullySkillAndLevel(Table table)
        {
            var expectedSkills = table.Rows.Select(row => row["Skill"]).ToArray();
            var expectedlevels = table.Rows.Select(row => row["Level"]).ToArray();
            skillstabobj.AssertMultipleSkills(expectedSkills,expectedlevels);
        }
        //Create a record without entering data
        [When(@"User tries to create data without giving needed detaials '([^']*)' and level '([^']*)'")]
        public void WhenUserTriesToCreateDataWithoutGivingNeededDetaialsAndLevel(string skill, string level)
        {
            skillstabobj.Add_Skills(skill, level);
        }

        [Then(@"""([^""]*)""-> Popup message should be displayed")]
        public void Then_PopupMessageShouldBeDisplayed(string error)
        {
            skillstabobj.ErrorMessage();
        }

        //TC_06 and 07 Existing and duplicated data
        [When(@"User tries to add skill  which is already existed in the table '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddSkillWhichIsAlreadyExistedInTheTable(string skill, string level)
        {
            skillstabobj.Add_Skills(skill, level);
        }
        [Then(@"""([^""]*)""-> Popup message  displayed\.")]
        public void Then_PopupMessageDisplayed_(string p0)
        {
            skillstabobj.ErrorMessage_Existingdata();
        }

       //Duplicated data

        [Then(@"""([^""]*)""->  message should be displayed")]
        public void Then_MessageShouldBeDisplayed(string p0)
        {
            skillstabobj.ErrorMessage_Duplicatedata();
        }

        //Update Skill
        [When(@"User tries to update an existing skill record in the list '([^']*)' '([^']*)'")]
        public void WhenUserTriesToUpdateAnExistingSkillRecordInTheList(string oldskill, string newSkill)
        {
            skillstabobj.EditSkillRecord(oldskill, newSkill);
        }

        [Then(@"'([^']*)' skill  has been update successfully")]
        public void ThenSkillHasBeenUpdateSuccessfully(string newskill)
        {
            skillstabobj.AssertEditSkillRecord(newskill);
        }

        //TC_09
        [Then(@"This skill is already added to your skills list popup message will be displayed\.")]
        public void ThenThisSkillIsAlreadyAddedToYourSkillsListPopupMessageWillBeDisplayed_()
        {
            skillstabobj.Geterrorpopupmessage();
        }




        //TC_10 Deleting a record
        [When(@"User tries to delete an existing skill record in the list '([^']*)'")]
        public void WhenUserTriesToDeleteAnExistingSkillRecordInTheList(string skill)
        {
            skillstabobj.Delete_Skill(skill);
        }
        [Then(@"'([^']*)' skill  has been deleted successfully")]
        public void ThenSkillHasBeenDeletedSuccessfully(string skill)
        {
            skillstabobj.Assert_DeleteSkills(skill);
        }














    }
}
