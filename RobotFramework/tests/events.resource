*** Settings ***
Resource    common.resource
*** Variables ***
${eventCard}=    //div[contains(@class, 'event-card')]
${addEventButton}=    //button[contains(@class, 'add-event-button')]
${eventTitle}=    //h5[contains(@class, 'event-title')]

*** Keywords ***
the user goes to the events page
    Go To events page

the page should display events
    Wait Until Page Contains Element    ${eventCard}
    @{events}=    Get WebElements    ${eventCard}
    ${eventCount}=    Get Length    ${events}
    Should Be True    ${eventCount} > 0

the user is on the events page
    Go To events page

Add Event
    [Arguments]    ${index}
    ${eventPath}=    Set Variable    ${eventCard}\[${index}\]
    Wait Until Page Contains Element    ${eventPath}
    ${addEventButtonPath}=    Set Variable    ${eventPath}${addEventButton}
    Wait Until Page Contains Element    ${addEventButtonPath}
    ${eventTitlePath}=    Set Variable    ${eventPath}${eventTitle}
    Wait Until Page Contains Element    ${eventTitlePath}
    Wait Until Element Is Visible    ${eventTitlePath}
    ${eventTitleText}=    Get Text    ${eventTitlePath}
    ${eventInDict}=    Get From Dictionary    ${eventsDict}    ${index}    -1
    IF    ${eventInDict} == -1
        ${event}=    Create Dictionary
        ...    eventTitle=${eventTitleText}
        ...    eventAmount=${1}
        Set To Dictionary    ${eventsDict}    ${index}=${event}
    ELSE
        ${eventInDictAmount}=    Set Variable    ${eventInDict}[eventAmount]
        ${eventInDict}[eventAmount]=    Evaluate    ${eventInDictAmount}+${1}
        Set To Dictionary    ${eventsDict}    ${index}=${eventInDict}
    END
    Log To Console    ${eventsDict}
    Wait Until Element Is Visible    ${addEventButtonPath}
    Click Button    ${addEventButtonPath}
Create Event List
    &{eventsDict}=    Create Dictionary
    Set Test Variable    ${eventsDict}
the user adds an event to the shopping cart
    Add Event    1

the shopping cart should display the added events
    @{eventList}=    Get Dictionary Values    ${eventsDict}
    FOR    ${event}    IN    @{eventList}
        Wait Until Page Contains Element    //h6[contains(text(), '${event}[eventTitle]')]
    END
