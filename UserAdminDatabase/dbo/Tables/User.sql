CREATE TABLE [dbo].[User] (
    [UserID]       INT           IDENTITY (1, 1) NOT NULL,
    [EmailAddress] VARCHAR (100) NOT NULL,
    [Salt]         VARCHAR (100) NOT NULL,
    [Password]     VARCHAR (100) NOT NULL,
    [DateAdded]    SMALLDATETIME CONSTRAINT [DF_User_DateAdded] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_User_UserID] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [UK_User_EmailAddress] UNIQUE NONCLUSTERED ([EmailAddress] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Email addresses will be unique across the User table.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User', @level2type = N'CONSTRAINT', @level2name = N'UK_User_EmailAddress';

