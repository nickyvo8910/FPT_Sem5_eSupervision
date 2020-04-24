<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffBloging.aspx.cs" Inherits="StaffBloging" enableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>FB Wall</title>

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
          <a href="StaffDashboard.aspx" class="logo" >e<span>Supervisor</span></a>
          <!--logo end-->
          
          <div class="top-nav ">
              <ul class="nav pull-right top-menu">
                  
                  <!-- user login dropdown start-->
                  <li class="dropdown">
                      <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                         <span class="username">Welcome , <%=UserId %></span>
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
                      <a href="StaffDashboard.aspx">
                          <i class="fa fa-dashboard"></i>
                          <span>Dashboard</span>
                      </a>
                  </li>
                  <li>
                      <a href="StaffProfile.aspx">
                          <i class="fa fa-user"></i>
                          <span>Profile</span>
                      </a>
                  </li>
                  <li>
                      <a href="StaffMeetings.aspx">
                          <i class="fa fa-users"></i>
                          <span>Meetings</span>
                      </a>
                  </li>
                  <li>
                      <a href="StaffDocuments.aspx">
                          <i class="fa fa-folder"></i>
                          <span>Documents</span>
                      </a>
                  </li>
                  <li>
                      <a href="StaffMessagings.aspx">
                          <i class="fa fa-envelope"></i>
                          <span>Messaging</span>
                      </a>
                  </li>
                  <li>
                      <a href="StaffBloging.aspx" class="active">
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
          <section class="wrapper site-min-height">
              <!-- page start-->
              <form runat="server">
              <div class="row">
                  <div class="col-md-12">
                      <section class="panel">
                          <div class="cover-photo">
                              <div class="fb-timeline-img">
                                  <img src="img/fb-img.jpg" alt="">
                              </div>
                              <div class="fb-name">
                                  <h2><a href="#"><%=TblCrrStaff.StaffName %></a></h2>
                              </div>
                          </div>
                          <div class="panel-body">
                              <div class="profile-thumb">
                                  <img src="Uploads/Avatars/<%=TblCrrStaff.StaffAvatar %>" alt="">
                              </div>
                              <a href="#" class="fb-user-mail"><%=TblCrrStaff.StaffMailAddr %></a>
                          </div>
                      </section>

                      <section class="panel profile-info">
                          
                              <asp:TextBox TextMode="MultiLine" class="form-control input-lg p-text-area" rows="2" placeholder="Whats in your mind today?" ID ="txtPostInfo" runat="server"></asp:TextBox>
                          
                          <footer class="panel-footer">
                              <asp:LinkButton runat="server" ID="btnSend" class="btn btn-danger pull-right" OnClick="btnSend_Click" CausesValidation="False">Post</asp:LinkButton>
                              <ul class="nav nav-pills"></ul>
                          </footer>
                      </section>
                      <%foreach (System.Data.DataRow dtRow in TblAllPost.Rows){ %>
                      <section class="panel">
                          
                          <div class="panel-body">
                              <div class="fb-user-thumb">
                                  <img src="Uploads/Avatars/<%=TblCrrStaff.StaffAvatar %>" alt="">
                              </div>
                              <div class="fb-user-details">
                                  <h3><a href="#" class="#"><%=TblCrrStaff.StaffName %></a></h3>
                                  <p><%=dtRow[1].ToString()%></p>
                              </div>
                              <div class="clearfix"></div>
                              <p class="fb-user-status"><%=dtRow[2].ToString() %>
                              </p>
                              
                              <div class="pull-right">                                  
                                  <a href="StaffBloging.aspx?action=Delete&&postID=<%=dtRow[0].ToString() %>" class="btn btn-danger" type="submit">Delete</a>
                              </div>
                              	
                              
                          </div>
                          
                      </section>
                    <%} %>
                  </div>
                  
              </div>
                  </form>
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
    <script src="js/respond.min.js" ></script>

    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>


  </body>
</html>
