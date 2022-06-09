Feature: HomeWorkWindowForAllUsers

Checking the creation, editing and deletion of Task and HomeWork
Сhecking the sending of homework to students for verification to the teacher

@HomeWorksTeacherCreate
Scenario: As I Teacher I can add HomeWork for Students of my Group
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
When I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name       | Description         | Link                   | AddLink                                      |
| 01.07.2022  | 02.07.2022   | HomeWork 1 | DescriptionHomeWork | https://function-x.ru/ | https://piter-education.ru:7074/new-homework |
Then I can see new HomeWork in list HomeWorks new Groups

@HomeWorksTeacherCreate
Scenario: As I Teacher I can add unpublish Task for my Group
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
When I fill all fields pages of create Task and click on the button SaveAsDraft
| DateOfIssue | DeliveryDate | Name       | Description          | Link                          | AddLink                   |
| 04.07.2022  | 05.07.2022   | HomeWork 2 | DescriptionHomeWork2 | https://www.awesomeandrew.ru/ | https://drive.google.com/ |
Then I can see new HomeWork in the list of saved homework

@HomeWorksTeacherCreateAndUpdate
Scenario: As I Teacher I can add publish HomeWork for my Group and update this HomeWork
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name       | Description          | Link                   | AddLink              |
| 04.07.2022  | 15.07.2022   | HomeWork 3 | DescriptionHomeWork3 | https://www.figma.com/ | https://metanit.com/ |
When I update new HomeWork 
| DateOfIssue | DeliveryDate | Name         | Description            | Link                                      | AddLink                |
| 09.07.2022  | 12.07.2022   | HomeWork 3.1 | DescriptionHomeWork3.1 | https://piter-education.ru:7074/homeworks | https://function-x.ru/ |
Then I can see new HomeWork with new field in list HomeWorks new Groups
#And I don't can see HomeWork in List of HomeWorks First Group

@HomeWorksTeacherDelete
Scenario: As I Teacher I can delete publish HomeWork
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name        | Description          | Link                   | AddLink              |
| 04.07.2022  | 06.07.2022   | HomeWork 11 | DescriptionHomeWork3 | https://www.figma.com/ | https://metanit.com/ |
And I go to the task card and click the edit button 
When In card of HomeWork I click in Button Delete task
Then I can see message about HomeWork is Deleted
And I don't can see HomeWork in list HomeWorks of Groups

@HomeWorksTeacherDelete
Scenario: As I Teacher I can cancel delete publish HomeWork after moment then I click in button delete
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name       | Description          | Link                   | AddLink              |
| 04.07.2022  | 06.07.2022   | HomeWork 7 | DescriptionHomeWork3 | https://www.figma.com/ | https://metanit.com/ |
And I go to the task card and click the edit button 
When In card of HomeWork I click in Button cancel Delete task
Then I can see new HomeWork in list HomeWorks of Groups 

@HomeWorksTeacherDelete
Scenario: As I Teacher I can delete unpublish Task
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button SaveAsDraft
| DateOfIssue | DeliveryDate | Name       | Description          | Link                          | AddLink                   |
| 04.07.2022  | 05.07.2022   | HomeWork 8 | DescriptionHomeWork8 | https://www.awesomeandrew.ru/ | https://drive.google.com/ |
And I go to the task card in list saved Tasks and click the edit button 
When In card of Task I click in Button Delete task
Then I can see message about HomeWork is Deleted
And I don't can see Task in list Tasks of Group

@HomeWorksTeacherCreateAndUpdate
Scenario: As I Teacher I can update unpublish Tasks of my Group and published them
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button SaveAsDraft for Task
| Name       | Description          | Link                   | AddLink              |
| HomeWork 8 | DescriptionHomeWork8 | https://www.figma.com/ | https://metanit.com/ |
And I go to the task card in list saved Tasks and click the edit button
When I update Task and publish it
| DateOfIssue | DeliveryDate | Name       | Description          | Link                          | AddLink                   |
| 04.07.2022  | 05.07.2022   | HomeWork 4 | DescriptionHomeWork4 | https://www.awesomeandrew.ru/ | https://drive.google.com/ |
Then I can see publish HomeWork in list HomeWorks of Groups
And I don't can see publish HomeWork in list saved Tasks of Group

# Role student 

@HomeworkStudentWindow
Scenario: As a student, I want to hand in my homework
    Given I log in to the system  with the window size <length> and <width>
       | Email                       | Password        |
       | userTestStudent@example.com | userTestStudent |
    And I click on the homework button
    And I choose a course
    And I click on the task tab
    And I leave a link to the completed task "https://piter-education.ru:7074/"
    When I click on the submit homework button 
    Then I refresh the page and check that my homework link is saved
    Examples: 
	| length | width |
	| 1920   | 1080  |

@HomeworkStudentWindow
Scenario: As a student, I want to edit my homework
    Given I log in to the system  with the window size <length> and <width>
       | Email                       | Password        |
       | userTestStudent@example.com | userTestStudent |
    And I click on the homework button
    And I choose a course
    And I click on the task tab
    And I leave a link to the completed task "https://piter-education.ru:7074/"
    And I click on the submit homework button 
    And I click on the edit button in window homework 
    When I clear the input and insert a new link "https://trello.com/b/YNep1Ge3/marvelous-frontend" and click on the send button
    Then I clicking on the back button and I check, the link should change
    Examples: 
    | length | width |
    | 1920   | 1080  |

 @Negative
 Scenario: As a student, I want to hand in my homework.Negative
    Given I log in to the system  with the window size <length> and <width>
       | Email                       | Password        |
       | userTestStudent@example.com | userTestStudent |
    And I click on the homework button
    And I choose a course
    And I click on the task tab
    And I leave a link to the completed task empty link ""
    When I click on the submit homework button
    Then Check if the submit button is disabled
    Given I leave a link to the completed task "Hellow 123, I am Ссылка !"
    When I click on the submit homework button
    Then Check if the submit button is disabled and delete student homework
     Examples: 
    | length | width |
    | 1920   | 1080  |

    # негативный сценарий окна редактирования домашнего задания - роль студента

   @Negative
   Scenario: As a student, I want to edit my homework.Negative
   Given I log in to the system  with the window size <length> and <width>
       | Email                       | Password        |
       | userTestStudent@example.com | userTestStudent |
    And I click on the homework button
    And I choose a course
    And I click on the task tab
    And I click on the edit button in window homework 
    When I clear the input and insert a new empty link "" and click on the send button twice
    Then I refresh the page and see that the link hasn't changed
    When I clear the input and insert a new empty link "123 I am sexy Ссылка!!!" and click on the send button twice
    Then I refresh the page and see that the link hasn't changed
    Examples: 
    | length | width |
    | 1920   | 1080  |