<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPatients.aspx.cs" Inherits="Hospital_Management_OPD.ViewPatients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="my-4">Patient List</h2>
    <!-- Search Bar Section -->
    <div class="form-group">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by Name, Phone, or Email"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mt-2" OnClick="btnSearch_Click" />
    </div>

    <asp:GridView ID="gvPatients" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="patient_id" OnRowCommand="gvPatients_RowCommand">
        <Columns>
            <asp:BoundField DataField="patient_id" HeaderText="Patient ID" />
            <asp:BoundField DataField="first_name" HeaderText="First Name" />
            <asp:BoundField DataField="last_name" HeaderText="Last Name" />
            <asp:BoundField DataField="date_of_birth" HeaderText="DOB" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="gender" HeaderText="Gender" />
            <asp:BoundField DataField="phone_number" HeaderText="Phone" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="blood_group" HeaderText="Blood Group" />
            <asp:ButtonField ButtonType="Button" CommandName="UpdatePatient" Text="Update" ControlStyle-CssClass="btn btn-primary btn-sm" />
            <asp:ButtonField ButtonType="Button" CommandName="ViewAppointment" Text="Appointment" ControlStyle-CssClass="btn btn-primary btn-sm" />
            <asp:ButtonField ButtonType="Button" CommandName="PatientMedicalRecords" Text="Medical Records" ControlStyle-CssClass="btn btn-danger  btn-sm" />

        </Columns>
    </asp:GridView>
    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
</asp:Content>





