using System.Data.SqlClient;
using System.Data;
namespace Hotel_Management_System.Pages.Models
{
    public class DB
    {
        public SqlConnection con { get; set; }
        public DB()
        {
            string conStr = "Data Source=DESKTOP-DFJM3O9;Initial Catalog=COMPANYDB_Lab11;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            con = new SqlConnection(conStr);
        }
        // Read a specific table
        public DataTable ReadTable(string tableName)
        {
            DataTable table = new DataTable();
            string q = "SELECT * FROM " + tableName;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(q, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }
    }
}
