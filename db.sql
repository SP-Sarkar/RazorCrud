--Sql DataBase file

-- Category Table

CREATE TABLE [dbo].[Categories] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- Category Data
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Adventure')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Crime and Detective')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Drama')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Action')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Comic ')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Adult Literature')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Thrillers ')
SET IDENTITY_INSERT [dbo].[Categories] OFF


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

-- Author Table data
SET IDENTITY_INSERT [dbo].[Authors] ON
INSERT INTO [dbo].[Authors] ([Id], [Name], [Email], [DOB], [MobileNo], [Website], [Bio], [Image]) VALUES (1, N'Joanne Rowling', N'tuhin@gmail.com', N'1965-07-31 00:00:00', N'9007368998', N'https://www.jkrowling.com/', N'Joanne Rowling CH, OBE, HonFRSE, FRCPE, FRSL (/ˈroʊlɪŋ/ "rolling";[1] born 31 July 1965), better known by her pen name J. K. Rowling, is a British author, film producer, television producer, screenwriter, and philanthropist. She is best known for writing the Harry Potter fantasy series, which has won multiple awards and sold more than 500 million copies,[2][3] becoming the best-selling book series in history.[4]', N'jkRowling2.jpg')
INSERT INTO [dbo].[Authors] ([Id], [Name], [Email], [DOB], [MobileNo], [Website], [Bio], [Image]) VALUES (2, N'James Patterson', N'james@amespatterson.com', N'1947-03-22 00:00:00', N'8420461244', N'http://www.jamespatterson.com/', N'James Brendan Patterson is an American author and philanthropist. Among his works are the Alex Cross, Michael Bennett, Women''s Murder Club, Maximum Ride, Daniel X, NYPD Red, Witch and Wizard, and Private series, as well as many stand-alone thrillers, non-fiction and romance novels.', N'james-patterson.jpg')
INSERT INTO [dbo].[Authors] ([Id], [Name], [Email], [DOB], [MobileNo], [Website], [Bio], [Image]) VALUES (3, N'John Grisham', N'john@jgrisham.com', N'1955-03-22 00:00:00', N'9008123456', N'http://www.jgrisham.com/', N'John Ray Grisham Jr. is an American novelist, attorney, politician, and activist, best known for his popular legal thrillers. His books have been translated into 42 languages and published worldwide.', N'JohnGrisham.jpg')
SET IDENTITY_INSERT [dbo].[Authors] OFF

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


-- book data
SET IDENTITY_INSERT [dbo].[Books] ON
INSERT INTO [dbo].[Books] ([Id], [Name], [ISBN], [PublishedDate], [CategoryId], [AuthorId]) VALUES (1, N'Harry Potter and the Philosopher''s Stone ', N'9780439023481', N'1997-06-26 00:00:00', 1, 1)
INSERT INTO [dbo].[Books] ([Id], [Name], [ISBN], [PublishedDate], [CategoryId], [AuthorId]) VALUES (2, N'Harry Potter and the Chamber of Secrets ', N'HWSP123456', N'1998-02-07 00:00:00', 1, 1)
INSERT INTO [dbo].[Books] ([Id], [Name], [ISBN], [PublishedDate], [CategoryId], [AuthorId]) VALUES (3, N'Harry Potter and the Prisoner of Azkaban', N'HWSP0987654', N'1999-08-07 00:00:00', 4, 1)
INSERT INTO [dbo].[Books] ([Id], [Name], [ISBN], [PublishedDate], [CategoryId], [AuthorId]) VALUES (4, N'Harry Potter and the Goblet of Fire ', N'JKRO08072000', N'2000-08-07 00:00:00', 4, 1)
INSERT INTO [dbo].[Books] ([Id], [Name], [ISBN], [PublishedDate], [CategoryId], [AuthorId]) VALUES (5, N'The Casual Vacancy', N'JKROCV12345', N'2012-07-08 00:00:00', 6, 1)
INSERT INTO [dbo].[Books] ([Id], [Name], [ISBN], [PublishedDate], [CategoryId], [AuthorId]) VALUES (6, N'Big Words for Little Geniuses', N'JPWLG123456', N'0001-01-01 00:00:00', 6, 2)
INSERT INTO [dbo].[Books] ([Id], [Name], [ISBN], [PublishedDate], [CategoryId], [AuthorId]) VALUES (7, N'Crazy House', N'JPCH12345', N'2020-01-01 00:00:00', 2, 2)
SET IDENTITY_INSERT [dbo].[Books] OFF
