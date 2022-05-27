Feature: Enter_Window

Окно войти

@EnterWindow
Scenario: As a user in the login window, I want to clear the data I entered when I click on the cancel button
    Given I enter the  window enter with the window size <length> and <width>
	And I am a user filling in email and password
	| Email         | Password    |
	| Harry@mail.ru | HarryPotter |
	When I click the cancel button
	Then The entered data should be erased
	Examples: 
	| length | width |
	| 1920   | 1080  |

@EnterWindow
Scenario: As a registered user, I want to login to the app
    Given I enter the  window enter with the window size <length> and <width>
    And I am a user filling in email and password
	| Email                       | Password        |
	| userTestStudent@example.com | userTestStudent |
    When I click the enter button
    Then A new window should open - Notifications section
    Examples: 
    | length | width |
    | 1920   | 1080  |

@Negative
Scenario: As a registered user, I want to login to the app.Negative
   Given I enter the  window enter with the window size <length> and <width>
   And I am a user filling in email and password
	| Email   | Password   |
	| <Email> | <Password> |
	When I click the enter button
    Then There should be a message with the text - Incorrect login or password and the url won't change
    Examples: 
    | Email                         | Password    | length | width |
    | ShapkaSPodvipodvertom@mail.ru | HarryPotter | 1920   | 1080  |
    | Harry@mail.ru                 | Гарри       | 1920   | 1080  |
    
	