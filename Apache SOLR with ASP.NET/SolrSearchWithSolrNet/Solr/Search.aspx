<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Solr.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Search</h1>
    <p>(Try searching the following: <a href="Search.aspx?q=*:*">*:*</a>, <a href="Search.aspx?q=midfielder">midfielder</a>,<a href="Search.aspx?q=Forward">Forward</a>)</p>
    <p>
        <asp:TextBox ID="tbSearch" runat="server" />
        <asp:Button ID="btnSubmit" OnClick="DoSearch" Text="Search" runat="server" />

        <asp:Literal ID="litSearchSuggestion" runat="server" />
        <asp:Literal ID="litNoOfHits" runat="server" />
    </p>

    <asp:Repeater ID="rptResults" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <th>Id</th>
                    <th>First name</th>
                    <th>Last name</th>
                    <th>Position</th>
                    <th>Remove from index</th>
                </thead>
                <tbody>
        </HeaderTemplate>
        <FooterTemplate></tbody></table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("id") %></td>
                <td><%#Eval("firstname") %></td>
                <td><%#Eval("lastname") %></td>
                <td><%#Eval("position") %></td>
                <td><a href="RemoveFromIndex.aspx?id=<%#Eval("id") %>" title="Remove from index">Remove</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
