<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="AdminPanel_SignIn" %>

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

        strong {
            color: red;
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
            margin-top: 7px;
        }

        .signin {
            margin-bottom: 30px;
        }

        .text {
            padding: 15px;
            margin-top: -15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <h2>Multi-User Address Book</h2>
                    <hr />
                </div>
            </div>

            <div class="row signin">
                <h3>SignIn</h3>
                <div class="col-md-8 col-sm-push-3">
                    <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="#FF3333"></asp:Label>
                </div>
            </div>

            <div class="row text">
                <div class="col-md-4 col-sm-push-3 text1">
                    <strong>*</strong>Username :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtUserName" runat="server" PlaceHolder="UserName" CssClass="form-control" Height="40px" Width="500px"></asp:TextBox>
                </div>
            </div>

            <div class="row text">
                <div class="col-md-4 col-sm-push-3 text1">
                    <strong>*</strong>Name :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtName" runat="server" PlaceHolder="Name" CssClass="form-control" Height="40px" Width="500px"></asp:TextBox>
                </div>
            </div>

            <div class="row text">
                <div class="col-md-4 col-sm-push-3 text1">
                    Mobile Number :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="Mobile Number" CssClass="form-control" Height="40px" Width="500px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Enter Valid Mobile Number" ForeColor="Red" ValidationExpression="\+?\d[\d -]{8,12}\d" EnableViewState="false" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row text">
                <div class="col-md-4 col-sm-push-3 text1">
                    Email :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="Email" CssClass="form-control" Height="40px" Width="500px"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row text">
                <div class="col-md-4 col-sm-push-3 text1">
                    <strong>*</strong>Password :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtPassword" runat="server" PlaceHolder="Password" CssClass="form-control" Height="40px" Width="500px" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div class="row text">
                <div class="col-md-4 col-sm-push-3 text1">
                    <strong>*</strong>Confirm Password :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" PlaceHolder="Confirm Password" CssClass="form-control" Height="40px" Width="500px" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                </div>
            </div>

            <div class="row login">
                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-sm btn-primary" Font-Size="20px" Width="80px" Height="40px" OnClick="btnLogin_Click"></asp:Button>&nbsp;&nbsp;&nbsp;

                    <asp:Button ID="btnSignIn" runat="server" Text="SignIn" CssClass="btn btn-sm btn-danger" Font-Size="20px" Width="80px" Height="40px" OnClick="btnSignIn_Click"></asp:Button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
