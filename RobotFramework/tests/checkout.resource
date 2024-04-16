*** Settings ***
Resource    common.resource

*** Variables ***
${goToCheckoutButton}=    //button[@id='go-to-checkout-btn']
${checkoutHeader}    //h3[@id='checkout-header']
${firstNameInput}    //input[@id='FirstName']
${lastNameInput}    //input[@id='LastName']
${emailInput}    //input[@id='Email']
${emailConfirmInput}    //input[@id='EmailVali']
${phoneInput}    //input[@id='Phone']

*** Keywords ***
Go to checkout page
    Go to shopping cart page
    Wait Until Page Contains Element    ${goToCheckoutButton}
    Click Button    ${goToCheckoutButton}
the user has products in the cart
    Go to products page
    Products are displaying
    Add first product to cart

the user goes to the checkout page
    Go to checkout page

the page should display the checkout page
    Wait Until Page Contains Element    //h3[@id='checkout-header']
    Wait Until Page Contains Element    ${firstNameInput}
    Wait Until Page Contains Element    ${lastNameInput}
    Wait Until Page Contains Element    ${emailInput}
    Wait Until Page Contains Element    ${emailConfirmInput}
    Wait Until Page Contains Element    ${phoneInput}
    