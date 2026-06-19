using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CRUDMahasiswaADO
{
    public partial class Dashboard : Form
    {
        static string connectionString = "Data Source=TARA\\TARA;Initial Catalog=DBAkademikADO; User ID=sa;Password=Mahendradwitara";

        DAL dbLogic = new DAL();
        bool isInitializing = true;
        DataTable dt;
        int button = 0;
