Feature: MethodistCheckBaseFunctional

Check base functional for Methodist

@tag1
Scenario: User in role methodist create new course
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role "Methodist"
	When I login as an "Methodist" and create new course with name <Name> and description <Description>
	Then Should Course Models coincide with the returned models of these entities
	Examples: 
	| FirstName | LastName | Patronymic | Email        | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name | Description                        |
	| IIII      | III      | I          | i123@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | III  | Samiy luchiy course v tvoei zhizni |
