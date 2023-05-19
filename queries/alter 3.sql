use Course_Work_Bus

-- Add a new column '[NewColumnName]' to table '[TableName]' in schema '[dbo]'
ALTER TABLE [dbo].Users
    ADD Name  NVARCHAR(50)
ALTER TABLE dbo.Users
    ADD Surname  NVARCHAR(50)
ALTER TABLE dbo.Users
    ADD Email  NVARCHAR(50)
