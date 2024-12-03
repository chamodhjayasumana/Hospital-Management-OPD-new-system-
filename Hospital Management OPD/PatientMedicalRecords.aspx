<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMedicalRecords.aspx.cs" Inherits="Hospital_Management_OPD.PatientMedicalRecords" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Medical Records for Patient: <asp:Label ID="lblPatientName" runat="server" /></h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>

        <asp:GridView ID="gvMedicalRecords" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="visit_date" HeaderText="Visit Date" />
                <asp:BoundField DataField="doctor_name" HeaderText="Doctor" />
                <asp:BoundField DataField="diagnosis" HeaderText="Diagnosis" />
                <asp:BoundField DataField="prescribed_treatment" HeaderText="Treatment" />
                
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <!-- Update Button -->
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateRecord" CommandArgument='<%# Eval("record_id") %>' CssClass="btn btn-warning btn-sm"   />

                        <!-- Delete Button -->
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("record_id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>