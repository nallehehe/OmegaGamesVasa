*** Settings ***
Library    SeleniumLibrary

*** Variables ***
${BROWSER}    Chrome
${PRODUCTS_PAGE}    GetAllProductsPage
${SHOPPING_CART_PAGE}    ShoppingCart
${BASE_URL}    https://localhost:7149

*** Keywords ***
Open browser and maximize
    Open Browser    browser=${BROWSER}
    Maximize Browser Window
    Set Selenium Speed    0.1

the user is on the OmegaGames website
    Go To    ${BASE_URL}

the user is on the products page
    Go To    ${BASE_URL}/${PRODUCTS_PAGE}