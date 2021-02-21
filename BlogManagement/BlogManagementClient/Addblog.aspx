<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addblog.aspx.cs" Inherits="BlogManagementClient.Addblog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            width: 455px;
            height: 157px;
            margin-left: 106px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            Title
            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 146px" Width="447px"></asp:TextBox>
            <br />
            <br />
            Description <asp:TextBox id="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" /><br />
            <br />
            <br />
            Date&amp;Time of upload
            <asp:TextBox ID="TextBox2" runat="server" TextMode="DateTimeLocal" style="margin-left: 31px" Width="449px"></asp:TextBox>
            

             <p>
            <asp:Button ID="Button1" runat="server"  Text="Upload Blog" OnClick="Button1_Click" />
        </p>
        </div>
    </form>
</body>
</html>
