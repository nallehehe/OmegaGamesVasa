*** Settings ***
Documentation    Test suite for testing shopping cart functionality
Metadata    UserStoryIds    86, 146
Metadata    UserStoryLinks    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/86    https://dev.azure.com/TeamVasa/TeamVasa/_workitems/edit/146
Library    SeleniumLibrary
Library    XML
Library    Collections
Resource    common.resource
Suite Setup    Open browser and maximize

*** Variables ***
${shoppingCartHeaderText}    ShoppingCart
@{addedProducts}

*** Test Cases ***
Shopping cart renders
    [Documentation]    Test case for checking that the shoqpping cart page renders correctly
    [Tags]    smoke    shopping-cart
    Given the user is on the OmegaGames website
    When the user goes to the shopping cart page
    Then the page should display the shopping cart page

Add single product to cart
    [Documentation]    Test case for adding a single product to cart
    [Tags]    shopping-cart
    Given the user is on the products page
    When the user adds a product to the shopping cart
    Then the shopping cart page should display the added product

Add multiple products to cart
    [Documentation]    Test case for adding multiple products to cart
    [Tags]    shopping-cart
    Given the user is on the products page
    When the user adds two products to the shopping cart
    Then the shopping cart page should display all added products

*** Keywords ***
the user goes to the shopping cart page
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}

the page should display the shopping cart page
    Wait Until Location Contains    ${SHOPPING_CART_PAGE}
    Wait Until Page Contains    ${shoppingCartHeaderText}

the user adds a product to the shopping cart
    Add product with index 1 to cart

the user adds two products to the shopping cart
    Add product with index 1 to cart
    Add product with index 2 to cart
    Log To Console    ${addedProducts}
    
Add product with index ${index} to cart
    ${productTitlePath}=    Set Variable    (//h4[contains(@class, 'card-title')])[${index}]
    ${productTitle}=    Get Text    ${productTitlePath}
    ${buttonPath}=    Set Variable    ${productTitlePath}/parent::*/parent::*//button[contains(@class, 'add-to-cart-button')]
    Click Button    ${buttonPath}
    Append To List    ${addedProducts}    ${productTitle}

the shopping cart page should display the added product
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}
    Wait Until Page Contains    ${shoppingCartHeaderText}
    ${productName}=    Get From List    ${addedProducts}    0
    Page Should Contain   ${productName} 
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}

the shopping cart page should display all added products
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}
    Wait Until Page Contains    ${shoppingCartHeaderText}
    FOR    ${productName}    IN    @{addedProducts}
        Page Should Contain    ${productName}
    END