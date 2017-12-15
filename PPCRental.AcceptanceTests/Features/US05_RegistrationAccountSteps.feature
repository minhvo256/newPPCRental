Feature: US05_RegistrationAccountSteps
	As a customer
	I want to register account

	Background: 
	Given I am at home page
	And I click registration button


    Scenario: register sucess with full valid informatinon 
	When I input full valid informatinon
	And i click button register
	Then I see message Successful Register
	
	
	Scenario: register fail with one or full empty informatinon 
	When I input one or full empty informatinon
	And i click buuton register
	Then I see message This field is required at empty informatinon

	Scenario: Login fail with email exist
	When I inputemail exist
	And i click buuton register
	Then I see message Email already exist
	