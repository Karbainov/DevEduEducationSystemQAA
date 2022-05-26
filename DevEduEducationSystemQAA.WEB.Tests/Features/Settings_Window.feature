Feature: Settings_Window

Окно настроект. Иземенение, данных пользователя

@SettingWindow
Scenario: As a user, I want to change my details
 Given I log in to the system  with the window size <length> and <width>
    | Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	And I click the button Setting
	And I user, I enter the account settings window
	And I enter data in the fields that I want to change
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone       | LinkByGitHub        |
	| James   | Harry | Potter     | 31.08.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | 89211234567 | https://github.com/ |
	When Button click save in window setting
	Then Refresh the page changes should be saved
	Examples: 
	| length | width |
    | 1920   | 1080  |



	
