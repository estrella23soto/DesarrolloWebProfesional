using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    string connectionString = "Data Source=ESTRELLITA;Initial Catalog=gamershop_v1;Integrated Security=True;";

    public Conexion(string connectionString = "Data Source=ESTRELLITA;Initial Catalog=gamershop_v1;Integrated Security=True;")
    {
        this.connectionString = connectionString;
    }

    public DataTable EjecutarConsulta(string query)
    {
        DataTable dataTable = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
        }

        return dataTable;
    }

    public bool EjecutarConsultaSinResultado(string query)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            return false;
        }
    }

}