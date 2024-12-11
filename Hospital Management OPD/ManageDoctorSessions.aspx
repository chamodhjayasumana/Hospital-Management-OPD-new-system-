<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDoctorSessions.aspx.cs" Inherits="Hospital_Management_OPD.ManageDoctorSessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center">Manage Doctor Sessions</h2>

        
        <div class="form-group">
            <label for="ddlDoctors">Select Doctor</label>
            <asp:DropDownList ID="ddlDoctors" runat="server" CssClass="form-control" AutoPostBack="true" >
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtSessionDate">Session Date</label>
            <asp:TextBox ID="txtSessionDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlSessionTime">Session Time</label>
            <asp:DropDownList ID="ddlSessionTime" runat="server" CssClass="form-control">
                <asp:ListItem Text="Morning" Value="Morning"></asp:ListItem>
                <asp:ListItem Text="Afternoon" Value="Afternoon"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <!-- Mark Attendance -->
        <asp:Button ID="btnMarkAttendance" runat="server" CssClass="btn btn-primary" Text="Mark Attendance" OnClick="btnMarkAttendance_Click" />

        <!-- Message -->
        <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 text-danger" Visible="false"></asp:Label>

        <hr />

        <!-- Doctor Sessions -->
        <h3 class="text-center">Doctor Sessions</h3>
        <asp:GridView ID="gvDoctorSessions" runat="server" CssClass="table mt-3" AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:BoundField DataField="first_name" HeaderText="Doctor Name" />
                <asp:BoundField DataField="session_date" HeaderText="Session Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="session_time" HeaderText="Session Time" />
                <asp:BoundField DataField="is_present" HeaderText="Present" />
                <asp:BoundField DataField="appointment_count" HeaderText="Appointments" />
             
               
                
            </Columns>


        </asp:GridView>

        

    </div>
</asp:Content>





