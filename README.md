# TrelloSpecFlowTestProject

This framework is based on SpecFlow. To execute created test scenarios, you need to perform next steps:
1. Open solution in IDE of your choice (Visual Studio, Rider)
2. Navigate to TrelloSpecFlowTestProject -> Features -> CreateBoardTest.feature
3. Right click on the feature file and click 'Run Unit Tests'

List of possible improvements:
1. First of all, it would be really great to add created board deletion using RestApi. Necessary endpoint could be found in https://developer.atlassian.com/cloud/trello/rest/api-group-boards/ (DELETE /1/boards/{id}). It is necessary because of limitation of created boards for free Trello account (maximum - 10 boards). And besides this it is a good practice - to perform clean up after test cases execution
2. Add credential encryption to increase security
3. Add ability to run test cases in different browsers (now only Chrome is supported)
4. Add ability to run test cases in parallel
5. Add reporting (e.g. AllureReport)
