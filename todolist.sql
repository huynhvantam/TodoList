USE [TodoList]
GO
/****** Object:  Table [dbo].[TodoList]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](max) NOT NULL,
	[TaskLevel] [int] NOT NULL,
	[TaskGroup] [nvarchar](50) NOT NULL,
	[UserID] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[FixDate] [datetime] NULL,
 CONSTRAINT [PK_TodoList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TodoList]  WITH CHECK ADD  CONSTRAINT [FK_TodoList_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[TodoList] CHECK CONSTRAINT [FK_TodoList_Users]
GO
/****** Object:  StoredProcedure [dbo].[CreateTodoList]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/19
-- Description:	Create new TodoList
-- =============================================
CREATE PROCEDURE [dbo].[CreateTodoList]
	
	@TaskName nvarchar(max),
	@TaskLevel nvarchar(50),
	@TaskGroup nvarchar(50)
	,@UserID int
AS
BEGIN
INSERT INTO [dbo].[TodoList]
           ([TaskName]
           ,[TaskLevel]
           ,[TaskGroup]
           ,[UserID]
           ,[Deleted]
           ,[CreatedDate]
           ,[FixDate])
     VALUES
           (@TaskName
           ,@TaskLevel
           ,@TaskGroup
           ,@UserID
           ,0
           ,getdate()
           ,getdate())
declare @Id int
set @Id = SCOPE_IDENTITY()
select @id as id
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/19
-- Description:	Create new users
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN

INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Deleted])
     VALUES
           (@Username,
          @Password,
           0)
declare @Id int
set @Id = SCOPE_IDENTITY()
select @Id as Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTodoList]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/20
-- Description:	Edit TodoList
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTodoList]
	@Id int
AS
BEGIN
UPDATE [dbo].[TodoList]
   SET [Deleted] = 1
		,[FixDate] = getdate()
 WHERE ID= @Id

select @Id as Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/19
-- Description:	Edit users
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
	
AS
BEGIN
declare @Result bit = 0
begin try

		UPDATE [dbo].[Users]
		   SET [Deleted]=1
		 WHERE ID = @Id
		 set @Result = 1
 end try
 begin catch
 end catch
select @Id as Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditTodoList]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/20
-- Description:	Edit TodoList
-- =============================================
CREATE PROCEDURE [dbo].[EditTodoList]
	@Id int,
	@UserID int,
	@TaskName nvarchar(max),
	@TaskLevel nvarchar(50),
	@TaskGroup nvarchar(50)

AS
BEGIN
UPDATE [dbo].[TodoList]
   SET [TaskName] = @TaskName
      ,[TaskLevel] = @TaskLevel
      ,[TaskGroup] = @TaskGroup
      ,[UserID] =@UserID
      ,[FixDate] = getdate()
 WHERE ID= @Id

select @Id as Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/19
-- Description:	Edit users
-- =============================================
CREATE PROCEDURE [dbo].[EditUser]
	@Id int,
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN


UPDATE [dbo].[Users]
   SET [Username] = @Username
      ,[Password] = @Password
     
 WHERE ID = @Id
select @Id as Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetListUser]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/19
-- Description:	Get List User
-- =============================================
CREATE PROCEDURE [dbo].[GetListUser]	
AS
BEGIN
SELECT [ID]
      ,[Username]
      ,[Password]
	  , (select count (*) from TodoList where UserID=Users.ID )as AllTask
  FROM [dbo].[Users]
where Deleted =0

END
GO
/****** Object:  StoredProcedure [dbo].[GetTodoListById]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/20
-- Description:	Get TodoList by Id
-- =============================================
CREATE PROCEDURE [dbo].[GetTodoListById]	
		@Id int
AS
BEGIN 


SELECT [ID]
      ,[TaskName]
      ,[TaskLevel]
      ,[TaskGroup]
      ,[UserID]
  FROM [dbo].[TodoList]

where Deleted =0 and ID = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[GetTodoListByUser]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/20
-- Description:	Get TodoList
-- =============================================
CREATE PROCEDURE [dbo].[GetTodoListByUser]	
		@UserID int
AS
BEGIN 


SELECT [ID]
      ,[TaskName]
      ,[TaskLevel]
      ,[TaskGroup]
      ,[UserID]
  FROM [dbo].[TodoList]

where UserID = @UserID  and Deleted =0 

END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 5/22/2020 4:04:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TamHV
-- Create date: 2020/05/19
-- Description:	Get List User by ID
-- =============================================
CREATE PROCEDURE [dbo].[GetUserById]
	@Id  int	
AS
BEGIN

if(not exists(select * from [dbo].[Users] where Deleted =0 and ID = @Id))
begin
	raiserror ('Invalid department',1,100)
end


SELECT [ID]
      ,[Username]
      ,[Password]
  FROM [dbo].[Users]
where Deleted =0 and ID= @Id

END
GO
