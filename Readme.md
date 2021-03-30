1. Folder Structure Explained: 
    |- InterviewQuestion            // Main project
    |   |- Data                     // Complex Public Holiday Rules
    |   |- Utils                    // Shared helper function
    |   |- BusinessDayCounter.cs    // Functions from interview tasks
    |- Test                         
        |- ...                      // Unit tests for the project above
    
2. To run the test:
    cd ./Test
    dotnet test

3. Explaination about task 3
Decided to extend BusinessDaysBetweenTwoDates so it can work with both fixed dates and complex rules. The complex rules all implement IHasPublicHoliday interface and will be flatten to fixed date when calculating the business days in between.