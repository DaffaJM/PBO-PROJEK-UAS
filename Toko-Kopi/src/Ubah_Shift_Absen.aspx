<%@ Page Title="" Language="C#" MasterPageFile="~/src/Admin.Master" AutoEventWireup="true" CodeBehind="Ubah_Shift_Absen.aspx.cs" Inherits="Toko_Kopi.src.Ubah_Shift_Absen" %>

<asp:Content ID="ubah_shift_absen" ContentPlaceHolderID="konten" runat="server">

    <div class="absen container mx-auto mt-5 pt-5">
        <div class="isi-konten">
            <div class="judul">
                <h1 class="fw-bold text-center">Shift Karyawan</h1>
            </div>
            <div class="shift-konten my-5 w-75 mx-auto">
                <p>Tanggal Shift Kerja : </p>
                <div class="atur d-flex justify-content-between mb-3">
                    <asp:TextBox ID="tanggal" placeholder="dd/mm/yyyy" TextMode="Date" AutoCompleteType="Disabled" CssClass="form-control" runat="server" />
                </div>
                <p>Jam Shift Kerja : </p>
                <div class="jam d-flex justify-content-between mb-3">
                    <asp:TextBox ID="jam_awal" CssClass="form-control text-center" TextMode="Time" format="HH:mm" placeholder="00:00" AutoCompleteType="Disabled" runat="server" />
                    <i class="bi bi-dash-lg fs-3 mx-3"></i>
                    <asp:TextBox ID="jam_akhir" CssClass="form-control text-center" TextMode="Time" format="HH:mm" placeholder="00:00" AutoCompleteType="Disabled" runat="server" />
                </div>
                <p>Nama Karyawan : </p>
                <div class="nama-karyawan mb-3">
                    <asp:DropDownList ID="karyawan" CssClass="form-control w-100" runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="tambah_absen text-end">
                    <asp:Button Text="Perbarui Absen" ID="tbl_ubah_absen" CssClass="btn btn-primary" runat="server" OnClick="tbl_ubah_absen_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
