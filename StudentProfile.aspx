<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentProfile.aspx.cs" Inherits="StudentProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>Profile</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
      <script src="js/html5shiv.js"></script>
      <script src="js/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>

  <section id="container" class="">
      <!--header start-->
      <header class="header white-bg">
          <div class="sidebar-toggle-box">
              <div data-original-title="Toggle Navigation" data-placement="right" class="fa fa-bars tooltips"></div>
          </div>
          <!--logo start-->
          <a href="StudentDashboard.aspx" class="logo" >e<span>Supervisor</span></a>
          <!--logo end-->
          
          <div class="top-nav ">
              <ul class="nav pull-right top-menu">
                  
                  <!-- user login dropdown start-->
                  <li class="dropdown">
                      <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                          <span class="username">Welcome , <%=userID %></span>
                      </a>
                  </li>
                  <!-- user login dropdown end -->
              </ul>
          </div>
      </header>
      <!--header end-->
      <!--sidebar start-->
      <aside>
          <div id="sidebar"  class="nav-collapse ">
              <!-- sidebar menu start-->
              <ul class="sidebar-menu" id="nav-accordion">
                  <li>
                      <a href="StudentDashboard.aspx">
                          <i class="fa fa-dashboard"></i>
                          <span>Dashboard</span>
                      </a>
                  </li>
                  <li>
                      <a href="StudentProfile.aspx" class="active">
                          <i class="fa fa-user"></i>
                          <span>Profile</span>
                      </a>
                  </li>
                  <li>
                      <a href="StudentMeetings.aspx">
                          <i class="fa fa-users"></i>
                          <span>Meetings</span>
                      </a>
                  </li>
                  <li>
                      <a href="StudentDocuments.aspx">
                          <i class="fa fa-folder"></i>
                          <span>Documents</span>
                      </a>
                  </li>
                  <li>
                      <a href="StudentMessagings.aspx">
                          <i class="fa fa-envelope"></i>
                          <span>Messaging</span>
                      </a>
                  </li>
                  <li>
                      <a href="StudentBloging.aspx">
                          <i class="fa fa-file-text"></i>
                          <span>Blogging</span>
                      </a>
                  </li>
                  <li>
                      <a href="Login.aspx?action=logout">
                          <i class="fa fa-power-off"></i>
                          <span>Log Out</span>
                      </a>
                  </li>
              </ul>
              <!-- sidebar menu end-->
          </div>
      </aside>
      <!--sidebar end-->
      <!--main content start-->
      <section id="main-content">
          <section class="wrapper">
              <!-- page start-->
              <div class="row">
                  <aside class="profile-nav col-lg-3">
                      <section class="panel">
                          <div class="user-heading round">
                              <a href="#">
                                  <img src="Uploads/Avatars/<%=Tbl_Student.StudentAvatar %>" alt=""/>
                              </a>
                              <h1><%=Tbl_Student.StudentName %></h1>
                              <p><%=Tbl_Student.StudentMailAddr %></p>
                          </div>

                          <ul class="nav nav-pills nav-stacked">
                              <li class="active"><a href="StudentProfile.aspx"> <i class="fa fa-user"></i> Profile</a></li>
                              <li><a href="StudentProfileEdit.aspx"> <i class="fa fa-edit"></i> Edit Profile</a></li>
                             
                          </ul>

                      </section>
                  </aside>
                  <aside class="profile-info col-lg-9">
                      <section class="panel">
                          <div class="bio-graph-heading">
                              Student's Infomation
                          </div>
                          <div class="panel-body bio-graph-info">
                              <h1>Student</h1>
                              <div class="row">
                                  <div class="bio-row">
                                      <p><span>Student ID </span>: <%=Tbl_Student.StudentID %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Academic Year</span>: <%=Tbl_Student.StudentAcademicYear %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Full Name </span>: <%=Tbl_Student.StudentName %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Birthday</span>:<%=Tbl_Student.StudentBirth.ToShortDateString() %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Email </span>:<%=Tbl_Student.StudentMailAddr %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Mobile </span>: <%=Tbl_Student.StudentPhone %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Address </span>: <%=Tbl_Student.StudentAddr %></p>
                                  </div>
                              </div>
                          </div>
                      </section>
                  </aside>
              </div>

              <!-- page end-->
          </section>
      </section>
      <!--main content end-->
      <!--footer start-->
      <footer class="site-footer">
          <div class="text-center">
              2013 &copy; FlatLab by VectorLab.
              <a href="#" class="go-top">
                  <i class="fa fa-angle-up"></i>
              </a>
          </div>
      </footer>
      <!--footer end-->
  </section>

    <!-- js placed at the end of the document so the pages load faster -->
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="assets/jquery-knob/js/jquery.knob.js"></script>
    <script src="js/respond.min.js" ></script>

    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>

  <script>

      //knob
      $(".knob").knob();

  </script>


</body>
</html>
