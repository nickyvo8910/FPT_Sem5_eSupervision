<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffCreateMeeting.aspx.cs" Inherits="StaffCreateMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>Advanced Form Components</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="assets/bootstrap-datepicker/css/datepicker.css" />
    <link rel="stylesheet" type="text/css" href="assets/jquery-multi-select/css/multi-select.css" />


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
                      <a href="StaffMeetings.aspx" class="active">
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
          <!-- page start-->
              <!--multiple select start-->
              <div class="row">
  				<div class="col-md-12">
                <section class="panel">
                      <header class="panel-heading">
                          Create New Meeting 
                          <span class="tools pull-right">
                            <a href="javascript:;" class="fa fa-chevron-down"></a>
                            <a href="javascript:;" class="fa fa-times"></a>
                          </span>
                      </header>
  					<div class="panel-body">
                          <form runat="server" class="form-horizontal tasi-form">
                          <div class="form-group">
                                      <label class="control-label col-md-2">Meeting Type</label>
                                      <div class="col-md-4 col-xs-11">
                                          <label class="label_radio" for="radio-01">
                                                <asp:RadioButton GroupName="GRB"  ID="cbxOnline" runat="server" Checked="true"/> Online
                                          </label>
                                          <label class="label_radio" for="radio-02">
                                                <asp:RadioButton GroupName="GRB"  ID="cbxOffline" runat="server" /> Offline
                                          </label>
                                      </div>
                              </div>
                             
                          
                          <div class="form-group">
                                  <label class="control-label col-md-2">Meeting Topic</label>
                                  <div class="col-md-4 col-xs-11">
                                      <asp:TextBox ID="txtTopic" runat="server" class="form-control col-lg-2" MaxLength="250" />
                           
                                  </div>
                      	  </div>
                          <div class="form-group">
                                  <label class="control-label col-md-2">Meeting Date</label>
                                  <div class="col-md-4 col-xs-11">
                                      <asp:TextBox ID="txtDate" runat="server" class="form-control col-lg-2 form-control-inline input-medium default-date-picker" />
                                  </div>
                      	  </div>
                          <asp:Panel runat="server" ID ="placePnl" class="form-group" Visible ="true">
                                  <label class="control-label col-md-2">Meeting Place</label>
 
                                  <div class="col-md-4 col-xs-11">
                                      <asp:TextBox ID="txtPlace" runat="server" class="form-control col-lg-2" MaxLength="250" />
                           
                                  </div>
                      	  </asp:Panel>
                           <div class="form-group">
                                    <label class="control-label col-md-2">Select Student To Invite</label>
                                    <div class="col-md-9">
                                    <asp:ListBox name="country" class="multi-select" multiple="" id="my_multi_select3" runat="server" SelectionMode="Multiple" >                                      
                                       </asp:ListBox>
                              </div>
                          </div>
                          <div class="form-group">
                          		<div class="col-lg-offset-2 col-lg-10">
                                    <asp:Button runat="server" id="btnCreate" text="Create" class="btn btn-danger" OnClick="btnCreate_Click" />
                                    <asp:Button runat="server" id="btnCancel" class="btn btn-default" Text="Cancel" OnClick="btnCancel_Click" />
                              	</div>
                       	  </div>
                    </form>
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
      <!--footer end--><!-- js placed at the end of the document so the pages load faster -->
    <!-- js placed at the end of the document so the pages load faster -->
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="js/respond.min.js" ></script>

    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>
  
    <!--this page plugins-->

	  <script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
      <script type="text/javascript" src="assets/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
      <script type="text/javascript" src="assets/bootstrap-daterangepicker/daterangepicker.js"></script>
      <script type="text/javascript" src="assets/bootstrap-colorpicker/js/bootstrap-colorpicker.js"></script>
      <script type="text/javascript" src="assets/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
      <script type="text/javascript" src="assets/jquery-multi-select/js/jquery.multi-select.js"></script>
      <script type="text/javascript" src="assets/jquery-multi-select/js/jquery.quicksearch.js"></script>
  
    <!--this page  script only-->
    <script src="js/advanced-form-components.js"></script>

  	<!--script for this page-->
  	<script src="js/form-component.js"></script>
    
    



  </body>
</html>
