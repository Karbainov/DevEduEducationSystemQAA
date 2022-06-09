Feature: GroupAllFunctionality

A short summary of the feature

@ManagerExitOutAccount
Scenario: I as user can login and log out
 Given I open Google Chrome browser
 And I login as an manager and enter in my account
	When I click on the button Exit
	Then I go to the login tab

@GroupManagerCreate
Scenario: I as manager can cancel create Group
 Given I open Google Chrome browser
 And I login as an manager and enter in my account
	When I fill in the fields pages of create group and click on the button Cancel
    |  Name   |
	| Group 1 |
	Then I go to the notifications tab

@GroupManagerCreate
Scenario: I as manager can create Group without students
 Given I open Google Chrome browser
 And I login as an manager and enter in my account
	When I fill all fields pages of create group <Name> and click on the button Save
	|  Name   |
	| Group 1 |
	Then I can see new group in the list all groups

#Scenario: I as manager I can create Group with students
# Given I login as an manager and enter in my account
#    #And I choose role for next step
#    #And I fill all fields pages of create group <Name> and click on the button Save
#	#|  Name   |
#	#| Group 1 |
#	When I can add students in Group
#	Then I can see new group in the list all groups

