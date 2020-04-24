<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentMeetings.aspx.cs" Inherits="StudentMeetings" %>

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
                      <a href="StudentMeetings.aspx" class="active">
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
          <section class="wrapper site-min-height">
              <!-- page start-->
              <div class="chat-room">                  
                  <aside class="mid-side">
                    <div class="chat-room-head">
                      <h3>Meetings</h3>
                    </div>
                    <div class="room-desk">
                      <h4>meetings list</h4>
                     <div class="adv-table">
                            <table  class="display table table-bordered table-striped" id="example">
                                      <thead>
                                      <tr>
                                          <th>No</th>
                                          <th>Meeting ID</th>
                                          <th>Meeting Topic</th>
                                          <th>Meeting Type</th>
                                          <th>Valid Date</th>                                          
                                          <th>Meeting Place</th>
                                          <th>Meeting Host</th>
                                          <th>Status</th>
                                          <th>Function</th>
                                      </tr>
                                      </thead>
                                      <tbody>
                                          <% int No = 0,tStt;
                                             Boolean tType;
                                             string mType = "", mStt = "", mHost = "";
                                              foreach (System.Data.DataRow dtRow in tblStuMeetings.Rows){ 
                                                  tStt = Convert.ToInt32(dtRow[5].ToString().Trim());
                                                  tType =Convert.ToBoolean(dtRow[2].ToString().Trim());
                                                  if(tStt ==1){
                                                      mStt="Schedueled/Joinable";
                                                  }else if(tStt ==2){
                                                      mStt="Occured/ReadOnly";
                                                  }
                                                  if(tType == true){
                                                      mType="Online";
                                                  }else if(tType ==false){
                                                      mType="Offline";
                                                  }
                                                  mHost = DaoStaff.GetStaffNameByID(dtRow[6].ToString());
                                                  %>
                                      <tr>
                                          <td><%=No %></td>
                                          <td><%=dtRow[0].ToString() %></td>
                                          <td><%=dtRow[1].ToString() %></td>
                                          <td><%=mType %></td>
                                          <td><%=Convert.ToDateTime(dtRow[3].ToString()).ToShortDateString() %></td>
                                          <td><%=dtRow[4].ToString() %></td>
                                          <td><%=mHost%></td>
                                          <td><%=mStt %></td>
                                          <%if(tType){ %>
                                          <td><a class="btn btn-info btn-xs" href="StudentMyMeeting.aspx?meetingID=<%=dtRow[0].ToString() %>">Join/Read</a>
                                          <%} %>
                                      </tr><%
                                                  No++;
                                           } %>
                                      </tbody>
                                      <tfoot>
                                      <tr>
                                         <th>No</th>
                                          <th>Meeting ID</th>
                                          <th>Meeting Topic</th>
                                          <th>Meeting Type</th>
                                          <th>Valid Date</th>                                          
                                          <th>Meeting Place</th>                                          
                                          <th>Meeting Host</th>
                                          <th>Status</th>
                                          <th>Function</th>
                                      </tr>
                                      </tfoot>
                          </table>
                        </div>         
                    </div>
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
    <script src="js/respond.min.js" ></script>

    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>

      <script type="text/javascript" charset="utf-8">
          $(document).ready(function () {
              $('#example').dataTable({
                  "aaSorting": [[4, "desc"]]
              });
          });
      </script>

  </body>
</html>
