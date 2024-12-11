<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateDSession.aspx.cs" Inherits="Hospital_Management_OPD.UpdateDSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center">Manage Doctor Sessions</h2>

        <div class="form-group">
            <label for="ddlDoctors">Select Doctor</label>
            <asp:DropDownList ID="ddlDoctors" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctors_SelectedIndexChanged">
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

        <div class="form-group">
            <label for="ddlAttendanceStatus">Attendance Status</label>
            <asp:DropDownList ID="ddlAttendanceStatus" runat="server" CssClass="form-control">
                <asp:ListItem Text="Present" Value="1" />
                <asp:ListItem Text="Absent" Value="0" />
            </asp:DropDownList>
        </div>

        <asp:Button ID="btnAddSession" runat="server" Text="Add Session" CssClass="btn btn-success" OnClick="btnAddSession_Click" />
        <asp:Button ID="btnViewSession" runat="server" Text="View Session" CssClass="btn btn-success" OnClick="btnViewSession_Click" />
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3" Visible="false"></asp:Label>

        <hr />

        <h4>Current Sessions</h4>
        
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvSessions" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="gvSessions_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="session_date" HeaderText="Date" />
                        <asp:BoundField DataField="session_time" HeaderText="Time" />
                        <asp:TemplateField HeaderText="Attendance">
                            <ItemTemplate>
                                <%# Convert.ToBoolean(Eval("is_present")) ? "Present" : "Absent" %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnToggleAttendance" runat="server" CommandName="ToggleAttendance" CommandArgument='<%# Eval("session_id") %>' Text="Toggle" CssClass="btn btn-warning" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteSession" runat="server" CommandName="DeleteSession" CommandArgument='<%# Eval("session_id") %>' Text="Delete" CssClass="btn btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="alert alert-info">No sessions available for the selected doctor.</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
