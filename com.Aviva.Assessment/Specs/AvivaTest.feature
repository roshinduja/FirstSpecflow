### Author :: Roshini Hinduja

Feature: Google search and printing data from the results
	As a generic user 
	I want to search for the keyword
	so that I can retrieve data from the results

Background: Launch Google search engine
Given I launch Google homepage on the web browser


@PositiveScenario:
Scenario Outline: Search with valid data and print result
	When I enter '<keyword>' in the searchbox
	And hit search button
	Then suitable results should be displayed
	And I should be able to display all links and print fifth link

Examples: 
| keyword |
| Aviva   |


@NegativeScenario:
Scenario: Search with invalid data and print error text
When I enter keyword in the searchbox
| keyword       |
| $#%@%!^@^@%#% |
And hit search button
Then suitable error message should be displayed
