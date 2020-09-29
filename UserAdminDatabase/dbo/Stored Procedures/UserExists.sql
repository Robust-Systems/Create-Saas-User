-- =============================================
-- Author:      Iftikhar Siddique
-- Create date: 26th September 2020
-- Description: Checks if user exists in User table
--              based on provided email address.
-- =============================================
CREATE PROCEDURE UserExists

  @EmailAddress VARCHAR(100)

AS
  BEGIN

      SET NOCOUNT ON;

      BEGIN TRY

		     IF EXISTS ( SELECT 1 FROM [User] WHERE EmailAddress = @EmailAddress )
		      BEGIN
			     SELECT [Exists] = CAST(1 AS BIT)
		      END
         ELSE
          BEGIN
           SELECT [Exists] = CAST(0 AS BIT)
          END

      END TRY
      BEGIN CATCH

          THROW;

      END CATCH

  END
