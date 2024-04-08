*** Settings ***
Documentation    Test suite for testing products page
Metadata    UserStoryName    As a <customer> I want to <see a list of products> because <I want to select products for purchase>
Metadata    UserStoryId    74
Metadata    UserStoryLink    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/74
Library    SeleniumLibrary
Suite Setup    Open browser and maximize

*** Variables ***
${BROWSER}    Chrome
${BASE_URL}    https://localhost:7149
${PAGE}    GetAllProductsPage

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

the user is on the OmegaGames website
    Go To    ${BASE_URL}

the user goes to the products page
    Go To    ${BASE_URL}/${PAGE}

the website should display the products page
    Wait Until Location Contains    ${PAGE}
    Wait Until Page Contains    ${productsPageHeaderText}
