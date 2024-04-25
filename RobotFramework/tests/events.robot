*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    116    128
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/116
...    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/128
Library    SeleniumLibrary
Library    Collections
Resource    common.resource

Suite Setup    Open browser and maximize
Suite Teardown    Close All Browsers
Test Setup    Create Event List
Test Teardown    Delete All Cookies

*** Test Cases ***
View events
    [Documentation]    Test case for viewing the events page
    [Tags]    events
    Given the user is on the OmegaGames website
    When the user goes to the events page
    Then the page should display events

Add event to cart
    [Documentation]    Test case for adding event to cart
    [Tags]    events    happy-path
    Given the user is on the events page
    When the user adds an event to the shopping cart
    And the user goes to the shopping cart page
    Then the shopping cart should display the added events
