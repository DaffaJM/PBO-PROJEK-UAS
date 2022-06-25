<%@ Page Title="" Language="C#" MasterPageFile="~/src/Admin.Master" AutoEventWireup="true" CodeBehind="Absensi_Karyawan.aspx.cs" Inherits="Toko_Kopi.src.Absensi_Karyawan" %>

<asp:Content ID="absen_karyawan" ContentPlaceHolderID="konten" runat="server">

    <div class="absen container mx-auto mt-5 pt-5">
        <div class="isi-konten">
            <div class="judul">
                <h1 class="fw-bold text-center">Absensi Karyawan</h1>
            </div>
            <div class="tabel-konten my-5">
                <p>Tanggal:</p>
                <div class="atur d-flex justify-content-between">
                    <div class="tanggal d-flex">
                        <asp:TextBox ID="cari_tanggal" placeholder="dd/mm/yyyy" TextMode="Date" AutoCompleteType="Disabled" CssClass="form-control w-75 me-3" runat="server" />
                        <asp:Button Text="Lihat" ID="lihat_data" CssClass="btn btn-primary" runat="server" OnClick="lihat_data_Click" />
                    </div>
                    <div class="tombol">
                        <a href="Tambah_Shift_Absen.aspx" class="btn btn-success">
                            <i class="bi bi-plus"></i>
                            Shift Kerja
                        </a>
                        <a href="Waktu_Jam_Kerja.aspx?cari=" class="btn btn-primary">Lihat Shift Kerja
                        </a>
                    </div>
                </div>
                <div class="tabel mt-5">
                    <table class="table table-hover table-borderless align-middle">
                        <thead style="border-top: 2px solid black; border-bottom: 2px solid black;">
                            <tr>
                                <th scope="col">No. </th>
                                <th scope="col">Nama Karyawan</th>
                                <th scope="col">No. Hp</th>
                                <th scope="col">Jam Absen</th>
                                <th scope="col">Status Absen</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="shift_karyawan" runat="server" />
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
