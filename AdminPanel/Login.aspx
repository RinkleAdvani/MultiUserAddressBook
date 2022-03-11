<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/css/bootstrap-theme.min.css" />
    <script src="../Content/js/bootstrap.bundle.min.js"></script>
    <style>
        .head {
            text-align: center;
        }

        .text {
            padding: 32px;
            margin-top: -15px;
        }

        .text1 {
            padding: 8px;
        }

        h3 {
            text-align: center;
            color: blue;
            margin-bottom: 0px;
        }

        .login {
            text-align: center;
            margin-top: -15px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row head">
                <div class="col-md-12">
                    <h2>Multi-User Address Book</h2>
                    <hr />
                </div>
            </div>
            <div class="row">
                <h3>Login</h3>
                <div class="col-md-8 col-lg-push-4">
                    <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="#FF3333"></asp:Label>
                </div>
                <div class="row text">
                    <div class="col-md-8 col-lg-push-4 text1">
                        <asp:TextBox ID="txtUserName" runat="server" PlaceHolder="UserName" CssClass="form-control" Height="40px" Width="500px"></asp:TextBox>
                    </div>
                    <div class="col-md-8 col-lg-push-4 text1">
                        <asp:TextBox ID="txtPassword" runat="server" PlaceHolder="Password" CssClass="form-control" Height="40px" Width="500px" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="row login">
                    <div class="col-md-8 col-lg-push-2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-sm btn-primary" Font-Size="20px" Width="90px" Height="40px"></asp:Button>&nbsp;&nbsp;&nbsp;

                        <asp:Button ID="btnSignIn" runat="server" Text="SignIn" CssClass="btn btn-sm btn-danger" Font-Size="20px" Width="90px" Height="40px" OnClick="btnSignIn_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
