Pre-requisite to run CronExpressionParser - 
dotnet SDK 5 must be installed on the system (Download link - https://dotnet.microsoft.com/en-us/download/dotnet/5.0)

Once SDK is downloaded and installed.

1. Open terminal and run below command inside /CronExpressionParser to run application - 
      $dotnet run "*/15 0 1,15 * 1-5 /usr/bin/find"

It will parse the provided cron string and display result in console.

2. Run below command on same level to run all tests - 
      $dotnet test

It will run all the unit tests and display result in console.

THANKS!!