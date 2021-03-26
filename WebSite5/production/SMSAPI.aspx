<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMSAPI.aspx.cs" Inherits="WebSite5_production_SMSAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="contractNo"></asp:TextBox>
         <asp:TextBox runat="server" ID="customerName"></asp:TextBox>
        <asp:TextBox runat="server" ID="phone"></asp:TextBox>
        <asp:TextBox ID="message" runat="server" Text="Congratulations and Welcome to The Karma Group. We have received with thanks the payment of Rs.40000/- towards your Karma Group Membership Purchase. Should you have any queries please contact us on +91-832-2720500-506." TextMode="MultiLine">Congratulations and Welcome to The Karma Group. We have received with thanks the payment of Rs.40000/- towards your Karma Group Membership Purchase. Should you have any queries please contact us on +91-832-2720500-506.</asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
      
    </form>
</body>
</html>
