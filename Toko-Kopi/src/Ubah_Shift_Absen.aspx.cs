using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Npgsql;

namespace Toko_Kopi.src
{
    public partial class Ubah_Shift_Absen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    data_karyawan();
                }
            }
        }

        protected void tbl_ubah_absen_Click(object sender, EventArgs e)
        {
            try 
            {
                int _id_absen = Convert.ToInt32(Request.QueryString["akses"].ToString());
                string _tanggal = tanggal.Text.ToString();
                string _jam_awal = jam_awal.Text.ToString();
                string _jam_akhir = jam_akhir.Text.ToString();
                int _id_akun = Convert.ToInt32(karyawan.SelectedItem.Value.ToString());

                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["toko_kopi"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;

                    // ABSEN
                    cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM absen WHERE id_absen = " + _id_absen;
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();

                    cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE absen SET akun_id = @akun_id, tanggal = @tanggal, jam_awal = @awal, jam_akhir = @akhir WHERE id_absen = @ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", _id_absen));
                    cmd.Parameters.Add(new NpgsqlParameter("@akun_id", _id_akun));
                    cmd.Parameters.Add(new NpgsqlParameter("@tanggal", _tanggal));
                    cmd.Parameters.Add(new NpgsqlParameter("@awal", _jam_awal));
                    cmd.Parameters.Add(new NpgsqlParameter("@akhir", _jam_akhir));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    connection.Close();

                    Response.Redirect("Absensi_Karyawan.aspx?cari=");
                }
            }
            catch (Exception ex) { }
        }

        protected void data_karyawan()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["toko_kopi"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM akun WHERE id_akun > 1 ORDER BY id_akun ASC;";
                    cmd.CommandType = CommandType.Text;

                    karyawan.DataSource = cmd.ExecuteReader();
                    karyawan.DataTextField = "nama";
                    karyawan.DataValueField = "id_akun";
                    karyawan.DataBind();
                    karyawan.Items.Insert(0, new ListItem("-- Pilih Karyawan --", "0"));

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();

                    connection.Close();
                }
            }
            catch (Exception ex) { }
        }

    }
}