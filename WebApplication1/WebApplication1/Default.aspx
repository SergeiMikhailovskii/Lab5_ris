<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    Amount
    <asp:TextBox ID="SumTextBox" runat="server"></asp:TextBox>
    <asp:CustomValidator runat="server" id="cusCustom" controltovalidate="SumTextBox" onservervalidate="cusCustom_ServerValidate" errormessage="Illegal format" />

    <asp:DropDownList ID="CurrencyFromList" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="CurrencyToList" runat="server">
    </asp:DropDownList>
    <asp:Button ID="CalculateBtn" runat="server" Text="Convert" OnClick="CalculateBtn_Click" />
    <asp:Label ID="ResultLb" runat="server" Text="Label" Visible="False"></asp:Label>


</asp:Content>
