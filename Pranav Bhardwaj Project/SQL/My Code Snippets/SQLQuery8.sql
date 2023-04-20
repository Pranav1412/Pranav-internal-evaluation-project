/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [TeacherId]
      ,[TeacherName]
      ,[CourseId]
      ,[CourseDetailsCourseId]
  FROM [StudentComputerCentreDb].[dbo].[teacherses]

    SET IDENTITY_INSERT teacherses ON
  Insert into teacherses
  ([TeacherId]
      ,[TeacherName]
      ,[CourseId]
      ,[CourseDetailsCourseId])
  values (11, 'Rajendra',1, 1);
   Insert into teacherses
  ([TeacherId]
      ,[TeacherName]
      ,[CourseId]
      ,[CourseDetailsCourseId])
  values (12, 'Jatin',2, 2);
   Insert into teacherses
  ([TeacherId]
      ,[TeacherName]
      ,[CourseId]
      ,[CourseDetailsCourseId])
  values (13, 'Aakash',3, 3);
   Insert into teacherses
  ([TeacherId]
      ,[TeacherName]
      ,[CourseId]
      ,[CourseDetailsCourseId])
  values (14, 'Sheetal',4, 4);