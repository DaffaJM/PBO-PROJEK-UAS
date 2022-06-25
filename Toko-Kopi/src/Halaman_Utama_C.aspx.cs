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
    public partial class Halaman_Utama_C : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["karyawan"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                try
                {
                    string _id_akun = Request.QueryString["akses"].ToString();
                    using (NpgsqlConnection connection = new NpgsqlConnection())
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["toko_kopi"].ToString();
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT nama, tanggal, jam_awal, jam_akhir, status FROM absen ab JOIN akun ak ON ab.akun_id = ak.id_akun WHERE id_akun = " + _id_akun + " ORDER BY id_absen DESC;";
                        cmd.CommandType = CommandType.Text;
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmd.Dispose();

                        StringBuilder sb = new StringBuilder();

                        sb.Append("<div class='judul-1 my-5'>");
                        sb.Append("<h1 class='fw-bold text-center fs-1'>");
                        sb.Append("Halo, " + dt.Rows[0][0]);
                        sb.Append("</h1>");
                        sb.Append("</div>");
                        sb.Append("<div class='judul-2 mb-5'>");
                        sb.Append("<h1 class='fw-bold text-center fs-1'>");
                        sb.Append("Jangan Lupa Absen Ya !");
                        sb.Append("</h1>");
                        sb.Append("</div>");
                        sb.Append("<div class='keterangan-absen'>");
                        sb.Append("<div class='card text-white bg-dark mb-3 mx-auto border border-3 border-dark' style='max-width: 19rem;'>");
                        sb.Append("<div class='card-header text-center fs-5' style='font-weight: 600;'>");
                        sb.Append("Hari ini (" + Convert.ToDateTime(dt.Rows[0][1]).ToString("dddd, dd MMM yyyy", new System.Globalization.CultureInfo("id-ID")) + ")");
                        sb.Append("</div>");
                        sb.Append("<div class='card-body bg-white text-dark fw-bold'>");
                        sb.Append("<div class='ket-jam d-flex justify-content-between mx-2'>");
                        sb.Append("<h6 class='fw-bold fs-5'>Jam Masuk</h6>");
                        sb.Append("<h6 class='fw-bold fs-5'>Jam Keluar</h6>");
                        sb.Append("</div>");
                        sb.Append("<div class='d-flex justify-content-between mx-4 fs-5'>");
                        sb.Append("<p>" + dt.Rows[0][2] + "</p>");
                        sb.Append("<i class='bi bi-dash-lg'></i>");
                        sb.Append("<p> " + dt.Rows[0][3] + " </p>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");

                        if (dt.Rows[0][4].ToString() == "Hadir")
                        {
                            sb.Append("<div class='mt-4 text-center'>");
                            sb.Append("<p style='padding: 0.5rem 1.5rem; background-color: green; display: inline; color:white;'>Berhasil Absen !!!</a>");
                            sb.Append("</div>");
                        }

                        konten_karyawan.Controls.Add(new LiteralControl(sb.ToString()));

                        sb = new StringBuilder();

                        if (dt.Rows[0][4].ToString() == "Hadir")
                        {
                            sb.Append("<button type='button' class='btn btn-primary disabled' data-bs-toggle='modal' data-bs-target='#modal'>");
                            sb.Append("Rekam Kehadiran");
                            sb.Append("</button>");
                        }
                        else
                        {
                            sb.Append("<button type='button' class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#modal'>");
                            sb.Append("Rekam Kehadiran");
                            sb.Append("</button>");
                        }

                        tbl_rekam.Controls.Add(new LiteralControl(sb.ToString()));

                        connection.Close();
                    }
                }
                catch (Exception ex) { }
            }
        }

        protected void tbl_rekam_hadir_Click(object sender, EventArgs e)
        {
            try
            {
                string _id_akun = Request.QueryString["akses"].ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["toko_kopi"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT id_absen FROM absen ab JOIN akun ak ON ab.akun_id = ak.id_akun WHERE id_akun = " + _id_akun + " ORDER BY id_absen DESC;";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int _id_absen_cari = Convert.ToInt32(dt.Rows[0][0].ToString());

                    cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT kehadiran FROM ket_absen ka JOIN absen ab ON ka.absen_id = ab.id_absen JOIN akun ak ON ab.akun_id = ak.id_akun WHERE absen_id = '" + _id_absen_cari + "' ORDER BY id_ket_absen DESC;";
                    cmd.CommandType = CommandType.Text;
                    da = new NpgsqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    int _kehadiran_lama = Convert.ToInt32(dt.Rows[0][0].ToString());

                    // UPDATE  DATA
                    cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE absen SET status = @status WHERE id_absen = @ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", _id_absen_cari));
                    cmd.Parameters.Add(new NpgsqlParameter("@status", "Hadir"));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE ket_absen SET kehadiran = @hadir WHERE absen_id = @ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", _id_absen_cari));
                    cmd.Parameters.Add(new NpgsqlParameter("@hadir", _kehadiran_lama + 1));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    Response.Redirect("Halaman_Utama_C.aspx?akses="+ _id_akun, true);
                }
            }
            catch (Exception ex) { }

        }

        protected void cek_gaji_Click(object sender, EventArgs e)
        {
            string _id_akun = Request.QueryString["akses"].ToString();
            Response.Redirect("~/src/Laporan_Gaji.aspx?akses=" + _id_akun, true);
        }
    }
}