<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="NewRfq.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Requisition Manager
    </h2>
  
  <table>
  <tr>
	<td>
		<fieldset>
		<legend>Bill To:</legend>
		</fieldset>
	</td>
	<td>
		<fieldset>
		<legend>Ship To:</legend>
		</fieldset>
	</td>
  </tr>
  </table>
	<asp:GridView ID="GridViewProducts" runat="server" 
	AutoGenerateColumns="false"
	EmptyDataText="Select from below to add items"
	ShowHeaderWhenEmpty="true"
	>
		<Columns>
		<asp:TemplateField>
			<HeaderTemplate>Qty</HeaderTemplate>
			<ItemTemplate>&nbsp;</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>UOM</HeaderTemplate>
			<ItemTemplate>&nbsp;</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>Product</HeaderTemplate>
			<ItemTemplate>&nbsp;</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>Unit Price</HeaderTemplate>
			<ItemTemplate>&nbsp;</ItemTemplate>
		</asp:TemplateField>
		</Columns>
	</asp:GridView>

	Add Item: 
	<asp:DropDownList ID="DropDownList" runat="server">
		<asp:ListItem Value="1">PTO Bags (Perforated Bags on Rolls)</asp:ListItem>
		<asp:ListItem Value="2">Loose Bags</asp:ListItem>
		<asp:ListItem Value="3">PTO Sheets (Perforated Sheets on Rolls)</asp:ListItem>
		<asp:ListItem Value="4">Loose Sheets </asp:ListItem>
		<asp:ListItem Value="5">Tubing</asp:ListItem>
		<asp:ListItem Value="6">Sheeting</asp:ListItem>
		<asp:ListItem Value="7">CGP (Construction Grade Poly)</asp:ListItem>
	</asp:DropDownList>
</asp:Content>
