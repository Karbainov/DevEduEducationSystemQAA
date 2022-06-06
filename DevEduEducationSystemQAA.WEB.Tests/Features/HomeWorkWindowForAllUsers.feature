Feature: HomeWorkWindowForAllUsers

A short summary of the feature

@tag1
Scenario: As I Teacher I can add HomeWork for Students of my Group
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
When I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name       | Description         | Link                   | AddLink                                      |
| 01.07.2022  | 02.07.2022   | HomeWork 1 | DescriptionHomeWork | https://function-x.ru/ | https://piter-education.ru:7074/new-homework |
Then I can see new HomeWork in list HomeWorks new Groups

Scenario: As I Teacher I can add unpublish Task for my Group
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
When I fill all fields pages of create Task and click on the button SaveAsDraft
| DateOfIssue | DeliveryDate | Name       | Description          | Link                          | AddLink                   |
| 04.07.2022  | 05.07.2022   | HomeWork 2 | DescriptionHomeWork2 | https://www.awesomeandrew.ru/ | https://drive.google.com/ |
Then I can see new HomeWork in the list of saved homework

Scenario: As I Teacher I can add publish HomeWork for my Group and update this HomeWork
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name       | Description          | Link                   | AddLink              |
| 04.07.2022  | 06.07.2022   | HomeWork 3 | DescriptionHomeWork3 | https://www.figma.com/ | https://metanit.com/ |
When I update new HomeWork 
| DateOfIssue | DeliveryDate | Name         | Description            | Link                                      | AddLink                |
| 09.07.2022  | 12.07.2022   | HomeWork 3.1 | DescriptionHomeWork3.1 | https://piter-education.ru:7074/homeworks | https://function-x.ru/ |
Then I can see new HomeWork with new field in list HomeWorks new Groups

Scenario: As I Teacher I can delete publish HomeWork
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name       | Description          | Link                   | AddLink              |
| 04.07.2022  | 06.07.2022   | HomeWork 3 | DescriptionHomeWork3 | https://www.figma.com/ | https://metanit.com/ |
And I go to the task card and click the edit button 
When In card of HomeWork I click in Button Delete task
Then I can see message about HomeWork is Deleted
And I don't can see HomeWork in list HomeWorks of Groups

Scenario: As I Teacher I can cancel delete publish HomeWork after moment then I click in button delete
Given I open Google Chrome browser
And I login as an manager and enter in my account
And I choose role Teacher for next step
And I fill all fields pages of create Task and click on the button Publish
| DateOfIssue | DeliveryDate | Name       | Description          | Link                   | AddLink              |
| 04.07.2022  | 06.07.2022   | HomeWork 3 | DescriptionHomeWork3 | https://www.figma.com/ | https://metanit.com/ |
And I go to the task card and click the edit button 
When In card of HomeWork I click in Button cancel Delete task
Then I can see new HomeWork in list HomeWorks of Groups 

#Теперь пишем про Delete

#Scenario: As I Teacher I can add HomeWork for Students of my Group
#Scenario: As I Teacher I can update HomeWork for Students of my Group
#Scenario: As I Teacher I can update unpublish Tasks of my Group and published them

