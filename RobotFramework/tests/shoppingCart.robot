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

*** Variables ***
${shoppingCartHeaderText}    ShoppingCart
@{addedProducts}

${firstProductTitle}=    (//h4[contains(@class, 'card-title')])[1]
${secondProductTitle}=    (//h4[contains(@class, 'card-title')])[2]

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

*** Keywords ***
the user goes to the shopping cart page
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}
    Wait Until Page Contains    ${shoppingCartHeaderText}

the page should display the shopping cart page
    Wait Until Location Contains    ${SHOPPING_CART_PAGE}
    Wait Until Page Contains    ${shoppingCartHeaderText}

the page should display an empty cart message
    Wait Until Page Contains    Your cart is empty

the user adds a product to the shopping cart
    Add first product to cart

the user adds two products to the shopping cart
    Add first product to cart
    Add second product to cart
    
Add first product to cart
    Wait Until Page Contains Element    ${firstProductTitle}
    ${productTitle}=    Get Text    ${firstProductTitle}
    ${buttonPath}=    Set Variable    ${firstProductTitle}/parent::*/parent::*//button[contains(@class, 'add-to-cart-button')]
    Wait Until Page Contains Element    ${buttonPath}
    Click Button    ${buttonPath}
    Append To List    ${addedProducts}    ${productTitle}
Add second product to cart
    Wait Until Page Contains Element    ${secondProductTitle}
    ${productTitle}=    Get Text    ${secondProductTitle}
    ${buttonPath}=    Set Variable    ${secondProductTitle}/parent::*/parent::*//button[contains(@class, 'add-to-cart-button')]
    Wait Until Page Contains Element    ${buttonPath}
    Click Button    ${buttonPath}
    Append To List    ${addedProducts}    ${productTitle}

Wait until shopping cart renders items
    Wait Until Page Contains    ${shoppingCartHeaderText}
    Wait Until Page Contains Element    //div[contains(@class, 'container text-center')]

the shopping cart page should display the added product
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}
    Wait until shopping cart renders items
    ${productName}=    Get From List    ${addedProducts}    0
    Wait Until Page Contains  ${productName} 
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}

the shopping cart page should display all added products
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}
    Wait until shopping cart renders items
    FOR    ${productName}    IN    @{addedProducts}
        Wait Until Page Contains    ${productName}
    END