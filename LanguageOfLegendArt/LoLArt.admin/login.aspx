<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LoLArt.admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Sign in</title>
    <meta content="width=device-width, initial-scale=1" name="viewport"/>
        <meta charset="UTF-8"/>
        <meta name="description" content="Lol Art" />
        <meta name="keywords" content="lol,lolart" />
        <meta name="author" content="Steelcoders" />
        <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600' rel='stylesheet' type='text/css' />
        <link href="Content/assets/plugins/pace-master/themes/blue/pace-theme-flash.css" rel="stylesheet"/>
        <link href="Content/assets/plugins/uniform/css/uniform.default.min.css" rel="stylesheet"/>
        <link href="Content/assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
        <link href="Content/assets/plugins/fontawesome/css/font-awesome.css" rel="stylesheet" type="text/css"/>
        <link href="Content/assets/plugins/line-icons/simple-line-icons.css" rel="stylesheet" type="text/css"/>	
        <link href="Content/assets/plugins/offcanvasmenueffects/css/menu_cornerbox.css" rel="stylesheet" type="text/css"/>	
        <link href="Content/assets/plugins/waves/waves.min.css" rel="stylesheet" type="text/css"/>	
        <link href="Content/assets/plugins/switchery/switchery.min.css" rel="stylesheet" type="text/css"/>
        <link href="Content/assets/plugins/3d-bold-navigation/css/style.css" rel="stylesheet" type="text/css"/>	       
        <!-- Theme Styles -->
        <link href="Content/assets/css/modern.min.css" rel="stylesheet" type="text/css"/>
        <link href="Content/assets/css/themes/white.css" class="theme-color" rel="stylesheet" type="text/css"/>
        <link href="Content/assets/css/custom.css" rel="stylesheet" type="text/css"/>
        <link rel="icon" href="favicon.ico" type="image/gif" sizes="16x16"/>  
        
</head>
<body>
   <main class="page-content">
        <div class="page-inner">
            <div id="main-wrapper">
                <div class="row">
                    <div class="col-md-3 center">
                        <div class="login-box">
                            <a href="index.html" class="logo-name text-lg text-center">Modern</a>
                            <p class="text-center m-t-md" id="txtMessage" runat="server">Please login into your account.</p>
                            <form class="m-t-md" action="DoLogin.ashx" method="post">
                                <div class="form-group">
                                <input type="email" runat="server" class="form-control" id="txtEmail" name="txtEmail" placeholder="Email" required/>
                                </div>
                                <div class="form-group">
                                <input type="password" id="txtPass" class="form-control" name="txtPass" placeholder="Password" required/>
                                </div>
                                <button runat="server" id="btnLogins" class="btn btn-success btn-block">Login</button>
                                <a href="forgot.aspx" class="display-block text-center m-t-md text-sm">Forgot Password?</a>
                                <p class="text-center m-t-xs text-sm">Do not have an account?</p>
                                <a href="register.aspx" class="btn btn-default btn-block m-t-md">Create an account</a>
                            </form>
                            <p class="text-center m-t-xs text-sm">2015 &copy; Modern by Steelcoders.</p>
                        </div>
                    </div>
                </div><!-- Row -->
            </div><!-- Main Wrapper -->
        </div><!-- Page Inner -->
    </main><!-- Page Content -->
    <script src="Content/assets/plugins/3d-bold-navigation/js/modernizr.js"></script>
    <script src="Content/assets/plugins/offcanvasmenueffects/js/snap.svg-min.js"></script>
    <script src="Content/assets/plugins/jquery/jquery-2.1.3.min.js"></script>
    <script src="Content/assets/plugins/jquery-ui/jquery-ui.min.js"></script>
    <script src="Content/assets/plugins/pace-master/pace.min.js"></script>
    <script src="Content/assets/plugins/jquery-blockui/jquery.blockui.js"></script>
    <script src="Content/assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="Content/assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="Content/assets/plugins/switchery/switchery.min.js"></script>
    <script src="Content/assets/plugins/uniform/jquery.uniform.min.js"></script>
    <script src="Content/assets/plugins/offcanvasmenueffects/js/classie.js"></script>
    <script src="Content/assets/plugins/offcanvasmenueffects/js/main.js"></script>
    <script src="Content/assets/plugins/waves/waves.min.js"></script>
    <script src="Content/assets/plugins/3d-bold-navigation/js/main.js"></script>
    <script src="Content/assets/js/modern.min.js"></script>
</body>
</html>
