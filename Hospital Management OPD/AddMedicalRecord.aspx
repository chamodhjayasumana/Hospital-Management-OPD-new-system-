<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMedicalRecord.aspx.cs" Inherits="Hospital_Management_OPD.AddMedicalRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Add Medical Record</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>

        <!-- Form to Add Medical Record -->
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label>Appointment ID</label>
                    <asp:TextBox ID="txtAppointmentId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Patient ID</label>
                    <asp:TextBox ID="txtPatientId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Doctor ID</label>
                    <asp:TextBox ID="txtDoctorId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Visit Date</label>
                    <asp:TextBox ID="txtVisitDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Diagnosis</label>
                    <asp:TextBox ID="txtDiagnosis" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Prescribed Treatment</label>
                    <asp:TextBox ID="txtTreatment" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>

                <asp:Button ID="btnSave" runat="server" Text="Save Medical Record" CssClass="btn btn-primary mt-3" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
