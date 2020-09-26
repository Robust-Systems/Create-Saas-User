-- =============================================
-- Author:      Iftikhar Siddique
-- Create date: 26th September 2020
-- Description: Checks if user exists in User table
--              based on provided email address.
-- =============================================
CREATE PROCEDURE UserExists
  @EmailAddress VARCHAR(100),
  @UserExists   BIT = 0 OUTPUT
AS
  BEGIN

      SET NOCOUNT ON;

      BEGIN TRY

         SET @UserExists = 0

		 IF EXISTS ( SELECT 1 FROM [User] WHERE EmailAddress = @EmailAddress )
		 BEGIN
			SET @UserExists = 1
		 END

      END TRY
      BEGIN CATCH

          THROW;

      END CATCH

  END
