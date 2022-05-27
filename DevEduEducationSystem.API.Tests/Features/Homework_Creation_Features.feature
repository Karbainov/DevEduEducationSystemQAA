Feature: Homework_Creation_Features

1.)Как преподаватель, я могу выдавать д.з.
2.)Как преподаватель, я могу изменять д.з.
3.)Как преподаватель, я могу удалять д.з.

@Homework
Scenario: As a teacher, I can give homework 
	Given Create  user
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as admin "user@example.com" , "stringst"
	And Assing  User "Teacher"
	And Create  course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create  Groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            | 3             |
	And Add users to group
	And Create task
	| Name            | Description                                 | Links | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски |       | true       |
	And Authorized by teacher
	When Create Homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Get Homework By Id 
	Then Created homework should return
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 |

	@Negative
	Scenario: As a teacher, I can give homework. Negative
	Given Create  user
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as admin "user@example.com" , "stringst"
	And Assing  User "Teacher"
	And Create  course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create  Groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            | 3             |
	And Add users to group
	And Create task
	| Name            | Description                                 | Links | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски |       | true       |
	And Authorized by teacher
	When Create Homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	Then The created homework status code should be 422
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.1760 | 10.10.1761 |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2023 | 10.10.2022 |

	@Homework
	Scenario: As a teacher, I can change my homework
	Given Create  user
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as admin "user@example.com" , "stringst"
	And Assing  User "Teacher"
	And Create  course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create  Groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            | 3             |
	And Add users to group
	And Create task
	| Name            | Description                                 | Links | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски |       | true       |
	And Authorized by teacher
	And Create Homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	When Edit a previously created homework
	| StartDate    | EndDate    |
	| <StartDate2> | <EndDate2> |
	And Get Homework By Id 
	Then Сheck the modified homework should have come
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | StartDate2 | EndDate2   |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | 10.01.2022 | 10.11.2022 |

	@Homework
	Scenario: As a teacher, I can delete my homework
	Given Create  user
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as admin "user@example.com" , "stringst"
	And Assing  User "Teacher"
	And Create  course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create  Groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            | 3             |
	And Add users to group
	And Create tasks
	| Name                        | Description                                 | Links | IsRequired |
	| Ищем Q на клаве             | Первые 2 часа история, вторые 2 часа поиски |       | true       |
	| Ищем время                  | Как искать время                            |       | true       |
	| Ищем телегу                 | Как искать телегу                           |       | true       |
	| Как отвечать,но не ответить | Сложная филосовская наука                   |       | true       |
	And Authorized by teacher
	And Create Homeworks
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	| <StartDate2> | <EndDate2> |
	| <StartDate3> | <EndDate3> |
	| <StartDate4> | <EndDate4> |
	When Delete previously created homework
	And Get all homeworks by group 
	Then Check homework should be deleted
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | StartDate2 | EndDate2   | StartDate3 | EndDate3   | StartDate4 | EndDate4   |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.01.2022 | 11.01.2022 | 20.01.2022 | 21.01.2022 | 25.01.2022 | 26.01.2022 | 01.02.2022 |

	