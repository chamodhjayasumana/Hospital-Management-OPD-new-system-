<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hospital_Management_OPD._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="container-fluid bg-primary text-white text-center py-5">
        <h1>Welcome to the Hospital Management System</h1>
        <p>Your health, our priority.</p>
    </div>

    <!-- Carousel Section -->
    <div id="hospitalCarousel" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#hospitalCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#hospitalCarousel" data-slide-to="1"></li>
            <li data-target="#hospitalCarousel" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://images.unsplash.com/photo-1576091160501-bbe57469278b" class="d-block w-100" alt="Hospital Facility">
                <div class="carousel-caption d-none d-md-block">
                    <h5>State-of-the-Art Facility</h5>
                    <p>Modern healthcare with the latest technology.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="/Images/img1.jpg" class="d-block w-100" alt="Doctors Team">
                <div class="carousel-caption d-none d-md-block">
                    <h5>Experienced Medical Team</h5>
                    <p>Our dedicated team of doctors and nurses is here for you.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="/Images/img2.jpg" class="d-block w-100" alt="Patient Care">
                <div class="carousel-caption d-none d-md-block">
                    <h5>Patient Care Excellence</h5>
                    <p>Compassionate care for all your health needs.</p>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#hospitalCarousel" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#hospitalCarousel" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <!-- Hospital Services Section -->
    <div class="container py-5">
        <h2 class="text-center mb-5">Our Services</h2>
        <div class="row">
            <!-- Emergency Services -->
            <div class="col-md-4">
                <div class="card">
                    <img src="https://images.unsplash.com/photo-1532938911079-1b06ac7ceec7" class="card-img-top" alt="Emergency Services">
                    <div class="card-body">
                        <h5 class="card-title">Emergency Services</h5>
                        <p class="card-text">Quick and reliable emergency care when you need it the most.</p>
                    </div>
                </div>
            </div>
            <!-- Diagnostic Equipment -->
            <div class="col-md-4">
                <div class="card">
                    <img src="/Images/img3.jpg" class="card-img-top" alt="Diagnostic Equipment">
                    <div class="card-body">
                        <h5 class="card-title">Diagnostic Equipment</h5>
                        <p class="card-text">Advanced diagnostic tools for accurate health assessments.</p>
                    </div>
                </div>
            </div>
            <!-- Comprehensive Care -->
            <div class="col-md-4">
                <div class="card">
                    <img src="https://images.unsplash.com/photo-1526256262350-7da7584cf5eb" class="card-img-top" alt="Comprehensive Care">
                    <div class="card-body">
                        <h5 class="card-title">Comprehensive Care</h5>
                        <p class="card-text">Complete care for your well-being, from diagnosis to recovery.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
