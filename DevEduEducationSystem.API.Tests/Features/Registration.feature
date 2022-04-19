Feature: Registration

Страница регистрации новых клиентов (студентов)


Scenario: 1Registration in system
	Given Create registration model
	| FirstName | LastName | Patronymic | Email                                   | Username | Password      | City            | BirthDate  | GitHubAccount | PhoneNumber  |
	| Северус   | Снейп    | Аланович   | Severus9wedr8990yggiпlfd09gdfdklоkfрhlрlj@mail.ru | север    | северусСнейп  | SaintPetersburg | 01.01.1993 |   string      | 89991234567  |
	When Activate registration endpoint
	And Activate Authorization method
	And Get User Models by id
	Then Should User Models coincide with the returned models of these entities
	Given Create too old, too young and write a thong in the phone number string
	| FirstName | LastName  | Patronymic   | Email              | Username       | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber        | 
	| Малыш     | Малышев   | Малышович    | Малыш1@mail.ru     | БоссМолокосос  | северусСнейп | SaintPetersburg | 09.01.2021 |   string      | 89991234567        |
	| Альбрехт  | Вильгельм | Эдуардович   | Вильгельм1@mail.ru | Альбрехт       | Вильгельм    | SaintPetersburg | 04.03.1800 | string        | 89991234567        | 
	| Телефон   | Телефонов | Телефонович  | Телефон1@mail.ru   | Телефончик     | Телефонама   | SaintPetersburg | 04.03.2003 |   string      | Чукча кушать хочет |
	Then Should return UnprocessableEntity response

Scenario: 2Authorization in system and Update User
	Given New model User
	| FirstName | LastName | Patronymic | Email                                | Username | Password   | City            | BirthDate  | GitHubAccount | PhoneNumber  |
	| Богданов  | Арутр    | Ашотович   | Ashotikew8d009fdgfygоkllkfdfgрlgjпfрlh@mail.ru | Ashot    | Qwerty123  | SaintPetersburg | 01.01.1993 |   string      | 89991234563  |
	When I want update user model
	And Get new User Model by id
	#Then Should my new model user with the returned models of these entities
	Then Get Admins Token
	| Email            | Password |
	| user@example.com | stringst |
	And Delete user