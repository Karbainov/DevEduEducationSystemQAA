Feature: MethodistCheckBaseFunctional

Check base functional for Methodist

@tag1
Scenario: User in role methodist create new course
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role> "Methodist"
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |
	Then Should Course Models coincide with the returned models of these entities
	And Delete new course
	And Delete new user
	Examples: 
	| FirstName | LastName | Patronymic | Email             | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name                    | Description                                       | Role      |
	| IIII      | III      | I          | lastluser@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | ChudoCtttorursftffrrlre1 | SOamtttttiry lucffffrrrdhiy cjourse v tvoei zhizni | Methodist |
