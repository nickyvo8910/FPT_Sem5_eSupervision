<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerProfile.aspx.cs" Inherits="ManagerProfile" %>

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
          <a href="ManagerDashboard.aspx" class="logo" >e<span>Supervisor</span></a>
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
                      <a href="ManagerDashboard.aspx">
                          <i class="fa fa-dashboard"></i>
                          <span>Dashboard</span>
                      </a>
                  </li>
                  <li>
                      <a href="ManagerProfile.aspx" class="active">
                          <i class="fa fa-user"></i>
                          <span>Profile</span>
                      </a>
                  </li>
                  <li class="sub-menu">
                      <a href="javascript:;">
                          <i class="fa fa-laptop"></i>
                          <span>Manage</span>
                      </a>
                      <ul class="sub">
                          <li><a  href="ManagingStaff.aspx">Managing Staff</a></li>
                          <li><a  href="ManagingStudents.aspx">Managing Students</a></li>
                      </ul>
                  </li>
					<li class="sub-menu">
                      <a href="javascript:;">
                          <i class="fa fa-plus"></i>
                          <span>Assigns</span>
                      </a>
                      <ul class="sub">
                          <li><a  href="StaffAllocation.aspx?action=setSuper">Assigns Supervisor</a></li>
                          <li><a  href="StaffAllocation.aspx?action=setSecond">Assigns Second Markers</a></li>
                      </ul>
                  </li>
                  
                  <li>
                      <a href="ManagerReport.aspx">
                          <i class="fa fa-bar-chart-o"></i>
                          <span>Report</span>
                      </a>
                  </li>
                  <li>
                      <a href="Login.aspx">
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
                                  <img src="Uploads/Avatars/<%=staffInfo[3].ToString()%>" alt="">
                              </a>
                              <h1><%=staffInfo[1].ToString() %></h1>
                              <p><%=staffInfo[2].ToString() %></p>
                          </div>

                          <ul class="nav nav-pills nav-stacked">
                              <li class="active"><a href="ManagerProfile.aspx"> <i class="fa fa-user"></i> Profile</a></li>
                              <li><a href="ManagerProfileEdit.aspx"> <i class="fa fa-edit"></i> Edit Profile</a></li>
                             
                          </ul>

                      </section>
                  </aside>
                  <aside class="profile-info col-lg-9">
                      <section class="panel">
                          <div class="bio-graph-heading">Staff's Infomation</div>
                          <div class="panel-body bio-graph-info">
                              <h1>Manager</h1>
                              <div class="row">
                                  <div class="bio-row">
                                      <p><span>Staff ID </span>: <%=staffInfo[0].ToString() %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Staff Authority </span>: <% switch (staffInfo[7].ToString())
                                                                     {
                                                                         case "2":
                                                                             {
                                                                                 %>"Staff/Falcuty"<%
                                                                             }break;
                                                                         case "3":
                                                                             {
                                                                                 %>Manager<%
                                                                             }break;
                                                                         default:{                                                                                 
                                                                                 %>"Staff/Falcuty"<%
                                                                             }break;
                                                                     }
                                                                       %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Full Name </span>: <%=staffInfo[1].ToString() %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Birthday</span>: <%=staffInfo[4].ToString().Substring(0,10) %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Email </span>: <%=staffInfo[2].ToString() %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Mobile </span>: <%=staffInfo[6].ToString() %></p>
                                  </div>
                                  <div class="bio-row">
                                      <p><span>Address </span>: <%=staffInfo[5].ToString() %></p>
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
