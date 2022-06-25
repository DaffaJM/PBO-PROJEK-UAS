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

namespace Toko_Kopi
{
    public partial class Laporan_Gaji : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["karyawan"] == null)
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
                        cmd.CommandText = "SELECT nama, kehadiran, gaji_pokok FROM ket_absen ka JOIN absen ab ON ka.absen_id = ab.id_absen JOIN akun ak ON ab.akun_id = ak.id_akun WHERE id_akun = " + _id_akun + " ORDER BY id_ket_absen DESC;";
                        cmd.CommandType = CommandType.Text;
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmd.Dispose();

                        StringBuilder sb = new StringBuilder();

                        nama.Text = "Halo, " + dt.Rows[0][0].ToString();

                        sb.Append("<h6 class='fs-5'>: " + dt.Rows[0][0] + " </h6>");
                        sb.Append("<h6 class='fs-5'>: " + dt.Rows[0][1] + " </h6>");
                        sb.Append("<h6 class='fs-5'>: " + dt.Rows[0][2] + " </h6>");
                        if (dt.Rows[0][1].ToString() == "30")
                        {
                            sb.Append("<h6 class='fs-5'>: " + Convert.ToDouble(dt.Rows[0][2].ToString()) + " </h6>");
                            double _hasil = Convert.ToDouble(dt.Rows[0][2].ToString()) * Convert.ToDouble(dt.Rows[0][1].ToString()) + Convert.ToDouble(dt.Rows[0][2].ToString());
                            sb.Append("<h6 class='fs-5'>: " + _hasil + "</h6>");
                        }
                        else
                        {
                            sb.Append("<h6 class='fs-5'>: 0</h6>");
                            sb.Append("<h6 class='fs-5'>: " + Convert.ToDouble(dt.Rows[0][2].ToString()) * Convert.ToDouble(dt.Rows[0][1].ToString()) + " </h6>");
                        }

                        gaji_karyawan.Controls.Add(new LiteralControl(sb.ToString()));

                        connection.Close();

                    }
                }
                catch (Exception ex) { }
            }

        }

        protected void tbl_lihat_data_Click(object sender, EventArgs e)
        {
            string _id_akun = Request.QueryString["akses"].ToString();
            Response.Redirect("Halaman_Utama_C.aspx?akses=" + _id_akun);
        }
    }
}