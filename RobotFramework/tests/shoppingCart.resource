*** Settings ***
Library    SeleniumLibrary
Library    Collections
Resource    common.resource

*** Variables ***
${firstProductTitle}=    //div[contains(@class, 'product-card')][1]//h4
${secondProductTitle}=    //div[contains(@class, 'product-card')][2]//h4
${firstProductRemoveButton}    //button[contains(@class, 'remove-from-cart-btn')][1]
${secondProductRemoveButton}    //button[contains(@class, 'remove-from-cart-btn')][2]
${emptyCartButton}=    id:clear-cart-btn
${shoppingCartCard}=    //div[contains(@class, 'card-registration')]

${increaseButton}=    //button[contains(@class, 'increase-amount-btn')]
${decreaseButton}=    //button[contains(@class, 'decrease-amount-btn')]

${totalPriceElement}=    //h5[contains(@class, 'total-price')]/span
${firstProductPrice}=    (//div[contains(@class, 'product-price')][1])[1]/span
${secondProductPrice}=    (//div[contains(@class, 'product-price')][1])[2]/span

${emptyCartMessage}=    Kundvagnen är tom!

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
    Wait Until Page Contains Element    ${firstProductPrice}
    ${productPrice}=    Get Text    ${firstProductPrice}
    &{productDict}=    Create Dictionary
    Set To Dictionary    ${productDict}    productName=${productTitle}
    Set To Dictionary    ${productDict}    productPrice=${productPrice}
    ${buttonPath}=    Set Variable    ${firstProductTitle}/parent::*/parent::*//button[contains(@class, 'add-to-cart-button')]
    Wait Until Page Contains Element    ${buttonPath}
    Click Button    ${buttonPath}
    Append To List    ${productDictList}    ${productDict}
Add second product to cart
    Wait Until Page Contains Element    ${secondProductTitle}
    ${productTitle}=    Get Text    ${secondProductTitle}
    &{productDict}=    Create Dictionary
    Wait Until Page Contains Element    ${secondProductPrice}
    ${productPrice}=    Get Text    ${secondProductPrice}
    Set To Dictionary    ${productDict}    productName=${productTitle}
    Set To Dictionary    ${productDict}    productPrice=${productPrice}
    ${buttonPath}=    Set Variable    ${secondProductTitle}/parent::*/parent::*//button[contains(@class, 'add-to-cart-button')]
    Wait Until Page Contains Element    ${buttonPath}
    Click Button    ${buttonPath}
    Append To List    ${productDictList}    ${productDict}

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
    Wait Until Page Contains    ${emptyCartMessage}

the page should display the correct price
    Wait Until Page Contains Element    ${totalPriceElement}
    ${totalPrice}=    Get Text    ${totalPriceElement}
    ${sum}=    Set Variable    ${0}
    FOR    ${product}    IN    @{productDictList}
        ${productPrice}=    Set Variable   ${product}[productPrice] 
        ${sum}=    Set Variable    ${${sum}+${productPrice}}
    END
    Should Be Equal As Integers    ${totalPrice}    ${sum}

Create Product List
    @{productDictList}=    Create List
    Set Test Variable    ${productDictList}