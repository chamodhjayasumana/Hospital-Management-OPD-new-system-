<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateDoctor.aspx.cs" Inherits="Hospital_Management_OPD.UpdateDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Update Doctor</h2>
    <div class="container">
        <div class="form-group">
            <label for="txtFirstName">First Name</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtLastName">Last Name</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtSpecialization">Specialization</label>
            <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtPhoneNumber">Phone Number</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlDepartment">Department</label>
            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update Doctor" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
    </div>
</asp:Content>

