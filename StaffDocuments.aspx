<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffDocuments.aspx.cs" Inherits="StaffDocuments" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content="">
    <meta name="author" content="Mosaddek"/>
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina"/>
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

    <!-- Upload CSS -->
    <link rel="stylesheet" type="text/css" href="assets/bootstrap-fileupload/bootstrap-fileupload.css" />
    
   	<!--- Table CSS -->
    <link href="assets/advanced-datatable/media/css/demo_page.css" rel="stylesheet" />
    <link href="assets/advanced-datatable/media/css/demo_table.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/data-tables/DT_bootstrap.css" />
    
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
                      <a href="StaffMeetings.aspx">
                          <i class="fa fa-users"></i>
                          <span>Meetings</span>
                      </a>
                  </li>
                  <li>
                      <a href="StaffDocuments.aspx" class="active">
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
          <form runat="server">
          <section class="wrapper site-min-height">
              <!-- page start-->
              <div class="row">
              <div class="col-lg-12">
                      <section class="panel">
                              <header class="panel-heading">
                                   Upload Document For Staff
                                  <span class="tools pull-right">
                            <a href="javascript:;" class="fa fa-chevron-down"></a>
                            <a href="javascript:;" class="fa fa-times"></a>
                          </span>
                              </header>
                              
                              <div class="panel-body">
                                  <div class="cmxform form-horizontal tasi-form"  role="form" >

                                      <div class="form-group">
                                          <label  class="control-label col-lg-2">Upload Title</label>
                                          
                                          <div class="col-md-4 col-xs-11">
                                              <asp:TextBox ID="txtTitle" runat="server" class=" form-control" MaxLength="100" />
                                         
                                          </div>
                                      </div>
                                      <div class="form-group">
                                          <label  class="control-label col-lg-2">Upload Document</label>
                                          
                                          <div class="col-md-4 col-xs-11">
                                              <div class="fileupload fileupload-new" data-provides="fileupload">
                                                <span class="btn btn-white btn-file">
                                                <span class="fileupload-new"><i class="fa fa-paper-clip"></i>Select a file to upload</span>
                                                <span class="fileupload-exists"><i class="fa fa-undo"></i> Change</span>
                                                <asp:FileUpload runat="server" id="FileUploadControl" class="default" />
                                                </span>
                                                  <span class="fileupload-preview" style="margin-left:5px;"></span>
                                                  <a href="#" class="close fileupload-exists" data-dismiss="fileupload" style="float: none; margin-left:5px;"></a>
                                              </div>
                                          </div>
                                      </div>
                                      
                                      <div class="form-group">
                                          <asp:Label runat="server" class="col-lg-6 control-label" id="StatusLabel" text="Upload Status: " />
                                          <div class="col-lg-offset-2 col-lg-10">
                                              <asp:Button runat="server" id="btnUpload" text="Upload" class="btn btn-info" onclick="btnUpload_Click" />
                                              <asp:Button runat="server" id="btnCancelUpload" class="btn btn-default" onclick="btnCancelUpload_Click" Text="Cancel" />
                                          </div>
                                      </div>
                                  </div>  
                      </section>
              </div>
              
              <div class="col-lg-6">
                      <section class="panel">
                           <header class="panel-heading">
                              My Uploads
                          </header>
                          <div class="panel-body">
                                <div class="adv-table">
                                    <asp:GridView  class="display table table-bordered table-striped" ID="GridView1" runat="server" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="documentID" HeaderText="Document ID" />
                                                <asp:BoundField DataField="documentTitle" HeaderText="Title" />
                                                <asp:BoundField DataField="documentDate" HeaderText="Upload Date" />
                                                <asp:TemplateField HeaderText="Functions">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("documentLink") %>' class="btn btn-primary btn-xs" CommandName="cmdDownload"><i class="fa fa-cloud-download"></i> Download</asp:LinkButton>
                                                        
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Bind("documentID") %>' class="btn btn-danger btn-xs" CommandName="cmdDelete"><i class="fa fa-ban"></i> Delete</asp:LinkButton>
                                                        
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </div>
                          </div>
                      </section>
                  </div>
                  
                  <div class="col-lg-6">
                      <section class="panel">
                          <header class="panel-heading">
                              Student's Uploads
                          </header>
                          <div class="panel-body">
                                <div class="adv-table">
                                    <asp:GridView  class="display table table-bordered table-striped" ID="GridView2" runat="server" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand">
                                            <Columns>                                                                                                
                                                <asp:BoundField DataField="studentID" HeaderText="Student ID" />
                                                <asp:BoundField DataField="studentName" HeaderText="Student Name" />
                                                <asp:BoundField DataField="documentID" HeaderText="Document ID" />
                                                <asp:BoundField DataField="documentTitle" HeaderText="Title" />
                                                <asp:BoundField DataField="documentDate" HeaderText="Upload Date" />
                                                <asp:TemplateField HeaderText="Functions">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("documentLink") %>' class="btn btn-primary btn-xs" CommandName="cmdDownload"><i class="fa fa-cloud-download"></i> Download</asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Bind("documentID") %>' class="btn btn-success btn-xs" CommandName="cmdComment"><i class="fa fa-comment"></i> Comment</asp:LinkButton>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </div>
                          </div>
                      </section>
                  </div>
                  
              </div>    
              <!-- page end-->
          </section>
              </form>
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

      <!-- Upload Scripts -->
      <script type="text/javascript" src="assets/bootstrap-fileupload/bootstrap-fileupload.js"></script>
      
      <!-- Table Scripts -->
      <script type="text/javascript" language="javascript" src="assets/advanced-datatable/media/js/jquery.dataTables.js"></script>
      <script type="text/javascript" src="assets/data-tables/DT_bootstrap.js"></script>
      <script type="text/javascript" charset="utf-8">
          $(document).ready(function () {
              $('#example').dataTable({
                  "aaSorting": [[4, "desc"]]
              });
          });
      </script>
      
      <script type="text/javascript" charset="utf-8">
          $(document).ready(function () {
              $('#example1').dataTable({
                  "aaSorting": [[4, "desc"]]
              });
          });
      </script>

  </body>
</html>
