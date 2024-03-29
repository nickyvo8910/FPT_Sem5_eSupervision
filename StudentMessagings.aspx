﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentMessagings.aspx.cs" Inherits="StudentMessagings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>Meeting</title>

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
                      <a href="StudentProfile.aspx">
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
                      <a href="StudentMessagings.aspx" class="active">
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
          <section class="wrapper site-min-height">
              <!-- page start-->
              <form runat="server" class="chat-room" >
                  <aside class="mid-side">
                    <div class="chat-room-head">
                      <h3>Messaging</h3>
                    </div>
                   <div class="room-desk">
                      <h4>messaging Conversations</h4>
                      <div class="adv-table" >
                          <asp:GridView ID="GridView1" runat="server" BorderStyle="None" style="width:100%" CssClass="table table-hover table-striped" AutoGenerateColumns="False">
                              <Columns>
                                  <asp:BoundField DataField="staffID" HeaderText="Staff ID" />
                                  <asp:BoundField DataField="staffName" HeaderText="Staff Name" />
                                  <asp:BoundField DataField="Total Mess" HeaderText="Total Message" />
                                  <asp:TemplateField HeaderText="Function">
                                      <ItemTemplate>
                                          <a class="btn btn-info btn-xs" href='StudentMyMessaging.aspx?staffID=<%#Eval("staffID")%>'>Join/Read</a>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
                          </asp:GridView>  
                      </div>
                    </div>
                  </aside>
                  <aside class="right-side">
                      <div class="user-head">
                      </div>
                      <div class="invite-row">
                          <h4 class="pull-left">Contacts List</h4>
                      </div>
                      <ul class="chat-available-user">
                          <li>
                               <a href="StudentMyMessaging.aspx?staffID=<%=crrStudent.StudentSupervisorID %>">
                                  <i class="fa fa-circle text-success"></i>
                                  Supervisor

                          </li>
                          <li>
                               <a href="StudentMyMessaging.aspx?staffID=<%=crrStudent.StudentSecondMarkerID %>">
                                  <i class="fa fa-circle text-success"></i>
                                  Second Maker

                          </li>
                      </ul>
                  </aside>
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
