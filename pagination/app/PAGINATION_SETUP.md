# Pagination Implementation Guide

## Setup Instructions

### Step 1: Update Database Connection String
Edit `appsettings.json` and update the connection string with your SQL Server details:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
}
```

### Step 2: Run SQL Scripts in SQL Server Management Studio
1. Open SQL Server Management Studio
2. Run the script from `SQL/CreateStoredProcedures.sql` to create:
   - `sp_GetDataCount` - Gets total count of records
   - `sp_GetDataPaginated` - Gets paginated data
   - `DataRecords` table - If it doesn't exist

3. Run the script from `SQL/InsertSampleData.sql` to:
   - Insert 60 sample records with Serial No, Name, and City

### Step 3: Add System.Data.SqlClient NuGet Package
In your terminal, run:
```bash
cd app
dotnet add package System.Data.SqlClient
```

### Step 4: Run the Application
```bash
dotnet run
```

## How It Works

### Pagination Configuration
- **Records per page**: 15
- **Total records**: 60
- **Total pages**: 4

### Models
- `DataRecord.cs` - Contains SerialNo, Name, and City properties
- `PaginationResult<T>.cs` - Generic pagination wrapper with page information

### Data Access
- `Data/DataAccess.cs` - Handles database connection and stored procedure calls
  - `GetDataWithPagination()` - Retrieves paginated data
  - Calculates total pages automatically

### Controller
- `Controllers/HomeController.cs`
  - `Index(int page = 1)` - Displays paginated data
  - Page parameter defaults to 1

### View
- `Views/Home/Index.cshtml`
  - Displays records in a responsive table
  - Bootstrap pagination controls
  - Previous/Next buttons
  - Page number links
  - Shows current page and total pages

## URL Structure
Navigate to pages using:
- Page 1: `/?page=1`
- Page 2: `/?page=2`
- Page 3: `/?page=3`
- Page 4: `/?page=4`

## Customization

### Change Page Size
Edit [HomeController.cs](Controllers/HomeController.cs#L18):
```csharp
const int pageSize = 15; // Change this value
```

Also update the stored procedure parameter in [DataAccess.cs](Data/DataAccess.cs#L35)

### Modify Stored Procedures
Edit procedures in [CreateStoredProcedures.sql](SQL/CreateStoredProcedures.sql) as needed

### Add More Data
Modify [InsertSampleData.sql](SQL/InsertSampleData.sql) to insert additional records
