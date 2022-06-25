<%@ Page Title="" Language="C#" MasterPageFile="~/src/Karyawan.Master" AutoEventWireup="true" CodeBehind="Halaman_Utama_C.aspx.cs" Inherits="Toko_Kopi.src.Halaman_Utama_C" %>

<asp:Content ID="halaman_utama_c" ContentPlaceHolderID="konten" runat="server">

    <div class="bungkus mt-3">
        <div class="konten-luar container pt-5">

            <asp:PlaceHolder ID="konten_karyawan" runat="server" />

            <div class="tbl-pilihan-hadir text-center mt-5 mb-3">

                <asp:PlaceHolder ID="tbl_rekam" runat="server" />

                <div class="modal fade" id="modal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-body">
                                <i class="bi bi-check-square-fill" style="color: #70CB29; font-size: 10rem;"></i>
                                <div class="my-3">
                                    <h1>Berhasil Absen !</h1>
                                </div>
                            </div>
                            <div class="modal-footer mx-auto w-50 border border-0">
                                <asp:Button Text="Oke" ID="tbl_rekam_hadir" CssClass="btn btn-primary w-100" runat="server" OnClick="tbl_rekam_hadir_Click"/>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="tbl-pilihan-gaji text-center">
                <asp:Button Text="Cek Penggajianmu Yuk !!" ID="cek_gaji" CssClass="btn btn-warning w-25 text-white" runat="server" OnClick="cek_gaji_Click" />
            </div>
        </div>
    </div>

</asp:Content>
