<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerReport.aspx.cs" Inherits="ManagerReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>xchart</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/xchart/xcharts.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />
    
        <!--external css-->
    <link href="assets/morris.js-0.4.3/morris.css" rel="stylesheet" />

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
                  <div class="fa fa-bars tooltips" data-placement="right" data-original-title="Toggle Navigation"></div>
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
                      <a href="ManagerReport.aspx" class="active">
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
              <div class="row state-overview">
                  <div class="col-lg-6 col-sm-6">
                      <section class="panel">
                          <div class="symbol red">
                              <i class="fa fa-users"></i>
                          </div>
                          <div class="value">
                              <h1 class=" count2">
                                  0
                              </h1>
                              <p>Inactive Students</p>
                          </div>
                      </section>
                  </div>
                  <div class="col-lg-6 col-sm-6">
                      <section class="panel">
                          <div class="symbol blue">
                              <i class="fa fa-times"></i>
                          </div>
                          <div class="value">
                              <h1 class=" count4">
                                  0
                              </h1>
                              <p>Not Allocated</p>
                          </div>
                      </section>
                  </div>
              </div>
              <div class="row">
                  <div class="col-lg-12">
                        <section class="panel">
                              <header class="panel-heading">
                                  Staff's average incoming messages
                              </header>
                              <div class="panel-body">
                                  <div id="hero-bar" class="graph" style="position:relative"></div>
                              </div>
                      </section>
                    </div>
              </div>
              <!--
              <section class="panel">
                  <header class="panel-heading">
                      Weekly Communication
                  </header>
                  <div class="panel-body">
                      <figure class="demo-xchart" id="chart"></figure>
                  </div>
              </section>
              -->
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

  	<script src="assets/xchart/d3.v3.min.js"></script>
  	<script src="assets/xchart/xcharts.min.js"></script>
   

    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>

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
  
  	<!-- JS for Chart -->
   
    <script src="assets/morris.js-0.4.3/morris.min.js" type="text/javascript"></script>
    <script src="assets/morris.js-0.4.3/raphael-min.js" type="text/javascript"></script>
    
    
<script>

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

    countUp2(<%=TOTAL_INACTIVE%>);

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

    countUp4(<%=TOTAL_NOTALLOCATED%>);

    var Script = function () {

        //morris chart

        $(function () {
            // data stolen from http://howmanyleft.co.uk/vehicle/jaguar_'e'_type


            Morris.Bar({
                element: 'hero-bar',
                data: [
                        <% foreach (System.Data.DataRow row in activaStaffsTab.Rows){
                               int count = Convert.ToInt32(row[2].ToString().Trim());
                               string name = row[1].ToString();
                               string staffID = row[0].ToString();
                               
                               %>
                      { device: '<%=name%>', geekbench: 0<%=count%> },
                      <%}%>
                      { device: '', geekbench: 0 }
                    ],
                    xkey: 'device',
                    ykeys: ['geekbench'],
                    labels: ['Messages'],
                    barRatio: 0.4,
                    xLabelAngle: 35,
                    hideHover: 'auto',
                    barColors: ['#BFC2CD']
                });

                $('.code-example').each(function (index, el) {
                    eval($(el).text());
                });
            });

    }();
</script>

  </body>
</html>
