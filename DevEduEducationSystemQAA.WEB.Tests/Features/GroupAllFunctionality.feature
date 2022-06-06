Feature: GroupAllFunctionality

A short summary of the feature
#And I create new users Teacher Tutor and Students
#| LastName  | FirstName |            | Patronymic          | Email     | Username  | Password        | City       | BirthDate     | GitHubAccount          | PhoneNumber     | Role  |
#| Петров    | Роман     | Степанович | PetrovRS@mail.ru    | PetrovRS  | Qwerty123 | Dnipro          | 12.03.1996 | GitHubAccount | https://www.figma.com/ | +79568746594521 |Teacher|
#| Kravcov   | Sergey    | Sergeevich | KravcovSS@mail.ru   | KravcovSS | Qwerty123 | SaintPetersburg | 10.03.1996 | GitHubAccount | https://www.figma.com/ | +79568746894522 |Tutor  |
#| Stepanova | Olga      | Glebovna   | StepanovaOG@mail.ru | PetrovRS  | Qwerty123 | Kyiv            | 28.03.1996 | GitHubAccount | https://www.figma.com/ | +79568746594523 |Student|
#| Kim       | Anton     | Petrovich  | KimAP@mail.ru       | KravcovSS | Qwerty123 | SaintPetersburg | 10.03.1996 | GitHubAccount | https://www.figma.com/ | +79568746894524 |Student|
#| Лыкова    | Роман     | Степанович | Лыкова@yandex.ru    | PetrovRS  | Qwerty123 | Dnipro          | 01.03.1996 | GitHubAccount | https://www.figma.com/ | 89568746594528  |Student|
#На этом шаге сохраняем в табличку пароль, email, role и ID

@tag1
Scenario: I as user can login and log out
 Given I open Google Chrome browser
 And I login as an manager and enter in my account
	When I click on the button Exit
	Then I go to the login tab

Scenario: I as manager can cancel create Group
 Given I open Google Chrome browser
 And I login as an manager and enter in my account
 And I choose role for next step
	When I fill in the fields pages of create group and click on the button Cancel
    |  Name   |
	| Group 1 |
	Then I go to the notifications tab

Scenario: I as manager can create Group without students
 Given I open Google Chrome browser
 And I login as an manager and enter in my account
  And I choose role for next step
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

