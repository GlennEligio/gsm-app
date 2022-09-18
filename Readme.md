# GSM APP

---

## Description

C# .NET WinForm application that uses GSM module alongside MSSQL to store and display messages

## Setup

1. Database
   - use the DDL scripts to create the needed tables for storing Messages and Sender data
2. ADO.NET Models
   - remove the connection strings related to the ADO.NET Model entities
   - create two new Model with the following information
     - namespaces of both Model should be GSM
     - Model name will be Message and Professor

## UI

![GSM app UI](./ui.png)
