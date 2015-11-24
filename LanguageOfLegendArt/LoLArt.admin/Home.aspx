<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LoLArt.admin.Home" MasterPageFile="~/Site.Master"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="plcContent" runat="server">   
    <link href="Content/assets/css/clock.css" rel="stylesheet" type="text/css"/>
    <link href="Content/assets/css/custom.css" rel="stylesheet" type="text/css"/>
    
    
    <div id="main-wrapper">
                    <%-- Thời gian hệ thống : block --%>
                    <div class="row">
                        <div class="col-lg-5 col-md-11">
                            <div class="panel info-box panel-white">
                                <div class="panel-body">
                                    <h3 style="margin-top: 0">Thời gian hệ thống:</h3>
                                    <div id="clock"></div>
                                </div>
                            </div>
                        </div>
                        <%-- code phần view + .... --%>
                       <%-- <div class="col-lg-3 col-md-6">
                            <div class="panel info-box panel-white">
                                <div class="panel-body">
                                    <div class="info-box-stats">
                                        <p class="counter">340,230</p>
                                        <span class="info-box-title">Page views</span>
                                    </div>
                                    <div class="info-box-icon">
                                        <i class="icon-eye"></i>
                                    </div>
                                    <div class="info-box-progress">
                                        <div class="progress progress-xs progress-squared bs-n">
                                            <div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="panel info-box panel-white">
                                <div class="panel-body">
                                    <div class="info-box-stats">
                                        <p>$<span class="counter">653,000</span></p>
                                        <span class="info-box-title">Monthly revenue goal</span>
                                    </div>
                                    <div class="info-box-icon">
                                        <i class="icon-basket"></i>
                                    </div>
                                    <div class="info-box-progress">
                                        <div class="progress progress-xs progress-squared bs-n">
                                            <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="panel info-box panel-white">
                                <div class="panel-body">
                                    <div class="info-box-stats">
                                        <p class="counter">47,500</p>
                                        <span class="info-box-title">New emails recieved</span>
                                    </div>
                                    <div class="info-box-icon">
                                        <i class="icon-envelope"></i>
                                    </div>
                                    <div class="info-box-progress">
                                        <div class="progress progress-xs progress-squared bs-n">
                                            <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" style="width: 50%">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div><!-- Row -->
                    <div class="row">
                        <div class="col-lg-9 col-md-12">
                            <div class="panel panel-white">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="visitors-chart">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">Danh sách lỗi</h4>
                                             </div>
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                <table class="table">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>ID</th>
                                                            <th>File Exception</th>
                                                            <th>Method Name</th>
                                                            <th>Exception</th>
                                                            <th>Time</th>
                                                            <th>Status</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Literal runat="server" ID="lbTableLog"></asp:Literal>
                                                    </tbody>
                                                </table>
                                                </div>
                                                <asp:Literal runat="server" ID="lbNote"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<div class="col-sm-4">
                                        <div class="stats-info">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">Browser Stats</h4>
                                            </div>
                                            <div class="panel-body">
                                                <ul class="list-unstyled">
                                                    <li>Google Chrome<div class="text-success pull-right">32%<i class="fa fa-level-up"></i></div></li>
                                                    <li>Firefox<div class="text-success pull-right">25%<i class="fa fa-level-up"></i></div></li>
                                                    <li>Internet Explorer<div class="text-success pull-right">16%<i class="fa fa-level-up"></i></div></li>
                                                    <li>Safari<div class="text-danger pull-right">13%<i class="fa fa-level-down"></i></div></li>
                                                    <li>Opera<div class="text-danger pull-right">7%<i class="fa fa-level-down"></i></div></li>
                                                    <li>Mobile &amp; tablet<div class="text-success pull-right">4%<i class="fa fa-level-up"></i></div></li>
                                                    <li>Others<div class="text-success pull-right">3%<i class="fa fa-level-up"></i></div></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <%--<div class="col-lg-3 col-md-6">
                            <div class="panel panel-white" style="height: 100%;">
                                <div class="panel-heading">
                                    <h4 class="panel-title">Server Load</h4>
                                    <div class="panel-control">
                                        <a href="javascript:void(0);" data-toggle="tooltip" data-placement="top" title="Expand/Collapse" class="panel-collapse"><i class="icon-arrow-down"></i></a>
                                        <a href="javascript:void(0);" data-toggle="tooltip" data-placement="top" title="Reload" class="panel-reload"><i class="icon-reload"></i></a>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="server-load">
                                        <div class="server-stat">
                                            <span>Total Usage</span>
                                            <p>67GB</p>
                                        </div>
                                        <div class="server-stat">
                                            <span>Total Space</span>
                                            <p>320GB</p>
                                        </div>
                                        <div class="server-stat">
                                            <span>CPU</span>
                                            <p>57%</p>
                                        </div>
                                    </div>
                                    <div id="flotchart2"></div>
                                </div>
                            </div>
                        </div>--%> <%--// block thông tin hệ thống--%>
                        <%--<div class="col-lg-5 col-md-6">
                            <div class="panel panel-white">
                                <div class="panel-heading">
                                    <h4 class="panel-title">Weather</h4>
                                    <div class="panel-control">
                                        <a href="javascript:void(0);" data-toggle="tooltip" data-placement="top" title="Reload" class="panel-reload"><i class="icon-reload"></i></a>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="weather-widget">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="weather-top">
                                                    <div class="weather-current pull-left">
                                                        <i class="wi wi-day-cloudy weather-icon"></i>
                                                        <p><span>83<sup>&deg;F</sup></span></p>
                                                    </div>
                                                    <h2 class="weather-day pull-right">Miami, FL<br><small><b>13th April, 2015</b></small></h2>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <ul class="list-unstyled weather-info">
                                                    <li>Wind <span class="pull-right"><b>ESE 16 mph</b></span></li>
                                                    <li>Humidity <span class="pull-right"><b>64%</b></span></li>
                                                    <li>Pressure <span class="pull-right"><b>30.15 in</b></span></li>
                                                    <li>UV Index <span class="pull-right"><b>6</b></span></li>
                                                </ul>
                                            </div>
                                            <div class="col-md-6">
                                                <ul class="list-unstyled weather-info">
                                                    <li>Cloud Cover <span class="pull-right"><b>60%</b></span></li>
                                                    <li>Ceiling <span class="pull-right"><b>17800 ft</b></span></li>
                                                    <li>Dew Point <span class="pull-right"><b>70° F</b></span></li>
                                                    <li>Visibility <span class="pull-right"><b>10 mi</b></span></li>
                                                </ul>
                                            </div>
                                            <div class="col-md-12">
                                                <ul class="list-unstyled weather-days row">
                                                    <li class="col-xs-4 col-sm-2"><span>12:00</span><i class="wi wi-day-cloudy"></i><span>82<sup>&deg;F</sup></span></li>
                                                    <li class="col-xs-4 col-sm-2"><span>13:00</span><i class="wi wi-day-cloudy"></i><span>82<sup>&deg;F</sup></span></li>
                                                    <li class="col-xs-4 col-sm-2"><span>14:00</span><i class="wi wi-day-cloudy"></i><span>82<sup>&deg;F</sup></span></li>
                                                    <li class="col-xs-4 col-sm-2"><span>15:00</span><i class="wi wi-day-cloudy"></i><span>83<sup>&deg;F</sup></span></li>
                                                    <li class="col-xs-4 col-sm-2"><span>16:00</span><i class="wi wi-day-cloudy"></i><span>82<sup>&deg;F</sup></span></li>
                                                    <li class="col-xs-4 col-sm-2"><span>17:00</span><i class="wi wi-day-sunny-overcast"></i><span>82<sup>&deg;F</sup></span></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%> <%--// blok thời tiết--%>
                        <div class="col-lg-9 col-md-12">
                            <div class="panel panel-white">
                                <div class="panel-heading">
                                    <h4 class="panel-title">FeedBack về hệ thống</h4>
                                    <div class="panel-control">
                                        <a href="javascript:void(0);" data-toggle="tooltip" data-placement="top" title="Reload" class="panel-reload"><i class="icon-reload"></i></a>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="inbox-widget slimscroll">
                                       <asp:Literal runat="server" ID="lbFeedBack"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="panel twitter-box">
                                <div class="panel-body">
                                    <div class="live-tile" data-mode="flip" data-speed="750" data-delay="3000">
                                        <span class="tile-title pull-right">New Tweets</span>
                                        <i class="fa fa-twitter"></i>
                                        <div><h2 class="no-m">It’s kind of fun to do the impossible...</h2><span class="tile-date">10 April, 2015</span></div>
                                        <div><h2 class="no-m">Sometimes by losing a battle you find a new way to win the war...</h2><span class="tile-date">6 April, 2015</span></div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel facebook-box">
                                <div class="panel-body">
                                    <div class="live-tile" data-mode="carousel" data-direction="horizontal" data-speed="750" data-delay="4500">
                                        <span class="tile-title pull-right">Facebook Feed</span>
                                        <i class="fa fa-facebook"></i>
                                        <div><h2 class="no-m">If you're going through hell, keep going...</h2><span class="tile-date">23 March, 2015</span></div>
                                        <div><h2 class="no-m">To improve is to change; to be perfect is to change often...</h2><span class="tile-date">15 March, 2015</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12">
                            <div class="panel panel-white">
                                <div class="panel-heading">
                                    <h4 class="panel-title">Danh sách bài đăng chưa duyệt</h4>
                                </div>
                                <div class="panel-body">
                                    <div class="table-responsive project-stats">  
                                       <table class="table">
                                           <thead>
                                               <tr>
                                                   <th>#</th>
                                                   <th>Title</th>
                                                   <th>Status</th>
                                                   <th>Category</th>
                                                   <th>Posted By</th>
                                                   <th>Time</th>
                                               </tr>
                                           </thead>
                                           <tbody>
                                                <asp:Literal runat="server" ID="lbPostWaiting"></asp:Literal>
                                           </tbody>
                                        </table>
                                    </div>
                                    <asp:Literal runat="server" ID="lbNotePostWating"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        <script src="Content/assets/plugins/jquery/jquery-2.1.3.min.js"></script>
        <script src="Content/assets/js/customClock.js" type="text/javascript" ></script>
</asp:Content>