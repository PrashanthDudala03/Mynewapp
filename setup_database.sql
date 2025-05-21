USE [Mynewapp-DB]
GO

-- Create Users table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
    [id] [uniqueidentifier] DEFAULT NEWID() PRIMARY KEY,
    [firstName] [nvarchar](100) NOT NULL,
    [lastName] [nvarchar](100) NOT NULL,
    [email] [nvarchar](100) NOT NULL UNIQUE,
    [password] [nvarchar](255) NOT NULL,
    [role] [nvarchar](50) NOT NULL DEFAULT 'user',
    [createdAt] [datetime] NOT NULL DEFAULT GETDATE(),
    [updatedAt] [datetime] NOT NULL DEFAULT GETDATE()
)
END
GO

-- Create Items table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Items]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Items](
    [id] [uniqueidentifier] DEFAULT NEWID() PRIMARY KEY,
    [name] [nvarchar](100) NOT NULL,
    [description] [nvarchar](500) NULL,
    [isActive] [bit] NOT NULL DEFAULT 1,
    [createdById] [uniqueidentifier] NOT NULL,
    [createdDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [lastModifiedById] [uniqueidentifier] NULL,
    [lastModified] [datetime] NULL,
    CONSTRAINT [FK_Items_Users_CreatedBy] FOREIGN KEY([createdById]) REFERENCES [dbo].[Users] ([id])
)
END
GO

-- Insert default admin user (password: Admin123!)
IF NOT EXISTS (SELECT * FROM [dbo].[Users] WHERE [email] = 'admin@example.com')
BEGIN
    INSERT INTO [dbo].[Users] ([firstName], [lastName], [email], [password], [role])
    VALUES ('Admin', 'User', 'admin@example.com', '', 'admin')
END
GO
