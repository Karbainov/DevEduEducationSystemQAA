Feature: MethodistCheckBaseFunctional

Check base functional for Methodist

@tag1
Scenario: User in role methodist create new course
	Given I create new user and get his token
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
	| FirstName | LastName | Patronymic | Email                      | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name          | Description           | Role      |
	| IIII      | III      | I          | qrtytretdrykrrerдq@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | dddfgrrа;rttd | Nqwhjhпsssrer;rwtto51 | Methodist |

Scenario: User in role methodist update course
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role> "Methodist"
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |
	And I update new course
	| Name      | Description      |
	| <NewName> | <NewDescription> |
	Then Should new course model coincide with the returned model of changes entities
	And Delete new course
	And Delete new user
	Examples: 
	| FirstName | LastName | Patronymic | Email                    | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name             | Description   | NewName          | NewDescription | Role      |
	| IIII      | III      | I          | qqqetrrrrrrfhret@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | sdfsrwrrkwfwdddo | sdfrr rdf4www | srdfsrjh4rdfdwww | trtwrwff5ffw   | Methodist |

Scenario: User in role methodist can get course by ID
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role> "Methodist"
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |	
	Then Should course model coincide with the returned model
	And Delete new course
	And Delete new user
	Examples: 
	| FirstName | LastName | Patronymic | Email                     | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name                | Description       | Role      |
	| IIII      | III      | I          | vbjvrrcrrrrttefeb@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | 1gfdn hgdrfttrrbtdg | dgffjk grjttrbrtd | Methodist |

@Negative
Scenario: User in role methodist can get course by ID.Negative
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role> "Methodist" 
	When I login as an Methodist and get course by not existing Id <Id>
	Then Should return 404 code response status
	Examples: 
	| FirstName | LastName | Patronymic | Email                 | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name       | Description  | Role      | Id |
	| IIII      | III      | I          | dddtttpqqwfwd@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | frrrfweuuu | lourr gffjjq | Methodist | -1 |