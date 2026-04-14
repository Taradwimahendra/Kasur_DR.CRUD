using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CRUDMahasiswaADO
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=TARA\\TARA;Initial Catalog=DBAkademikADO;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void ConnectDatabase()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MessageBox.Show("Koneksi berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectDatabase();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("NIM", "NIM");
                dataGridView1.Columns.Add("Nama", "Nama");
                dataGridView1.Columns.Add("JenisKelamin", "JenisKelamin");
                dataGridView1.Columns.Add("TanggalLahir", "TanggalLahir");
                dataGridView1.Columns.Add("Alamat", "Alamat");
                dataGridView1.Columns.Add("KodeProdi", "KodeProdi");

                string query = "SELECT * FROM Mahasiswa";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    dataGridView1.Rows.Add(r["NIM"].ToString(), r["Nama"].ToString(), r["JenisKelamin"].ToString(),
                        Convert.ToDateTime(r["TanggalLahir"]).ToString("yyyy-MM-dd"), r["Alamat"].ToString(), r["KodeProdi"].ToString()
                    );
                }

                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (txtNIM.Text == "")
                {
                    MessageBox.Show("NIM harus diisi!");
                    txtNIM.Focus();
                    return;
                }

                if (txtNama.Text == "")
                {
                    MessageBox.Show("Nama harus diisi!");
                    txtNama.Focus();
                    return;
                }

                if (cmbJK.Text == "")
                {
                    MessageBox.Show("Jenis Kelamin harus dipilih!");
                    cmbJK.Focus();
                    return;
                }

                if (txtKodeProdi.Text == "")
                {
                    MessageBox.Show("Kode Prodi harus diisi!");
                    txtKodeProdi.Focus();
                    return;
                }

                string query = "INSERT INTO Mahasiswa (NIM, Nama, JenisKelamin, TanggalLahir, Alamat, KodeProdi, TanggalDaftar) " +
                               "VALUES (@NIM, @Nama, @JenisKelamin, @TanggalLahir, @Alamat, @KodeProdi, @TanggalDaftar)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NIM", txtNIM.Text);
                cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@JenisKelamin", cmbJK.Text);
                cmd.Parameters.AddWithValue("@TanggalLahir", dtpTanggalLahir.Value);
                cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@KodeProdi", txtKodeProdi.Text);
                cmd.Parameters.AddWithValue("@TanggalDaftar", DateTime.Now);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data Mahasiswa berhasil ditambahkan!");
                    btnLoad.PerformClick();
                }
                else
                {
                    MessageBox.Show("Data gagal ditambahkan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }
    }

}

