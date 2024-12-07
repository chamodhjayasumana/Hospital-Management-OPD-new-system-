<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hospital_Management_OPD.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        body {
            background-image: url('Images/img1.jpg'); /* Adjust the path if necessary */
            background-size: cover; /* Ensures the image covers the whole page */
            background-position: center; /* Centers the background image */
            background-repeat: no-repeat; /* Prevents the image from repeating */
            height: 100vh; /* Full viewport height */
            margin: 0; /* Removes default margin */
        }

        .container {
            background-color: rgba(255, 255, 255, 0.8); /* Adds transparency to the form background */
            padding: 30px;
            border-radius: 10px;
            max-width: 400px;
            margin-top: 10%;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Optional shadow for better visibility */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Admin Login</h2>
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-3" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
