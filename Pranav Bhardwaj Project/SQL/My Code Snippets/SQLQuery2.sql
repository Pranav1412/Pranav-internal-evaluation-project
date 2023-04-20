/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CourseId]
      ,[CourseName]
      ,[Fees]
  FROM [StudentComputerCentreDb].[dbo].[courses]

  SET IDENTITY_INSERT courses ON
  Insert into courses
  ([CourseId],[CourseName],[Fees])
  values (1, 'C#', 12000);
  Insert into courses
  ([CourseId],[CourseName],[Fees])
  values (2, 'Java', 22000);
  Insert into courses
  ([CourseId],[CourseName],[Fees])
  values (3, 'Python', 5000);
  Insert into courses
  ([CourseId],[CourseName],[Fees])
  values (4, 'JavaScript', 10000);
