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
Test Teardown    Clear Cart

*** Variables ***

@{productDictList}

${firstProductTitle}=    //div[contains(@class, 'product-card')][1]//h4
${secondProductTitle}=    //div[contains(@class, 'product-card')][2]//h4
${firstProductRemoveButton}    //button[contains(@class, 'remove-from-cart-btn')][1]
${secondProductRemoveButton}    //button[contains(@class, 'remove-from-cart-btn')][2]
${emptyCartButton}=    id:clear-cart-btn
${shoppingCartCard}=    //div[contains(@class, 'card-registration')]

${increaseButton}=    //button[contains(@class, 'increase-amount-btn')]
${decreaseButton}=    //button[contains(@class, 'decrease-amount-btn')]

${emptyCartMessage}=    Kundvagnen är tom!

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
    [Tags]    shopping-cart    expected-fail
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

Remove product from cart
    [Documentation]    Test case for removing product from cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    When the user removes the product from the shopping cart
    Then the page should display an empty cart message

Increment product in cart
    [Documentation]    Test case for incrementing product amount in cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    When the user increments the amount of the product
    Then the product should have an incremented amount

Decrement product in cart
    [Documentation]    Test case for decrementing product amount in cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    And the user increments the amount of the product twice
    When the user decrements the amount of the product
    Then the product should have an decremented amount

Clear cart with single product
    [Documentation]    Test case for clearing cart
    [Tags]    shopping-cart
    Given the user is on the products page
    And the products page is displaying products
    And the user adds a product to the shopping cart
    And the user goes to the shopping cart page
    When the user clicks the clear cart button
    Then the page should display an empty cart message

*** Keywords ***
the user goes to the shopping cart page
    Go to shopping cart page
    Wait Until Page Contains Element    ${shoppingCartImage}

the page should display the shopping cart page
    Wait Until Location Contains    ${SHOPPING_CART_PAGE}
    Wait Until Page Contains Element    ${shoppingCartImage}

the page should display an empty cart message
    Wait Until Page Contains    Kundvagnen är tom!

the user adds a product to the shopping cart
    Add first product to cart

the user adds two products to the shopping cart
    Add first product to cart
    Add second product to cart
    
Add first product to cart
    Wait Until Page Contains Element    ${firstProductTitle}
    ${productTitle}=    Get Text    ${firstProductTitle}
    &{productDict}=    Create Dictionary
    Set To Dictionary    ${productDict}    productName=${productTitle}
    ${buttonPath}=    Set Variable    ${firstProductTitle}/parent::*/parent::*//button[contains(@class, 'add-to-cart-button')]
    Wait Until Page Contains Element    ${buttonPath}
    Click Button    ${buttonPath}
    Append To List    ${productDictList}    ${productDict}
Add second product to cart
    Wait Until Page Contains Element    ${secondProductTitle}
    ${productTitle}=    Get Text    ${secondProductTitle}
    &{productDict}=    Create Dictionary
    Set To Dictionary    ${productDict}    productName=${productTitle}
    ${buttonPath}=    Set Variable    ${secondProductTitle}/parent::*/parent::*//button[contains(@class, 'add-to-cart-button')]
    Wait Until Page Contains Element    ${buttonPath}
    Click Button    ${buttonPath}
    Append To List    ${productDictList}    ${productDict}
    Log To Console    ${productDictList}

Wait until shopping cart renders items
    Wait Until Page Contains Element    ${shoppingCartImage}
    Wait Until Page Contains Element    ${shoppingCartCard}

the shopping cart page should display the added product
    Go to shopping cart page
    Wait until shopping cart renders items
    ${product}=    Get From List    ${productDictList}    0
    Wait Until Page Contains  ${product}[productName]
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}

the shopping cart page should display all added products
    Go to shopping cart page
    Wait until shopping cart renders items
    FOR    ${product}    IN    @{productDictList}
        Log To Console    ${product}[productName]
        Wait Until Page Contains    ${product}[productName]
    END
    
the user clicks the clear cart button
    Wait Until Page Contains Element    ${emptyCartButton}
    Click Button    ${emptyCartButton}

the user removes the product from the shopping cart
    Go to shopping cart page
    Wait Until Page Contains Element    ${firstProductRemoveButton}
    Click Button    ${firstProductRemoveButton}

the user increments the amount of the product
    Go to shopping cart page
    ${product}=    Get From List    ${productDictList}    0
    Wait Until Page Contains  ${product}[productName]
    Wait Until Page Contains Element    ${increaseButton}
    Click Button    ${increaseButton}

the user increments the amount of the product twice
    Go to shopping cart page
    ${product}=    Get From List    ${productDictList}    0
    Wait Until Page Contains  ${product}[productName]
    Wait Until Page Contains Element    ${increaseButton}
    Click Button    ${increaseButton}
    Click Button    ${increaseButton}

the user decrements the amount of the product
    ${product}=    Get From List    ${productDictList}    0
    Wait Until Page Contains  ${product}[productName]
    Wait Until Page Contains Element    ${decreaseButton}
    Click Button    ${decreaseButton}

the product should have an incremented amount
    Wait Until Page Contains Element    identifier:quantity
    ${amountCountText}=    Get Value    identifier:quantity
    Should Be Equal As Integers    2    ${amountCountText}

the product should have an decremented amount
    Wait Until Page Contains Element    identifier:quantity
    ${amountCountText}=    Get Value    identifier:quantity
    Should Be Equal As Integers    2    ${amountCountText}

Clear Cart
    Go to shopping cart page
    ${emptyCartCount}=    SeleniumLibrary.Get Element Count    //p[text()='Your cart is empty']
    Return From Keyword If    ${emptyCartCount} > 0
    Wait Until Page Contains Element    ${emptyCartButton}
    Click Button    ${emptyCartButton}