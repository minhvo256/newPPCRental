Feature: US01_ProjectSearch
	As a customer
	I want to search for projects by a keyword
	So that I can easily search projects by keyword name of projects 

	Background: 
	Given I access to PPC Rental Website
	And I press search button

    Scenario: Simple search
	When I search for projects by the keyword 'Top'
	Then the list of found projects should contain only: 'PIS Top Apartment'
	
	
	 Scenario: Simple search fail
	When I search for projects by the name 'nm'
	Then note : 'No Property found'

		


	


