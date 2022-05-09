﻿Feature: Organization_of_the_delivery_and_verification_of_the_student_is_homework_with_the_ability_to_leave_comments

1.) Как преподавтель/тьютор я могу оставлять комментарий про домашнюю работу
2.) Как преподователь, я могу принимать домашнюю работу от студента
3.)Как студент, я могу сдавать своб домашнюю работу
4.)Как студент, я могу оставлять комментарии под домашней работай

@Chat
Scenario: As a teacher, I can leave comments about homework
	Given Create Users
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as Admin "user@example.com" , "stringst"
	And Assing user "Teacher" and removing the role assigned by default
	And Create Course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	And Add Users to group
	And Create Task
	| Name            | Description                                 | Links                                                                             | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски | @https://piter-education.ru:7070/swagger/index.html#/Comments/Comments_GetComment | true       |
	And Authorized by Teacher
	And Create homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Authorized by student
	And I am a student adding my homework
	| Answer   |
	| <Answer> |
	And Authorized by Teacher 
	When  Add new comment to student answer
	| Text   |
	| <Text> |
	And  Get comment by id
	Then Check that the comment sent by the teacher under the student's homework should have been returned by id
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |


	@Chat
Scenario: As a tutor, I can leave comments about homework
	Given Create Users
	| FirstName       | LastName       | Patronymic       | Email       | Username       | Password       | City       | BirthDate       | GitHubAccount       | PhoneNumber       |
	| <FirstName>     | <LastName >    | <Patronymic>     | <Email>     | <Username>     | <Password>     | <City>     | <BirthDate>     | <GitHubAccount>     | <PhoneNumber>     |
	| <NewFirstName>  | <NewLastName>  | <NewPatronymic>  | <NewEmail>  | <NewUsername>  | <NewPassword>  | <NewCity>  | <NewBirthDate>  | <NewGitHubAccount>  | <NewPhoneNumber>  |
	| <NewFirstName2> | <NewLastName2> | <NewPatronymic2> | <NewEmail2> | <NewUsername2> | <NewPassword2> | <NewCity2> | <NewBirthDate2> | <NewGitHubAccount2> | <NewPhoneNumber2> |
	And Autorized as Admin "user@example.com" , "stringst"
	And Assing user "Teacher" and "Tutor" removing the role assigned by default
	And Create Course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	And Add Users to group
	And Create Task
	| Name            | Description                                 | Links                                                                             | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски | @https://piter-education.ru:7070/swagger/index.html#/Comments/Comments_GetComment | true       |
	And Authorized by Teacher
	And Create homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Authorized by student
	And I am a student adding my homework
	| Answer   |
	| <Answer> |
	And Authorized by Tutor 
	When  Add as tutor new comment to student answer
	| Text   |
	| <Text> |
	And  Get comment by ID
	Then Check that the comment sent by the tutor under the student's homework should be returned by id
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | NewFirstName2 | NewLastName2 | NewPatronymic2 | NewEmail2      | NewUsername2 | NewPassword2 | NewCity2        | NewBirthDate2 | NewGitHubAccount2 | NewPhoneNumber2 |StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | Иван          | Макаров      | Кучерявый      | Ivan91@mail.ru | Vanka        | VankaVstanka | SaintPetersburg | 01.01.2003    | string            | 89112112345     |01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |




	@StudentHomework
	Scenario: As a teacher, can I get homework
	Given Create Users
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as Admin "user@example.com" , "stringst"
	And Assing user "Teacher" and removing the role assigned by default
	And Create Course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	And Add Users to group
	And Create Task
	| Name            | Description                                 | Links                                                                             | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски | @https://piter-education.ru:7070/swagger/index.html#/Comments/Comments_GetComment | true       |
	And Authorized by Teacher
	And Create homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Authorized by student
	And I am a student adding my homework
	| Answer   |
	| <Answer> |
	And Authorized by Teacher 
	When Get student homework by id
	Then I am a teacher checking that the homework submitted by the student should be returned by id
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |

	@StudentHomework
	Scenario: As a teacher, I can accept homework from a student
	Given Create Users
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as Admin "user@example.com" , "stringst"
	And Assing user "Teacher" and removing the role assigned by default
	And Create Course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	And Add Users to group
	And Create Task
	| Name            | Description                                 | Links                                                                             | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски | @https://piter-education.ru:7070/swagger/index.html#/Comments/Comments_GetComment | true       |
	And Authorized by Teacher
	And Create homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Authorized by student
	And I am a student adding my homework
	| Answer   |
	| <Answer> |
	And Authorized by Teacher 
	When I teacher and can approve student homework
	Then Сheck selected homework should have been approved
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |

	@StudentHomework
	Scenario: As a teacher, I can decline student homework
	Given Create Users
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as Admin "user@example.com" , "stringst"
	And Assing user "Teacher" and removing the role assigned by default
	And Create Course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	And Add Users to group
	And Create Task
	| Name            | Description                                 | Links                                                                             | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски | @https://piter-education.ru:7070/swagger/index.html#/Comments/Comments_GetComment | true       |
	And Authorized by Teacher
	And Create homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Authorized by student
	And I am a student adding my homework
	| Answer   |
	| <Answer> |
	And Authorized by Teacher 
	When I teacher and can decline student homework
	Then Сheck selected homework should have been declined
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |

	@StudentHomework
	Scenario: As a student, I can submit my homework
	Given Create Users
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as Admin "user@example.com" , "stringst"
	And Assing user "Teacher" and removing the role assigned by default
	And Create Course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	And Add Users to group
	And Create Task
	| Name            | Description                                 | Links                                                                             | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски | @https://piter-education.ru:7070/swagger/index.html#/Comments/Comments_GetComment | true       |
	And Authorized by Teacher
	And Create homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Authorized by student
	And I am a student adding my homework
	| Answer   |
	| <Answer> |
	When Get Student homework by id
	Then I am a student, check that my submitted homework is returned to me by id
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |

	@Chat
	Scenario: As a student, I can leave comments on homework
	Given Create Users
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <FirstName>    | <LastName >   | <Patronymic>    | <Email>    | <Username>    | <Password>    | <City>    | <BirthDate>    | <GitHubAccount>    | <PhoneNumber>    |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	And Autorized as Admin "user@example.com" , "stringst"
	And Assing user "Teacher" and removing the role assigned by default
	And Create Course
	| Name | Description                                |
	| QQQQ | Где Q и как его выводить на экран три раза |
	And Create groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	And Add Users to group
	And Create Task
	| Name            | Description                                 | Links                                                                             | IsRequired |
	| Ищем Q на клаве | Первые 2 часа история, вторые 2 часа поиски | @https://piter-education.ru:7070/swagger/index.html#/Comments/Comments_GetComment | true       |
	And Authorized by Teacher
	And Create homework
	| StartDate    | EndDate    |
	| <StartDate1> | <EndDate1> |
	And Authorized by student
	And I am a student adding my homework
	| Answer   |
	| <Answer> |
	When  Add a comment as a student to your homework
	| Text   |
	| <Text> |
	And  Get student comment by id
	Then I am a student, check that the created comment is returned by id correct
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |

