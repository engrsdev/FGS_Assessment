﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="FgsHomeProgram.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="ImportCSV"  />
        </div>
    </form>
</body>
</html>
