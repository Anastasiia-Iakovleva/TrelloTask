Feature: Create Board Tests
Testing boards creation in Trello

    Scenario: Create simple board
        Given User logged into Trello using username '$username' and password '$password'
        When User clicks on the 'Create' button in Boards page
        When User clicks on the 'Create Board' button in Creation menu in Boards page
        And User fills Board Title input in Boards page
        And User clicks on the 'Create' button in Create Board menu in Boards page
        Then The board was added to My Boards list
        And Created board is opened

    Scenario Outline: Create boards with different visibility
        Given User logged into Trello using username '$username' and password '$password'
        When User clicks on the 'Create' button in Boards page
        And User clicks on the 'Create Board' button in Creation menu in Boards page
        When User fills Board Title input in Boards page
        And User selects '<Visibility>' visibility option in Boards page
        And User clicks on the 'Create' button in Create Board menu in Boards page
        Then The board was added to My Boards list
        And Created board is opened
        And The displayed Board Permission level is '<PermissionLevel>'

        Examples:
          | Visibility | PermissionLevel   |
          | Private    | Private           |
          | Workspace  | Workspace visible |