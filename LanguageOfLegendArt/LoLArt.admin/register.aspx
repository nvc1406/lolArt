<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="LoLArt.admin.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>LOL Art | Login - Sign up</title>
        <meta content="width=device-width, initial-scale=1" name="viewport"/>
        <meta charset="UTF-8"/>
        <meta name="description" content="LOl Art" />
        <meta name="keywords" content="lol,lolart" />
        <meta name="author" content="Steelcoders" />
        
        <!-- Styles -->
        <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600' rel='stylesheet' type='text/css'/>
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
        
        <script src="Content/assets/plugins/3d-bold-navigation/js/modernizr.js"></script>
        <script src="Content/assets/plugins/offcanvasmenueffects/js/snap.svg-min.js"></script>
</head>
<body>
     <main class="page-content">
            <div class="page-inner">
                <div id="main-wrapper">
                    <div class="row">
                        <div class="col-md-3 center">
                            <div class="login-box">
                                <a href="index.html" class="logo-name text-lg text-center">Modern</a>
                                <p class="text-center m-t-md">Create a Modern's account</p>
                                <form class="m-t-md" action="login.aspx">
                                    <div class="form-group">
                                        <input type="text" class="form-control" placeholder="Name" required/>
                                    </div>
                                    <div class="form-group">
                                        <input type="email" class="form-control" placeholder="Email" required/>
                                    </div>
                                    <div class="form-group">
                                        <input type="password" class="form-control" placeholder="Password" required/>
                                    </div>
                                    <label>
                                        <input type="checkbox"/> Agree the terms and policy
                                    </label>
                                    <button type="submit" class="btn btn-success btn-block m-t-xs">Submit</button>
                                    <p class="text-center m-t-xs text-sm">Already have an account?</p>
                                    <a href="login.aspx" class="btn btn-default btn-block m-t-xs">Login</a>
                                </form>
                                <p class="text-center m-t-xs text-sm">2015 &copy; Modern by Steelcoders.</p>
                            </div>
                        </div>
                    </div><!-- Row -->
                </div><!-- Main Wrapper -->
            </div><!-- Page Inner -->
        </main><!-- Page Content -->
	

        <!-- Javascripts -->
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
