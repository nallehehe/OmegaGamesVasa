*** Settings ***
Library    SeleniumLibrary

*** Variables ***
${BROWSER}    Chrome
${PRODUCTS_PAGE}    GetAllProductsPage
${SHOPPING_CART_PAGE}    ShoppingCart
${BASE_URL}    https://localhost:7149

${productsXpath}    //div[contains(@class, 'product-container')]//div[contains(@class, 'card')]
${firstProductXpath}    //div[contains(@class, 'card')][1]
${firstProductNamePath}    //h4[contains(@class, 'card-title')][1]
${addFirstProductButtonPath}    //button[contains(@class, 'add-to-cart-button')][1]
${productsContainerElement}    //div[contains(@class, 'product-container')]
${shoppingCartHeaderText}    ShoppingCart

*** Keywords ***
Open browser and maximize
    Open Browser    browser=${BROWSER}
    Maximize Browser Window
    Set Selenium Speed    0.2

Get all products on page
    Wait Until Page Contains Element    ${productsXpath}
    ${products}=    Get WebElements    ${productsXpath}
    ${productsCount}=    Get Length    ${products}
    RETURN    ${products}

Products are displaying
    ${products}=    Get all products on page
    ${productsCount}=    Get Length    ${products}
    Should Be True    ${productsCount} > 0

the user is on the OmegaGames website
    Go To    ${BASE_URL}

the user is on the products page
    Go To    ${BASE_URL}/${PRODUCTS_PAGE}
    Wait Until Page Contains Element    ${productsContainerElement}

the products page is displaying products
    Products are displaying

the user is on the shopping cart page
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}
    Wait Until Page Contains    ${shoppingCartHeaderText}