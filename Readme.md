# First Widget API and Web Application
By Yaron Habot May 2021

## Prerequisits
* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet/5.0)
## Introduction
This project is the implementation of a coding task. The task is to create a web application and API for a company named First Widget that monitor its employees and receives alrets about them from National Crime Database and a Credit bureou.
## Implementation
Although this is a coding task, the majority of the work was done to create the environment. The C# web Api code was created following [Microsoft tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio-code). The web site was created following [Websocket Demo](https://www.c-sharpcorner.com/article/using-websocket-to-build-real-time-application-via-asp-net-core/). 

I tried to demonstrate my coding capabilities in the Employee class by doing the input arguments validation, spliting code into functions for readability and coherency. In AlertController.cs, I packed 3 classes becuase the code in each class was very minimal. I meant to demonstrate object oriented inheritance and abstraction.

## Web Application
The web application is located at wwwroot folder. Due to lack of time, I created it as plain HTML and embeded JavaScript. In normal work setting, I would use Angular or reactJS. The web application It is comprised of 2 components:
* Employee monitor - index.html. Opens a web socket to the API and displays alerts on the page for any employee.
* Employee management - employee.html. Provides 2 forms on the page, the top form for employee search and the bottom form for employee search result for update or creating a new employee. The code demonstrates form validation and API calls.
## Execution
* Start Visual Studio Code
* Open the folder FirstWidget.ITMS.WebApi
* From VS Code, Run Menu, click Run Without Debugging or hit Ctrl+F5
* A web server will be created that listens to https://localhost:5001/. This is the web application per the static files in wwwroot folder
* The API methods are documented by Swagger at https://localhost:5001/swagger/index.html
* A crude test script can be found in **Tests.cmd**. It uses curl command line application to make HTTP requests. There are call for positive tests that show API response to valid input and calls for negative test showing the API response to invalid input
* An alert generator can be found in **AlertsGenerator.cmd**. After executing the project, a new browser tab will open, rendering https://localhost:5001/ which is the Employee Monitor page. Click the Accept Alerts button to connect to the API's websock. Next, execute **AlertsGenerator.cmd** and observe the alerts showing in Employee Monitor page.
