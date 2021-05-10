Feature: Assignment - Muinmos
	“Write a small program in C# finds as many prime numbers as possible in 1 minute, starting from a input argument.
	On this create a blackbox test scenarios verifying: results (is it actually primes) and count of primes found. And other aspects you think should be tested.”

@Assignment @Muinmos @PrimeNumber
Scenario Outline: Find prime numbers in 1 min from a input argument
	Given I find prime number from <startNumber> in <time> min
	Then I test results are all prime numbers
	And The count of prime number

	Examples:
		| startNumber | time |
		| 25          | 1    |
		| 3457        | 1    |

@PrimeNumber @UsingExcel
Scenario Outline: Find prime numbers in 1 min from excel sheet
	Given I find prime number from <excelName> in <time> min
	Then I test results are all prime numbers
	And The count of prime number

	Examples:
		| excelName | time |
		| Test1     | 1    |
		| Test2     | 1    |