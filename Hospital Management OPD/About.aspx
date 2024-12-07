<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Hospital_Management_OPD.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" class="container py-5">
        <div class="text-center mb-4">
            <h2 id="title" class="display-4">About Our Hospital Management System</h2>
            <p class="lead">Committed to Excellence in Patient Care and Management</p>
        </div>
        
        <section class="mb-5">
            <h3>Our Mission</h3>
            <p>
                Our hospital management system is designed to streamline patient care, manage administrative tasks efficiently,
                and provide accurate data for informed decision-making. We aim to improve healthcare delivery through innovative technology.
            </p>
        </section>
        
        <section class="mb-5">
            <h3>Key Features</h3>
            <ul class="list-group">
                <li class="list-group-item">Efficient Patient Management</li>
                <li class="list-group-item">Doctor and Appointment Scheduling</li>
                <li class="list-group-item">Medical Records Management</li>
                <li class="list-group-item">Secure Admin and User Access</li>
                <li class="list-group-item">Detailed Reporting and Analytics</li>
            </ul>
        </section>
        
        <section class="mb-5">
            <h3>Why Choose Us?</h3>
            <p>
                Our system offers a user-friendly interface, comprehensive modules for different departments, and robust security.
                It helps healthcare providers focus more on patient care while we handle the rest.
            </p>
        </section>

        <section class="text-center">
            <h4>Contact Us</h4>
            <p>Email: support@hospitalmanagement.com | Phone: +1 (123) 456-7890</p>
        </section>
    </main>
</asp:Content>
