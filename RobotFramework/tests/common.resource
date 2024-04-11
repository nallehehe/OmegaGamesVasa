*** Settings ***
Library    SeleniumLibrary

*** Variables ***
${SLEEP_TIME}=    600ms
${BROWSER}    Chrome
${PRODUCTS_PAGE}    GetAllProductsPage
${SHOPPING_CART_PAGE}    ShoppingCart
${BASE_URL}    https://localhost:7149

${productsXpath}    //div[contains(@class, 'product-card')]
${firstProductXpath}    //div[contains(@class, 'card')][1]
${firstProductNamePath}    //h4[contains(@class, 'card-title')][1]
${addFirstProductButtonPath}    //button[contains(@class, 'add-to-cart-button')][1]
${productsContainerElement}    //div[contains(@class, 'product-container')]

${shoppingCartImage}    //div[contains(@class, 'shopping-cart-image')]

*** Keywords ***
Open browser and maximize
    Open Browser    browser=${BROWSER}    options=add_argument("--incognito")
    Maximize Browser Window
    Set Selenium Speed    0.1

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

Go to products page
    Go To    ${BASE_URL}/${PRODUCTS_PAGE}
    Sleep    ${SLEEP_TIME}

Go to shopping cart page
    Go To    ${BASE_URL}/${SHOPPING_CART_PAGE}
    Sleep    ${SLEEP_TIME}

the user is on the products page
    Go to products page
    Wait Until Page Contains Element    ${productsContainerElement}

the products page is displaying products
    Products are displaying

the user is on the shopping cart page
    Go to shopping cart page