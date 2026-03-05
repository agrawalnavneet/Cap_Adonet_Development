using System.Data;
using System.Data.SqlClient;
using app.Models;
using Microsoft.Extensions.Configuration;

namespace app.Data;

public class DataAccess
{
    private readonly string _connectionString;

    public DataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public PaginationResult<DataRecord> GetDataWithPagination(int pageNumber = 1, int pageSize = 15)
    {
        var result = new PaginationResult<DataRecord>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize
        };

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Get total count first
                using (SqlCommand countCommand = new SqlCommand("sp_GetDataCount", connection))
                {
                    countCommand.CommandType = CommandType.StoredProcedure;
                    result.TotalItems = (int)countCommand.ExecuteScalar();
                }

                // Calculate total pages
                result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / pageSize);

                // Get paginated data
                using (SqlCommand command = new SqlCommand("sp_GetDataPaginated", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Items.Add(new DataRecord
                            {
                                SerialNo = (int)reader["SerialNo"],
                                Name = reader["Name"].ToString(),
                                City = reader["City"].ToString()
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return result;
    }
}
