using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Toko_Kopi.src
{
    public partial class Karyawan1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["karyawan"] = null;
            Response.Redirect("Login.aspx", true);
        }

        protected void tbl_home_Click(object sender, EventArgs e)
        {
            string _id_akun = Request.QueryString["akses"].ToString();
            Response.Redirect("Halaman_Utama_C.aspx?akses=" + _id_akun, true);
        }
    }
}