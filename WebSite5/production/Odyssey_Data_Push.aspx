<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Odyssey_Data_Push.aspx.cs" Inherits="WebSite5_production_Odyssey_Data_Push" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src='select2/dist/js/select2.min.js' type='text/javascript'></script>
    <link href='select2/dist/css/select2.min.css' rel='stylesheet' type='text/css'>
    <style>
        body{background-color:darkgrey; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
              <div style="margin-top:300px;">
          <%--<select id='selUser' style='width:350px;' name="memberNo">
              <option disabled selected value>Select an Option</option>
              <% Response.Write(getAllMembers()); %>
              </select> <br /><br --%>
              <asp:Button ID="Button1" runat="server" style="width:80px; height:30px;" Text="Start" OnClick="Button1_Click" /> <asp:Button ID="Button2" runat="server" style="width:80px; height:30px;" Text="Stop"  OnClick="Button2_Click"  />
              <br /><br />
              <asp:Label ID="label1" runat="server" style="color:green"></asp:Label>
              </div>
       </center>

    </form>

    <script>
        $(document).ready(function () {
            $("#selUser").select2();
            $("#selUser").change(function () {
            $("#label1").text("");
            });
        });
    </script>
    



</body>
</html>
