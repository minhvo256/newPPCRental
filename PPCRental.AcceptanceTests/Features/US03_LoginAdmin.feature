Feature: US03_LoginAdmin
	As a Admin
	I want to login admin

	Background: 
	Given I am loginpage


    Scenario: Login success with valid account
	When I input account and click button Login
	Then I am admin page
	
	
	 Scenario: Login fail with invalid account
	When I input invalid account and click button Login
	Then I see the red line:Account does not exist

	Scenario: Login fail with input only username or password
	When I input only username and click button Login
	Then I see the red line:Account does not exist
	
	

