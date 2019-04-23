[[_TOC_]]
# Introduction
An example of WebSockets using Vue.js, Electron and .NET Core.

# Getting Started

## Installation

### Service
- Execute **sc start WebSocketsExample** to run the service.
- Execute **sc stop WebSocketsExample** to run the service.

### UI
- Execute **web-sockets-example.exe** to install and start the front end for the first time. Subsequently, execute **C:\Users\[username]\AppData\Local\Programs\web-sockets-example\web-sockets-example.exe** to start the front end.

## Software dependencies

## Latest releases

## API references

# Build & Test

## Build

### Service
- Navigate to the folder containing **Service.csproj** in a terminal and execute **dotnet publish -c Release -r win10-x64** to build the API.
- Execute **sc create WebSocketsExample binPath=[path to publish/Service.exe]** from the command line (run as administrator) to install the service.
- Execute **sc delete WebSocketsExample** from the command line (run as administrator) to uninstall the service.

### UI
- Navigate to the folder containing **package.json** in a terminal and execute **npm install**, and then **npm run electron:build** to build the API.

## Test
See **installation**.

# Contribute
I welcome you to improve the WebSocketsExample application.

If you want to learn more about creating good README files then refer to the following [guidelines](https://www.visualstudio.com/en-us/docs/git/create-a-readme). You can also seek inspiration from the below README files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
