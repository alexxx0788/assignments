USE [ShepherdDb]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 2/2/2017 2:54:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE [dbo].[InsertOrder](@UserId INT,@StockId INT,@Amount INT)
AS
BEGIN
DECLARE @StockPrice MONEY;
DECLARE @StockAmount INT;
SELECT @StockPrice=Price,@StockAmount=Amount FROM [Stock] WHERE StockId=@StockId;

DECLARE @Balance INT;
SELECT @Balance=Balance FROM [User] WHERE UserId=@UserId;

UPDATE [User] SET Balance=(@Balance-@StockPrice*@Amount) WHERE UserId=@UserId

UPDATE [Stock] SET Amount=(Amount-@Amount) WHERE StockId=@StockId;

INSERT INTO [Order] (UserId,StockId,Price,DateTime,Amount) VALUES (@UserId,@StockId,@StockPrice,GETDATE(),@Amount)

END
