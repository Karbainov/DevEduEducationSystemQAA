Feature: Registration_Window

Registration window (окно регистрации)

@RegistrationWindow
Scenario: As a user, I want to register
    Given I enter the registration window 
	And I am a user fill in all required fields
	| Surname | Name  | Patronymic | BirthDate  | Password    | RepeatPassword | Email         | Phone        |
	| Джеймс  | Гарри | Поттер     | 31.07.1998 | HarryPotter | HarryPotter    | Harry@mail.ru | +79211234567 |
	#And Click checkbox on the privacy policy 
	#When Click on the privacy policy link
	#When Click on register button
	
	 
