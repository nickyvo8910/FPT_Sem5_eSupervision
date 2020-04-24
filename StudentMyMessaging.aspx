<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentMyMessaging.aspx.cs" Inherits="StudentMyMessaging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>chat room </title>

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
      <form runat="server">
      <section id="main-content">
          <section class="wrapper site-min-height">
              <!-- page start-->
             <div class="chat-room" style="background-color:whitesmoke">
                  <div class="adv-table">
                      <div class="chat-room-head">
                          <h3>Personal Conversation</h3>
                      </div>
                      <div class="room-desk2">
                          <a href="StudentMessagings.aspx"><button type="button" class="btn btn-default">Back To Messagings</button></a>
                        <hr /> 
                          <asp:Panel ID="pnl" runat ="server" Height="200" Width="100%" ScrollBars ="vertical">
                              <%foreach(System.Data.DataRow dtRow in tblConversation.Rows){ %>
                          <div class="group-rom">
                              <div class="first-part odd"><%=Convert.ToDateTime(dtRow[0].ToString()).ToShortDateString() %></div>
                              <div class="second-part" style="background-color:white"><%=dtRow[1].ToString() %></div>
                              <div class="third-part"><%=Convert.ToDateTime(dtRow[0].ToString()).ToShortTimeString() %></div>
                          </div><%} %>
                              </asp:Panel>
                      </div>
                      
                  </div>
                    <footer>
                          <div class="chat-txt">
                              <asp:TextBox ID="txtMessInfo" runat="server" CssClass="form-control" MaxLength="300"></asp:TextBox>
                          </div>
                          <div class="btn-group">
                               <asp:LinkButton ID="btnSend" runat="server" class="btn btn-danger" OnClick="btnSend_Click">Send</asp:LinkButton> 
                          </div>
                      </footer>
              </div>
              <!-- page end-->
          </section>
      </section>
          </form>
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
      <script type="text/javascript">
          window.onload = function () {
              var objDiv = document.getElementById("<%=pnl.ClientID %>");
               objDiv.scrollTop = objDiv.scrollHeight;
           }
</script>

  </body>
</html>
