<%@ Page Language="C#" AutoEventWireup="true" CodeFile="googlesign.aspx.cs" Inherits="Contractsite_googlesign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
    <script src="https://apis.google.com/js/platform.js" async defer></script>
   <meta name="google-signin-client_id" content="606504304030-n75chncdgcj30pkjrtmu6dnscdljb5ol.apps.googleusercontent.com">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>

        function SI()
        {
            alert('hi');
            var profile = googleUser.getBasicProfile();
            var email = profile.getEmail();

            alert(profile + '  ' + email);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" name="b1" id="b1" value="sign in" onclick="SI();" />
        <asp:Button ID="Button1" runat="server" Text="ok" OnClick="Button1_Click" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
