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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="NewGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCancelingEdit="NewGridView_RowCancelingEdit" OnRowCommand="NewGridView_RowCommand" OnRowDeleting="NewGridView_RowDeleting" OnRowEditing="NewGridView_RowEditing" OnRowUpdating="NewGridView_RowUpdating" ShowFooter="True" OnRowDataBound="NewGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="TalentName" SortExpression="TalentName">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTalentName" runat="server" Text='<%# Bind("TalentName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewTalentName" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("TalentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TalentDescription" SortExpression="TalentDescription">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("TalentDescription") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewDescription" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TalentDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tier" SortExpression="Tier">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTier" runat="server" Text='<%# Bind("Tier") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewTier" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Tier") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cost" SortExpression="Cost">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCost" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewCost" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Cost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GodName" SortExpression="GodName">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlGodName" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlNewGodName" runat="server">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("GodName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AttributeName" SortExpression="AttributeName">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlAttributeName" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlNewAttributeName" runat="server">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("AttributeName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WasRevised" SortExpression="WasRevised">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkWasRevised" runat="server" Checked='<%# Bind("WasRevised") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("WasRevised") %>' Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Enabled="true"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAddNew" runat="server" CommandName="AddNew">Add New</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>


                        
    </form>
</body>
</html>
