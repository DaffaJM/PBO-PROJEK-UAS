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
    public partial class Waktu_Jam_Kerja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                if (!Page.IsPostBack)
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

                            string _satu = dt.Columns[0].ToString();
                            string _dua = dt.Columns[1].ToString();
                            string _tiga = dt.Columns[2].ToString();
                            string _empat = dt.Columns[3].ToString();
                            string _lima = dt.Columns[4].ToString();

                            DataTable d = new DataTable();
                            d.Columns.AddRange(new DataColumn[5] { new DataColumn(_satu), new DataColumn(_dua), new DataColumn(_tiga), new DataColumn(_empat), new DataColumn(_lima) });
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                int a = i + 1;
                                d.Rows.Add(a, dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
                            }

                            shift_jam_kerja.DataSource = d;
                            shift_jam_kerja.DataBind();

                            cmd.Dispose();
                            connection.Close();

                        }
                    }
                    catch (Exception ex) { }
                }
            }

        }

        protected void akses_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Text = string.Format("{0} - {1}", DataBinder.Eval(e.Row.DataItem, "jam_awal"), DataBinder.Eval(e.Row.DataItem, "jam_akhir"));
            }
        }
        protected void hapus_data(object sender, EventArgs e)
        {
            try
            {
                int _row_index = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
                int _id_absen = Convert.ToInt32(shift_jam_kerja.Rows[_row_index].Cells[0].Text);

                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["toko_kopi"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;

                    // ABSEN
                    cmd.CommandText = "DELETE FROM absen WHERE id_absen = @ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", _id_absen));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    // KET ABSEN
                    cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM ket_absen WHERE absen_id = @ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", _id_absen));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    connection.Close();

                    Response.Redirect("Waktu_Jam_Kerja.aspx?cari=", true);
                }
            }
            catch (Exception ex) { }

        }

        protected void edit_data(object sender, EventArgs e)
        {
            try
            {
                int _row_index = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
                int _id_ket_absen = Convert.ToInt32(shift_jam_kerja.Rows[_row_index].Cells[0].Text);

                Response.Redirect("Ubah_Shift_Absen.aspx?akses=" + _id_ket_absen);
            }
            catch (Exception ex) { }
        }

        protected void lihat_data_Click(object sender, EventArgs e)
        {
            string _cari_tanggal = cari_tanggal.Text.ToString();
            Response.Redirect("Waktu_Jam_Kerja.aspx?cari=" + _cari_tanggal, true);
        }
    }
}