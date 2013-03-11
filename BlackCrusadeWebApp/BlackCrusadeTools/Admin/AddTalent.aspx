<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTalent.aspx.cs" Inherits="WebApplication1.Admin.AddTalent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=BlackCrusadeEntities" DefaultContainerName="BlackCrusadeEntities" 
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="TalentSpells">
    </asp:EntityDataSource>


    <form id="form1" runat="server">
        <asp:EntityDataSource ID="TestEntityDataSource" runat="server" ConnectionString="name=BlackCrusadeEntities" DefaultContainerName="BlackCrusadeEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Sifus">
        </asp:EntityDataSource>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="NewGridView" runat="server">
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
<%--    <asp:EntityDataSource ID="GridViewEntityDataSource" runat="server" 
    ContextTypeName="Rvl.Demo.AspNet4.EF.WebApplication.Dal.AdventureWorksEntities" 
    ConnectionString="name=AdventureWorksEntities" DefaultContainerName="AdventureWorksEntities" 
    EntitySetName="Product" 
    OnQueryCreated="GridViewEntityDataSource_QueryCreated">
    </asp:EntityDataSource>--%>
    <div>
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataKeyNames="Id" OnRowEditing="GridView1_RowEditing" style="margin-left: 0px">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:CommandField ShowInsertButton="true" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="GodId" HeaderText="GodId" SortExpression="GodId" />
                <asp:BoundField DataField="TalentName" HeaderText="TalentName" SortExpression="Name" />
                <asp:BoundField DataField="TalentDescription" HeaderText="TalentDescription" SortExpression="TalentDescription" />
                <asp:BoundField DataField="WasRevised" HeaderText="WasRevised" SortExpression="WasRevised" />
                <asp:BoundField DataField="Tier" HeaderText="Tier" SortExpression="Tier" />
                <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost" />
                <asp:BoundField DataField="GodName" HeaderText="GodName" ReadOnly="True" SortExpression="GodName" Visible="False" />
                <asp:BoundField DataField="AttributeName" HeaderText="AttributeName" SortExpression="AttributeName" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="EntityDataSource1" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Id">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:CommandField ShowInsertButton="true" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CheckBoxField DataField="Revised" HeaderText="Revised" SortExpression="Revised" />
                <asp:BoundField DataField="WhichGod" HeaderText="WhichGod" SortExpression="WhichGod" />
                <asp:BoundField DataField="Tier" HeaderText="Tier" SortExpression="Tier" />
                <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="True" />
                <asp:BoundField DataField="AttributeType" HeaderText="AttributeType" SortExpression="AttributeType" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:GridView ID="TestGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="TestEntityDataSource">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Desc" HeaderText="Desc" SortExpression="Desc" />
                <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
