Feature: Settings_Window

Окно настроект. Иземенение, данных пользователя

@tag1
Scenario: As a user, I want to change my details
	Given I user, I enter the account settings window
	And I enter data in the fields that I want to change
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone       | LinkByGitHub        |
	| James   | Harry | Potter     | 31.08.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | 89211234567 | https://github.com/ |


	
