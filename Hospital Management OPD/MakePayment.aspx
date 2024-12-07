<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakePayment.aspx.cs" Inherits="Hospital_Management_OPD.MakePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container mt-5">
        <h2 class="text-center text-primary mb-4">Make Payment</h2>

        <!-- Payment Form -->
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-sm">
                    <div class="card-body">
                         <!-- Success/Error Message -->
                        <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 text-center" Visible="false"></asp:Label>
                        <form>
                            <!-- Patient Selection -->
                            <div class="form-group">
                                <label for="ddlPatients" class="font-weight-bold">Select Patient</label>
                                <asp:DropDownList ID="ddlPatients" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPatients_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <!-- Appointment Selection -->
                            <div class="form-group">
                                <label for="ddlAppointments" class="font-weight-bold">Select Appointment</label>
                                <asp:DropDownList ID="ddlAppointments" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <!-- Doctor Charges -->
                            <div class="form-group">
                                <label for="txtDoctorCharges" class="font-weight-bold">Doctor Charges</label>
                                <asp:TextBox ID="txtDoctorCharges" runat="server" CssClass="form-control" placeholder="Enter doctor charges"></asp:TextBox>
                            </div>

                            <!-- Hospital Charges -->
                            <div class="form-group">
                                <label for="txtHospitalCharges" class="font-weight-bold">Hospital Charges</label>
                                <asp:TextBox ID="txtHospitalCharges" runat="server" CssClass="form-control" placeholder="Enter hospital charges"></asp:TextBox>
                            </div>

                            <!-- Payment Method Selection -->
                            <div class="form-group">
                                <label for="ddlPaymentMethod" class="font-weight-bold">Payment Method</label>
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Cash" Value="Cash" />
                                    <asp:ListItem Text="Card" Value="Card" />
                                    <asp:ListItem Text="Online" Value="Online" />
                                </asp:DropDownList>
                            </div>

                            <!-- Payment Status Selection -->
                            <div class="form-group">
                                <label for="ddlpaymentStatus" class="font-weight-bold">Payment Status</label>
                                <asp:DropDownList ID="ddlpaymentStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Paid" Value="Paid" />
                                    <asp:ListItem Text="Pending" Value="Pending" />
                                    
                                </asp:DropDownList>
                            </div>

                            <!-- Submit Button -->
                            <div class="form-group">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit Payment" CssClass="btn btn-success btn-block" OnClick="btnSubmit_Click" />
                            </div>

                            <div class="form-group">
                                <asp:Button ID="btnViewBilling" runat="server" Text="View Billing Details" CssClass="btn btn-info btn-block" OnClick="btnViewBilling_Click" />
                            </div>
                        </form>

                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
