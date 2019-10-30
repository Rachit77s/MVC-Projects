# Project Title

* WebAPI ==> CRUD * operations using MVC and WEB API.Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Prerequisites

What things you need to install the software.

* Visual Studio 2015 onwards
* SQL Server 

## Installing

A step by step series of examples that tell you how to get a development env running

1. Open SSMS and create a database with name = RachitTest and execute the attached DB script *OR* else you can create your own DB and update DB name in the connection string.

```c#
<connectionStrings>
    <add name="RachitTestEntities" connectionString="metadata=res://*/Models.DBModels.csdl|res://*/Models.DBModels.ssdl|res://*/Models.DBModels.msl;
    provider=System.Data.SqlClient;provider connection string=&quot;data source=FIC-I7K40\MSSQLSRV2017STD;initial catalog=RachitTest;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
```

```c#
initial catalog=RachitTest
```

2. Open Visual Studio and under the WEBAPIMVC project, open the Web.config and change the connection string. For example, see below

```c#
<connectionStrings>
    <add name="RachitTestEntities" connectionString="metadata=res://*/Models.DBModels.csdl|res://*/Models.DBModels.ssdl|res://*/Models.DBModels.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=FIC-I7K40\MSSQLSRV2017STD;initial catalog=RachitTest;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
```

```c#
In the above connectionString, change the source=FIC-I7K40\MSSQLSRV2017STD to your own SQL Server DB instance name.
```

3. Open Visual Studio and right-click on solution WebApi and click on properties. Now in the solution property, click on Multiple Startup Project and set both MVC and WebAPI projects as Start.

![Reference Image](https://pasteboard.co/IEpysjE.jpg)

## Features

Designed the project in MVC using Restful services using Entity Framework.

* [X] Implemented dependency injection using Unity Framework.
* [X] Implemented Repository design pattern.
* [X] Implemented Global Exception filter both in MVC and Web API.
* [X] Implemented Single Responsibility and the Open/Closed Principle.
* [X] Implemented basic CRUD operations.
* [X] Implemented Model validations.  


### Built With

* ASP.NET MVC and WEB API - The web framework used
* Unity Framework - Dependency Management
