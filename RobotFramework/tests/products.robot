*** Settings ***
Documentation    Test suite for testing products page
Metadata    UserStoryIds    74
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/74
Library    SeleniumLibrary
Resource    common.resource
Suite Setup    Open browser and maximize

*** Variables ***
${productsPageHeaderText}    GetAllProductsPage

*** Test Cases ***
Products page renders correctly
    [Documentation]    Test case for rendering products page
    [Tags]    smoke    products
    Given the user is on the OmegaGames website
    When the user goes to the products page
    Then the website should display the products page

*** Keywords ***
Open browser and maximize
    Open Browser    browser=${BROWSER}
    Maximize Browser Window
    Set Selenium Speed    0.1

the user goes to the products page
    Go To    ${BASE_URL}/${PRODUCTS_PAGE}

the website should display the products page
    Wait Until Location Contains    ${PRODUCTS_PAGE}
    Wait Until Page Contains    ${productsPageHeaderText}
