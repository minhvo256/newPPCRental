Feature: US02_ViewDetail
	As a Customer 
	I want to see detail project

	Background: 
	Given I am homepage


    Scenario: View detail sucess with click button detail
	When I click button detail 
	Then I see detail project
	
	
	 Scenario: View detail sucess with clik picture of project
	When I ckick picture of project
	Then I see detail project

	Scenario: View drtail sucess with click infomation of project
	When I click infomation line
	Then I see the detail project
	
	
