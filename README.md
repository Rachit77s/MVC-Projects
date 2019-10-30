# MVC Projects

Project TitleWebAPI --> CRUD operations using MVC and WEB API.Getting StartedThese instructions will get you a copy of the project up and running on your local machine for development and testing purposes.PrerequisitesWhat things you need to install the software.Visual Studio 2015 onwards, SQL Server InstallingA step by step series of examples that tell you how to get a development env running1. Open SSMS and create a database with name = RachitTest and execute the attached DB script.
   Or else you can create your own DB and update DB name in the connection string.<connectionStrings>
    <add name="RachitTestEntities" connectionString="metadata=res://*/Models.DBModels.csdl|res://*/Models.DBModels.ssdl|res://*/Models.DBModels.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=FIC-I7K40\MSSQLSRV2017STD;initial catalog=RachitTest;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
initial catalog=RachitTest
2. Open Visual Studio and under the WEBAPIMVC project, open the Web.config and change the connection string. For example, see below<connectionStrings>
    <add name="RachitTestEntities" connectionString="metadata=res://*/Models.DBModels.csdl|res://*/Models.DBModels.ssdl|res://*/Models.DBModels.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=FIC-I7K40\MSSQLSRV2017STD;initial catalog=RachitTest;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
In the above connectionString, change the source=FIC-I7K40\MSSQLSRV2017STD to your own SQL Server DB instance name.
3. Open Visual Studio and right-click on solution WebApi and click on properties.
    Now in the solution property, click on Multiple Startup Project and set both MVC and WebAPI projects as Start. 

Features  Designed the project in MVC using Restful services using Entity Framework.  Implemented dependency injection using Unity Framework.  Implemented Repository design pattern.  Implemented Global Exception filter both in MVC and Web API.  Implemented Single Responsibility and the Open/Closed Principle.  Implemented basic CRUD operations.  
  Implemented Model validations.  
 
Built WithASP.NET MVC and WEB API - The web framework usedUnity Framework - Dependency Management
