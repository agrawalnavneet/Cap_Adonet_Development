using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using global::MVCwithADO.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace MVCwithADO.Data
{
    public class StudentRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(IConfiguration configuration, ILogger<StudentRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT Id, Name, Age, City FROM StudentsMaster";

                    using var cmd = new SqlCommand(query, con);

                    con.Open();
                    using SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            Id = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                            Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetFieldValue<int>(reader.GetOrdinal("Age")),
                            City = reader.IsDBNull(reader.GetOrdinal("City")) ? string.Empty : reader.GetString(reader.GetOrdinal("City"))
                        };

                        students.Add(student);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Database error while fetching students.");
                // Return empty list on DB errors to avoid bubbling up an unhandled exception to the UI.
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching students.");
            }

            return students;
        }
    }
}