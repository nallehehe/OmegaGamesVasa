*** Settings ***
Resource    common.resource

*** Variables ***
${ORDERS_PAGE}=    Orders
${ordersHeader}=    //h3[text()='All Orders']
${orderCard}=    //div[contains(@class, 'order-card')]

*** Keywords ***
the admin is signed in
    Go to admin login page
    Sign in as admin
    
the admin goes to the orders page
    Go to Orders page

Go to Orders page
    Click Link    /${ORDERS_PAGE}
    Sleep    ${SLEEP_TIME}

the website should display the orders page
    Wait Until Page Contains Element    ${ordersHeader}
    
the page should not display a link to the orders page
    Page Should Not Contain Link    /${ORDERS_PAGE}

the user goes to the orders page
    Go to Orders url

Go to Orders url
    Go To    ${BASE_URL}/${ORDERS_PAGE}

the page should display the login page
    Wait Until Page Contains Element    ${loginForm}

the page should contain orders
    Wait Until Page Contains Element    ${orderCard}
    @{orders}=    Get WebElements    ${orderCard}
    ${orderCount}=    Get Length    ${orders}
    Should Be True    ${orderCount} > 0