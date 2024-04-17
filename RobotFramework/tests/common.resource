*** Settings ***
Library    SeleniumLibrary
Resource    shoppingCart.resource
Resource    checkout.resource

*** Variables ***
${SLEEP_TIME}=    800ms
${BROWSER}    Chrome
${PRODUCTS_PAGE}    ProductPage
${SHOPPING_CART_PAGE}    ShoppingCart
${BASE_URL}    https://localhost:7149

${productsXpath}    //div[contains(@class, 'product-card')]
${firstProductXpath}    //div[contains(@class, 'product-card')][1]
${firstProductNamePath}    //h4[contains(@class, 'card-title')][1]
${addFirstProductButtonPath}    //button[contains(@class, 'add-to-cart-button')][1]
${productsContainerElement}    //div[contains(@class, 'product-container')]

${shoppingCartImage}    //div[contains(@class, 'shopping-cart-image')]

*** Keywords ***
Open browser and maximize
    Open Browser    browser=${BROWSER}
    Maximize Browser Window
    Set Selenium Speed    0.1
    Go To    ${BASE_URL}

Open incognito browser
    Open Browser    browser=${BROWSER}    options=add_argument("--incognito")
    Maximize Browser Window
    Go To    ${BASE_URL}

Get all products on page
    Wait Until Page Contains Element    ${firstProductXpath}    10s
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
    Click Link    /ProductPage
    Sleep    ${SLEEP_TIME}

Go to shopping cart page
    Click Link    /ShoppingCart
    Sleep    ${SLEEP_TIME}

the user is on the products page
    Go to products page
    Wait Until Page Contains Element    ${productsContainerElement}

the products page is displaying products
    Products are displaying

the user is on the shopping cart page
    Go to shopping cart page

the user has a browser open
    @{browserIds}=    Get Browser Ids    
    ${browserIdLength}=    Get Length    ${browserIds}
    Return From Keyword If    ${browserIdLength} > 0

the user goes to the OmegaGames website
    Go To    ${BASE_URL}
    Sleep    ${SLEEP_TIME}

the user goes to the products page
    Go to products page

the website should display the products page
    Wait Until Location Contains    ${PRODUCTS_PAGE}
    Wait Until Page Contains Element    ${productsContainerElement}

two browsers are open
    Open incognito browser
    
the user switches browser
    Switch Browser    1
    
