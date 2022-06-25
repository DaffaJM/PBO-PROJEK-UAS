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
    public partial class Absensi_Karyawan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try
                {
                    string _cari_tanggal = Request.QueryString["cari"].ToString() == "" ? "" : Request.QueryString["cari"].ToString();
                    using (NpgsqlConnection connection = new NpgsqlConnection())
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["toko_kopi"].ToString();
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        if (_cari_tanggal != "")
                        {
                            cmd.CommandText = "SELECT id_absen, nama, no_hp, jam_awal, jam_akhir, status FROM absen ab JOIN akun ak ON ab.akun_id = ak.id_akun WHERE tanggal = '" + Convert.ToDateTime(_cari_tanggal).ToString("yyyy-MM-dd") + "' ORDER BY id_absen ASC;";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT id_absen, nama, no_hp, jam_awal, jam_akhir, status FROM absen ab JOIN akun ak ON ab.akun_id = ak.id_akun ORDER BY id_absen ASC;";
                        }
                        cmd.CommandType = CommandType.Text;
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmd.Dispose();

                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int a = i + 1;
                            sb.Append("<tr>");
                            sb.Append("<td>" + a + "</td>");
                            sb.Append("<td>" + dt.Rows[i][1] + "</td>");
                            sb.Append("<td>" + dt.Rows[i][2] + "</td>");
                            sb.Append("<td>" + dt.Rows[i][3] + " - " + dt.Rows[i][4] + "</td>");
                            sb.Append("<td>" + dt.Rows[i][5] + "</td>");
                            sb.Append("</tr>");
                        }

                        shift_karyawan.Controls.Add(new LiteralControl(sb.ToString()));

                        connection.Close();

                    }
                }
                catch (Exception ex) { }
            }

        }

        protected void lihat_data_Click(object sender, EventArgs e)
        {

            string _cari_tanggal = cari_tanggal.Text.ToString();
            Response.Redirect("Absensi_Karyawan.aspx?cari=" + _cari_tanggal, true);
        }
    }
}