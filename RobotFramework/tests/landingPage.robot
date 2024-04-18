*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    218
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/218
Library    SeleniumLibrary
Library    Collections
Resource    common.resource
Suite Setup    Open browser and maximize
Suite Teardown    Close All Browsers

*** Variables ***
${topSection}=    class:frontpage2
${carousel}=    class:carousel
${section3}=    class:section3
${welcomeText}=    Välkommen till Omega Games!

*** Test Cases ***
Landing page renders
    Given the user has a browser open
    When the user goes to the OmegaGames website
    Then the website should display the landing page

*** Keywords ***
the website should display the landing page
    Wait Until Page Contains Element    ${topSection}
    Wait Until Page Contains Element    ${carousel}
    Wait Until Page Contains Element    ${section3}
    Wait Until Page Contains    ${welcomeText}

