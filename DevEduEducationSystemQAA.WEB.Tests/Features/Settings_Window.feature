Feature: Settings_Window

Окно настроект. Иземенение, данных пользователя

@SettingWindow
Scenario: As a user, I want to change my details and save them
 Given I log in to the system  with the window size <length> and <width>
    | Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	And I click the button Setting
	And I user, I enter the account settings window
	And I enter data in the fields that I want to change
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone       | LinkByGitHub        |
	| Ignatov | Ignat | Ignatovich | 31.08.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | 89990089090 | https://github.com/ |
	When Button click save in window setting
	Then Refresh the page changes should be saved
	Examples: 
	| length | width |
    | 1920   | 1080  |

	Scenario: As a user, I want to change my details and cancel them
	Given I log in to the system  with the window size <length> and <width>
    | Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	And I click the button Setting
	And I user, I enter the account settings window
	And I enter data in the fields that I want to change
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone       | LinkByGitHub        | 
	| James   | Harry | Potter     | 31.08.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | 89211234567 | https://github.com/ |
	When Button click cancel in window setting
	Then Should return to the notification window 
	Then Check that the changes are not saved
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone       | LinkByGitHub        |
	| Ignatov | Ignat | Ignatovich | 31.08.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | 89990089090 | https://github.com/ |
	Examples: 
	| length | width |
    | 1920   | 1080  |

	Scenario: As user, I want change my password and save

	Scenario: As user, I want change my password and cancel

	Scenario: As user, I wand add or change photo to my profile and save
	Given I log in to the system  with the window size <length> and <width>
    | Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	And I click the button Setting
	And I user, I enter the account settings window
	When I user, I click text Upload new photo
	Then A window should appear with cancel buttons and select a file
	Given Click button Select a file
	Then Photo should be changed
	Examples: 
	| length | width |
    | 1920   | 1080  |


	Scenario: As user, I want add or change photo to my profile and cancel
	Given I log in to the system  with the window size <length> and <width>
    | Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	And I click the button Setting
	And I user, I enter the account settings window
	And I user, I click text Upload new photo
	When Click on the cancel button to deselect the photo
	Then The message box for choosing a photo should close
	Examples: 
	| length | width |
    | 1920   | 1080  |



	
