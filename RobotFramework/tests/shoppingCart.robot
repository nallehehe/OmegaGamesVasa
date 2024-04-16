*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    86, 146
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/86    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/146
Library    SeleniumLibrary
Library    XML
Library    Collections
Resource    common.resource
Suite Setup    Open browser and maximize
Suite Teardown    Close All Browsers
Test Setup    Create Product List
Test Teardown    Clear Cart

*** Test Cases ***
Shopping cart renders
    [Documentation]    Test case for checking that the shoqpping cart page renders correctly
    [Tags]    smoke    shopping-cart
    Given the user is on the OmegaGames website
    When the user goes to the shopping cart page
    Then the page should display the shopping cart page

Empty shopping cart displays message
    [Documentation]    Test case for checking that the shopping cart page shows a message
    ...    if the shopping cart is empty
    [Tags]    shopping-cart
    Given the user is on the OmegaGames website
    When the user goes to the shopping cart page
    Then the page should display the shopping cart page
    And the page should display an empty cart message

Add single product to cart
    [Documentation]    Test case for adding a single product to cart
    [Tags]    shopping-cart    happy-path
    Given the user is on the products page
    And the products page is displaying products
    When the user adds a product to the shopping cart
    Then the shopping cart page should display the added product

Add multiple products to cart
    [Documentation]    Test case for adding multiple products to cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    When the user adds two products to the shopping cart
    Then the shopping cart page should display all added products

Remove product from cart
    [Documentation]    Test case for removing product from cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    When the user removes the product from the shopping cart
    Then the page should display an empty cart message

Increment product in cart
    [Documentation]    Test case for incrementing product amount in cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    When the user increments the amount of the product
    Then the product should have an incremented amount

Decrement product in cart
    [Documentation]    Test case for decrementing product amount in cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    And the user increments the amount of the product twice
    When the user decrements the amount of the product
    Then the product should have an decremented amount

Clear cart with single product
    [Documentation]    Test case for clearing cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    And the user goes to the shopping cart page
    When the user clicks the clear cart button
    Then the page should display an empty cart message

Cart displays correct price for single product
    [Documentation]    Test case for checking that the total price of the cart is correct for single product
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    When the user goes to the shopping cart page
    Then the page should display the correct price

Cart displays correct price for multiple products
    [Documentation]    Test case for checking that the total price of the cart is correct for single product
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds two products to the shopping cart
    When the user goes to the shopping cart page
    Then the page should display the correct price

Cart only shows products added in current browser
    [Documentation]    Test case for making sure shopping cart isn't shared between browsers
    [Tags]    shopping-cart
    Given two browsers are open
    And the user is on the products page
    And the user adds a product to the shopping cart
    And the user switches browser
    When the user goes to the shopping cart page
    Then the page should display an empty cart message

