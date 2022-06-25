<%@ Page Title="" Language="C#" MasterPageFile="~/src/Admin.Master" AutoEventWireup="true" CodeBehind="Tambah_Shift_Absen.aspx.cs" Inherits="Toko_Kopi.src.Tambah_Shift_Absen" %>

<asp:Content ID="tambah_shift_absen" ContentPlaceHolderID="konten" runat="server">

    <div class="absen container mx-auto mt-5 pt-5">
        <div class="isi-konten">
            <div class="judul">
                <h1 class="fw-bold text-center">Shift Karyawan</h1>
            </div>
            <div class="shift-konten my-5 w-75 mx-auto">
                <p>Tanggal Shift Kerja : </p>
                <div class="atur d-flex justify-content-between mb-3">
                    <asp:TextBox ID="tanggal" placeholder="dd/mm/yyyy" TextMode="Date" AutoCompleteType="Disabled" CssClass="form-control w-100" runat="server" />
                </div>
                <p>Jam Shift Kerja : </p>
                <div class="jam d-flex justify-content-between mb-3">
                    <asp:TextBox ID="jam_awal" CssClass="form-control text-center" placeholder="00.00" TextMode="Time" format="HH:mm" AutoCompleteType="Disabled" runat="server" />
                    <i class="bi bi-dash-lg fs-3 mx-3"></i>
                    <asp:TextBox ID="jam_akhir" CssClass="form-control text-center" placeholder="00.00" TextMode="Time" format="HH:mm" AutoCompleteType="Disabled" runat="server" />
                </div>
                <p>Nama Karyawan : </p>
                <div class="nama-karyawan mb-3">
                    <asp:DropDownList ID="karyawan" CssClass="form-control w-100" runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="tambah_absen text-end">
                    <asp:Button Text="Tambah Absen" ID="tbl_tambah_absen" CssClass="btn btn-primary" runat="server" OnClick="tbl_tambah_absen_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
