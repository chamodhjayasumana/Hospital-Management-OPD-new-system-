<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBilling.aspx.cs" Inherits="Hospital_Management_OPD.ViewBilling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container mt-5">
        <h2 class="text-center">Billing Details</h2>
        
        <!-- Search/Filter Section -->
        <div class="row mb-3">
            <div class="col-md-4">
                <asp:TextBox ID="txtSearchPatient" runat="server" CssClass="form-control" Placeholder="Search by Patient Name"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlPaymentStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Text="All" Value=""></asp:ListItem>
                    <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
            </div>
        </div>

        <!-- GridView to Display Billing Records -->
        <asp:GridView ID="gvBilling" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvBilling_RowCommand">
            <Columns>
                <asp:BoundField DataField="bill_id" HeaderText="Bill ID" />
                <asp:BoundField DataField="patient_name" HeaderText="Patient Name" />
                <asp:BoundField DataField="appointment_date" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:C}" />
                <asp:BoundField DataField="payment_status" HeaderText="Status" />
                <asp:BoundField DataField="payment_method" HeaderText="Payment Method" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnDetails" runat="server" Text="Details" CommandName="ViewDetails" CommandArgument='<%# Eval("bill_id") %>' CssClass="btn btn-info btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
