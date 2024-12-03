<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="Hospital_Management_OPD.AddPatient" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
         <!-- Message Label -->
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" />

        <h2>Add New Patient</h2>

        <!-- First Name -->
        <label for="txtFirstName">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="RequiredFirstName" ControlToValidate="txtFirstName"
            ErrorMessage="First name is required." runat="server" ForeColor="Red" /><br />

        <!-- Last Name -->
        <label for="txtLastName">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="RequiredLastName" ControlToValidate="txtLastName"
            ErrorMessage="Last name is required." runat="server" ForeColor="Red" /><br />



        <!-- Date of Birth -->
        <label for="txtDOB">Date of Birth:</label>
        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date" />
        <asp:RequiredFieldValidator ID="RequiredDateOfBirth" ControlToValidate="txtDOB"
            ErrorMessage="Date of birth is required." runat="server" ForeColor="Red" />
        <asp:RegularExpressionValidator ID="ValidDateOfBirth" ControlToValidate="txtDOB"
            ErrorMessage="Invalid date format (e.g., yyyy-mm-dd)." ValidationExpression="^\d{4}-\d{2}-\d{2}$"
            runat="server" ForeColor="Red" /><br />

        <!-- Gender -->
        <label for="ddlGender">Gender:</label>
        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
            <asp:ListItem Text="Select Gender" Value="" />
            <asp:ListItem Text="Male" Value="Male" />
            <asp:ListItem Text="Female" Value="Female" />
            <asp:ListItem Text="Other" Value="Other" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredGender" ControlToValidate="ddlGender"
            InitialValue="" ErrorMessage="Gender is required." runat="server" ForeColor="Red" /><br />

        <!-- Phone Number -->
        <label for="txtPhoneNumber">Phone Number:</label>
        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="RequiredPhoneNumber" ControlToValidate="txtPhoneNumber"
            ErrorMessage="Phone number is required." runat="server" ForeColor="Red" />
        <asp:RegularExpressionValidator ID="ValidPhoneNumber" ControlToValidate="txtPhoneNumber"
            ErrorMessage="Invalid phone number format." ValidationExpression="^\d{10}$"
            runat="server" ForeColor="Red" /><br />

        <!-- Email -->
        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ID="ValidEmail" ControlToValidate="txtEmail"
            ErrorMessage="Invalid email format." ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
            runat="server" ForeColor="Red" /><br />

        <!-- Address -->
        <label for="txtAddress">Address:</label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" /><br />

        <!-- Emergency Contact -->
        <label for="txtEmergencyContact">Emergency Contact:</label>
        <asp:TextBox ID="txtEmergencyContact" runat="server" CssClass="form-control" /><br />

        <!-- Blood Group -->
        <label for="ddlBloodGroup">Blood Group:</label>
        <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="form-control">
            <asp:ListItem Text="Select Blood Group" Value="" />
            <asp:ListItem Text="A+" Value="A+" />
            <asp:ListItem Text="A-" Value="A-" />
            <asp:ListItem Text="B+" Value="B+" />
            <asp:ListItem Text="B-" Value="B-" />
            <asp:ListItem Text="AB+" Value="AB+" />
            <asp:ListItem Text="AB-" Value="AB-" />
            <asp:ListItem Text="O+" Value="O+" />
            <asp:ListItem Text="O-" Value="O-" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredBloodGroup" ControlToValidate="ddlBloodGroup"
            InitialValue="" ErrorMessage="Blood group is required." runat="server" ForeColor="Red" /><br />

        <!-- Submit Button -->
        <asp:Button ID="Button1" runat="server" Text="Add Patient" CssClass="btn btn-primary" OnClick="btnSubmit_Click" /><br />


    </div>
</asp:Content>
