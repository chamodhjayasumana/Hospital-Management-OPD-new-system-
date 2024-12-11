<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewDahboard.aspx.cs" Inherits="Hospital_Management_OPD.NewDahboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2 style="text-align: center; margin-bottom: 20px; color: #007bff;">Doctor Dashboard</h2>

    <style>
        .doctor-container { display: flex; flex-wrap: wrap; gap: 25px; justify-content: center; padding: 20px; }
        .doctor-box { border: 2px solid #007bff; padding: 20px; width: 300px; border-radius: 15px; background-color: #fff; box-shadow: 0 8px 16px rgba(0, 0, 0, 0.15); text-align: center; transition: transform 0.3s; }
        .doctor-box:hover { transform: translateY(-5px); }
        .doctor-box h3 { color: #007bff; margin-bottom: 10px; }
        .appointment-box { border: 1px solid #ddd; padding: 10px; margin: 8px 0; border-radius: 8px; background-color: #f7f7f7; text-align: left; }
        .appointment-box strong { color: #333; }
    </style>

    <!-- Date Filter -->
    <div style="text-align: center; margin-bottom: 20px;">
        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Style="display: inline-block; width: 200px;" Text='<%# DateTime.Now.ToString("yyyy-MM-dd") %>' />
        <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnFilter_Click" />
    </div>

    <!-- Doctor List -->
    <div class="doctor-container">
        <asp:Repeater ID="rptDoctors" runat="server" OnItemDataBound="rptDoctors_ItemDataBound">
            <ItemTemplate>
                <div class="doctor-box">
                    <h3><%# Eval("first_name") + " " + Eval("last_name") %></h3>
                    <p><strong>Department:</strong> <%# Eval("department_name") %></p>

                    <!-- Appointments -->
                    <asp:Repeater ID="rptAppointments" runat="server">
                        <HeaderTemplate>
                            <h4 style="color: #555;">Appointments:</h4>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="appointment-box">
                                <p><strong>Patient:</strong> <%# Eval("patient_name") %></p>
                                <p><strong>Reason:</strong> <%# Eval("reason_for_visit") %></p>
                                <p><strong>Date:</strong> <%# Convert.ToDateTime(Eval("appointment_date")).ToString("MMM dd, yyyy") %></p>
                                <p><strong>Status:</strong> <%# Eval("status") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
