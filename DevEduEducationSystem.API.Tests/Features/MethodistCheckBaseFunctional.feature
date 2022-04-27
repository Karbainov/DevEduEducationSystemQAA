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
	And Delete new course
	And Delete new user
	Examples: 
	| FirstName | LastName | Patronymic | Email                            | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name          | Description           | Role      |
	| IIII      | III      | I          | qrtytret341qqq234drykrrerдq@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | dddfgrrfdа;rttd | Nqwhjhпsssrer;rwtto51 | Methodist |

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
	And Delete new course
	And Delete new user
	Examples: 
	| FirstName | LastName | Patronymic | Email     | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name             | Description   | NewName          | NewDescription | Role      |
	| IIII      | III      | I          | m@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | sdfsrsdfswrrkwfwdddo | sdfsdfsrr rdf4www | srdfsrjh4rdfdwww | trtwrwff5ffw   | Methodist |

Scenario: User in role methodist can get course by ID
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |	
	Then Should course model coincide with the returned model
	And Delete new course
	And Delete new user
	Examples: 
	| FirstName | LastName | Patronymic | Email                     | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name                | Description       | Role      |
	| IIII      | III      | I          | vbjvrqqqqrcr2341rrrttefeb@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | 1gfdn hgdrfttdfsdfrrbtdg | dgffjk grjttrbrtd | Methodist |

@Negative
Scenario: User in role methodist can get course by ID.Negative
	Given I create new user and get his token
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role> 
	When I login as an Methodist and get course by not existing Id <Id>
	Then Should return 404 code response status
	Examples: 
	| FirstName | LastName | Patronymic | Email                 | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber | Name       | Description  | Role      | Id |
	| IIII      | III      | I          | dddttqqqqpqq2341wfwd@mail.ru | iiii     | qwerty123 | Dnipro | 02.02.1993 | string        | 89991234567 | frrrfwesdfsdfsduuu | lourr gffjjq | Methodist | -1 |