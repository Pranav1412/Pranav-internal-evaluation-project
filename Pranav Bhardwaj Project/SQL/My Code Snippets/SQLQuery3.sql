/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [iRoll]
      ,[CourseId]
      ,[FeesPaid]
      ,[DateJoined]
      ,[StudentsiRoll]
      ,[CourseDetailsCourseId]
  FROM [StudentComputerCentreDb].[dbo].[studentDetails]

    SET IDENTITY_INSERT studentDetails ON
  Insert into studentDetails
  ([iRoll],[CourseId],[FeesPaid],[DateJoined],[StudentsiRoll],[CourseDetailsCourseId])
  values (1, 1, 6000, '2022-12-24',10, 1);
  Insert into studentDetails
  ([iRoll],[CourseId],[FeesPaid],[DateJoined],[StudentsiRoll],[CourseDetailsCourseId])
  values (2, 2, 4500, '2023-01-08',20, 2);
   Insert into studentDetails
  ([iRoll],[CourseId],[FeesPaid],[DateJoined],[StudentsiRoll],[CourseDetailsCourseId])
  values (3, 3, 2100, '2021-4-14',30, 3);
   Insert into studentDetails
  ([iRoll],[CourseId],[FeesPaid],[DateJoined],[StudentsiRoll],[CourseDetailsCourseId])
  values (4, 4, 3300, '2020-04-29',40, 4);