<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="Hospital_Management_OPD.ViewAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Patient Appointments</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>

        <asp:GridView ID="gvAppointments" runat="server" CssClass="table table-bordered mt-3" AutoGenerateColumns="False" DataKeyNames="appointment_id">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="appointment_id" HeaderText="Appointment ID" />
                <asp:BoundField DataField="appointment_date" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                <asp:BoundField DataField="reason_for_visit" HeaderText="Reason for Visit" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="doctor_name" HeaderText="Doctor" />
            </Columns>
        </asp:GridView>

        
        <asp:Button ID="btnAddMedicalRecord" runat="server" Text="Add Medical Record" CssClass="btn btn-primary mt-3" OnClick="btnAddMedicalRecord_Click" />
        <asp:Button ID="btnAddAppointment" runat="server" Text="Add Appointment" CssClass="btn btn-primary mt-3" OnClick="btnAddAppointment_Click" />


    </div>
</asp:Content>
