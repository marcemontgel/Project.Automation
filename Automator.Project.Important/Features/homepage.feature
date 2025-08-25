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
	When Add Name Prueba Net
	When Add Telephone 3128596410
	When Add Email pruebanet@gmail.com
	When Click Button Reserve Now
	When Write Credit Card 4111111111111111
	When Write Date Expiration MMYY 1230
	When Write CVV 123
	When Click Button Pay Now