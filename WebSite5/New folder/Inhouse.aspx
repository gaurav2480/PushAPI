<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inhouse.aspx.cs" Inherits="WebSite5_production_Inhouse" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title> </title>
    <style>
          #sidebar-menu{
         position: fixed;
         width: 230px;
         margin-top:70px;
        }

     .main {

    margin: 13px auto;
}

/* Bootstrap 3 text input with search icon */

.has-search .form-control-feedback {
    right: initial;
    left: 0;
    color: #ccc;
}

.has-search .form-control {
    padding-right: 12px;
    padding-left: 34px;
}

         #searchPro{
            padding:8px 40px;
            border-top-left-radius: 25px;
            border-bottom-left-radius:25px;
            margin-right:10px;
            font-size:13px;
            text-align:center;
        }
    .title{
           font-size:13px;
      font-style:oblique;
        }

        #img {
            position:fixed;
            background: #04070B;
            text-align: center;
            -webkit-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
            box-shadow: -1px 1px 3px 0px rgba(0,0,0,0.75);
        }

         #update,#directory,#insert,#menu_toggle,#profileDetails,#Groups{
             display:none;
         }

           #success-alert,#danger-alert,#danger-alert1,#venueInd,#TextBox2{
            display:none;
        }
           #TextBox5{
               text-align:center;
           }




    .hint-text {
        float: left;
        margin-top: 10px;
        font-size: 13px;
    }
	/* Custom checkbox */

	/* Modal styles */
	.modal .modal-dialog {
		max-width: 400px;
	}
	.modal .modal-header, .modal .modal-body, .modal .modal-footer {
		padding: 20px 30px;
	}
	.modal .modal-content {
		border-radius: 3px;
	}
	.modal .modal-footer {
		background: #ecf0f1;
		border-radius: 0 0 3px 3px;
	}
    .modal .modal-title {
        display: inline-block;
    }
	.modal .form-control {
		border-radius: 2px;
		box-shadow: none;
		border-color: #dddddd;
	}
	.modal textarea.form-control {
		resize: vertical;
	}
	.modal .btn {
		border-radius: 2px;
		min-width: 100px;
	}
	.modal form label {
		font-weight: normal;
	}

      #menu-list a {
  padding: 0px 0px 0px 0px;
  display: block;

}

        .pagination {
        float: right;
        margin: 0 0 5px;
    }
    .pagination li a {
        border: none;
        font-size: 13px;
        min-width: 30px;
        min-height: 30px;
        color: #999;
        margin: 0 2px;
        line-height: 30px;
        border-radius: 2px !important;
        text-align: center;
        padding: 0 6px;
    }
    .pagination li a:hover {
        color: #666;
    }
    .pagination li.active a, .pagination li.active a.page-link {
        background: #03A9F4;
    }
    .pagination li.active a:hover {
        background: #0397d6;
    }
	.pagination li.disabled i {
        color: #ccc;
    }
    .pagination li i {
        font-size: 16px;
        padding-top: 6px
    }

    .nav-side-menu {
      width: 400px !important;
    }
    </style>
       <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
     <link href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap.min.css" rel="stylesheet">
     <link href="https://cdn.datatables.net/scroller/2.0.0/css/scroller.bootstrap.min.css" rel="stylesheet">

    <link href="./css/master.css" rel="stylesheet">
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">

     <link href="../production/css/report_slidebar.css" rel="stylesheet">
    <link href="../vendors/google-code-prettify/bin/prettify.min.css" rel="stylesheet">

    <!-- Custom styling plus plugins -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
    <script src="jquery-3.2.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.2.1.min.js"></script>

     <script type="text/javascript">

        function pele(date,country,venue,venueGroup,group) {

            var name = "SEAP. RECAP INH";
            var url = "reportViewer.aspx?name=" + name + "&date=" + date + "&country=" + country + "&venue=" + venue + "&venueGroup=" + venueGroup + "&group=" + group + "";

            window.open(url,'_blank');


        }


    </script>
</head>
<body class="nav-md">

    <div class="container body">
      <div class="main_container">
        <!-- Sidebar Menu -->
         <!--#include file="./html/Sidebar_Menu.html"-->
         <!-- Slidbar Menu End --> 
           <form id="form1" runat="server">
        <!-- top navigation -->
        <!--#include file="./html/TopNav.html"-->
        <!-- /top navigation -->

        <!-- page content -->

        <div class="right_col" role="main">
          <div class="">



            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                  <div class="x_panel">
                                <div class="table-responsive" id="profileDetails">

                              <table class="table table-striped table-hover" id="task-table2">
                                  <thead>
                                      <tr>
                                         <th>PROFILE ID</th>
                                          <th>TITLE</th>
                                          <th>NAME</th>
                                          <th>EMAIL</th>
                                            <th>MOBILE</th>
                                          <th>TOUR DATE</th>
                                          <th>CARD</th>
                                      </tr>
                                  </thead>
                                 <tbody id="myTable" style="font-size:12px;">
                                  </tbody>

                              </table>

                      </div>

                       <div class="col-md-12 col-xs-12 col-sm-12">
                          <ul class="pagination pagination-lg pager" id="myPager"></ul>
                      </div>
                              <div class="x_content" id="x_content">
                <div id="addEmployeeModal" class="modal fade">
                                      <div class="modal-dialog">
                                          <div class="modal-content">

                                              <div class="modal-header">
                                                  <h4 class="modal-title">Admin</h4>
                                                  <!-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>-->
                                              </div>
                                              <div class="modal-body">
                                                  <div class="container-fluid">

                                                      <div class="table-responsive">
                                                           <div style="overflow:scroll;height:200px;width:100%;overflow:auto">
                                                          <table class="table table-striped table-hover" id="task-table1">
                                                              <thead>
                                                                  <tr>
                                                                      <th>Name</th>
                                                                  </tr>
                                                              </thead>
                                                              <tbody>


                                                              </tbody>

                                                          </table>
                                                               </div>
                                                      </div>


                                                  </div>

                                              </div>
                                              <div class="modal-footer">
                                                  <input type="button" class="btn btn-default" id="cancel" data-dismiss="modal" value="Cancel" />

                                              </div>

                                          </div>
                                      </div>
                                  </div>
                     <div class="alert alert-success" id="success-alert">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Success! </strong>

                     </div>
                    <div class="alert alert-danger" id="danger-alert">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Something went wrong! </strong>

                    </div>
                    <div class="alert alert-danger" id="danger-alert1">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <strong>Enter Details! </strong>

                    </div>
                    <div class="container-fluid">

                        <div class="row">
                            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12 " id="head">
                                <br />
                                <h4 class="text-center">RECAP IN-HOUSE</h4>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="container-fluid">
                        <div class="row">


                            <div class="col-md-4 col-xs-12 col-sm-12 col-lg-5" id="">
                                <div class="row">
                                    <div class="nav-side-menu">
                                        <div class="brand">REPORTS</div>
                                        <i class="fa fa-bars fa-2x toggle-btn" data-toggle="collapse" data-target="#menu-content"></i>

                                        <div class="menu-list" id="menu-list">

                                            <ul id="menu-content" class="menu-content collapse out">
                                                  <% Response.Write(getreportdetailsAllReports()); %>
                                                <% Response.Write(getreportdetails()); %>
                                            </ul>
                                        </div>


                                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12" id="">
                                          <div class="form-group">
                                            <label for="sel1">SELECT REGION/COUNTRY</label>
                                            <select class="form-control" name="region" id="region">
                                                  <% Response.Write(getregion()); %>
                                            </select>
                                          </div>
                                        </div>

                                        <div class="menu-list" id="menu-list">
                                                  <div>
                                                    <li id="title" data-toggle='collapse' data-target='#products' class='collapsed'><a href='#'><i class='fa fa-gift fa-lg'></i>RECEPTION<span class='arrow'></span></a></li><ul>
                                                    <ul id="office">

                                                    </ul>
                                                            </div>
                                                  <div>
                                                    <li id="title2" data-toggle='collapse' data-target='#products4' class='collapsed'><a href='#'><i class='fa fa-gift fa-lg'></i>CONTRACTS<span class='arrow'></span></a></li><ul>
                                                    <ul id="office2">

                                                    </ul>
                                                  </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                              <div class="col-md-8 col-xs-12 col-sm-12 col-lg-7" id="">
                                  <div class="row">
                                      <div class="col-md-4 col-xs-12 col-sm-12 col-lg-4" id="">
                                          <label for="sel1">Date:</label>
                                          <div class="input-group date" id="datepicker1" data-provide="datepicker">
                                              <asp:TextBox ID="TextBox4" class="form-control pull-right" runat="server"></asp:TextBox>
                                              <div class="input-group-addon">
                                                  <span class="glyphicon glyphicon-th"></span>
                                              </div>
                                          </div>
                                      </div>
                                  </div>

                                  <div class="row">
                                      <div class="col-md-4 col-sm-12 col-xs-12 col-lg-4" id="">
                                          <div class="form-group">
                                              <label for="sel1">Country:</label>
                                              <select class="form-control" name="country" id="country">
                                                 <%-- <option disabled selected value>--Select an Option--</option>--%>
                                                  <% Response.Write(getcountries()); %>
                                              </select>
                                          </div>
                                      </div>

                                  </div>

                                  <div class="row">
                                      <div class="col-md-4 col-sm-12 col-xs-12 col-lg-4" id="Venue">
                                          <div class="form-group">
                                              <label for="sel1">Venue:</label>
                                              <asp:TextBox ID="TextBox1" class="form-control pull-right" runat="server" value="Inhouse"></asp:TextBox>
                                               <select class="form-control" name="venueInd" id="venueInd">


                                              </select>
                                          </div>
                                      </div>

                                  </div>

                                  <div class="row">
                                      <div class="col-md-4 col-sm-12 col-xs-12 col-lg-4" id="VenueGroup">
                                          <div class="form-group">

                                              <label for="sel1">Venue Group:</label>
                                                <asp:TextBox ID="TextBox2" class="form-control pull-right" runat="server" value="Inhouse"></asp:TextBox>
                                              <select class="form-control" name="venueGroup" id="venueGroup">
                                              </select>

                                          </div>
                                      </div>

                                  </div>

                                   <div class="row">
                                    <div class="col-md-4 col-sm-12 col-xs-12 col-lg-4" id="Groups">
                                        <div class="form-group">
                                            <label for="sel1">Group:</label>
                                            <select class="form-control" name="group" id="group">
                                                <option disabled selected value>--Select an Option--</option>
                                                <option value="PRE COOLING OFF">PRE COOLING OFF</option>
                                                <option value="POST COOLING OFF">POST COOLING OFF</option>
                                            </select>
                                        </div>
                                    </div>

                                </div>

                                  <div class="row">

                                              <div class="col-md-2 col-xs-9 col-sm-2 col-lg-2">
                                                  <label for="sel1">&nbsp;</label>
                                                  <asp:Button ID="Button1" runat="server" class="btn btn-primary pull-right btn-block" OnClick="Button1_Click" Text="Generate" />

                                              </div>

                                  </div>


                              </div>

                        </div>
                    </div>
                              </div>
                  </div>
              </div>
            </div>
        </div>
               </div>
               </form>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right">

          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
      </div>
    </div>

    <!-- compose -->
    <div class="compose col-md-6 col-xs-12">
      <div class="compose-header">
        New Message
        <button type="button" class="close compose-close">
          <span>×</span>
        </button>
      </div>

      <div class="compose-body">
        <div id="alerts"></div>

        <div class="btn-toolbar editor" data-role="editor-toolbar" data-target="#editor">
          <div class="btn-group">
            <a class="btn dropdown-toggle" data-toggle="dropdown" title="Font"><i class="fa fa-font"></i><b class="caret"></b></a>
            <ul class="dropdown-menu">
            </ul>
          </div>

          <div class="btn-group">
            <a class="btn dropdown-toggle" data-toggle="dropdown" title="Font Size"><i class="fa fa-text-height"></i>&nbsp;<b class="caret"></b></a>
            <ul class="dropdown-menu">
              <li>
                <a data-edit="fontSize 5">
                  <p style="font-size:17px">Huge</p>
                </a>
              </li>
              <li>
                <a data-edit="fontSize 3">
                  <p style="font-size:14px">Normal</p>
                </a>
              </li>
              <li>
                <a data-edit="fontSize 1">
                  <p style="font-size:11px">Small</p>
                </a>
              </li>
            </ul>
          </div>







        <div id="editor" class="editor-wrapper"></div>
      </div>

      <div class="compose-footer">
        <button id="send" class="btn btn-sm btn-success" type="button">Send</button>
      </div>
    </div>
    <!-- /compose -->

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- bootstrap-wysiwyg -->
    <script src="../vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js"></script>
    <script src="../vendors/jquery.hotkeys/jquery.hotkeys.js"></script>
    <script src="../vendors/google-code-prettify/src/prettify.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>



     <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"></script>

         <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/scroller/2.0.0/js/dataTables.scroller.min.js "></script>

               <script type="text/javascript">

            $(document).ready(function () {

                $('#datepicker1').datepicker({
                    format: "dd-mm-yyyy",
                    autoclose: true
                });



            });
        </script>

       <%--  <script>

            $('#form1').bind('keydown', function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                }
            });
        </script>--%>

        <script>

            $(document).ready(function () {


                    var region = $("#region option:selected").text();
                  //  alert(office);
                    $.ajax({

                        type: 'Post',
                        url: 'reportSlider.aspx/getReport',
                        contentType: "application/json; charset=utf-8",
                        data: "{'region':'" + region + "'}",
                        async: false,
                        success: function (data) {


    						$("#office2").empty();
    						subJson1 = JSON.parse(data.d);

    						 $("#office").empty();
    						subJson1 = JSON.parse(data.d);

    						$("#reception").empty();
    						subJson1 = JSON.parse(data.d);

    						$.each(subJson1, function (key, value) {

    							$.each(value, function (index1, value1) {

    								if (value1[2] == 'Reception') {

    									$("#office").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");


    								} else if (value1[2] == 'Contracts'){

    									$("#office2").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");
    								}

                                });

    						});

                        },
                        error: function () {

                        }

                    });


                    $("#region").change(function () {

                        var region = $("#region option:selected").text();
                        $.ajax({

                            type: 'Post',
                            url: 'reportSlider.aspx/getReport',
                            contentType: "application/json; charset=utf-8",
                            data: "{'region':'" + region + "'}",
                            async: false,
                            success: function (data) {


    							$("#office2").empty();
    							subJson1 = JSON.parse(data.d);

    							 $("#office").empty();
    							subJson1 = JSON.parse(data.d);

    							$("#reception").empty();
    							subJson1 = JSON.parse(data.d);

    							$("#page").empty();
    							subJson2 = JSON.parse(data.d);

    							$.each(subJson1, function (key, value) {

    							$.each(value, function (index1, value1) {

    								if (value1[2] == 'Reception') {

    									$("#office").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");


    								} else if (value1[2] == 'Contracts'){

    									$("#office2").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");
    								}

                                });

    						});



                            },
                            error: function () {

                            }

                        });
                    });



                $("#status").change(function() {

                    $("#venue").change();
                });

            });

        </script>


        


        <script>

            $(document).ready(function () {

                    var region = $("#region option:selected").text();
                  //  alert(office);
                    $.ajax({

                        type: 'Post',
                        url: 'reportSlider.aspx/getReport',
                        contentType: "application/json; charset=utf-8",
                        data: "{'region':'" + region + "'}",
                        async: false,
                        success: function (data) {


    						$("#office2").empty();
    						subJson1 = JSON.parse(data.d);

    						 $("#office").empty();
    						subJson1 = JSON.parse(data.d);

    						$("#reception").empty();
    						subJson1 = JSON.parse(data.d);

    						$.each(subJson1, function (key, value) {

    							$.each(value, function (index1, value1) {

    								if (value1[2] == 'Reception') {

    									$("#office").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");


    								} else if (value1[2] == 'Contracts'){

    									$("#office2").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");
    								}

                                });

    						});

                        },
                        error: function () {

                        }

                    });


                    $("#region").change(function () {

                        var region = $("#region option:selected").text();
                        $.ajax({

                            type: 'Post',
                            url: 'reportSlider.aspx/getReport',
                            contentType: "application/json; charset=utf-8",
                            data: "{'region':'" + region + "'}",
                            async: false,
                            success: function (data) {


    							$("#office2").empty();
    							subJson1 = JSON.parse(data.d);

    							 $("#office").empty();
    							subJson1 = JSON.parse(data.d);

    							$("#reception").empty();
    							subJson1 = JSON.parse(data.d);

    							$("#page").empty();
    							subJson2 = JSON.parse(data.d);

    							$.each(subJson1, function (key, value) {

    							$.each(value, function (index1, value1) {

    								if (value1[2] == 'Reception') {

    									$("#office").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");


    								} else if (value1[2] == 'Contracts'){

    									$("#office2").append("<li style='background-color:#535a62;'><a href=" + value1[1] + "><span class='glyphicon glyphicon-menu-right'></span>" + value1[0] + "</a></li>");
    								}

                                });

    						});



                            },
                            error: function () {

                            }

                        });
                    });



                $("#status").change(function() {

                    $("#venue").change();
                });

            });

        </script>




         <script>

        $(document).ready(function () {

                var country = $("#country option:selected").text();

                if(country=="India" || country=="INDIA"){

                    $("#venueInd").show();
                    $("#TextBox1").hide();

                    $("#venueGroup").hide();
                    $("#TextBox2").show();


				}

				else if (country == "GERMANY" || country == "ITALY" || country == "FRANCE" || country == "GREECE" || country == "IRELAND") {
					$("#venueInd").show();
                    $("#TextBox1").hide();

                    $("#venueGroup").hide();
					$("#TextBox2").show();

					$("#Groups").show();
                        $("#group").val('');

				} else {

                    $("#venueInd").show();
                    $("#TextBox1").hide();

                    $("#venueGroup").hide();
                    $("#TextBox2").show();
                }
              //  alert(office);
                $.ajax({

                    type: 'Post',
                    url: 'Inhouse.aspx/getVenue',
                    contentType: "application/json; charset=utf-8",
                    data: "{'country':'" + country + "'}",
                    async: false,
                    success: function (data) {
                   //     alert(data.d);
                        $("#venueInd").empty();
                        $("#venueInd").append("<option disabled selected value>--Select an Option--</option>");
                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                $("#venueInd").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
                            });


                        });



                    },
                    error: function () {

                    }

                });


                $("#country").change(function () {

                    var country = $("#country option:selected").text();

                        $("#venueInd").show();
                        $("#TextBox1").hide();

                        $("#venueGroup").hide();
                        $("#TextBox2").show();

                    //if (country == "India" || country == "INDIA") {

                    //    $("#venueInd").show();
                    //    $("#TextBox1").hide();

                    //    $("#venueGroup").hide();
                    //    $("#TextBox2").show();


                    //} else {

                    //    $("#venueInd").hide();
                    //    $("#TextBox1").show();

                    //    $("#venueGroup").show();
                    //    $("#TextBox2").hide();
                    //}



                    if (country == "INDONESIA" || country == "VIETNAM" || country == "THAILAND" || country == "INDIA"|| country == "India") {
                        $("#Groups").hide();
                        $("#group").val('');
                    } else {
                        $("#Groups").show();
                        $("#group").val('');
                    }

                    $.ajax({

                        type: 'Post',
                        url: 'Inhouse.aspx/getVenue',
                        contentType: "application/json; charset=utf-8",
                        data: "{'country':'" + country + "'}",
                        async: false,
                        success: function (data) {
                              // alert(data.d);
                               $("#venueInd").empty();
                               $("#venueInd").append("<option disabled selected value>--Select an Option--</option>");
                            subJson = JSON.parse(data.d);

                            $.each(subJson, function (key, value) {

                                $.each(value, function (index1, value1) {

                                    $("#venueInd").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
                                });


                            });



                        },
                        error: function () {

                        }

                    });
                });

                return false;


        });

    </script>


         <script>

             $(document).ready(function () {


                     var country = $("#country option:selected").text();
                     var venue = $("#TextBox1").val();
                     //  alert(venue);
                     $.ajax({

                         type: 'Post',
                         url: 'Inhouse.aspx/getVenueGroup',
                         contentType: "application/json; charset=utf-8",
                         data: "{'venue':'" + venue + "','country':'" + country + "'}",
                         async: false,
                         success: function (data) {
                             //    alert(data.d);
                             $("#venueGroup").empty();
                             $("#venueGroup").append("<option disabled selected value>--Select an Option--</option>");

                             subJson = JSON.parse(data.d);

                             $.each(subJson, function (key, value) {

                                 $.each(value, function (index1, value1) {

                                     $("#venueGroup").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
                                 });


                             });



                         },
                         error: function () {

                         }
                     });

                     $("#country").change(function () {
                         var country = $("#country option:selected").text();
                         var venue = $("#TextBox1").val();
                         //  alert(venue);
                         $.ajax({

                             type: 'Post',
                             url: 'Inhouse.aspx/getVenueGroup',
                             contentType: "application/json; charset=utf-8",
                             data: "{'venue':'" + venue + "','country':'" + country + "'}",
                             async: false,
                             success: function (data) {
                                 //    alert(data.d);
                                 $("#venueGroup").empty();
                                 $("#venueGroup").append("<option disabled selected value>--Select an Option--</option>");

                                 subJson = JSON.parse(data.d);

                                 $.each(subJson, function (key, value) {

                                     $.each(value, function (index1, value1) {

                                         $("#venueGroup").append("<option value='" + value1[0] + "'>" + value1[0] + "</option>");
                                     });


                                 });



                             },
                             error: function () {

                             }
                         });

                     });


        });

    </script>

            <script>

        $(document).ready(function () {

            $.ajax({

                type: 'Post',
                url: 'Inhouse.aspx/getAdminRights',
                contentType: "application/json; charset=utf-8",
                data: "{}",
                async: false,
                success: function (data) {

                    $("#task-table1 tbody").empty();

                    subJson = JSON.parse(data.d);

                    $.each(subJson, function (key, value) {

                        $.each(value, function (index1, value1) {


                                $("#task-table1 tbody").append("<tr><td><a href='"+value1[1]+"'>"+value1[0]+"</a></td></tr>");

                        });

                    });
                },
                error: function () {
                    $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                        $("#danger-alert").slideUp(500);
                    });
                }

            });
            return false;



        });

    </script>



        <script>

           /* $(document).ready(function () {

                $("#Button1").click(function (e) {
                    var country = $("#country option:selected").text();
                    if (country == "India" || country == "INDIA") {
                        var isValid = true;
                        if ($.trim($("#TextBox4").val()) == '') {
                            isValid = false;

                            $("#TextBox4").css({

                                "border": "1px solid red",

                                "background": "#FFCECE"
                            });
                            if (isValid == false)
                                e.preventDefault();


                        } else {
                            $("#TextBox4").css({

                                "border": "",

                                "background": ""

                            });

                        }

                        var isValid = true;
                        if ($.trim($("#country").val()) == '') {
                            isValid = false;

                            $("#country").css({

                                "border": "1px solid red",

                                "background": "#FFCECE"
                            });
                            if (isValid == false)
                                e.preventDefault();


                        } else {
                            $("#country").css({

                                "border": "",

                                "background": ""

                            });

                        }


                        var isValid = true;
                        if ($.trim($("#venueInd").val()) == '') {
                            isValid = false;

                            $("#venueInd").css({

                                "border": "1px solid red",

                                "background": "#FFCECE"
                            });
                            if (isValid == false)
                                e.preventDefault();


                        } else {
                            $("#venueInd").css({

                                "border": "",

                                "background": ""

                            });

                        }

                    } else {
                        var isValid = true;
                        if ($.trim($("#TextBox4").val()) == '') {
                            isValid = false;

                            $("#TextBox4").css({

                                "border": "1px solid red",

                                "background": "#FFCECE"
                            });
                            if (isValid == false)
                                e.preventDefault();


                        } else {
                            $("#TextBox4").css({

                                "border": "",

                                "background": ""

                            });

                        }


                        var isValid = true;
                        if ($.trim($("#country").val()) == '') {
                            isValid = false;

                            $("#country").css({

                                "border": "1px solid red",

                                "background": "#FFCECE"
                            });
                            if (isValid == false)
                                e.preventDefault();


                        } else {
                            $("#country").css({

                                "border": "",

                                "background": ""

                            });

                        }


                        var isValid = true;
                        if ($.trim($("#venueGroup").val()) == '') {
                            isValid = false;

                            $("#venueGroup").css({

                                "border": "1px solid red",

                                "background": "#FFCECE"
                            });
                            if (isValid == false)
                                e.preventDefault();


                        } else {
                            $("#venueGroup").css({

                                "border": "",

                                "background": ""

                            });

                        }
                    }



                });


            }); */

        </script>

         <script>

        $(document).ready(function () {

            $("#searchPro").keyup(function () {

                var profileID = $("#searchPro").val();

                $.ajax({

                    type: 'Post',
                    url: 'Inhouse.aspx/searchProfile',
                    contentType: "application/json; charset=utf-8",
                    data: "{'profileID':'" + profileID + "'}",
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        $("#task-table2 tbody").empty();
                        $("#x_content").hide();
                        $("#toprow").hide();
                        $("#task-table2").show();
                        $("#profileDetails").show();
                        $("#myPager").empty();

                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                if (value1[0] == "") {
                                    $("#task-table2").hide();
                                    $("#x_content").show();
                                    //  window.location.reload();
                                    $(window).scrollTop(0);
                                } else {

                                    //$("#task-table2 tbody").append("<tr><td><a href='" + value1[1] + "'>" + value1[0] + "</a></td></tr>");
                                    $("#task-table2 tbody").append("<tr><td><a href='" + value1[0] + "' id='profileclick'>" + value1[0] + "</a></td><td>" + value1[1] + "</td><td>" + value1[2] + "</td><td>" + value1[3] + "</td><td>" + value1[4] + "</td><td>" + value1[5] + "</td><td><a href=GuestCard.aspx?name=" + value1[0] + ">Guest Card</a></td></tr>");
                                }
                            });

                        });

                        jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                            "formatted-num-pre": function (a) {
                                a = (a === "-" || a === "") ? 0 : a.replace(/[^\d\-\.]/g, "");
                                return parseFloat(a);
                            },

                            "formatted-num-asc": function (a, b) {
                                return a - b;
                            },

                            "formatted-num-desc": function (a, b) {
                                return b - a;
                            }
                        });

                        jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                            "date-uk-pre": function (a) {
                                var ukDatea = a.split('-');
                                return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
                            },

                            "date-uk-asc": function (a, b) {
                                return ((a < b) ? -1 : ((a > b) ? 1 : 0));
                            },

                            "date-uk-desc": function (a, b) {
                                return ((a < b) ? 1 : ((a > b) ? -1 : 0));
                            }
                        });


                        $('#task-table2').DataTable({
                            deferRender: true,
                            scrollY: 400,
                            "bDestroy": true,
                            "bRetrieve": true,
                            "order": [[0, "asc"]],
                            aoColumnDefs: [
                               { type: 'formatted-num', targets: 0 },
                               { type: 'formatted-num', targets: 4 },
                               { type: 'date-uk', targets: 5 }
                            ]


                        });
                    },
                    error: function (xhr, status, error) {
                        var err = JSON.parse(xhr.responseText);
                        alert(err.Message);
                    }

                });
                return false;


            });






        });

    </script>


         <script>

        $(document).ready(function () {

            $(document).on('click','#profileclick',function() {

                var row = $(this).closest("tr");
                var profileID = row.find("td:eq(0)").text();
                //alert(profileID);
              //  var profileID = $("#profileclick").text();

                $.ajax({

                    type: 'Post',
                    url: 'Inhouse.aspx/getlink',
                    contentType: "application/json; charset=utf-8",
                    data: "{'profileID':'" + profileID + "'}",
                    async: false,
                    success: function (data) {

                     //   alert(data.d);

                        subJson = JSON.parse(data.d);

                        $.each(subJson, function (key, value) {

                            $.each(value, function (index1, value1) {

                                window.location.href =value1[0];

                            });

                        });
                    },
                    error: function () {
                        $("#danger-alert").fadeTo(1500, 500).slideUp(500, function () {
                            $("#danger-alert").slideUp(500);
                        });
                    }

                });
                return false;


            });

        });

    </script>


         <script>

            $(document).ready(function () {

                $(document).on('keypress', '#searchReports', function (event) {
                    var keycode = (event.keyCode ? event.keyCode : event.which);
                    if (keycode == '13') {
                        var val = $("#searchReports").val();

                        $.ajax({

                            type: 'Post',
                            url: 'Inhouse.aspx/searchReports',
                            contentType: "application/json; charset=utf-8",
                            data: "{'val':'" + val + "'}",
                            async: false,
                            success: function (data) {
                               // alert(data.d);
                                $("#productss0").empty();
                                $("#productss0").append("<input type='Text' style='color:black;' id='searchReports' class='form-control' placeholder='Search for reports'/>");
                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {

                                        if (value1[0] == "") {

                                        } else {


                                            $("#productss0").append("<li style='background-color:#535a62;'>  <a href=" + value1[1] + "?name=" + value1[3] + "><span class='glyphicon glyphicon-menu-right'></span> " + value1[0] + " </a></li>");
                                        }
                                    });

                                });


                            },
                            error: function (xhr, status, error) {
                                var err = JSON.parse(xhr.responseText);
                                alert(err.Message);
                            }

                        });
                        return false;

                    }
                });






            });

        </script>


       <script>

            $(document).ready(function () {

                $(document).on('keypress', '#searchReports1', function (event) {

                    var keycode = (event.keyCode ? event.keyCode : event.which);
                    if (keycode == '13') {

                        var val = $("#searchReports1").val();

                        $.ajax({

                            type: 'Post',
                            url: 'Inhouse.aspx/searchReports1',
                            contentType: "application/json; charset=utf-8",
                            data: "{'val':'" + val + "'}",
                            async: false,
                            success: function (data) {
                                // alert(data.d);
                                $("#productsss0").empty();
                                $("#productsss0").append("<input type='Text' style='color:black;' id='searchReports1' class='form-control' placeholder='Search By Country'/>");
                                subJson = JSON.parse(data.d);

                                $.each(subJson, function (key, value) {

                                    $.each(value, function (index1, value1) {

                                        if (value1[0] == "") {

                                        } else {


                                            $("#productsss0").append("<li style='background-color:#535a62;'>  <a href=" + value1[1] + "?name=" + value1[3] + "&office=" + value1[4] + "><span class='glyphicon glyphicon-menu-right'></span> " + value1[0] + " </a></li>");
                                        }
                                    });

                                });


                            },
                            error: function (xhr, status, error) {
                                var err = JSON.parse(xhr.responseText);
                                alert(err.Message);
                            }

                        });
                        return false;

                    }
                });






            });

        </script>
          <script src="./js/master.js"></script>
        <script type="text/javascript" src="https://app.getbeamer.com/js/beamer-embed.js" defer="defer"></script>
</body>
</html>
