*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    149
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/149
Library    SeleniumLibrary
Library    Collections
Resource    common.resource
Suite Setup    Open browser and maximize
Suite Teardown    Close All Browsers
Test Setup    Create Product List
Test Teardown    Clear Cart

*** Test Cases ***
Go to checkout with product in cart
    [Documentation]    Test case for going to checkout with a product added to the cart
    [Tags]    checkout    happy-path
    Given the user has a product in the cart
    And the user is on the shopping cart page
    When the user goes to the checkout page
    Then the page should display the checkout page with a product
    
Go to checkout without products
    [Documentation]    Test case for going to checkout with no products
    [Tags]    checkout
    Given the user is on the shopping cart page
    When the user goes to the checkout page
    Then the checkout page should display an empty cart message

Checkout price is correct for one product
    [Documentation]    Test case for checking that the price is correct for one product
    [Tags]    checkout
    Given the user has a product in the cart
    And the user is on the shopping cart page
    When the user goes to the checkout page
    Then the checkout page should display the correct price

Go to checkout with multiple of same product
    [Documentation]    Test case for going to checkout with multiple amount of same product
    [Tags]    checkout
    Given the user has multiple of one product in the cart
    And the user is on the shopping cart page
    When the user goes to the checkout page
    Then the checkout page should display the correct price and amount
    
Enter valid checkout information
    [Documentation]    Test case for entering valid customer information
    [Tags]    checkout    happy-path
    Given the user has a product in the cart
    And the user is on the checkout page
    When the user enters valid customer information
    And the user finalizes the order
    Then the page should display klarna checkout page

Required fields show errors when empty
    [Documentation]    Test case for that required fields show correct error when empty
    [Tags]    checkout
    Given the user has a product in the cart
    And the user is on the checkout page
    When the user enters invalid information
    And the user finalizes the order
    Then the page should display error messages for required fields

Invalid email format shows error
    [Documentation]    Test case for checking that an email in an invalid format shows an error message
    [Tags]    checkout
    Given the user has a product in the cart
    And the user is on the checkout page
    When the user enters an email in an invalid format
    And the user finalizes the order
    Then the page should display an error message for an invalid email format

Invalid phone format shows error
    [Documentation]    Test case for checking that entering a phone number with invalid format shows an error message
    [Tags]    checkout
    Given the user has a product in the cart
    And the user is on the checkout page
    When the user enters a phone number in an invalid format
    And the user finalizes the order
    Then the page should display an error message for an invalid phone number format

Entering different email in email confirmation shows error
    [Documentation]    Test case for checking that entering different emails in email and email confirm fields shows an error message
    [Tags]    checkout
    Given the user has a product in the cart
    And the user is on the checkout page
    When the user enters different emails in the email and confirm email field
    And the user finalizes the order
    Then the page should display an error message for different emails