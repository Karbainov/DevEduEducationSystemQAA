﻿Feature: Manager_Functionality

1.)Как менеджер/админ, я хочу назначать роли юзерам
2.) Как менеджер, я хочу создавать группу
3.) Как менеджер, я хочу получить созданную группу по id 
4.)Как менеджер. я хочу добавлять в группу студента, преподавателя и тьютора

@tag1
Scenario: As manadger I want to assign a role to users
	Given Create future manadger
	| FirstName   | LastName    | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName > | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And Autorized as admin
	And Assing Minevra "Manager"
	Given Create new users for our roles
	| FirstName      | LastName      | Patronymic      | Email      | Username      | Password      | City      | BirthDate      | GitHubAccount      | PhoneNumber      |
	| <NewFirstName> | <NewLastName> | <NewPatronymic> | <NewEmail> | <NewUsername> | <NewPassword> | <NewCity> | <NewBirthDate> | <NewGitHubAccount> | <NewPhoneNumber> |
	When Autorized by manager
	And Assing users role methodist, teacher, tutor
	| NameRole   |
	| <NameRole> |
	Then Сheck user roles
	Examples: 
	| FirstName | LastName    | Patronymic | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber | NewFirstName | NewLastName | NewPatronymic | NewEmail        | NewUsername | NewPassword  | NewCity         | NewBirthDate | NewGitHubAccount | NewPhoneNumber | NameRole  |
	| Миневра   | Макгонагалл | Смит       | Smit@mail.ru  | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Хагрид       | Рубеус      | Колтрейн      | Rubeus6@mail.ru | Hagrid      | hagridRubeus | SaintPetersburg | 01.03.2003   | string           | 89211111111    | Methodist |
	| Миневра   | Макгонагалл | Смит       | Smit1@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Римус        | Джон        | Люпин         | Djon6@mail.ru   | Rimus       | rimusDjon    | SaintPetersburg | 01.03.1990   | string           | 89110001234    | Teacher   |
	| Миневра   | Макгонагалл | Смит       | Smit2@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Златопуст    | Локонс      | Брана         | Brana6@mail.ru  | Zlatopust   | zlatopust    | SaintPetersburg | 01.12.2001   | string           | 89210081122    | Tutor     |
	
Scenario: As a manager, I want to create groups
    Given  Create future manadger and methodist
	| FirstName           | LastName            | Patronymic           | Email           | Username           | Password           | City           | BirthDate           | GitHubAccount           | PhoneNumber           |
	| <FirstName>         | <LastName >         | <Patronymic>         | <Email>         | <Username>         | <Password>         | <City>         | <BirthDate>         | <GitHubAccount>         | <PhoneNumber>         |
	| <MehodistFirstName> | <MehodistLastName > | <MehodistPatronymic> | <MehodistEmail> | <MehodistUsername> | <MehodistPassword> | <MehodistCity> | <MehodistBirthDate> | <MehodistGitHubAccount> | <MehodistPhoneNumber> |
	And Autorized as admin
	And Assing Minevra and Methodist roles
	| NameRole           |
	| <NameRole>         |
	| <MehodistNameRole> |
	When Autorized by methodist
	Given Create Course by methodist
	| Name | Description                                |
	| QQQ  | Где Q и как его выводить на экран три раза |
	And Autorized by manager
	When Create Groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            |
	Then Compare group status code 201
	When Get group by id 
	Then Compare the resulting group by id with group request
	Examples: 
	| FirstName | LastName    | Patronymic | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber | MehodistFirstName | MehodistLastName | MehodistPatronymic | MehodistEmail  | MehodistUsername | MehodistPassword | MehodistCity    | MehodistBirthDate | MehodistGitHubAccount | MehodistPhoneNumber | NameRole | MehodistNameRole |
	| Миневра   | Макгонагалл | Смит       | Smit3@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Хагрид            | Рубеус           | Колтрейн           | Rubeus@mail.ru | Hagrid           | hagridRubeus     | SaintPetersburg | 01.03.2003        | string                | 89211111111         | Manager  | Methodist        |
	
 
 Scenario: As a manager, I want add in group students, teachers and tutors
	 Given Create future manadger and methodist
	| FirstName           | LastName            | Patronymic           | Email           | Username           | Password           | City           | BirthDate           | GitHubAccount           | PhoneNumber           |
	| <FirstName>         | <LastName >         | <Patronymic>         | <Email>         | <Username>         | <Password>         | <City>         | <BirthDate>         | <GitHubAccount>         | <PhoneNumber>         |
	| <MehodistFirstName> | <MehodistLastName > | <MehodistPatronymic> | <MehodistEmail> | <MehodistUsername> | <MehodistPassword> | <MehodistCity> | <MehodistBirthDate> | <MehodistGitHubAccount> | <MehodistPhoneNumber> |
	And Autorized as admin
	And Assing Minevra and Methodist roles
	| NameRole           |
	| <NameRole>         |
	| <MehodistNameRole> |
	When Autorized by methodist
	Given Create Course by methodist
	| Name     | Description                          |
	| Дрязяшки | Курс юных любителей анлийского языка |
	And Autorized by manager
	And Create Groupe
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Группа 2 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 10:00 - 14:00 | 7500            |
	Given Create three users 
	| FirstName | LastName | Patronymic | Email           | Username  | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber |
	| Рональд   | Билиус   | Уизли      | Ron@mail.ru     | Ronald    | RonUizli    | SaintPetersburg | 01.01.2000 | string        | 89991122334 |
	| Аластор   | Mad-Eye  | Грюм       | Alastor@mail.ru | Alastor   | menacingEye | SaintPetersburg | 01.01.1992 | string        | 89213456789 |
	| Златопуст | Локонс   | Брана      | Brana6@mail.ru  | Zlatopust | zlatopust   | SaintPetersburg | 01.12.2001 | string        | 89210081122 |
	And Assign two students roles "Teacher" and "Tutor"
	And Get Users by id 
	 When Add three users Student, Teacher and Tutor in group
	 And Get my group by id
	 Then Compare the resulting filled group by id with group request
	 Examples: 
	 | FirstName | LastName    | Patronymic | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber | MehodistFirstName | MehodistLastName | MehodistPatronymic | MehodistEmail  | MehodistUsername | MehodistPassword | MehodistCity    | MehodistBirthDate | MehodistGitHubAccount | MehodistPhoneNumber | NameRole | MehodistNameRole |
	 | Миневра   | Макгонагалл | Смит       | Smit4@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Хагрид            | Рубеус           | Колтрейн           | Rubeus1@mail.ru | Hagrid           | hagridRubeus     | SaintPetersburg | 01.03.2003        | string                | 89211111111         | Manager  | Methodist        |



	 
	#Role      |
	# Manager  |
	#Methodist |
	#Teacher   |
	#Tutor     |