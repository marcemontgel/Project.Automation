Feature: homepage

A short summary of the feature

@Browser=Chrome
Scenario: Navigate
	Given Navigate to the website home page https://holacarrentals.com/
	#When Write location Orlando and select location Orlando International Airport, MCO, Orlando, Florida
	When Select Pick-Up Date 50
	When Select Drop-off Date 56
	When Select Hour PickUp 3:00 PM
	When Asign Hour Return 8:30 AM
	When Click Button SearchCar
	When Select Vehicle