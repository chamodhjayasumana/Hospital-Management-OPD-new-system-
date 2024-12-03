<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMedicalRecords.aspx.cs" Inherits="Hospital_Management_OPD.ViewMedicalRecords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Medical Records</h2>
        <asp:GridView ID="gvMedicalRecords" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowCommand="gvMedicalRecords_RowCommand" DataKeyNames="record_id">
            <Columns>
                <asp:BoundField DataField="record_id" HeaderText="Record ID" />
                <asp:BoundField DataField="patient_name" HeaderText="Patient Name" />
                <asp:BoundField DataField="doctor_name" HeaderText="Doctor Name" />
                <asp:BoundField DataField="visit_date" HeaderText="Visit Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="diagnosis" HeaderText="Diagnosis" />
                <asp:BoundField DataField="prescribed_treatment" HeaderText="Treatment" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateRecord" CommandArgument='<%# Eval("record_id") %>' CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("record_id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
    </div>
</asp:Content>
