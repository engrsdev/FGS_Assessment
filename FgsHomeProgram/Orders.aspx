<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="FgsHomeProgram.Orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>&nbsp

                <asp:DropDownList runat="server" ID="ddlist" OnSelectedIndexChanged="ddlist_SelectedIndexChanged">
                    <asp:ListItem Text="ALL" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="CREATED" Value="2"></asp:ListItem>
                    <asp:ListItem Text="FAILED" Value="3"></asp:ListItem>
                </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="Filter" OnClick="Button1_Click" />
            <input type="button" id="btnReset" onclick="Reset()" value="Reset   " />

        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" AllowSorting="true">
                <Columns>
                    <asp:BoundField ItemStyle-Width="150px" DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Address1" HeaderText="Address1" SortExpression="Address1" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Address2" HeaderText="Address2" SortExpression="Address2" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                   <%-- <asp:TemplateField HeaderText="Delete Row">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" CommandName="Delete" OnRowDataBound="OnRowDataBound" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function Reset() {
        window.location.reload(true);
    }
</script>
