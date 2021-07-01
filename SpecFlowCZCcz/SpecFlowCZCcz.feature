Feature: SpecFlowFeature1Steps
	Search given product
	select first category
	select first product on page and add it to cart
	check that product is in the cart

@mytag
Scenario: Add item to cart 
	Given that i am on the czc webpage
	When find search box to enter <findingproduct>
	When click search button
	When click first category
	When add first product to cart
	Then verify whether item is added to cart
	Then close the browser instance

	Examples: 
	|findingproduct|
	|smartphone|
	|notebook|
	|keyboard|