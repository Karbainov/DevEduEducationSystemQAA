Feature: Manager_Functionality

1.)Как менеджер/админ, я хочу назначать роли юзерам
2.) Как менеджер, я хочу создавать группу
3.) Как менеджер, я хочу получить созданную группу по id 
4.)Как менеджер. я хочу добавлять в группу студента, преподавателя и тьютора
5.) Как менеджер, я хочу изменять группу 
6.)Как менеджер, я хочу удалять группу
7.)Как менеджер, я хочу менять статус группы
8.) Как менеджер, я хочу удалять юзера из группы
9.)Как менеджер, я хочу создавать оплату

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
@Manager	
Scenario: As a manager, I want to create groups
    Given  Create user
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
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
	| Группа 1 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 18:00 - 20:00 | 7500            | 3             |
	Then Compare group status code 201
	When Get group by id 
	Then Compare the resulting group by id with group request
	Examples: 
	| FirstName | LastName    | Patronymic | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber | MehodistFirstName | MehodistLastName | MehodistPatronymic | MehodistEmail  | MehodistUsername | MehodistPassword | MehodistCity    | MehodistBirthDate | MehodistGitHubAccount | MehodistPhoneNumber | NameRole | MehodistNameRole |
	| Миневра   | Макгонагалл | Смит       | Smit3@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Хагрид            | Рубеус           | Колтрейн           | Rubeus@mail.ru | Hagrid           | hagridRubeus     | SaintPetersburg | 01.03.2003        | string                | 89211111111         | Manager  | Methodist        |
	
 @Manager
 Scenario: As a manager, I want add in group students, teachers and tutors
	 Given Create user
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
	| Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
	| Группа 2 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 10:00 - 14:00 | 7500            | 4             |
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
@Manager
Scenario: As manager, I want change my created group
    Given Create user
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
	| Name    | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
	| Група 3 | 1             | 28.01.2022 | 28.10.2022 | пн, ср, пт 17:00 - 20:00 | 5000            | 4             |
   When chanche group
   | Name     | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | PaymentsCount |
   | Группа 3 | 1             | 13.05.2022 | 13.12.2022 | вт, пт, вс 09:00 - 12:00 | 2500            | 3             |
   And Get group number three by id
   Then Сompare changed group and returned group
   Examples: 
	 | FirstName | LastName    | Patronymic | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber | MehodistFirstName | MehodistLastName | MehodistPatronymic | MehodistEmail   | MehodistUsername | MehodistPassword | MehodistCity    | MehodistBirthDate | MehodistGitHubAccount | MehodistPhoneNumber | NameRole | MehodistNameRole |
	 | Миневра   | Макгонагалл | Смит       | Smitt@mail.ru | Minevra  | minevraSmit | SaintPetersburg | 01.01.1985 | string        | 89991111111 | Хагрид            | Рубеус           | Колтрейн           | Rubeuss@mail.ru | Hagrid           | hagridRubeus     | SaintPetersburg | 01.03.2003        | string                | 89211111111         | Manager  | Methodist        |
	 
@Manager
 Scenario: As a manager, I want to delete a group
 Given Create user
 | FirstName   | LastName    | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
 | <FirstName> | <LastName > | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
 And Autorized as admin
 And Assign manager role to user "Manager"
 And Create course
 | Name   | Description   |
 | <Name> | <Description> |
 And Autorized by manager
 And Create Groupe QAA 
 | Name     | GroupStatusId   | StartDate   | EndDate   | Timetable   | PaymentPerMonth   | PaymentsCount |
 | <Name 1> | <GroupStatusId> | <StartDate> | <EndDate> | <Timetable> | <PaymentPerMonth> | 3             |
 When Delete group by id
 And Get all groups 
 Then Deleted group should disappear 
 Examples: 
 | FirstName | LastName  | Patronymic | Email         | Username | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber | Name     | Description              | Name 1 | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Солнышки | Как опоздать на 10 минут | QAA    | 1             | 13.05.2022 | 13.12.2022 | вт, пт, вс 09:00 - 17:00 | 7000            |

 @Manager
 Scenario: As manager, I want to change the status group
 Given Create user
 | FirstName   | LastName    | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
 | <FirstName> | <LastName > | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
 And Autorized as admin
 And Assign manager role to user "Manager"
 And Create course
 | Name   | Description   |
 | <Name> | <Description> |
 And Autorized by manager
 And Create Groupe Back
 | Name     | GroupStatusId   | StartDate   | EndDate   | Timetable   | PaymentPerMonth   | PaymentsCount |
 | <Name 1> | <GroupStatusId> | <StartDate> | <EndDate> | <Timetable> | <PaymentPerMonth> | 3             |
 When Change group status by id
 | GroupStatusName   |
 | <GroupStatusName> |
 Then Group Status should changed
 Examples: 
 | FirstName | LastName  | Patronymic | Email          | Username | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber | Name    | Description              | Name 1 | GroupStatusId | StartDate  | EndDate    | Timetable                | PaymentPerMonth | GroupStatusName |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru  | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | MyBack  | Как опоздать на 10 минут | Back   | 1             | 13.05.2022 | 13.12.2022 | вт, пт, вс 09:00 - 17:00 | 7500            | ReadyToStudy    |
 | Альбус    | Персиваль | Дамблдор   | Albus1@mail.ru | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | MyBack1 | Как опоздать на 10 минут | Back1  | 1             | 13.05.2022 | 13.12.2022 | вт, пт, вс 09:00 - 17:00 | 7500            | InProgress      |
 | Альбус    | Персиваль | Дамблдор   | Albus2@mail.ru | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | MyBack2 | Как опоздать на 10 минут | Back2  | 1             | 13.05.2022 | 13.12.2022 | вт, пт, вс 09:00 - 17:00 | 7500            | Completed       |
 
 @Manager
Scenario: As manager, I want to remove a student from a group
Given Create user
| FirstName | LastName | Patronymic  | Email             | Username | Password        | City            | BirthDate  | GitHubAccount | PhoneNumber |
| Марина    | Пушкина  | Иванова     | Pushkin90@mail.ru | Маришка  | PushkinMarishka | SaintPetersburg | 01.01.1990 | string        | 89001112345 |
| Антон     | Пушкин   | Эдикович    | Anton@mail.ru     | Antonio  | Antonio1990     | SaintPetersburg | 01.01.1990 | string        | 89012223344 |
| Максим    | Опаздун  | Опаздунович | Max@mail.ru       | Opazdun  | Opasdun2003     | SaintPetersburg | 01.01.2003 | string        | 99117778899 |
| Инокентий | Гай      | Пай         | Max1@mail.ru      | Guy      | Opasdun2003     | SaintPetersburg | 01.01.2001 | string        | 99117778891 |
And Autorized as admin
And Create course
| Name   | Description      |
| Delete | Delete me please |
And Assign role
| NameRole |
| Manager  |
And Autorized by manager
And Сreate a group to remove a user from it
| Name         | GroupStatusId | StartDate  | EndDate    | Timetable      | PaymentPerMonth | PaymentsCount |
| Хочу удалить | 1             | 01.01.2022 | 01.10.2022 | пр пр пр 13244 | 1000            | 3             |
And Add Users in group
When Delete adding user from a group
And Get group  by id
Then Check that student have left the group
| FirstName | LastName | Patronymic  | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber |
| Антон     | Пушкин   | Эдикович    | Anton@mail.ru | Antonio  | Antonio1990 | SaintPetersburg | 01.01.1990 | string        | 89012223344 |
| Максим    | Опаздун  | Опаздунович | Max@mail.ru   | Opazdun  | Opasdun2003 | SaintPetersburg | 01.01.2003 | string        | 99117778899 |
| Инокентий | Гай      | Пай         | Max1@mail.ru  | Guy      | Opasdun2003 | SaintPetersburg | 01.01.2001 | string        | 99117778891 |

@Manager
Scenario: As manager, I want to remove a teacher from a group
Given Create user
| FirstName | LastName | Patronymic  | Email             | Username | Password        | City            | BirthDate  | GitHubAccount | PhoneNumber |
| Марина    | Пушкина  | Иванова     | Pushkin90@mail.ru | Маришка  | PushkinMarishka | SaintPetersburg | 01.01.1990 | string        | 89001112345 |
| Антон     | Пушкин   | Эдикович    | Anton@mail.ru     | Antonio  | Antonio1990     | SaintPetersburg | 01.01.1990 | string        | 89012223344 |
| Максим    | Опаздун  | Опаздунович | Max@mail.ru       | Opazdun  | Opasdun2003     | SaintPetersburg | 01.01.2003 | string        | 99117778899 |
| Инокентий | Гай      | Пай         | Max1@mail.ru      | Guy      | Opasdun2003     | SaintPetersburg | 01.01.2001 | string        | 99117778891 |
And Autorized as admin
And Create course
| Name   | Description      |
| Delete | Delete me please |
And Assign role 
| NameRole |
| Manager  |
| Teacher  |
And Autorized by manager
And Сreate a group to remove a user from it
| Name         | GroupStatusId | StartDate  | EndDate    | Timetable      | PaymentPerMonth | PaymentsCount |
| Хочу удалить | 1             | 01.01.2022 | 01.10.2022 | пр пр пр 13244 | 1000            | 3             |
And Add Users in group as teacher
When Delete adding teacher from a group
And Get group  by id
Then Check that teacher have left the group
| FirstName | LastName | Patronymic  | Email         | Username | Password    | City            | BirthDate  | GitHubAccount | PhoneNumber |
| Антон     | Пушкин   | Эдикович    | Anton@mail.ru | Antonio  | Antonio1990 | SaintPetersburg | 01.01.1990 | string        | 89012223344 |
| Максим    | Опаздун  | Опаздунович | Max@mail.ru   | Opazdun  | Opasdun2003 | SaintPetersburg | 01.01.2003 | string        | 99117778899 |
| Инокентий | Гай      | Пай         | Max1@mail.ru  | Guy      | Opasdun2003 | SaintPetersburg | 01.01.2001 | string        | 99117778891 |

@Manager
Scenario: As manager, I want get all groups
Given Create user
 | FirstName   | LastName    | Patronymic   | Email   | Username   | Password   | City   | BirthDate   | GitHubAccount   | PhoneNumber   |
 | <FirstName> | <LastName > | <Patronymic> | <Email> | <Username> | <Password> | <City> | <BirthDate> | <GitHubAccount> | <PhoneNumber> |
 And Autorized as admin
 And Assign manager role to user "Manager"
 And Create course
 | Name   | Description   |
 | <Name> | <Description> |
 And Autorized by manager
 And Create Groupe all group 
 | Name      | GroupStatusId | StartDate  | EndDate    | Timetable                   | PaymentPerMonth | PaymentsCount |
 | Сосиски   | 1             | 12.02.2022 | 12.12.2022 | Я обещаю завтра будет лучше | 1000            | 3             |
 | Колбаски  | 1             | 12.02.2022 | 12.12.2022 | Я обещаю завтра будет лучше | 2000            | 4             |
 | Сордельки | 1             | 12.02.2022 | 12.12.2022 | Я обещаю завтра будет лучше | 3000            | 5             |
 When Get all  groups 
 Then Check that all groups should have returned
 Examples: 
 | FirstName | LastName  | Patronymic | Email          | Username | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber | Name     | Description                  | 
 | Альбус    | Персиваль | Дамблдор   | Albuss@mail.ru | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | MyCourse | Как пообещать и не выполнить |


 #Scenario with payment


 @Payment 
 Scenario: As a manager, I want to create a payment
 Given Create user
 | FirstName       | LastName       | Patronymic       | Email       | Username       | Password       | City      | BirthDate       | GitHubAccount       | PhoneNumber       |
 | <FirstName>     | <LastName >    | <Patronymic>     | <Email>     | <Username>     | <Password>     | <City>    | <BirthDate>     | <GitHubAccount>     | <PhoneNumber>     |
 | <StudFirstName> | <StudLastName> | <StudPatronymic> | <StudEmail> | <StudUsername> | <StudPassword> | <StudCity> | <StudBirthDate> | <StudGitHubAccount> | <StudPhoneNumber> |
 And Autorized as admin
 And Assign manager role to user "Manager"
 And Autorized by manager
 When Create one payment
 | Date   | Sum   | IsPaid   |
 | <Date> | <Sum> | <IsPaid> |
 And Get payment by id
 Then Created payment should be returned
 Examples: 
 | FirstName | LastName  | Patronymic | Email         | Username | Password      | City            | BirthDate  | GitHubAccount | PhoneNumber | StudFirstName | StudLastName | StudPatronymic | StudEmail     | StudUsername | StudPassword | StudCity        | StudBirthDate | StudGitHubAccount | StudPhoneNumber | Date       | Sum  | IsPaid |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | AlbusDambdor  | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Максим        | Опаздун      | Опаздунович    | Opazd@mail.ru | ILoveOpasd   | ILoveOpasd   | SaintPetersburg | 01.01.2000    | string            | 89211230987     | 20.01.2022 | 7500 | true   |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | Albus1Dambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Максим        | Опаздун      | Опаздунович    | Opazd@mail.ru | ILoveOpasd   | ILoveOpasd   | SaintPetersburg | 01.01.2000    | string            | 89211230987     | 28.03.2022 | 5000 | false  |

 @negative 
 Scenario: As manager, I want to create a payment. Negative
 Given Create user
 | FirstName       | LastName       | Patronymic       | Email       | Username       | Password       | City      | BirthDate       | GitHubAccount       | PhoneNumber       |
 | <FirstName>     | <LastName >    | <Patronymic>     | <Email>     | <Username>     | <Password>     | <City>    | <BirthDate>     | <GitHubAccount>     | <PhoneNumber>     |
 | <StudFirstName> | <StudLastName> | <StudPatronymic> | <StudEmail> | <StudUsername> | <StudPassword> | <StudCity> | <StudBirthDate> | <StudGitHubAccount> | <StudPhoneNumber> |
 And Autorized as admin
 And Assign manager role to user "Manager"
 And Autorized by manager
 When Create one payment
 | Date   | Sum   | IsPaid   |
 | <Date> | <Sum> | <IsPaid> |
 Then Should return Status code 422 
 Examples: 
 | FirstName | LastName  | Patronymic | Email         | Username | Password      | City            | BirthDate  | GitHubAccount | PhoneNumber | StudFirstName | StudLastName | StudPatronymic | StudEmail     | StudUsername | StudPassword | StudCity        | StudBirthDate | StudGitHubAccount | StudPhoneNumber | Date       | Sum   | IsPaid |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | AlbusDambdor  | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Максим        | Опаздун      | Опаздунович    | Opazd@mail.ru | ILoveOpasd   | ILoveOpasd   | SaintPetersburg | 01.01.2000    | string            | 89211230987     | 20.01.1754 | 7500  | true   |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | Albus1Dambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Максим        | Опаздун      | Опаздунович    | Opazd@mail.ru | ILoveOpasd   | ILoveOpasd   | SaintPetersburg | 01.01.2000    | string            | 89211230987     | 28.03.2022 | -5000 | false  |

 @payment
 Scenario: As a manager, I want to change payment
 Given Create user
 | FirstName       | LastName       | Patronymic       | Email       | Username       | Password       | City      | BirthDate       | GitHubAccount       | PhoneNumber       |
 | <FirstName>     | <LastName >    | <Patronymic>     | <Email>     | <Username>     | <Password>     | <City>    | <BirthDate>     | <GitHubAccount>     | <PhoneNumber>     |
 | <StudFirstName> | <StudLastName> | <StudPatronymic> | <StudEmail> | <StudUsername> | <StudPassword> | <StudCity> | <StudBirthDate> | <StudGitHubAccount> | <StudPhoneNumber> |
 And Autorized as admin
 And Assign manager role to user "Manager"
 And Autorized by manager
 And Create one payment
 | Date   | Sum   | IsPaid   |
 | <Date> | <Sum> | <IsPaid> |
 When Change payment
 | Date         | Sum         | IsPaid         |
 | <DateChange> | <SumChange> | <IsPaidChange> |
 And Get a modified payment by
 Then Changed payment should be returned by id
 Examples: 
 | FirstName | LastName  | Patronymic | Email         | Username | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber | StudFirstName | StudLastName | StudPatronymic | StudEmail     | StudUsername | StudPassword | StudCity        | StudBirthDate | StudGitHubAccount | StudPhoneNumber | Date       | Sum  | IsPaid | DateChange | SumChange | IsPaidChange |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Максим        | Опаздун      | Опаздунович    | Opazd@mail.ru | ILoveOpasd   | ILoveOpasd   | SaintPetersburg | 01.01.2000    | string            | 89211230987     | 20.01.2022 | 7500 | true   | 28.02.2022 | 9500      | false        |

 @Payment
 Scenario: As a manager, I want to delete and get all payments 
 Given Create user
 | FirstName       | LastName       | Patronymic       | Email       | Username       | Password       | City      | BirthDate       | GitHubAccount       | PhoneNumber       |
 | <FirstName>     | <LastName >    | <Patronymic>     | <Email>     | <Username>     | <Password>     | <City>    | <BirthDate>     | <GitHubAccount>     | <PhoneNumber>     |
 | <StudFirstName> | <StudLastName> | <StudPatronymic> | <StudEmail> | <StudUsername> | <StudPassword> | <StudCity> | <StudBirthDate> | <StudGitHubAccount> | <StudPhoneNumber> |
 And Autorized as admin
 And Assign manager role to user "Manager"
 And Autorized by manager
 And Create payments
 | Date    | Sum    | IsPaid    |
 | <Date>  | <Sum>  | <IsPaid>  |
 | <Date1> | <Sum1> | <IsPaid1> |
 | <Date2> | <Sum2> | <IsPaid2> |
 When Delete payment
 And Get all payments by
 Then Remote payment should not return
 Examples: 
 | FirstName | LastName  | Patronymic | Email         | Username | Password     | City            | BirthDate  | GitHubAccount | PhoneNumber | StudFirstName | StudLastName | StudPatronymic | StudEmail     | StudUsername | StudPassword | StudCity        | StudBirthDate | StudGitHubAccount | StudPhoneNumber | Date       | Sum  | IsPaid | Date1      | Sum1 | IsPaid1 | Date2      | Sum2 | IsPaid2 |
 | Альбус    | Персиваль | Дамблдор   | Albus@mail.ru | Dambldor | AlbusDambdor | SaintPetersburg | 01.01.1985 | string        | 89991234566 | Максим        | Опаздун      | Опаздунович    | Opazd@mail.ru | ILoveOpasd   | ILoveOpasd   | SaintPetersburg | 01.01.2000    | string            | 89211230987     | 20.01.2022 | 7500 | true   | 28.02.2022 | 9500 | true    | 30.03.2022 | 6000 | true    |




	#Role      |
	# Manager  |
	#Methodist |
	#Teacher   |
	#Tutor     |