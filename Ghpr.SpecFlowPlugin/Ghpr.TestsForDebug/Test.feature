Feature: Test
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
	
@mytag
Scenario: Add two numbers
	Given I have number 50
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	And I add test data
	Then the result should be 120 on the screen

@mytag
Scenario: Add two numbers v2
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 140 on the screen

@outline
Scenario Outline: Some tests with table
Given I take '<First>' from table
And I take '<Second>' from table
Then the sum should be '<Result>'

Examples: 
| First | Second | Result |
| 1     | 2      | 3      | 
| 1     | 3      | 4      | 
| 1     | 2      | 10     | 