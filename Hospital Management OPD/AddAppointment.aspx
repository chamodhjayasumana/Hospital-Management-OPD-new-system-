<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAppointment.aspx.cs" Inherits="Hospital_Management_OPD.AddAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <h2>Create New Appointment</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="ddlPatient">Patient</label>
                    <asp:DropDownList ID="ddlPatient" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

               <div class="form-group">
                    <label for="ddlDepartments">Select Department</label>
                    <asp:DropDownList ID="ddlDepartments" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="ddlDoctor">Select Doctor</label>
                    <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="txtAppointmentDate">Appointment Date</label>
                    <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtAppointmentTime">Appointment Time</label>
                    <asp:TextBox ID="txtAppointmentTime" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtReason">Reason for Visit</label>
                    <asp:TextBox ID="txtReason" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <asp:Button ID="btnCreate" runat="server" Text="Create Appointment" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
            </div>
        </div>
    </div>
</asp:Content>


