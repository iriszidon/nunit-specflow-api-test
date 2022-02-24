Feature: ApiExampleTests

This is a sample test to demonstrate api call to some dummy server
@sanity
Scenario: Sample test for api get Platinume User id
	Given a platinum user id "1"
	When I call method with endpoint todos
	Then the returned id is "1"


@test-with-many-params
Scenario: Sample test for many params
	Given two numbers with values '<fisrtNumber>' and '<secondNumber>'
	When I add two numbers
	Then the sum of the numbers is '10'
	Examples: 
	| fisrtNumber | secondNumber |
	| 5			  | 5			 |
	| 6			  | 4			 |
	| 3			  | 7			 |
	| 1			  | 9			 |
	| -1		  | 11			 |
	| -50	      | 60			 |


