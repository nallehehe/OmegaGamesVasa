*** Settings ***
Resource    common.resource
*** Variables ***
${adminUsername}=    admin@omegavasa.com
${adminPassword}=    Password123!

${loginEmailInput}=    //input[@name='Input.Email']
${passwordInput}=    //input[@name='Input.Password']
${loginButton}=    //button[@id='login-button']

${userBadge}=    //div[contains(@class, 'active-user')]
${loginErrorDiv}=    //div[@role='alert']

${loginForm}=    //form[@id='login-form']

*** Keywords ***
the user is on the admin login page
    Go to admin login page
    Wait Until Page Contains Element    //form

Enter username
    [Arguments]    ${username}
    Wait Until Page Contains Element   ${loginEmailInput}
    Input Text    ${loginEmailInput}    ${username}
    
Enter password
    [Arguments]    ${password}
    Wait Until Page Contains Element   ${passwordInput}
    Input Password    ${passwordInput}    ${password}

the user enters valid admin login
    Enter username    ${adminUsername}
    Enter password    ${adminPassword}

the user enters invalid admin login
    Enter username    notadmin@example.com
    Enter password    WrongPassword123!

the user clicks the login button
    Click login button

the page should display successful login
    Wait Until Page Contains Element   ${userBadge}

the page should display a login error message
    Wait Until Page Contains Element    ${loginErrorDiv}

Click login button
    Wait Until Page Contains Element    ${loginButton}
    Click Button    ${loginButton}

Sign in
    [Arguments]    ${loginEmail}    ${loginPassword}
    Enter username    ${loginEmail}
    Enter password    ${loginPassword}
    Click login button

Sign in as admin
    Sign in    ${adminUsername}    ${adminPassword}
    Wait Until Page Contains Element    ${userBadge}
