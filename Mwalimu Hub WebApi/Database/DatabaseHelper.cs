using System.Data;
using System.Data.SqlClient;

namespace Mwalimu_Hub_API.Database
{
    public class DatabaseHelper
    {
        
            private readonly string connectionString;
            public DatabaseHelper()
            {
                this.connectionString = "Data Source=Bricho;Initial Catalog=School;Integrated Security=True";
            }
            public DataTable GetData(string procedureName)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand(procedureName, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;


                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;


                }
            }
            public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    using (SqlCommand sqlCommand = new SqlCommand(procedureName, connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            sqlCommand.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(dataTable);
                        }

                        return dataTable;
                    }

                }
            }
            public int ExecuteNonQueryStoredProcedure(string procedureName, SqlParameter[] parameters)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand(procedureName, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;

                }

            }
        }
}
