<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerProfileEdit.aspx.cs" Inherits="ManagerProfileEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>Profile Edit</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/bootstrap-fileupload/bootstrap-fileupload.css" />
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
                      <a href="ManagerProfile.aspx" class="active">
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
                  <form class="cmxform form-horizontal tasi-form" runat="server" method ="post">
                  <aside class="profile-nav col-lg-3">
                      <section class="panel">
                          <div class="user-heading round">
                              <a href="#">
                                  <img src="Uploads/Avatars/<%=staffInfo[3].ToString()%>" alt="">
                              </a>
                              <h1><%=staffInfo[1].ToString() %></h1>
                              <p><%=staffInfo[2].ToString() %></p>
                          </div>

                          <ul class="nav nav-pills nav-stacked">
                              <li><a href="ManagerProfile.aspx"> <i class="fa fa-user"></i> Profile</a></li>
                              <li class="active"><a href="ManagerProfileEdit.aspx"> <i class="fa fa-edit"></i> Edit Profile</a></li>
                              
                          </ul>

                      </section>
                  </aside>
                  <aside class="profile-info col-lg-9">
                      <section class="panel">
                          <div class="bio-graph-heading">Update Staff's Profile</div>
                          <div class="panel-body bio-graph-info">
                              <h1> <%=staffInfo[0].ToString() %> Profile Info</h1>
                                  <div class="form-group">
                                      <label  class="col-lg-2 control-label">Full Name</label>
                                      <div class="col-lg-6">
                                          <asp:TextBox ID="txtName" runat="server" class="form-control"  MaxLength="150" />
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtName" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Can't be blank" ForeColor="Red" ValidationGroup="change Info"></asp:RequiredFieldValidator>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label  class="col-lg-2 control-label">Birthday</label>
                                      <div class="col-md-6 col-xs-11">
                                         <asp:TextBox ID="txtBirthday" runat="server" class="col-lg-2 form-control form-control-inline input-medium default-date-picker"/>
                                  	   </div>
                                  </div>
                                  <div class="form-group">
                                      <label  class="col-lg-2 control-label">Email</label>
                                      <div class="col-lg-6">
                                          <asp:TextBox ID="txtEmail" runat="server" class="form-control col-lg-2" MaxLength="150" />
                                           or
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail" ErrMessage="RequiredFieldValidator" Display="Dynamic" Text="Can't be blank" ValidationGroup="change Info" ForeColor="Red"></asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression='^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$' ValidationGroup="change Info" Display="Dynamic" Text="Wrong Email format"></asp:RegularExpressionValidator>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label  class="col-lg-2 control-label">Mobile</label>
                                      <div class="col-lg-6">
                                          <asp:TextBox ID="txtMobile" runat="server" class="form-control col-lg-2" MaxLength="20" />
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Display="Dynamic" ControlToValidate="txtMobile" ValidationExpression="[0-9]{8}|([0-9]{11})" EnableViewState="True" EnableTheming="True" ForeColor="Red" Text="Phone must be 8 or 11 ligit numbers" ValidationGroup="change Info"></asp:RegularExpressionValidator>
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <label  class="col-lg-2 control-label">Address</label>
                                      <div class="col-lg-6">
                                          <asp:TextBox ID="txtAddress" runat="server" class="form-control col-lg-2" MaxLength="250" />
                                      </div>
                                  </div>
                                  <div class="form-group">
                                      <div class="col-lg-offset-4 col-lg-8">
                                          <asp:Button runat="server" id="btnSave" text="Save" class="btn btn-success" OnClick="btnSave_Click" ValidationGroup="change Info" />
                                      </div>
                                  </div>
                          </div>
                      </section>
                      <section>
                          <div class="panel panel-primary">
                              <div class="panel-heading"> Sets New Password & Avatar</div>
                              <div class="panel-body">
                                  <div class="form-group">
                                          <label  class="col-lg-2 control-label">Pass Update Status:</label>
                                          <div class="col-lg-6">
                                              <asp:Label ID="PassLabel" runat="server" class="col-lg-6"></asp:Label>
                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <label  class="col-lg-2 control-label">Current Password</label>
                                          <div class="col-lg-6">
                                             <asp:TextBox TextMode="Password" ID="txtCurPass" runat="server" class="form-control col-lg-2"  MaxLength="50" />
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCurPass" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Text="Can't be blank" Visible="True" ForeColor="Red" ValidationGroup="ChangePass"></asp:RequiredFieldValidator>
                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <label  class="col-lg-2 control-label">New Password</label>
                                          <div class="col-lg-6">
                                              <asp:TextBox TextMode="Password" ID="txtNewPass" runat="server" class="form-control col-lg-2" MaxLength="50" />
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNewPass" Display="Dynamic" ForeColor="Red" ValidationGroup="ChangePass">Can&#39;t be blank</asp:RequiredFieldValidator>
                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <label  class="col-lg-2 control-label">Re-type New Password</label>
                                          <div class="col-lg-6">
                                              <asp:TextBox TextMode="Password" ID="txtRePass" runat="server" class="form-control col-lg-2" MaxLength="50" />
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtRePass" Display="Dynamic" ForeColor="Red" ValidationGroup="ChangePass">Can&#39;t be blank</asp:RequiredFieldValidator>
                                          </div>
                                      </div>

                                      <div class="form-group">
                                          <label  class="col-lg-2 control-label">Change Avatar</label>
                                      
                                      <div class="col-md-9">
                                              <div class="fileupload fileupload-new" data-provides="fileupload">
                                                  <div class="fileupload-new thumbnail" style="width: 200px; height: 150px;">
                                                      <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />
                                                  </div>
                                                  <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 200px; max-height: 150px; line-height: 20px;"></div>
                                                  <div>
                                                   <span class="btn btn-white btn-file">
                                                   <span class="fileupload-new"><i class="fa fa-paper-clip"></i> Select image</span>
                                                   <span class="fileupload-exists"><i class="fa fa-undo"></i> Change</span>
                                                   <asp:FileUpload runat="server" ID="FileUploadControl" class="default"/>                                                   
                                                   </span>

                                                      <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="FileUploadControl"><i class="fa fa-trash"></i> Remove</a>
                                                  </div>
                                                  <asp:Label ID="StatusLabel" class="default" runat="server" Text="Upload status: "></asp:Label>
                                              </div>
                                          </div>

                                      <div class="form-group">
                                          <div class="col-lg-offset-4 col-lg-8">
                                              <asp:Button runat="server" id="btnSave1" text="Save" class="btn btn-info" ValidationGroup="ChangePass"  OnClick="btnSave1_Click" />
                                          </div>
                                      </div>
                              </div>
                          </div>
                      </section>
                  </aside>
                    </form>
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
    <script src="assets/jquery-knob/js/jquery.knob.js"></script>
    <script src="js/respond.min.js" ></script>
    
    <!--this page plugins-->
    <script type="text/javascript" src="assets/bootstrap-fileupload/bootstrap-fileupload.js"></script>
    
    <!--common script for all pages-->
    <script src="js/common-scripts.js"></script>

	<!-- JS for Datepicker  -->
  	<script type="text/javascript" src="assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
  	<script src="js/advanced-form-components.js"></script>

  </body>
</html>
