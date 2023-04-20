/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [iRoll]
      ,[Name]
  FROM [StudentComputerCentreDb].[dbo].[studentes]
  SET IDENTITY_INSERT studentes ON
  Insert into studentes ([iRoll]
      ,[Name]) values (10,'Aman');
	  Insert into studentes ([iRoll]
      ,[Name]) values (20,'Haider');
	  Insert into studentes ([iRoll]
      ,[Name]) values (30,'Kunal');
	  Insert into studentes ([iRoll]
      ,[Name]) values (40,'Rajat');