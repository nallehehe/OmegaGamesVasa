*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    86, 146
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/74    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/146
Library    SeleniumLibrary
Library    XML
Library    Collections
Resource    common.resource
Suite Setup    Open browser and maximize

*** Variables ***
${shoppingCartHeaderText}    ShoppingCart

*** Test Cases ***
Shopping cart renders
    [Documentation]    Test case for checking that the shopping cart page renders correctly
    [Tags]    smoke    shopping-cart
    Given the user is on the OmegaGames website
    When the user goes to the shopping cart page
    Then the page should display the shopping cart page

Add single product to cart
    [Documentation]    Test case for adding a single product to cart
    [Tags]    shopping-cart    expected-fail
    Given the user is on the products page
    When the user adds a product to the shopping cart
    Then the shopping cart page should display the added product

*** Keywords ***
the user goes to the shopping cart page
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}

the page should display the shopping cart page
    Wait Until Location Contains    ${SHOPPING_CART_PAGE}
    Wait Until Page Contains    ${shoppingCartHeaderText}

the user adds a product to the shopping cart
    ${productName}=    Get Text    ${firstProductNamePath}
    Click Button    ${addFirstProductButtonPath}
    Set Test Variable    $addedProductName    ${productName}

the shopping cart page should display the added product
    Page Should Contain    ${addedProductName}
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}