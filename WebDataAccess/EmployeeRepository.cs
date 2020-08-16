using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebDataAccess
{
    public class EmployeeRepository
    {
        SqlConnection connection;
        public EmployeeRepository()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeeDbCon"].ConnectionString);
        }

        public DataTable GetEmployees()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", connection))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                sda.Fill(dataSet);
                dt = dataSet.Tables[0];
            }
            return dt;
        }
        public DataTable GetByEmployeeId(int employeeId)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE ID=" + employeeId, connection))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                sda.Fill(dataSet);
                dt = dataSet.Tables[0];
            }
            return dt;
        }
    }
}
