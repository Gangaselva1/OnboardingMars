Feature: Language_feature

A short summary of the feature

@tag1
Scenario: TC_01 Add new language and level record
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test 
When User tries to add new language and level 'English' 'Conversational'
Then The new language  record added successfully 'English' 'Conversational'


Scenario: TC_02 Verify user cannot create a data without language name
Given User Logs into Mars portal and navigates to language tab
When User creates a record without language name '' and level 'Fluent'
Then  "Please enter language and level"-> Error message should be displayed

Scenario: TC_03 Verify user cannot create a data without level name
Given User Logs into Mars portal and navigates to language tab
When User creates a record without language name 'English' and level ''
Then  "Please enter language and level"-> Error message should be displayed

Scenario: TC_04 Verify user cannot create a data without entering the details
Given User Logs into Mars portal and navigates to language tab
When User creates a record without language name '' and level ''
Then  "Please enter language and level"-> Error message should be displayed

Scenario: TC_05 Verify user cannot add existing data
Given User Logs into Mars portal and navigates to language tab
When User tries to create Language  which is already existed in the table 'English' 'Conversational'
Then "This language is already exist in your language list."->   message should be displayed

Scenario: TC_06 Verify user cannot create Duplicated data
Given User Logs into Mars portal and navigates to language tab
When User tries to create Language  which is already existed in the table 'English' 'Basic'
Then "Duplicated data"->  message should be displayed

Scenario: TC_07 Verify user is able to edit "Language" in the table
Given User Logs into Mars portal and navigates to language tab
When User edits language record 'German' and 'Conversational'
Then 'German' has been updated to your languages 

Scenario: TC_08 Verify user is able to edit "Language" in the table
Given User Logs into Mars portal and navigates to language tab
When User edits language record 'German' and 'Conversational'
Then "This language is already added to your language list." message should be displayed

Scenario: TC_09 User is able to cancel "Language"  while adding
Given User Logs into Mars portal and navigates to language tab
When User tries to delete an existing record in the list 'English' and 'Fluent'
Then Cancel  Langugae  has been  successfully done



Scenario Outline:  TC_10 Verify user is able to add multiple number of languages in the table
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
When User tries to add number of records <Language> and <Level>

              | Language |  | Level  |
              | English  |  | Basic  |
              | Chinese  |  | Basic  |
              | Tamil    |  | Fluent |
              | French   |  | Basic  |


Then All Language record should be created successfully <Language> and <Level>

              | Language |  | Level  |
              | English  |  | Basic  |
              | Chinese  |  | Basic  |
              | Tamil    |  | Fluent |
              | French   |  | Basic  |

Scenario: TC_11 User is able to delete "Language"  which is already in the table
Given User Logs into Mars portal and navigates to language tab
When User tries to delete an existing record in the list 'French'
Then 'French' Langugae  has been deleted successfully








 





    
    
      