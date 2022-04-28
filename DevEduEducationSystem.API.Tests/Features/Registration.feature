Feature: User CRUD

Страница регистрации новых клиентов (студентов)

@User 
Scenario: Registration in system
	When I register
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And Autorized by <Email> and <Password>
	And Get User by my Id
	Then Should User Models coincide with the returned models of these entities
Examples: 
	| FirstName | LastName | Patronymic | Email           | Username | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Северус   | Снейп    | Аланович   | severus@mail.ru | север    | северусСнейп | SaintPetersburg | 01.01.1993 | string        | 89991234567 |
	| Северус   | Снейп    | Аланович   | severus@mail.ru | север    | северусСнейп | SaintPetersburg | 01.01.1993 | string        | 89991234567 |


@Negative
Scenario: Registration in system. Negative
	When I try to register as
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	Then Should return 422 status code response
Examples:
	| FirstName | LastName  | Patronymic  | Email             | Username      | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber        |
	| Малыш     | Малышев   | Малышович   | Малыш@mail.ru     | БоссМолокосос | северусСнейп | SaintPetersburg | 09.01.2021 | string        | 89991234567        |
	| Альбрехт  | Вильгельм | Эдуардович  | Вильгельм@mail.ru | Альбрехт      | Вильгельм    | SaintPetersburg | 04.03.1800 | string        | 89991234567        |
	| Телефон   | Телефонов | Телефонович | Телефон@mail.ru   | Телефончик    | Телефонама   | SaintPetersburg | 04.03.2003 | string        | Чукча кушать хочет |
	|           |           |             |                   |               |              |                 |            |               |                    |

@User
Scenario: Update User
	Given I register
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	When Autorized by <Email> and <Password>
	And I Update myself
	| FirstName      | LastName      | Patronymic      |    Email   | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Get User by my Id
	Then Should User Models coincide with the returned models of these entities
Examples: 
	| FirstName | LastName | Patronymic | Email           | Username | Password  | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewUsername | NewEmail        | NewCity | NewBirthDate | NewGitHubAccount | NewPhoneNumber |
	| Северус   | Снейп    | Аланович   | severus@mail.ru | север    | Qwerty123 | SaintPetersburg | 01.01.1993 | string        | 89991234567 | Богданов     | Арутр       | Ашотович      | Ashot       | severus@mail.ru | Dnipro  | 01.02.1993   | string           | 89991234563    |


@Negative	
	Scenario: Delete User
	Given I register
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	When Autorized by <Email> and <Password>
	And I Deleted created User By ID
	Then Delete user can not pass authorization by <Email> and <Password>
	And Delete user not found in list all Users
Examples: 
	| FirstName | LastName | Patronymic | Email       | Username | Password  | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| QQQ       | YYY      | AAA        | QYA@mail.ru | QYA      | qwerty123 | SaintPetersburg | 02.02.1992 | string        | 89991234567 |