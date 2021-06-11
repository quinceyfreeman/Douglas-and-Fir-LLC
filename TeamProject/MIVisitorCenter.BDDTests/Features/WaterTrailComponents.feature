Feature: As an admin, I would like to have the ability to update content on the Willamette River Trail page, so that I can keep information on the trail up to date


Scenario: Link to Manage Page visible on navbar
    Given I am on the Homepage
    And I am signed in as the admin
    Then I will see a link to the Manage Page in the navbar

Scenario: Link to Manage Page not visible on navbar as business owner
    Given I am on the Homepage
    And I am signed in as a business owner
    Then I will not see a link to the Manage Page in the navbar

Scenario: Link to Manage Page not visible on navbar as visitor
    Given I am on the Homepage
    And I am not signed in to the site
    Then I will not see a link to the Manage Page in the navbar

Scenario: Willamette River Trail components visible in Manage Page
    Given I am signed in as the admin
    And I am on the Manage Page
    When I click on the Willamette River Trail subnav
    Then I will see all Willamette River Trail components displayed

Scenario: Admin can edit content for Willamette River Trail components
    Given I am signed in as the admin
    And I am viewing the Willamette River Trail components
    When update the content of the components
    Then the updated components content is shown on the Manage Page
