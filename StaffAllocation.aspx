<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffAllocation.aspx.cs" Inherits="StaffAllocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>Blank</title>

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
                      <a href="ManagerProfile.aspx">
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
                      <a href="javascript:;" class="active">
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
              <div class="row">
                  <div class="col-lg-12">
                      <section class="panel">
                          <header class="panel-heading">
                              Staff Allocation
                          </header>
                          <form runat="server" class="panel-body">                          		
                                <div class="adv-table">
                                    <table  class="display table table-bordered table-striped" id="example">
                                      <thead>
                                      <tr>
                                          <th>No</th>
                                          <th>Staff ID</th>
                                          <th>Staff Name</th>
                                          <th>Staff Email</th>
                                          <th>Staff Birthday</th>                                          
                                          <th>Staff Phone</th>
                                          <th>Authority</th>
                                          <th>Function</th>
                                      </tr>
                                      </thead>
                                      <tbody>
                                          <% int No = 0;
                                             string authority = "";
                                              foreach (System.Data.DataRow dtRow in tblAllStaffs.Rows){
                                                  if (Convert.ToInt32(dtRow[4].ToString()) ==2) {
                                                      authority = "Teacher";
                                                   %>
                                      
                                          <tr>
                                          <td><%=No %></td>
                                          <td><%=dtRow[0].ToString() %></td>
                                          <td><%=dtRow[1].ToString() %></td>
                                          <td><%=dtRow[2].ToString() %></td>
                                          <td><%=Convert.ToDateTime(dtRow[3].ToString()).ToShortDateString() %></td>
                                          <td><%=dtRow[5].ToString() %></td>
                                          <td><%=authority %></td>
                                          <td><a href="StudentAllocation.aspx?action=<%=actionPasser%>&&staffID=<%=dtRow[0].ToString() %>"> <i class="fa fa-plus"></i>Assign</a></td>
                                      </tr>                                          
                                          <%                                              
                                                  No++;
                                                  } } %>
                                      </tbody>
                                      <tfoot>
                                      <tr>
                                          <th>No</th>
                                          <th>Staff ID</th>
                                          <th>Staff Name</th>
                                          <th>Staff Email</th>
                                          <th>Staff Birthday</th>
                                          <th>Staff Phone</th>
                                          <th>Authority</th>
                                          <th>Function</th>
                                      </tr>
                                      </tfoot>
                          </table>
                                </div>
                          </form>
                      </section>
                  </div>
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
    <!--<script src="js/jquery.js"></script>-->
    <script type="text/javascript" language="javascript" src="assets/advanced-datatable/media/js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="assets/advanced-datatable/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="assets/data-tables/DT_bootstrap.js"></script>
    <script src="js/respond.min.js" ></script>


  <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>

    <!--script for this page only-->

      <script type="text/javascript" charset="utf-8">
          $(document).ready(function () {
              $('#example').dataTable({
                  "aaSorting": [[4, "desc"]]
              });
          });
      </script>

  </body>
</html>
