Contact Manager Web Api 

This project contains simple rest apis to perform CRUD operations using ASP.net Web Api with appropriate architecture.

TOOL

  1.Visual Studio 2017

Technology

  1. C#
  2. ASP.NET Web Api
  3. MVC(Template)
  4. Dependency Injection(Ninject)
  5.SQL Server 2008

Contact api List

  1. contact-GET
     
     Returns all contact information
     
  2. contact/id-GET
     
     Returns contact information for given contact id.
     
  3. contact-POST
  
     Add contacts information 
  
  4. contact-DELETE(soft)
  
     Delete contact information for given contact id
    
  5. contact-PUT
  
     Updates contact information for given contact id

Application Setup

  1.The project is developed using Code First approach.
    It will create database as application runs.
    
  2.Connection string in Web.Config needs to change for local server.Windows authentication is used in connection string.
  
Solution Structure

  1. Web Layer
  
      Application Service
    
      Ninject Configuration
    
      AutoMapper
  
  2. Service Layer
   
  3. Data Layer
    
      Database Context
    
      Database Repository
    
      Mapping Configuration
    
  4. Core Layer
    
      Database Entity
      
      Repository
    
    
  
    
    
