Feature: Manager_Functionality

Как менеджер/админ, я хочу назначать роли юзерам

@tag1
Scenario: As manadger I want to assign a role to users
	Given Create future manadger
	| FirstName   | LastName    | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName > | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And Autorized as admin
	And Assing Minevra "Manager"
	Given Create new users for our roles
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	When Autorized by manager
	And Assing users role methodist, teacher, tutor
	| NameRole   |
	| <NameRole> |
	Then Сheck user roles
	Examples: 
	| FirstName | LastName    | Patronymic | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail        | NewUsername | NewPassword  | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | NameRole  |
	| Миневра   | Макгонагалл | Смит       | Smit@mail.ru  | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Хагрид       | Рубеус      | Колтрейн      | Rubeus6@mail.ru | Hagrid      | hagridRubeus | SaintPetersburg | 01.03.2003   | string           | 89211111111    | Methodist |
	| Миневра   | Макгонагалл | Смит       | Smit1@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Римус        | Джон        | Люпин         | Djon6@mail.ru   | Rimus       | rimusDjon    | SaintPetersburg | 01.03.1990   | string           | 89110001234    | Teacher   |
	| Миневра   | Макгонагалл | Смит       | Smit2@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Златопуст    | Локонс      | Брана         | Brana6@mail.ru  | Zlatopust   | zlatopust    | SaintPetersburg | 01.12.2001   | string           | 89210081122    | Tutor     |
	
	
	#Role      |
	# Manager  |
	#Methodist |
	#Teacher   |
	#Tutor     |