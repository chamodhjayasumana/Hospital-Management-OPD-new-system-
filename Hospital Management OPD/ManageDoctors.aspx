<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDoctors.aspx.cs"  Inherits="Hospital_Management_OPD.ManageDoctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manage Doctors</h2>

        
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>

        <!-- Doctor Form -->
        <div class="row mb-4">
            <div class="col-md-6">
                <h4>Add New Doctor</h4>

                <div class="form-group">
                    <label>First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Specialization</label>
                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Phone Number</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Department</label>
                    <asp:DropDownList ID="ddlDepartments" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <asp:Button ID="btnInsert" runat="server" Text="Add Doctor" CssClass="btn btn-primary mt-3" OnClick="btnInsert_Click" />
            </div>
        </div>

        <!-- Doctor List -->
        <h4>Doctor List</h4>
        <asp:GridView ID="gvDoctors" runat="server" DataKeyNames="doctor_id" CssClass="table table-bordered mt-3" AutoGenerateColumns="False" OnRowCommand="gvDoctors_RowCommand">
            <Columns>
                <asp:BoundField DataField="doctor_id" HeaderText="ID" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                <asp:BoundField DataField="specialization" HeaderText="Specialization" />
                <asp:BoundField DataField="department_name" HeaderText="Department" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                            CommandName="UpdateDoctor" CommandArgument='<%# Eval("doctor_id") %>' 
                            CssClass="btn btn-warning btn-sm" /> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>

