-- SQL Server Stored Procedures for Pagination
-- Run these scripts in your SQL Server Management Studio

-- Drop existing stored procedures if they exist
IF OBJECT_ID('sp_GetDataCount', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetDataCount;
IF OBJECT_ID('sp_GetDataPaginated', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetDataPaginated;
IF OBJECT_ID('sp_GetAllData', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllData;

GO

-- Stored Procedure 1: Get total count of records
CREATE PROCEDURE sp_GetDataCount
AS
BEGIN
    SELECT COUNT(*) FROM DataRecords
END

GO

-- Stored Procedure 2: Get paginated data
CREATE PROCEDURE sp_GetDataPaginated
    @PageNumber INT = 1,
    @PageSize INT = 15
AS
BEGIN
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
    
    SELECT 
        SerialNo,
        Name,
        City
    FROM DataRecords
    ORDER BY SerialNo
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY
END

GO

-- Stored Procedure 3: Get all data (optional)
CREATE PROCEDURE sp_GetAllData
AS
BEGIN
    SELECT 
        SerialNo,
        Name,
        City
    FROM DataRecords
    ORDER BY SerialNo
END

GO

-- Create the DataRecords table if it doesn't exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DataRecords')
BEGIN
    CREATE TABLE DataRecords
    (
        SerialNo INT PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        City NVARCHAR(100) NOT NULL
    )
END
