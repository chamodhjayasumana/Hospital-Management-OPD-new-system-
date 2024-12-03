<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateMedicalRecord.aspx.cs" Inherits="Hospital_Management_OPD.UpdateMedicalRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Update Medical Record</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
        <div class="form-group">
            <label>Diagnosis</label>
            <asp:TextBox ID="txtDiagnosis" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Prescribed Treatment</label>
            <asp:TextBox ID="txtTreatment" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary mt-3" OnClick="btnUpdate_Click" />
    </div>
</asp:Content>