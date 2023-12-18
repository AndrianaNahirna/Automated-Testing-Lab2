Feature: Customers

  Scenario: Search customer
    Given I am on the banking website
    When I select "Login as Bank Manager" option
    Then I click "Add Customer"
    Then I enter data about person and add customer
    Then I click OK on alert
    When I click "Customers" 
    Then I should see a newly added person
    Then I click "Add Customer" once more
    Then I enter data about the same person and click "add customer"
    Then I should see alert that it's duplicate
    When I click "Customers" again
    Then I shouldn't see duplicate
    #Then I should see an error message
    Then I should close Chrome