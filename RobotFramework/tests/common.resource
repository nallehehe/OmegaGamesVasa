*** Settings ***
Library    SeleniumLibrary

*** Variables ***
${BROWSER}    Chrome
${PRODUCTS_PAGE}    GetAllProductsPage
${SHOPPING_CART_PAGE}    ShoppingCart
${BASE_URL}    https://localhost:7149

${productsXpath}    //div[contains(@class, 'product-container')]//div[contains(@class, 'card')]

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