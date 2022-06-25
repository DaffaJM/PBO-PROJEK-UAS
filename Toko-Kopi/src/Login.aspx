<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Toko_Kopi.src.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TOKO-KOPI</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.3/font/bootstrap-icons.css">
</head>
<body>

    <header>
        <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #FFF625;">
            <div class="container-fluid">
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mx-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active fs-2 fw-bold" aria-current="page" href="#">MANAJEMEN KARYAWAN</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <form id="form1" runat="server">
        <div class="form-login container text-center">
            <div class="judul-login text-align-content-center my-5">
                <h1 class="fs-1 fw-bold">Login</h1>
            </div>
            <div class="akses-form my-3 w-50 mx-auto">
                <div class="form-akses">
                    <asp:TextBox ID="username" CssClass="form-control" placeholder="Username" AutoCompleteType="Disabled" runat="server" />
                </div>
                <div class="form-akses my-3">
                    <asp:TextBox ID="password" CssClass="form-control" placeholder="Password" AutoCompleteType="Disabled" runat="server" />
                </div>
            </div>
            <div class="tbl">
                <asp:Button Text="Login" ID="tbl_login" CssClass="btn btn-primary w-25" runat="server" OnClick="tbl_login_Click" />
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>

</body>
</html>
