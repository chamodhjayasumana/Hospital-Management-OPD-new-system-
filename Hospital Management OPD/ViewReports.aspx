<%@ Page Title="Patient Summary Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="Hospital_Management_OPD.ViewReports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px;">
        <h2>Patient Summary Report</h2>
        <div style="margin-bottom: 10px;">
            <label for="txtPatientID">Enter Patient ID:</label>
            <asp:TextBox 
                ID="txtPatientID" 
                runat="server" 
                CssClass="form-control" 
                placeholder="Enter Patient ID" 
                style="width: 300px; display: inline-block; margin-right: 10px;">
            </asp:TextBox>
            <asp:Button 
                ID="btnLoadReport" 
                runat="server" 
                Text="Load Report" 
                CssClass="btn btn-primary" 
                OnClick="btnLoadReport_Click" />
        </div>

        <!-- ReportViewer to display the SSRS report -->
        <rsweb:ReportViewer 
            ID="ReportViewer1" 
            runat="server" 
            Width="100%" 
            Height="600px" 
            ProcessingMode="Remote">
        </rsweb:ReportViewer>
    </div>
</asp:Content>
