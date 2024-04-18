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
${productAmountCheckout}    //h6[contains(@class, 'product-amount')]

${firstNameInput}=    //input[@id='FirstName']
${lastNameInput}=    //input[@id='LastName']
${emailInput}=    //input[@id='Email']
${emailConfirmInput}=    //input[@id='EmailVali']
${phoneInput}=    //input[@id='Phone']

${orderSubmitButton}=    //button[contains(@class, 'submit-button')]

${firstNameValidation}=    id:first-name-validation
${lastNameValidation}=    id:last-name-validation
${emailValidation}=    id:email-validation
${phoneValidation}=    id:phone-validation

${requiredMessage}=    Kan inte lämnas tomt
${successfulOrderMessage}=    Din order gick igenom!
    

*** Keywords ***
Go to checkout page
    Go to shopping cart page
    Wait Until Page Contains Element    ${goToCheckoutButton}
    Click Button    ${goToCheckoutButton}
Given the user has a product in the cart
    Go to products page
    Products are displaying
    Add first product to cart

the user goes to the checkout page
    Go to checkout page

the page should display the checkout page with a product
    Wait Until Page Contains Element    //h3[@id='checkout-header']
    Wait Until Page Contains Element    ${firstNameInput}
    Wait Until Page Contains Element    ${lastNameInput}
    Wait Until Page Contains Element    ${emailInput}
    Wait Until Page Contains Element    ${emailConfirmInput}
    Wait Until Page Contains Element    ${phoneInput}
    Wait Until Page Contains Element    ${productAmountCheckout}
    ${productAmountCheckoutText}=    Get Text    ${productAmountCheckout}
    Should Be Equal As Strings    ${productAmountCheckoutText}    x 1
    @{productList}=    Get Dictionary Values    ${productsDict}
    Wait Until Page Contains    ${productList}[0][productName]
    
the checkout page should display an empty cart message
    Wait Until Page Contains    Lägg till produkter i kundvagnen för att gå till kassan

the checkout page should display the correct price
    Wait Until Page Contains Element    ${totalPriceElement}
    ${totalPrice}=    Get Text    ${totalPriceElement}
    ${sum}=    Set Variable    ${0}
    @{productList}=    Get Dictionary Values    ${productsDict}
    FOR    ${product}    IN    @{productList}
        ${productPrice}=    Set Variable   ${product}[productPrice] 
        ${sum}=    Evaluate    ${sum}+(${product}[productAmount]*${productPrice})
    END
    Should Be Equal As Integers    ${totalPrice}    ${sum}

the checkout page should display the correct price and amount
    the checkout page should display the correct price
    Wait Until Page Contains Element    ${productAmountCheckout}
    ${productAmountCheckoutText}=    Get Text    ${productAmountCheckout}
    @{productList}=    Get Dictionary Values    ${productsDict}
    ${productAmount}=    Set Variable    ${productList}[0][productAmount]
    Should Be Equal As Strings    ${productAmountCheckoutText}    x ${productAmount}
    Log To Console    ${productAmount}
    
the user is on the checkout page
    Go to shopping cart page
    Go to checkout page

the user enters valid customer information
    Enter firstname    Testare
    Enter lastname    Testsson
    Enter email    test@example.com
    Enter email confirm    test@example.com
    Enter phone    070-1740635

Enter firstname
    [Arguments]    ${firstName}
    Wait Until Page Contains Element    ${firstNameInput}
    Input Text    ${firstNameInput}    ${firstName}

Enter lastname
    [Arguments]    ${lastName}
    Wait Until Page Contains Element    ${lastNameInput}
    Input Text    ${lastNameInput}    ${lastName}
    
Enter email
    [Arguments]    ${email}
    Wait Until Page Contains Element    ${emailInput}
    Input Text    ${emailInput}    ${email}

Enter email confirm
    [Arguments]    ${emailConfirm}
    Wait Until Page Contains Element    ${emailConfirmInput}
    Input Text    ${emailConfirmInput}    ${emailConfirm}

Enter phone
    [Arguments]    ${phone}
    Wait Until Page Contains Element    ${phoneInput}
    Input Text    ${phoneInput}    ${phone}

the user finalizes the order
    Wait Until Page Contains Element    ${orderSubmitButton}
    Click Button    ${orderSubmitButton}
    
the page should display an order confirmation
    Wait Until Page Contains    ${successfulOrderMessage}

the user enters invalid information
    Enter firstname    ${EMPTY}
    Enter lastname    ${EMPTY}
    Enter email    ${EMPTY}
    Enter email confirm    ${EMPTY}
    Enter phone    ${EMPTY}

Firstname validation shows required message
    Wait Until Page Contains Element    ${firstNameValidation}
    ${validationMessage}=    Get Text    ${firstNameValidation}
    Should Be Equal As Strings    ${validationMessage}    ${requiredMessage}

Lastname validation shows required message
    Wait Until Page Contains Element    ${lastNameValidation}
    ${validationMessage}=    Get Text    ${lastNameValidation}
    Should Be Equal As Strings    ${validationMessage}    ${requiredMessage}

Email validation shows required message
    Wait Until Page Contains Element    ${emailValidation}
    ${validationMessage}=    Get Text    ${emailValidation}
    Should Be Equal As Strings    ${validationMessage}    ${requiredMessage}

Phone validation shows required message
    Wait Until Page Contains Element    ${phoneValidation}
    ${validationMessage}=    Get Text    ${phoneValidation}
    Should Be Equal As Strings    ${validationMessage}    ${requiredMessage}

the page should display error messages for required fields
    Firstname validation shows required message
    Lastname validation shows required message
    Email validation shows required message
    Phone validation shows required message