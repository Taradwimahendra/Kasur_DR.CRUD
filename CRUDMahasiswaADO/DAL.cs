using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    internal class DAL
    {

        static string connectionString = "Data Source=TARA\\TARA;Initial Catalog=DBAkademikADO; User ID=sa;Password=Mahendradwitara";

        public string GetConnectionString()
        {
            string connection = $"Data Source={GetLocalIPAddress()};Initial Catalog=DBAkademikADO; User ID=sa;Password=Kadirojo7;";
            return connectionString;
        }

        SqlConnection conn = new SqlConnection(connectionString);

        SqlDataAdapter da;
        DataTable dtMahasiswa;
        DataTable dtProdi;

       