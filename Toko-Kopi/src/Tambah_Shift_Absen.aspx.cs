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
    public partial class Tambah_Shift_Absen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            if (!IsPostBack)
            {
                data_karyawan();
            }

        }

        protected void tbl_tambah_absen_Click(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                try
                {
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

                        cmd.CommandText = "SELECT kehadiran FROM ket_absen ka JOIN absen ab ON ka.absen_id = ab.id_absen JOIN akun ak ON ab.akun_id = ak.id_akun WHERE id_akun = " + _id_akun + " ORDER BY id_absen DESC;";
                        cmd.CommandType = CommandType.Text;
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmd.Dispose();
                        int _kehadiran = Convert.ToInt32(dt.Rows[0][0].ToString());

                        // ABSEN
                        cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT * FROM absen";
                        cmd.CommandType = CommandType.Text;
                        da = new NpgsqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        cmd.Dispose();
                        int _id_absen_baru = dt.Rows.Count + 1;

                        cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO absen VALUES(@ID,@akun_id,@tanggal,@awal, @akhir, @status)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@ID", _id_absen_baru));
                        cmd.Parameters.Add(new NpgsqlParameter("@akun_id", _id_akun));
                        cmd.Parameters.Add(new NpgsqlParameter("@tanggal", _tanggal));
                        cmd.Parameters.Add(new NpgsqlParameter("@awal", _jam_awal));
                        cmd.Parameters.Add(new NpgsqlParameter("@akhir", _jam_akhir));
                        cmd.Parameters.Add(new NpgsqlParameter("@status", "Tidak Hadir"));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        // KET ABSEN
                        cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT * FROM ket_absen";
                        cmd.CommandType = CommandType.Text;
                        da = new NpgsqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        cmd.Dispose();
                        int _id_ket_absen_baru = dt.Rows.Count + 1;

                        cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO ket_absen VALUES(@ID,@absen_id,@hadir)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@ID", _id_ket_absen_baru));
                        cmd.Parameters.Add(new NpgsqlParameter("@absen_id", _id_absen_baru));
                        cmd.Parameters.Add(new NpgsqlParameter("@hadir", _kehadiran));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        connection.Close();

                        Response.Redirect("Absensi_Karyawan.aspx?cari=");

                    }
                }
                catch (Exception ex) { }
            }

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