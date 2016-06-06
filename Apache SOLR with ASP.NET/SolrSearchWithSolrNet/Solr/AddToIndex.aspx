<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddToIndex.aspx.cs" Inherits="Solr.AddToIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>Add player</h1>

<p>First name: <asp:TextBox ID="tbFirstName" runat="server" />
Last name<asp:TextBox ID="tbLastName" runat="server" />
<asp:DropDownList ID="ddlPosition" runat="server">
	<asp:ListItem Text="Goalkeeper" />
	<asp:ListItem Text="Defender" />
	<asp:ListItem Text="Midfielder" />
	<asp:ListItem Text="Forward" />
</asp:DropDownList>
<asp:Button ID="btnSubmit" OnClick="AddPlayer" Text="Add player" runat="server" />
</p>
</asp:Content>
