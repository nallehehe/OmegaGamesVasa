*** Settings ***
Documentation    Test suite for testing products page
Metadata    UserStoryIds    74
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/74
Library    SeleniumLibrary
Resource    common.resource
Suite Setup    Open browser and maximize
Suite Teardown    Close All Browsers

*** Variables ***

*** Test Cases ***
Products page renders correctly
    [Documentation]    Test case for rendering products page
    [Tags]    smoke    products    
    Given the user is on the OmegaGames website
    When the user goes to the products page
    Then the website should display the products page

Products page displays multiple products
    [Documentation]    Test case for rendering multiple products
    [Tags]    products    happy-path
    Given the user is on the OmegaGames website
    When the user goes to the products page
    Then the website should display multiple products

*** Keywords ***
the website should display multiple products
    Products are displaying