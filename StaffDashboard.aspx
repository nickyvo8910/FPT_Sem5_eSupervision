<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffDashboard.aspx.cs" Inherits="StaffDashboard" %>

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
                      <a href="StaffDashboard.aspx" class="active">
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
                      <a href="StaffBloging.aspx">
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
                              <i class="fa fa-user"></i>
                          </div>
                          <div class="value">
                              <h1 class="count">
                                  0
                              </h1>
                              <p>Supervisor's Students</p>
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
                                    <td>Student Supervised</td>
                                    <td><%=TOTAL_SUPERVISES %></td>
                                </tr>
                                <tr>
                                    <td>
                                        <i class="fa fa-bookmark-o"></i>
                                    </td>
                                    <td>Student Second Marked</td>
                                    <td><%=TOTAL_SECOND %></td>
                                </tr>
                                <tr>
                                    <td>
                                        <i class=" fa fa-envelope"></i>
                                    </td>
                                    <td>Messages Sent/Received</td>
                                    <td><%=TOTAL_MESS %></td>
                                </tr>
                                
                              </tbody>
                          </table>
                      </section>
                      <!--user info table end-->
                  </div>
              <!--
                  <div class="col-lg-8">
                      <section class="panel">
                          <header class="panel-heading">
                              Communication Graph
                          </header>
                          <div class="panel-body">
                              <figure class="demo-xchart" id="chart"></figure>
                          </div>
                      </section>
                  </div>
              -->
                  <div class="col-lg-8">
                      <section class="panel">
                          <header class="panel-heading">
                              Students List
                          </header>
                          <div class="panel-body">
                                <div class="adv-table">
                                    <table  class="display table table-bordered table-striped" id="example">
                                      <thead>
                                      <tr>
                                          <th>No</th>
                                          <th>Student ID</th>
                                          <th>Student Name</th>
                                          <th>Role</th>
                                          <th>Student Mail</th>
                                      </tr>
                                      </thead>
                                      <tbody>
                                          <%String role;
                                            int No=0;
                                              foreach(System.Data.DataRow dtRow in tblStaffStudents.Rows){
                                                  if (userID.Equals(dtRow[7].ToString()))
                                                  {
                                                      role = "Supervisor";
                                                  }
                                                  else
                                                  {
                                                      role = "SecondMarker";
                                                  }
                                          %>
                                      	<tr>
                                          <td><%=No %></td>
                                          <td><%=dtRow[0].ToString() %></td>
                                          <td><%=dtRow[1].ToString() %></td>
                                          <td><%=role %></td>
                                          <td><%=dtRow[4].ToString() %></td>
                                         
                                      	</tr>
                                          <%
                                                  No++;
                                          } %>
                                      </tbody>
                                      <tfoot>
                                      <tr>
                                          <th>No</th>
                                          <th>Student ID</th>
                                          <th>Student Name</th>
                                          <th>Role</th>
                                          <th>Student Mail</th>
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
  
  <!--- Script for Xchart -->
  
  <script src="assets/xchart/d3.v3.min.js"></script>
  <script src="assets/xchart/xcharts.min.js"></script>
  
  <script>
      (function () {
          var data = [
		  { "xScale": "ordinal", "comp": [], "main": [{ "className": ".main.l1", "data": [{ "y": 15, "x": "2012-11-19T00:00:00" }, { "y": 11, "x": "2012-11-20T00:00:00" }, { "y": 8, "x": "2012-11-21T00:00:00" }, { "y": 10, "x": "2012-11-22T00:00:00" }, { "y": 1, "x": "2012-11-23T00:00:00" }, { "y": 6, "x": "2012-11-24T00:00:00" }, { "y": 8, "x": "2012-11-25T00:00:00" }] }], "type": "line-dotted", "yScale": "linear" },
		  { "xScale": "ordinal", "comp": [], "main": [{ "className": ".main.l1", "data": [{ "y": 15, "x": "2012-11-19T00:00:00" }, { "y": 11, "x": "2012-11-20T00:00:00" }, { "y": 8, "x": "2012-11-21T00:00:00" }, { "y": 10, "x": "2012-11-22T00:00:00" }, { "y": 1, "x": "2012-11-23T00:00:00" }, { "y": 6, "x": "2012-11-24T00:00:00" }, { "y": 8, "x": "2012-11-25T00:00:00" }] }], "type": "bar", "yScale": "linear" }
          ];
          var order = [0, 1, 0, 2],
                  i = 0,
                  xFormat = d3.time.format('%A'),
                  chart = new xChart('line-dotted', data[order[i]], '#chart', {
                      axisPaddingTop: 5,
                      dataFormatX: function (x) {
                          return new Date(x);
                      },
                      tickFormatX: function (x) {
                          return xFormat(x);
                      },
                      timing: 1250
                  }),
                  rotateTimer,
                  toggles = d3.selectAll('.multi button'),
                  t = 3500;

          function updateChart(i) {
              var d = data[i];
              chart.setData(d);
              toggles.classed('toggled', function () {
                  return (d3.select(this).attr('data-type') === d.type);
              });
              return d;
          }

          toggles.on('click', function (d, i) {
              clearTimeout(rotateTimer);
              updateChart(i);
          });

          function rotateChart() {
              i += 1;
              i = (i >= order.length) ? 0 : i;
              var d = updateChart(order[i]);
              rotateTimer = setTimeout(rotateChart, t);
          }
          rotateTimer = setTimeout(rotateChart, t);
      }());
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

          countUp(<%= TOTAL_STUDENTS %>);

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
