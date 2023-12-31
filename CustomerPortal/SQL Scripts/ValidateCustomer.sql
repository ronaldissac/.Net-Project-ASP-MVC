USE [omegabase]
GO
/****** Object:  StoredProcedure [dbo].[ValidateCustomer]    Script Date: 18-10-2023 13:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ValidateCustomer]
    @customerid VARCHAR(50),
    @customerpass VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IsValid BIT;
	DECLARE @CustomerName VARCHAR(50)
    -- Check if the customer exists and the password matches
    IF EXISTS (SELECT 1 FROM [dbo].[Customer] WHERE [customerId] = @customerid AND [CustomerPassword] = @customerpass)
    BEGIN
        -- Update the LastLogin to the current time
        UPDATE [dbo].[Customer] SET [LastLogin] = GETDATE() WHERE [customerId] = @customerid;
		SET @customerid= (SELECT DISTINCT  [CustomerName] FROM [Customer] WHERE  [customerId] = @customerid);
        -- Customer is valid
        SET @IsValid = 1;
    END
    ELSE
    BEGIN
        -- Customer is not valid
        SET @IsValid = 0;
    END
	
    SELECT @IsValid AS IsValid
	SELECT @CustomerName AS CustomerName;
END
