--Sql DataBase file

-- Author table
CREATE TABLE [dbo].[Authors] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (200)  NOT NULL,
    [Email]    NVARCHAR (MAX)  NOT NULL,
    [DOB]      DATETIME2 (7)   NOT NULL,
    [MobileNo] NVARCHAR (10)   NULL,
    [Website]  NVARCHAR (100)  NULL,
    [Bio]      NVARCHAR (2000) NULL,
    [Image]    NVARCHAR (200)  NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- Book table

CREATE TABLE [dbo].[Books] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [ISBN]          NVARCHAR (MAX) NOT NULL,
    [PublishedDate] DATETIME2 (7)  NOT NULL,
    [CategoryId]    INT            DEFAULT ((0)) NOT NULL,
    [AuthorId]      INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Books_CategoryId]
    ON [dbo].[Books]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Books_AuthorId]
    ON [dbo].[Books]([AuthorId] ASC);

-- Category Table

CREATE TABLE [dbo].[Categories] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

