*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    149
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/149
Library    SeleniumLibrary
Library    Collections
Resource    common.resource

Suite Setup    Open browser and maximize
Suite Teardown    Close All Browsers
Test Teardown    Delete All Cookies

*** Test Cases ***
Login with valid admin credentials
    [Documentation]    Test case for valid admin login
    [Tags]    admin-login    happy-path
    Given the user is on the admin login page
    When the user enters valid admin login
    And the user clicks the login button
    Then the page should display successful login

Login with invalid admin credentials
    [Documentation]    Test case for invalid admin login
    [Tags]    admin-login
    Given the user is on the admin login page
    And the user enters invalid admin login
    And the user clicks the login button
    Then the page should display a login error message