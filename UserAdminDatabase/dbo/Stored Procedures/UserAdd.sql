-- =============================================
-- Author:      Iftikhar Siddique
-- Create date: 26th September 2020
-- Description: Adds new user to User table.
-- =============================================
CREATE PROCEDURE UserAdd
                 @EmailAddress VARCHAR(100),
                 @Salt         VARCHAR(100),
                 @Password     VARCHAR(100)
AS
  BEGIN

      SET NOCOUNT ON;

      BEGIN TRY

         INSERT INTO [User]
                     (
                       EmailAddress,
                       Salt,
                       [Password]
                     )
         VALUES      (
                       @EmailAddress,
                       @Salt,
                       @Password
                     )

      END TRY
      BEGIN CATCH

          THROW;

      END CATCH

  END
