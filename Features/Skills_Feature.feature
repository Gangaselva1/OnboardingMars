Feature: Skills_Feature

A short summary of the feature

@tag1
Scenario: TC_01 Add new Skill and level record
Given User Logs into Mars portal and navigates
And delete all the data  before test 
When User tries to add new skill 'C' and 'Intermediate'
Then The new skill  record has been added successfully 'C' and 'Intermediate'

Scenario Outline: TC_02  Verify user is able to create multiple skills
Given User Logs into Mars portal and navigates 
And  delete all the data  before test 
When User add a multiple skill and level at the same time <Skill> and <Level>
      | Skill | Level        |
      | C     | Beginner     |
      | C++   | Expert       |
      | C#    | Intermediate |
      | Java  | Expert       |
 
Then All record has been added successfully <Skill> and <Level> 
      | Skill | Level        |
      | C     | Beginner     |
      | C++   | Expert       |
      | C#    | Intermediate |
      | Java  | Expert       |

Scenario: TC_03 Verify user cannot create a data without skill
Given User Logs into Mars portal and navigates 
When User tries to create data without giving needed detaials '' and level 'Beginner'
Then  "Please enter skill and experience level"-> Popup message should be displayed

Scenario: TC_04 Verify user cannot create a data without level 
Given User Logs into Mars portal and navigates  
When User tries to create data without giving needed detaials 'Music' and level ''
Then  "Please enter skill and experience level"-> Popup message should be displayed

Scenario: TC_05 Verify user cannot create a data without entering the details
Given User Logs into Mars portal and navigates 
When User tries to create data without giving needed detaials '' and level ''
Then  "Please enter skill and experience level"-> Popup message should be displayed

Scenario: TC_06 Verify user cannot add existing data
Given User Logs into Mars portal and navigates 
When User tries to add skill  which is already existed in the table 'C++' 'Expert'
Then "This skill is already exist in your skill list."-> Popup message  displayed.


Scenario: TC_07 Verify user cannot create Duplicated data
Given User Logs into Mars portal and navigates 
When User tries to add skill  which is already existed in the table 'C++' 'Intermediate'
Then "Duplicated data"->  message should be displayed

Scenario: TC_08 User is able to update "Skill"  which is already in the table
Given User Logs into Mars portal and navigates 
When User tries to update an existing skill record in the list 'Java' 'Music'
Then 'Music' skill  has been update successfully

Scenario: TC_09 User is able to update "Skill"  which is already in the table
Given User Logs into Mars portal and navigates 
When User tries to update an existing skill record in the list 'Music' 'Music'
Then This skill is already added to your skills list popup message will be displayed.



Scenario: TC_10 User is able to delete "Skill"  which is already in the table
Given User Logs into Mars portal and navigates 
When User tries to delete an existing skill record in the list 'Music'
Then 'Music' skill  has been deleted successfully

