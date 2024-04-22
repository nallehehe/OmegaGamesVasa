*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    119, 345
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/119
...    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/345
Library    SeleniumLibrary
Library    Collections
Resource    common.resource
Suite Setup    Open browser and maximize
Suite Teardown    Close All Browsers
Test Teardown    Delete All Cookies

*** Test Cases ***
Access orders page
    [Documentation]    Test case for accessing orders page
    [Tags]    orders
    Given the admin is signed in
    When the admin goes to the orders page
    Then the website should display the orders page
    And the page should contain orders

Unauthenticated user should not see orders link
    [Documentation]    Test case for checking that unauthenticated users don't see the orders link
    [Tags]    orders
    Given the user has a browser open
    When the user goes to the OmegaGames website
    Then the page should not display a link to the orders page
    
Unauthenticated user should not be able to access orders
    [Documentation]    Test case for checking that unauthenticated users cannot access orders page
    [Tags]    orders
    Given the user is on the OmegaGames website
    When the user goes to the orders page
    Then the page should display the login page