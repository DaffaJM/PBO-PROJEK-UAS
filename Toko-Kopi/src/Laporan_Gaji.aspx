<%@ Page Title="" Language="C#" MasterPageFile="~/src/Karyawan.Master" AutoEventWireup="true" CodeBehind="Laporan_Gaji.aspx.cs" Inherits="Toko_Kopi.Laporan_Gaji" %>

<asp:Content ID="gaji" ContentPlaceHolderID="konten" runat="server">

    <div class="laporan-gaji mt-5">

        <div class="container mb-3">
            <div class="judul-1 text-center my-3">
                <asp:Label Text="" ID="nama" CssClass="fw-bold fs-1" runat="server" />
            </div>
            <div class="judul-2 text-center  my-3">
                <h1 class="fw-bold">Ini Laporan Gajimu :)</h1>
            </div>
        </div>

        <div class="container mx-auto p-4 my-4" style="border-top: 2px solid black; border-bottom: 2px solid black;">
            <div class="konten-2 row mx-auto p-3">
                <div class="col-3 offset-4">
                    <h6 class="fs-5">Nama</h6>
                    <h6 class="fs-5">Total Kehadiran</h6>
                    <h6 class="fs-5">Gaji per Hari</h6>
                    <h6 class="fs-5">Bonus Tambahan</h6>
                    <h6 class="fs-5">Jumlah Gaji Bulan Ini</h6>
                </div>
                <div class="col-2">
                    <asp:PlaceHolder ID="gaji_karyawan" runat="server" />
                </div>
            </div>
        </div>

        <div class="tbl container">
            <asp:Button Text="Oke" ID="tbl_lihat_data" CssClass="btn btn-primary w-100" runat="server" OnClick="tbl_lihat_data_Click" />
        </div>

    </div>

</asp:Content>
