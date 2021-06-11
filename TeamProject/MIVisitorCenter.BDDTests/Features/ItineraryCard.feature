Feature: As a visitor to the site, I would like to view itinerary cards in an intuitive way.


Scenario: View Itinerary Card for One Day Intinerary
    Given I am on the Plan a Trip Page
    Then I will see an itinerary card for a one day itinerary

Scenario: View Itinerary Cards for Two Day Intinerary
    Given I am on the Plan a Trip Page
    Then I will see an itinerary card for a two day itinerary

Scenario: View Itinerary Cards details on card interaction
    Given I am on the Plan a Trip Page
    When I click on the view more details button
    Then I will see a modal with more details on the itinerary
