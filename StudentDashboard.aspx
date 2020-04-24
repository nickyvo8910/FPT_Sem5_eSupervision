<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDashboard.aspx.cs" Inherits="StudentDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">
    
    <title>FlatLab - Flat & Responsive Bootstrap Admin Template</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/owl.carousel.css" type="text/css">
    <link href="assets/advanced-datatable/media/css/demo_table.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/data-tables/DT_bootstrap.css" />
    <link href="assets/xchart/xcharts.css" rel="stylesheet" />
    
    
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

  <section id="container" >
      <!--header start-->
      <header class="header white-bg">
              <div class="sidebar-toggle-box">
                  <div class="fa fa-bars tooltips" data-placement="right" data-original-title="Toggle Navigation"></div>
              </div>
            <!--logo start-->
            <a href="StaffDashboard.aspx" class="logo" >e<span>Supervisor</span></a>
            <!--logo end-->
            
            <div class="top-nav ">
                <!--search & user info start-->
                <ul class="nav pull-right top-menu">
                    <!-- user login dropdown start-->
                    <li class="dropdown">
                      <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                          <span class="username">Welcome , <%=userID %></span>
                      </a>
                  </li>
                    <!-- user login dropdown end -->
                </ul>
                <!--search & user info end-->
            </div>
        </header>
      <!--header end-->
      <!--sidebar start-->
      <aside>
          <div id="sidebar"  class="nav-collapse ">
              <!-- sidebar menu start-->
              <ul class="sidebar-menu" id="nav-accordion">
                  <li>
                      <a href="StudentDashboard.aspx" class="active">
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
              <!--state overview start-->
              <div class="row state-overview">
                  <div class="col-lg-3 col-sm-6">
                      <section class="panel">
                          <div class="symbol terques">
                              <i class="fa fa-envelope"></i>
                          </div>
                          <div class="value">
                              <h1 class="count">
                                  0
                              </h1>
                              <p>Message Sent</p>
                          </div>
                      </section>
                  </div>
                  <div class="col-lg-3 col-sm-6">
                      <section class="panel">
                          <div class="symbol red">
                              <i class="fa fa-users"></i>
                          </div>
                          <div class="value">
                              <h1 class=" count2">
                                  0
                              </h1>
                              <p>Upcoming Meeting</p>
                          </div>
                      </section>
                  </div>
                  <div class="col-lg-3 col-sm-6">
                      <section class="panel">
                          <div class="symbol yellow">
                              <i class="fa fa-file-text"></i>
                          </div>
                          <div class="value">
                              <h1 class=" count3">
                                  0
                              </h1>
                              <p>Blog Post</p>
                          </div>
                      </section>
                  </div>
                  <div class="col-lg-3 col-sm-6">
                      <section class="panel">
                          <div class="symbol blue">
                              <i class="fa fa-cloud-upload"></i>
                          </div>
                          <div class="value">
                              <h1 class=" count4">
                                  0
                              </h1>
                              <p>Uploaded</p>
                          </div>
                      </section>
                  </div>
              </div>
              <!--state overview end-->
          <div class="row">
            <div class="col-lg-4">
                      <!--user info table start-->
                      <section class="panel">
                          <div class="panel-body">
                              <a href="#" class="task-thumb">
                                  <img src="\Uploads\Avatars\<%=getAvatarByID(userID) %>" alt="" width="85px" height="85px"/>
                              </a>
                              <div class="task-thumb-details">
                                  <h1><a href="#"><%=getUserNameByID(userID)%></a></h1>
                                  <p><%=USER_TYPE %></p>
                              </div>
                          </div>
                          <table class="table table-hover personal-task">
                              <tbody>
                                <tr>
                                    <td>
                                        <i class=" fa fa-bookmark"></i>
                                    </td>
                                    <td>Supervisor Name : </td>
                                    <td><%=SuperName %></td>
                                </tr>
                                <tr>
                                    <td>
                                        <i class="fa fa-bookmark-o"></i>
                                    </td>
                                    <td>Second Marker Name : </td>
                                    <td><%=SecondName %></td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <i class="fa fa-flag-o"></i>
                                    </td>
                                    <td>Last Login : </td>
                                    <td><%=LastLogin %></td>
                                </tr>
                              </tbody>
                          </table>
                      </section>
                      <!--user info table end-->
                  </div>
                  
                  <div class="col-lg-8">
                      <section class="panel">
                          <header class="panel-heading">
                              Communication
                          </header>
                          <div class="panel-body">
                                <div class="adv-table">
                                    <table  class="display table table-bordered table-striped" id="example">
                                      <thead>
                                      <tr>
                                          <th>No</th>
                                          <th>Staff ID</th>
                                          <th>Staff Name</th>
                                          <th >Total Messages</th>
                                          
                                          
                                      </tr>
                                      </thead>
                                      <tbody>
                                          <%int No = 0;
                                            foreach( System.Data.DataRow dtRow in tblCommunication.Rows){
                                             %>
                                      	<tr>
                                          <td><%=No %></td>
                                          <td><%=dtRow[0].ToString() %></td>
                                          <td><%=dtRow[1].ToString() %></td>
                                          <td><%=dtRow[2].ToString() %></td>

                                      	</tr>
                                        <%
                                                No++;
                                                } %>
                                      </tbody>
                                      <tfoot>
                                      <tr>
                                          <th>No</th>
                                          <th>Staff ID</th>
                                          <th>Staff Name</th>
                                          <th >Total Messages</th>
                                          
                                      </tr>
                                      </tfoot>
                          </table>
                                </div>
                          </div>
                      </section>
                  </div>
          </div>
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
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="js/owl.carousel.js" ></script>
    <script src="js/jquery.customSelect.min.js" ></script>
    <script src="js/respond.min.js" ></script>

    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>

    <!--script for this page-->
    <!--<script src="js/count.js"></script>-->
    <script class="include" type="text/javascript" src="js/jquery.dcjqaccordion.2.7.js"></script>
    <script type="text/javascript" language="javascript" src="assets/advanced-datatable/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="assets/data-tables/DT_bootstrap.js"></script>
	<script src="js/respond.min.js" ></script>
    
  <script type="text/javascript" charset="utf-8">
      $(document).ready(function () {
          $('#example').dataTable({
              "aaSorting": [[4, "desc"]]
          });
      });
      </script>
  
 <script>
     function countUp(count) {
         var div_by = 100,
             speed = Math.round(count / div_by),
             $display = $('.count'),
             run_count = 1,
             int_speed = 24;

         var int = setInterval(function () {
             if (run_count < div_by) {
                 $display.text(speed * run_count);
                 run_count++;
             } else if (parseInt($display.text()) < count) {
                 var curr_count = parseInt($display.text()) + 1;
                 $display.text(curr_count);
             } else {
                 clearInterval(int);
             }
         }, int_speed);
     }

     countUp(<%= TOTAL_MESS %>);

          function countUp2(count) {
              var div_by = 100,
                  speed = Math.round(count / div_by),
                  $display = $('.count2'),
                  run_count = 1,
                  int_speed = 24;

              var int = setInterval(function () {
                  if (run_count < div_by) {
                      $display.text(speed * run_count);
                      run_count++;
                  } else if (parseInt($display.text()) < count) {
                      var curr_count = parseInt($display.text()) + 1;
                      $display.text(curr_count);
                  } else {
                      clearInterval(int);
                  }
              }, int_speed);
          }

          countUp2(<%=TOTAL_MEETINGS%>);

           function countUp3(count) {
               var div_by = 100,
                   speed = Math.round(count / div_by),
                   $display = $('.count3'),
                   run_count = 1,
                   int_speed = 24;

               var int = setInterval(function () {
                   if (run_count < div_by) {
                       $display.text(speed * run_count);
                       run_count++;
                   } else if (parseInt($display.text()) < count) {
                       var curr_count = parseInt($display.text()) + 1;
                       $display.text(curr_count);
                   } else {
                       clearInterval(int);
                   }
               }, int_speed);
           }

           countUp3(<%=TOTAL_POSTS%>);

        function countUp4(count) {
            var div_by = 100,
                speed = Math.round(count / div_by),
                $display = $('.count4'),
                run_count = 1,
                int_speed = 24;

            var int = setInterval(function () {
                if (run_count < div_by) {
                    $display.text(speed * run_count);
                    run_count++;
                } else if (parseInt($display.text()) < count) {
                    var curr_count = parseInt($display.text()) + 1;
                    $display.text(curr_count);
                } else {
                    clearInterval(int);
                }
            }, int_speed);
        }

        countUp4(<%=TOTAL_UPLOADS%>);
      </script>


  </body>
</html>
