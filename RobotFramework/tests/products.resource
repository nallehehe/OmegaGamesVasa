*** Settings ***
Library    SeleniumLibrary
Resource    common.resource

*** Variables ***
${allProductsXpath}=    //div[contains(@class, 'row')]/div[contains(@class, 'product-card')]
${addToCartButton}=    //button[contains(@class, 'add-to-cart-button')]
${productTitle}=    //h4[contains(@class, 'card-title')]
${productPriceXPath}=    //div[contains(@class, 'product-price')]/span

*** Keywords ***
Add Product
    [Arguments]    ${index}
    ${productPath}=    Set Variable    ${allProductsXpath}\[${index}\]
    Wait Until Page Contains Element    ${productPath}
    ${addButtonPath}=    Set Variable    ${productPath}${addToCartButton}
    Wait Until Page Contains Element    ${addButtonPath}
    ${productTitlePath}=    Set Variable    ${productPath}${productTitle}
    Wait Until Page Contains Element    ${productTitlePath}
    ${productTitleText}=    Get Text    ${productTitlePath}
    ${productPricePath}=    Set Variable    ${productPath}${productPriceXPath}
    Wait Until Page Contains Element    ${productPricePath}
    ${productPrice}=    Get Text    ${productPricePath}
    ${productInDict}=    Get From Dictionary    ${productsDict}    ${index}    -1
    IF    ${productInDict} == -1
        ${product}=    Create Dictionary    
        ...    productName=${productTitleText}
        ...    productPrice=${productPrice}
        ...    productAmount=${1}
        Set To Dictionary    ${productsDict}    ${index}=${product}
    ELSE
        ${productInDictAmount}=    Set Variable    ${productInDict}[productAmount]
        ${productInDict}[productAmount]=    Evaluate    ${productInDictAmount}+${1}
        Set To Dictionary    ${productsDict}    ${index}=${productInDict}  
    END
    Log To Console    ${productsDict}
    
    Click Button    ${addButtonPath}