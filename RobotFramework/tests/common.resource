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

*** Keywords ***
Open browser and maximize
    Open Browser    browser=${BROWSER}
    Maximize Browser Window
    Set Selenium Speed    0.1

Get all products on page
    ${products}=    Get WebElements    ${productsXpath}
    ${productsCount}=    Get Length    ${products}
    Log To Console    ${productsCount}
    RETURN    ${products}

the user is on the OmegaGames website
    Go To    ${BASE_URL}

the user is on the products page
    Go To    ${BASE_URL}/${PRODUCTS_PAGE}