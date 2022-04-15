Feature: Registration

Страница регистрации новых клиентов (студентов)


Scenario: Registration in system
	Given Create registration model
	When Activete registration endpoint
	Then Should return CREATED response 
