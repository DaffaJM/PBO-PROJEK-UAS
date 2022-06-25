using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Text;

namespace Toko_Kopi.src
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbl_login_Click(object sender, EventArgs e)
        {
            try
            {
                string _username = username.Text.ToString();
                string _password = password.Text.ToString();
                string _id_akun = "";
                string _jabatan = "";
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["toko_kopi"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT id_akun, jabatan FROM akun WHERE username = '" + _username + "' AND password = '" + _password + "';";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose(); 
                    _id_akun = dt.Rows[0][0].ToString();
                    _jabatan = dt.Rows[0][1].ToString();
                    connection.Close();

                    if(_jabatan.Equals("admin"))
                    {
                        Session["admin"] = _jabatan;
                        Response.Redirect("Absensi_Karyawan.aspx?cari=");
                    }
                    else if(_jabatan.Equals("karyawan"))
                    {
                        Session["karyawan"] = _jabatan;
                        Response.Redirect("~/src/Halaman_Utama_C.aspx?akses=" + _id_akun, true);
                    }
                }
            }
            catch (Exception ex) { }

        }
    }
}