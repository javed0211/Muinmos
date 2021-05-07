Feature: IncidentManagement
	Simple calculator for adding two numbers

@mytag
Scenario Outline: Create New Incident from ITIL portal
	Given I am on '<portal>' portal
	When  I impersonate as '<role>' with '<user>' user
	And   I click on '<menu>' from application tree
	And   I select <subMenu>
	And   I enter Incident details
	And   I submit the changes

	Examples:
		| portal  | role             | user       | menu     |
		| ITIL    | Incident Manager | Hetal Nair | Incident |
		| Service | Incident Manager | Hetal Nair | Incident |