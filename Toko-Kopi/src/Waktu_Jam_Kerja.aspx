<%@ Page Title="" Language="C#" MasterPageFile="~/src/Admin.Master" AutoEventWireup="true" CodeBehind="Waktu_Jam_Kerja.aspx.cs" Inherits="Toko_Kopi.src.Waktu_Jam_Kerja" %>

<asp:Content ID="jam_kerja" ContentPlaceHolderID="konten" runat="server">

    <div class="absen container mx-auto mt-5 pt-5">
        <div class="isi-konten">
            <div class="judul">
                <h1 class="fw-bold text-center">Waktu Jam Kerja</h1>
            </div>
            <div class="tabel-konten my-5">
                <p>Tanggal:</p>
                <div class="atur d-flex justify-content-between">
                    <div class="tanggal d-flex">
                        <asp:TextBox ID="cari_tanggal" placeholder="dd/mm/yyyy" TextMode="Date" AutoCompleteType="Disabled" CssClass="form-control w-75 me-3" runat="server" />
                        <asp:Button Text="Lihat" ID="lihat_data" CssClass="btn btn-primary" runat="server" OnClick="lihat_data_Click" />
                    </div>
                </div>
                <div class="tabel mt-5">

                    <asp:GridView ID="shift_jam_kerja" CssClass="table table-hover table-borderless table-responsive align-middle" runat="server" AutoGenerateColumns="false" OnRowDataBound="akses_DataBound" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="id_absen" HeaderText="No." runat="server" />
                            <asp:BoundField DataField="nama" HeaderText="Nama Karyawan" runat="server" />
                            <asp:BoundField DataField="no_hp" HeaderText="No.Hp" runat="server" />
                            <asp:BoundField DataField="" HeaderText="Jam Absen" runat="server" />
                            <asp:TemplateField HeaderText="Aksi">
                                <ItemTemplate>
                                    <asp:Button Text="Edit" ID="edit_jam_kerja" AutoCompleteType="Disabled" CssClass="btn btn-primary btn-sm" runat="server" OnClick="edit_data" />
                                    <asp:Button Text="Hapus" ID="hapus_jam_kerja" AutoCompleteType="Disabled" CssClass="btn btn-danger btn-sm" runat="server" OnClick="hapus_data" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" CssClass="border-0 border-top border-bottom" />
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
