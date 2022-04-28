Feature: MethodistCheckBaseFunctional

Check base functional for Methodist

@Metodist
Scenario: User in role methodist create new course
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |
	Then Should Course Models coincide with the returned models of these entities
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name                | Description         | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | Samiy luchshiy kurs | Samiy luchshiy kurs | Methodist |

@Metodist
Scenario: User in role methodist update course
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |
	And I update new course
	| Name      | Description      |
	| <NewName> | <NewDescription> |
	Then Should new course model coincide with the returned model of changes entities
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name                | Description         | NewName                     | NewDescription              | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Samiy luchshiy kurs | Samiy luchshiy kurs | Samiy luchshiy kurs v tvoei | Samiy luchshiy kurs v tvoei | Methodist |

@Metodist
Scenario: User in role methodist can get course by ID
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |	
	Then Should course model coincide with the returned model
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name                                | Description                         | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Samiy luchshiy kurs v tvoei zchizni | Samiy luchshiy kurs v tvoei zchizni | Methodist |

@Metodist @Negative
Scenario: User in role methodist can get course by ID.Negative
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role> 
	When I login as an Methodist and get course by not existing Id <Id>
	Then Should return 404 code response status
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username  | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name          | Description | Role      | Id |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT    | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | ProstoCourse  | l;sjdhsg    | Methodist | -1 |
	| Petr      | Seredin  | Petrovich  | Seredin@mail.ru    | SeredinPP | qwerty123 | Dnipro | 02.02.1993 | string        | 899912347896 | ProstoCourse2 | l;sjdhsg    | Methodist | 0  |

@Metodist
Scenario: User in role methodist can delete course by ID
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |	
	Then Should course model coincide with the returned model
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name                                | Description                         | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Samiy luchshiy kurs v tvoei zchizni | Samiy luchshiy kurs v tvoei zchizni | Methodist |