<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerUpdateStudent.aspx.cs" Inherits="ManagerUpdateStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>Form Validation</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/bootstrap-datepicker/css/datepicker.css" />   
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
                      <a href="ManagerProfile.aspx">
                          <i class="fa fa-user"></i>
                          <span>Profile</span>
                      </a>
                  </li>
                  <li class="sub-menu">
                      <a href="javascript:;" class="active">
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
              <div class="row">
                  <div class="col-lg-12">
                      <section class="panel">
                          <header class="panel-heading">
                          Update Student's Infomation
                          <span class="tools pull-right">
                            <a href="javascript:;" class="fa fa-chevron-down"></a>
                            <a href="javascript:;" class="fa fa-times"></a>
                          </span>
                      </header>
                          <div class="panel-body">
                              <div class=" form">
                                  <form class="cmxform form-horizontal tasi-form" runat="server">
                                      
                                  	  <div class="form-group ">
                                          <label for="cname" class="control-label col-lg-2">Student ID</label>
                                          <div class="col-md-4 col-xs-11">
                                              <asp:TextBox ID="txtID" ReadOnly="true" runat="server" class="form-control col-lg-2" />
                                              <asp:HiddenField runat="server" ID ="hidID"/>
                                          </div>
                                      </div>
                                      <div class="form-group ">
                                          <label for="cname" class="control-label col-lg-2">Student Name</label>
                                          <div class="col-md-4 col-xs-11">
                                               <asp:TextBox ID="txtName" runat="server" class="form-control col-lg-2" MaxLength="150" />
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic" Text="Can't be blank"></asp:RequiredFieldValidator>
                                          </div>
                                      </div>
                                      <div class="form-group ">
                                          <label for="cname" class="control-label col-lg-2">Academic Year</label>
                                          <div class="col-md-4 col-xs-11">
                                              <asp:DropDownList ID ="dropAca" runat="server" class="form-control col-lg-2">                                                  
                                              </asp:DropDownList>
                                          </div>
                                      </div>
                                      <div class="form-group ">
                                          <label for="cname" class="control-label col-lg-2">Birthday</label>
                                          <div class="col-md-4 col-xs-11">
                                             <asp:TextBox ID="txtBirthday" runat="server" class="col-lg-2 form-control form-control-inline input-medium default-date-picker" />
                                  	   </div>
                                      </div>
                                      <div class="form-group ">
                                          <label for="cname" class="control-label col-lg-2">Email</label>
                                          <div class="col-md-4 col-xs-11">
                                              <asp:TextBox ID="txtEmail"  runat="server" class="form-control col-lg-2" MaxLength="150" />
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic" Text="Can't be blank"></asp:RequiredFieldValidator>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression='^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$'  Display="Dynamic" Text="Wrong Email format"></asp:RegularExpressionValidator>

                                          </div>
                                      </div>
                                      <div class="form-group ">
                                          <label for="cname" class="control-label col-lg-2">Mobile</label>
                                          <div class="col-md-4 col-xs-11">
                                              <asp:TextBox ID="txtMobile" runat="server" class="form-control col-lg-2" MaxLength="20" />
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Display="Dynamic" ControlToValidate="txtMobile" ValidationExpression="[0-9]{8,11}" EnableViewState="True" EnableTheming="True" ForeColor="Red" Text="Phone must be 8 to 11 digit numbers"></asp:RegularExpressionValidator>
                                          </div>
                                      </div>
                                      <div class="form-group ">
                                          <label for="ccomment" class="control-label col-lg-2">Address</label>
                                          <div class="col-md-4 col-xs-11">
                                              <asp:TextBox ID="txtAddress" runat="server" class="form-control col-lg-2" MaxLength="250" />
                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <div class="col-lg-offset-2 col-lg-10">
                                              <asp:Button runat="server" id="btnUpdate" text="Update" class="btn btn-danger"  CausesValidation="True"  OnClick="btnUpdate_Click"/>
                                              <asp:Button runat="server" id="btnCancel" class="btn btn-default" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click"/>
                                          </div>
                                      </div>
                                  </form>
                              </div>

                          </div>
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
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery.validate.min.js"></script>
    <script src="js/respond.min.js" ></script>

    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>

    <!--script for this page-->
    <script src="js/form-validation-script.js"></script>
    
   	<!-- JS for Datepicker  -->
  	<script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
  	<script src="js/advanced-form-components.js"></script>    


  </body>
</html>
