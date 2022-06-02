Feature: Journal_Window

Как преподаватель, я хочу вести журнал у своей группы

@JournalWindow
Scenario: As a teacher, I want to keep a journal for my group
	Given I logged in as a teacher and went to the journal window with the window size <length> and <width>
	| Email                       | Password        |
    | userTestStudent@example.com | userTestStudent |
	Then Check that you have entered the Journal window
	Given 
	Examples: 
	| length | width |
	| 1920   | 1080  |
	
