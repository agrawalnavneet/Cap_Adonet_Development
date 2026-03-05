using System.Data;
using System.Data.SqlClient;

namespace app.Data;

public class DatabaseInitializer
{
    private readonly string _connectionString;

    public DatabaseInitializer(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void InitializeDatabase()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                Console.WriteLine("✓ Database connection successful");

                // Create table
                CreateTable(connection);

                // Create stored procedures
                CreateStoredProcedures(connection);

                // Seed data
                SeedData(connection);

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Database initialization error: {ex.Message}");
        }
    }

    private void CreateTable(SqlConnection connection)
    {
        string createTableQuery = @"
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DataRecords')
            BEGIN
                CREATE TABLE DataRecords
                (
                    SerialNo INT PRIMARY KEY,
                    Name NVARCHAR(100) NOT NULL,
                    City NVARCHAR(100) NOT NULL
                )
                PRINT 'Table DataRecords created successfully'
            END
            ELSE
            BEGIN
                PRINT 'Table DataRecords already exists'
            END";

        using (SqlCommand command = new SqlCommand(createTableQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    private void CreateStoredProcedures(SqlConnection connection)
    {
        // Drop existing procedures
        string dropProcedures = @"
            IF OBJECT_ID('sp_GetDataCount', 'P') IS NOT NULL DROP PROCEDURE sp_GetDataCount;
            IF OBJECT_ID('sp_GetDataPaginated', 'P') IS NOT NULL DROP PROCEDURE sp_GetDataPaginated;";

        using (SqlCommand command = new SqlCommand(dropProcedures, connection))
        {
            command.ExecuteNonQuery();
        }

        // Create sp_GetDataCount
        string createCountProcedure = @"
            CREATE PROCEDURE sp_GetDataCount
            AS
            BEGIN
                SELECT COUNT(*) FROM DataRecords
            END";

        using (SqlCommand command = new SqlCommand(createCountProcedure, connection))
        {
            command.ExecuteNonQuery();
        }

        // Create sp_GetDataPaginated
        string createPaginatedProcedure = @"
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
            END";

        using (SqlCommand command = new SqlCommand(createPaginatedProcedure, connection))
        {
            command.ExecuteNonQuery();
        }

        Console.WriteLine("✓ Stored procedures created successfully");
    }

    private void SeedData(SqlConnection connection)
    {
        // Check if data already exists
        using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM DataRecords", connection))
        {
            int recordCount = (int)checkCommand.ExecuteScalar();
            if (recordCount > 0)
            {
                Console.WriteLine($"✓ Database already contains {recordCount} records");
                return;
            }
        }

        // Insert 60 sample records
        string insertQuery = @"
            INSERT INTO DataRecords (SerialNo, Name, City) VALUES
            (1, 'John Smith', 'New York'),
            (2, 'Jane Doe', 'Los Angeles'),
            (3, 'Michael Brown', 'Chicago'),
            (4, 'Emily Davis', 'Houston'),
            (5, 'David Wilson', 'Phoenix'),
            (6, 'Sarah Miller', 'Philadelphia'),
            (7, 'James Taylor', 'San Antonio'),
            (8, 'Jessica Anderson', 'San Diego'),
            (9, 'Robert Thomas', 'Dallas'),
            (10, 'Amanda Jackson', 'San Jose'),
            (11, 'William White', 'Austin'),
            (12, 'Rachel Harris', 'Jacksonville'),
            (13, 'Richard Martin', 'Fort Worth'),
            (14, 'Lauren Thompson', 'Columbus'),
            (15, 'Joseph Garcia', 'Charlotte'),
            (16, 'Megan Martinez', 'San Francisco'),
            (17, 'Charles Robinson', 'Indianapolis'),
            (18, 'Ashley Clark', 'Austin'),
            (19, 'Thomas Rodriguez', 'Memphis'),
            (20, 'Brittany Lewis', 'Boston'),
            (21, 'Christopher Lee', 'Seattle'),
            (22, 'Elizabeth Walker', 'Denver'),
            (23, 'Daniel Hall', 'Washington DC'),
            (24, 'Margaret Allen', 'Nashville'),
            (25, 'Matthew Young', 'Baltimore'),
            (26, 'Patricia Hernandez', 'Louisville'),
            (27, 'Mark King', 'Milwaukee'),
            (28, 'Barbara Wright', 'Albuquerque'),
            (29, 'Donald Lopez', 'Tucson'),
            (30, 'Susan Hill', 'Fresno'),
            (31, 'Steven Scott', 'Sacramento'),
            (32, 'Jessica Green', 'Long Beach'),
            (33, 'Paul Adams', 'Kansas City'),
            (34, 'Karen Nelson', 'Mesa'),
            (35, 'Andrew Carter', 'Virginia Beach'),
            (36, 'Donna Roberts', 'Atlanta'),
            (37, 'Joshua Phillips', 'St. Louis'),
            (38, 'Michelle Campbell', 'Riverside'),
            (39, 'Kenneth Parker', 'Corpus Christi'),
            (40, 'Betty Evans', 'Lexington'),
            (41, 'Kevin Edwards', 'Henderson'),
            (42, 'Sandra Collins', 'Plano'),
            (43, 'Brian Reeves', 'Stockton'),
            (44, 'Kathleen Morris', 'Cincinnati'),
            (45, 'Edward Rogers', 'Saint Paul'),
            (46, 'Shirley Reed', 'Irvine'),
            (47, 'Ronald Cook', 'Chula Vista'),
            (48, 'Angela Morgan', 'Toledo'),
            (49, 'Aaron Peterson', 'Chandler'),
            (50, 'Brenda Cooper', 'Laredo'),
            (51, 'Jose Bell', 'Durham'),
            (52, 'Anna Cox', 'Lubbock'),
            (53, 'Adam Howard', 'Winston-Salem'),
            (54, 'Dorothy Ward', 'Garland'),
            (55, 'Henry Torres', 'Lubbock'),
            (56, 'Samantha Peterson', 'Durham'),
            (57, 'Douglas Gray', 'Chula Vista'),
            (58, 'Maria Ramirez', 'Garland'),
            (59, 'Peter James', 'Las Vegas'),
            (60, 'Joyce Watson', 'Scottsdale')";

        using (SqlCommand command = new SqlCommand(insertQuery, connection))
        {
            command.ExecuteNonQuery();
        }

        Console.WriteLine("✓ Inserted 60 sample records successfully");
    }
}
