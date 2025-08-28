# Rebtel.DeveloperTest.API

**Setting up the code base : 

1) Clone the repository.
2) Open in Visual studio 2022 (or later). Mostly used .net 9.0
3) Restore Nuget.
4) Make sure to set "Start" on two projects :

   <img width="1415" height="809" alt="image" src="https://github.com/user-attachments/assets/0c87f2f7-46df-4381-9fd3-16fe11929102" />


**Setting up Database :

1)Open Tools > NuGet Package Manager > Package Manager Console
2)Run the following command on Rebtel.DeveloperTest.DAL
   Install-Package Microsoft.EntityFrameworkCore.Tools
   Add-Migration InitialCreate
   Update-Database

   <img width="1904" height="954" alt="image" src="https://github.com/user-attachments/assets/6b972658-fd77-42d8-bd44-7ab61bb8b79a" />



**Run the application and testing the APIs
A launcher profile has been set for running the API project 


"Rebtel.DeveloperTest.API": {
  "commandName": "Project",
  "dotnetRunMessages": true,
  "launchBrowser": true,
  "launchUrl": "swagger",
  "applicationUrl": "https://localhost:7187;http://localhost:5187",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }

After running, a swagger url should appear in a browers. We can test the Apis from the browser. 
Very limited test data has been seeded. Recomended parameter for any bookId is 1 and any borrowerId is 1.
<img width="1221" height="578" alt="image" src="https://github.com/user-attachments/assets/5db62302-2d29-4ad4-8c9a-1e9c255352c0" />

** Unit test and Integration test :
Unit test project : Rebtel.DeveloperTest.SL.UnitTest
Integration test project : Rebtel.DeveloperTest.SL.IntegrationTest

**Warm-Up tasks :

Those task can be found as a static class inside Rebtel.DeveloperTest.WarmUpTasks. Set up a test project Rebtel.DeveloperTest.WarmUpTasks.UnitTest to test the methods.
