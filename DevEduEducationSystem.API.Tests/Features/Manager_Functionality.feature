Feature: Manager_Functionality

1.)Как менеджер/админ, я хочу назначать роли юзерам
2.) Как менеджер, я хочу создавать группу
3.) Как менеджер, я хочу получить созданную группу по id 
4.)Как менеджер. я хочу добавлять в группу студента, преподавателя и тьютора
5.) Как менеджер, я хочу изменять группу 
6.)Как менеджер, я хочу удалять группу

@Manager
Scenario: As manadger I want to assign a role to users
	Given Create user
	| FirstName   | LastName    | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
	| <FirstName> | <LastName > | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
	And Autorized as admin
	And Assing User "Manager"
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
    Given  Create users
	| FirstName           | LastName            | Patronymic           | Email           | Username           | Password           | City           | BirthDate           | GitHubAccount           | PhoneNumber           |
	| <FirstName>         | <LastName >         | <Patronymic>         | <Email>         | <Username>         | <Password>         | <City>         | <BirthDate>         | <GitHubAccount>         | <PhoneNumber>         |
	| <MehodistFirstName> | <MehodistLastName > | <MehodistPatronymic> | <MehodistEmail> | <MehodistUsername> | <MehodistPassword> | <MehodistCity> | <MehodistBirthDate> | <MehodistGitHubAccount> | <MehodistPhoneNumber> |
	And Autorized as admin
	And Assing Manager and Methodist roles
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
	 Given Create users
	| FirstName           | LastName            | Patronymic           | Email           | Username           | Password           | City           | BirthDate           | GitHubAccount           | PhoneNumber           |
	| <FirstName>         | <LastName >         | <Patronymic>         | <Email>         | <Username>         | <Password>         | <City>         | <BirthDate>         | <GitHubAccount>         | <PhoneNumber>         |
	| <MehodistFirstName> | <MehodistLastName > | <MehodistPatronymic> | <MehodistEmail> | <MehodistUsername> | <MehodistPassword> | <MehodistCity> | <MehodistBirthDate> | <MehodistGitHubAccount> | <MehodistPhoneNumber> |
	And Autorized as admin
	And Assing Manager and Methodist roles
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

Scenario: As manager, I want change my created group
    Given Create users
	| FirstName           | LastName            | Patronymic           | Email           | Username           | Password           | City           | BirthDate           | GitHubAccount           | PhoneNumber           |
	| <FirstName>         | <LastName >         | <Patronymic>         | <Email>         | <Username>         | <Password>         | <City>         | <BirthDate>         | <GitHubAccount>         | <PhoneNumber>         |
	| <MehodistFirstName> | <MehodistLastName > | <MehodistPatronymic> | <MehodistEmail> | <MehodistUsername> | <MehodistPassword> | <MehodistCity> | <MehodistBirthDate> | <MehodistGitHubAccount> | <MehodistPhoneNumber> |
	And Autorized as admin
	And Assing Manager and Methodist roles
	| NameRole           |
	| <NameRole>         |
	| <MehodistNameRole> |
	When Autorized by methodist
	Given Create Course by methodist
	| Name            | Description                      |
	| Юный натуралист | Чем double отличается от decimal |
	And Autorized by manager
	And Create Groupe number three
	| Name    | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
	| Група 3 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 17:00 - 20:00 | 5000            |
   When chanche group
   | Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
   | Группа 3 | 1             | 13.05.2022 | 13.12.2022 | вт, пт, вс 09:00 - 12:00 | 2500            |
   And Get group number three by id
   Then Сompare changed group and returned group
   Examples: 
	 | FirstName | LastName    | Patronymic | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber | MehodistFirstName | MehodistLastName | MehodistPatronymic | MehodistEmail   | MehodistUsername | MehodistPassword | MehodistCity    | MehodistBirthDate | MehodistGitHubAccount | MehodistPhoneNumber | NameRole | MehodistNameRole |
	 | Миневра   | Макгонагалл | Смит       | Smitt@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Хагрид            | Рубеус           | Колтрейн           | Rubeuss@mail.ru | Hagrid           | hagridRubeus     | SaintPetersburg | 01.03.2003        | string                | 89211111111         | Manager  | Methodist        |
	 

 Scenario: As a manager, I want to delete a group
 Given Create user
 | FirstName   | LastName    | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
 | <FirstName> | <LastName > | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
 And Autorized as admin
 And Assign manager role to user
 | NameRole   |
 | <NameRole> |
 And Create course
 | Name   | Description   |
 | <Name> | <Description> |
 And Create Groupe QAA 
 | Name     | GroupStatusId   | StartDate   | EndDate   | Timetable   | PaymentPerMonth   |
 | <Name 1> | <GroupStatusId> | <StartDate> | <EndDate> | <Timetable> | <PaymentPerMonth> |
 When Delete group by id
 Then Get all groups 
 Examples: 
 | FirstName | LastName  | Patronymic | Email         | Username | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber | NameRole | Name     | Description              | Name 1 | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Manager  | Солнышки | Как опоздать на 10 минут | QAA    | 1             | 13.05.2022 | 13.12.2022 | вт, пт, вс 09:00 - 17:00 | 7000            |



	#Role      |
	# Manager  |
	#Methodist |
	#Teacher   |
	#Tutor     |