Feature: Chat_With_Specific_Person

1.) Как преподавтель/тьютор я могу оставлять комментарий про домашнюю работу

@Chat
Scenario: As a teacher and tutor, I can leave comments about homework
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
	Then Check the left comment should have returned
	Examples: 
	| FirstName | LastName | Patronymic | Email          | Username | Password | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail     | NewUsername | NewPassword | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | StartDate1 | EndDate1   | Answer                    | Text                                                     |
	| Маркус    | Ус       | Николаевич | Markus@mail.ru | MarkusUs | MarkusUs | SaintPetersburg | 01.01.2001 | string        | 89991112233 | Студент      | Иванов      | Студентович   | Stud@mail.ru | Stud        | studentic   | SaintPetersburg | 01.01.2003   | string           | 99114567890    | 01.01.2022 | 10.10.2022 | @https://json2csharp.com/ | Это понятно, но наверное не понятно, потому что кукуруза |
