<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePatient.aspx.cs" Inherits="Hospital_Management_OPD.UpdatePatient" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="my-4">Update Patient</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
       <table>
            <tr>
                <td>Patient ID:</td>
                <td><asp:Label ID="lblPatientIDValue" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Date of Birth:</td>
                <td><asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Gender:</td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server">
                        <asp:ListItem Text="Select" Value="" />
                        <asp:ListItem Text="Male" Value="Male" />
                        <asp:ListItem Text="Female" Value="Female" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Phone Number:</td>
                <td><asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Address:</td>
                <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Emergency Contact:</td>
                <td><asp:TextBox ID="txtEmergencyContact" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Blood Group:</td>
                <td>
                    <asp:DropDownList ID="ddlBloodGroup" runat="server">
                        <asp:ListItem Text="Select" Value="" />
                        <asp:ListItem Text="A+" Value="A+" />
                        <asp:ListItem Text="A-" Value="A-" />
                        <asp:ListItem Text="B+" Value="B+" />
                        <asp:ListItem Text="B-" Value="B-" />
                        <asp:ListItem Text="O+" Value="O+" />
                        <asp:ListItem Text="O-" Value="O-" />
                        <asp:ListItem Text="AB+" Value="AB+" />
                        <asp:ListItem Text="AB-" Value="AB-" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnUpdate_Click" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>


