Feature: Journal_Window

Как преподаватель, я хочу вести журнал у своей группы

@JournalWindow
Scenario: As a teacher, I want to sort by last name
 Given I log in to the system  with the window size <length> and <width>
    | Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	And I click button Journal
	Then Check that you have entered the Journal window
	Given Select group in window Journal
	When Click on filter rating down
	Then Checking that the rating order has changed in ascending order
	When Click on filter rating up
	Then Checking that the rating order has changed in descending order
	Given Horizontal scroll
	Then Checking the class date
	Then Verify that the desired attendance item is selected
	When Click to sort by last name
	Then The list of students should be sorted by last name
	Examples: 
	| length | width |
	| 1920   | 1080  |

	@JournalWindow
	Scenario: Checking that the log is filled out correctly
	Given I log in to the system  with the window size <length> and <width>
    | Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	And I click button Journal
	And Select group in window Journal
	Then We check that the student corresponds to the element of attendance and the date of the lesson
	Examples: 
	| length | width |
	| 1920   | 1080  |
