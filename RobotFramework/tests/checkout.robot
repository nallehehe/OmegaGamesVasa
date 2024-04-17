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
    Given the user has products in the cart
    And the user is on the shopping cart page
    When the user goes to the checkout page
    Then the page should display the checkout page
    
Go to checkout without products
    [Documentation]    Test case for going to checkout with no products
    [Tags]    checkout
    Given the user is on the shopping cart page
    When the user goes to the checkout page
    Then the checkout page should display an empty cart message
    

