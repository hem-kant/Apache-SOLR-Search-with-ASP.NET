<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Indexer.aspx.cs" Inherits="Solr.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Re-index</h1>
<p><asp:Button ID="btnReIndex" Text="Push to re-index" OnClick="ReIndex" runat="server" /></p>
</asp:Content>
