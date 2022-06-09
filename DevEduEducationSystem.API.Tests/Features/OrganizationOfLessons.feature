Feature: OrganizationOfLessons

Организация проведения уроков, в том числе дополнительные материалы к занятиям, посещаемость занятий

@Teacher
Scenario: User in role Teacher can create Lesson on the topic
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	Given I login as an admin and give new user role <Role>
	And I create course under login admin
	| Name   | Description   |
	| <Name> | <Description> |
	And I create topics under login admin 	
	| Name    | Duration |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	And I add course topics on positions under login admin
	| Name    | Position |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	And I create groupe under login admin
	| Name  | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount  |
	| Group | 1             | 28.06.2022 | 28.10.2022 | пн, ср, пт 10:00 - 14:00 | 7500            |       4        |
	And I to appoint new group "Teacher" under login admin
    And I Create students for group 
	| FirstName | LastName  | Patronymic | Email             | Username  | Password  | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Student 1 | Student 1 | Student 1  | student_1@mail.ru | Student 1 | Qwerty123 | SaintPetersburg | 01.01.2000 | string        | 89991122334 |
	| Student 2 | Student 2 | Student 2  | student_2@mail.ru | Student 2 | Qwerty123 | SaintPetersburg | 01.01.1992 | string        | 89213456789 |
	| Student 3 | Student 3 | Student 3  | student_3@mail.ru | Student 3 | Qwerty123 | SaintPetersburg | 01.12.2001 | string        | 89210081122 |	
	And I login as an admin and add students in group
	When I login as an Lecturer and create Lesson with topics
    | Name    | Date       | AdditionalMaterials | linkToRecord             |
    | Lesson1 | 28.06.2022 | string              | https://json2csharp.com/ |
	Then Under login Lecturer I get lesson by id <Teacher> and check that lessons is in return model and have correct field
	Then Under login Lecturer I get lesson by id <Group> and check that lessons is in return model and have correct field
	Examples: 
	| FirstName | LastName | Patronymic   | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name         | Description                       | Role    |
	| Anton     | Kutepov  | Vldimirovich | TroyanovIP@mail.ru | IvanPT   | Qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | ProstoCourse | I don't have word for description | Teacher |

@Teacher
Scenario: User in role Teacher can mark attendance of students in Lesson
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	Given I login as an admin and give new user role <Role>
	And I create course under login admin
	| Name   | Description   |
	| <Name> | <Description> |
	And I create topics under login admin 	
	| Name    | Duration |
	| Thema 1 | 1        |
	| Thema 2 | 2        |
	And I create groupe under login admin
	| Name  | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount  |
	| Group | 1             | 28.06.2022 | 28.10.2022 | пн, ср, пт 10:00 - 14:00 | 7500            |       4        |
	And I to appoint new group "Teacher" under login admin
    And I Create students for group 
	| FirstName | LastName  | Patronymic | Email             | Username  | Password  | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Student 1 | Student 1 | Student 1  | student_1@mail.ru | Student 1 | Qwerty123 | SaintPetersburg | 01.01.2000 | string        | 89991122334 |
	| Student 2 | Student 2 | Student 2  | student_2@mail.ru | Student 2 | Qwerty123 | SaintPetersburg | 01.01.1992 | string        | 89213456789 |
	| Student 3 | Student 3 | Student 3  | student_3@mail.ru | Student 3 | Qwerty123 | SaintPetersburg | 01.12.2001 | string        | 89210081122 |	
	And I login as an admin and add students in group
	When I login as an Lecturer and create Lesson with topics
    | Name    | Date       | AdditionalMaterials | linkToRecord             |
    | Lesson1 | 28.06.2022 | string              | https://json2csharp.com/ |
	And Under login Lecturer I can mark attendance of students in Lesson
    | Email             | AttendanceType    |
    | student_1@mail.ru | Absent            |
    | student_2@mail.ru | Attend            |
    | student_3@mail.ru | PartiallyAttended |
	Then I get full-info about Lesson and check that AttendanceType of student mark for the relevant student
	Examples: 
	| FirstName | LastName | Patronymic   | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name         | Description                       | Role    |
	| Anton     | Kutepov  | Vldimirovich | TroyanovIP@mail.ru | IvanPT   | Qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | ProstoCourse | I don't have word for description | Teacher |

@Teacher
Scenario: User in role Teacher can update lesson
	Given I create new user
	| FirstName   | LastName   | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName> | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	Given I login as an admin and give new user role <Role>
	And I create course under login admin
	| Name   | Description   |
	| <Name> | <Description> |
	And I create topics under login admin 	
	| Name    | Duration |
	| Thema 1 | 2        |
	| Thema 2 | 1        |
	| Thema 3 | 1        |
	| Thema 4 | 2        |
	And I create groupe under login admin
	| Name  | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount  |
	| Group | 1             | 28.06.2022 | 28.10.2022 | пн, ср, пт 10:00 - 14:00 | 7500            |       4        |
	And I to appoint new group "Teacher" under login admin
    And I Create students for group 
	| FirstName | LastName  | Patronymic | Email             | Username  | Password  | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Student 1 | Student 1 | Student 1  | student_1@mail.ru | Student 1 | Qwerty123 | SaintPetersburg | 01.01.2000 | string        | 89991122334 |
	| Student 2 | Student 2 | Student 2  | student_2@mail.ru | Student 2 | Qwerty123 | SaintPetersburg | 01.01.1992 | string        | 89213456789 |
	| Student 3 | Student 3 | Student 3  | student_3@mail.ru | Student 3 | Qwerty123 | SaintPetersburg | 01.12.2001 | string        | 89210081122 |	
	And I login as an admin and add students in group
	When I login as an Lecturer and create Lesson with topics
    | Name    | Date       | AdditionalMaterials | linkToRecord             |
    | Lesson1 | 28.06.2022 | string              | https://json2csharp.com/ |
	And I create new list topics for update lesson
	| Name    | Duration |
	| Thema 1 | 2        |
	And Under login Lecturer I update Lesson by id
    | Date       | AdditionalMaterials | linkToRecord                            |
    | 01.07.2022 | string              | https://translate.yandex.ru/?lang=en-ru |
	Then I get full-info about Lesson and check that new returned model of Lesson contained updating field
	Examples: 
	| FirstName | LastName | Patronymic   | Email              | Username | Password  | City   | BirthDate  | GitHubAccount | PhoneNumber  | Name         | Description                       | Role    |
	| Anton     | Kutepov  | Vldimirovich | TroyanovIP@mail.ru | IvanPT   | Qwerty123 | Dnipro | 02.02.1993 | string        | 899912349954 | ProstoCourse | I don't have word for description | Teacher |



