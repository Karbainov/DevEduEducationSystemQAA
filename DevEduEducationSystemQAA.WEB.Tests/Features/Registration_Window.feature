Feature: Registration_Window

Registration window (окно регистрации)

@RegistrationWindow
Scenario: As a user, I want to register
    Given I enter the registration window with the window size <length> and <width>
	And I am a user fill in all required fields
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone        |
	| Джеймс  | Гарри | Поттер     | 31.07.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | +79211234567 |
	When Click on register button
	#Then When the Privacy Policy checkbox is unchecked, the Register button should be inactive
	Given Click checkbox on the privacy policy 
	#When Click on the privacy policy link - оставлено до лучших времен - возможно вынесу в другой сценарий
	When Click on register button
	Then Сheck that a registered user will log into the application
	And Delete User
	Examples: 
	| length | width |
	| 1920   | 1080  |
	
	@RegistrationWindow
	Scenario: As a user when registering, I want to click on the "Cancel" button
	Given I enter the registration window with the window size <length> and <width>
	And I am a user fill in all required fields
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone        |
	| Джеймс  | Гарри | Поттер     | 31.07.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | +79211234567 |
	And Click checkbox on the privacy policy
	When Click on "Cancel" button
	Then The registration window should return to the Login window.
	Examples: 
	| length | width |
	| 1920   | 1080  |


	@Negative
	Scenario: As a user, I want to register.Negative
	Given I enter the registration window with the window size <length> and <width>
	And I am a user fill in all required fields
	| Surname   | Name   | Patronymic   | BirthDate   | Password    | RepeatPassword   | Email         | Phone        |
	| <Surname> | <Name> | <Patronymic> | <BirthDate> | <Password>  | <RepeatPassword> | <Email>       | <Phone>      |
	And Click checkbox on the privacy policy 
	When Click on register button
	Then The system should respond, the register button will be inactive
	And Delete users
	Examples: 
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email          | Phone              | length | width |
	| Джеймс  | Гарри | Поттер     | 30.01.1800 | HarryPotter | HarryPotter    | Harry1@mail.ru | +79211234567       | 1920   | 1080  |
	| Джеймс  | Гарри | Поттер     | 31.07.1998 | HarryPotter | HarryPotter    | Harry2@mail.ru | Чукча кушать хочет | 1920   | 1080  |
	| Джеймс  | Гарри | Поттер     | 31.07.1998 | HarryPotter | HarryPotter    | Я email        | +79211234567       | 1920   | 1080  |
	
	 
	
	 
