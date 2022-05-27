Feature: MethodistCheckBaseFunctional

Check base functional for Methodist

@Metodist
Scenario: User in role methodist create new course
	Given I create new user
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
	Given I create new user
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
	Given I create new user
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
	Given I create new user
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
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name   | Description   |
	| <Name> | <Description> |	
	And I deleting new course 
	And I get new course by id full models
	And I get all courses
	Then Field IsDeleted full models course must be true 
	Then In the list of all courses can't be a remote course 
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name                                | Description                         | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Samiy luchshiy kurs v tvoei zchizni | Samiy luchshiy kurs v tvoei zchizni | Methodist |
	
@Metodist
Scenario: User in role methodist can see all courses
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new courses
	| Name     | Description                                       |
	| Course 1 | Samiy luchshiy kurs                               |
	| Course 2 | Samiy luchshiy kurs v tvoei zchizni               |
	| Course 3 | Samiy luchshiy kurs v tvoei zchizni.Perezagruzka. |
	And I get all courses
	Then The list contains all created courses
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Methodist |

@Metodist
Scenario: User in role methodist add new topics to the course in a certain sequence
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name     | Description           |
	| Course 1 | Samiy luchshiy kurs   |
	And I create topics under login Methodist 	
	| Name    | Duration |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	| Thema 3 | 2        |
	| Thema 4 | 4        |
	And I add course topics on position
	| Name    | Position |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	| Thema 3 | 3        |
	| Thema 4 | 4        |
	Then I get a course by id and the returned model contains all the topics at a given position
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Methodist |

@Metodist
Scenario: User in role methodist change the sequence of topics
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name     | Description           |
	| Course 1 | Samiy luchshiy kurs   |
	And I create topics under login Methodist	
	| Name    | Duration |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	| Thema 3 | 4        |
	| Thema 4 | 1        |
	And I add course topics on position
	| Name    | Position | 
	| Thema 1 | 1        | 
	| Thema 2 | 2        |
	| Thema 3 | 3        |
	| Thema 4 | 4        |
	And I am changing the positions of the topics of the course
	| Name    | Position | 
	| Thema 1 | 3        | 
	| Thema 2 | 4        |
	| Thema 3 | 1        |
	| Thema 4 | 2        |
	#Then I get a course by id and the returned model contains all the topics at a given position
	Then I get all topics of courses by Id and the returned model contains all the topics at a given new positions
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Methodist |

@Metodist
Scenario: User in role methodist I want to see all courses and added topics in the courses
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new courses
	| Name     | Description           |
	| Course 1 | Samiy luchshiy kurs   |
	| Course 2 | Samiy luchshiy kurs 2 |
	And I create topics under login Methodist
	| Name    | Duration |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	| Thema 3 | 4        |
	| Thema 4 | 1        |
	And I add "Course 1" topics on position
	| Name    | Position | 
	| Thema 1 | 1        | 
	| Thema 2 | 2        |
	| Thema 3 | 3        |
	| Thema 4 | 4        |
	Then I get course "Course 1" and check that he containes topics
	Then I get course "Course 2" and check that he doesn't containes topics
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Methodist |

@Metodist
Scenario: User in role methodist to delete the topic of the course 
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And I login as an admin and give new user role <Role>
	When I login as an Methodist and create new course
	| Name     | Description           |
	| Course 1 | Samiy luchshiy kurs   |
	And I create topics under login Methodist	
	| Name    | Duration |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	| Thema 3 | 4        |
	| Thema 4 | 1        |
	And I delete "Thema 1" 
	And I delete "Thema 3" 
	Then I get course by id and check that he doesn't containes deleted topics
	| Name            |
	| Thema 1,Thema 3 |
	Examples: 
	| FirstName | LastName | Patronymic | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Role      |
	| Ivan      | Troyanov | Petrovich  | TroyanovIP@mail.ru | IvanPT   | qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | Methodist |

