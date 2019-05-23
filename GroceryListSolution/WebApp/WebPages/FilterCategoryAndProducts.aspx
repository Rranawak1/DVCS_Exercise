﻿<%@ Page Title="Filtering Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilterCategoryAndProducts.aspx.cs" Inherits="WebApp.WebPages.FilterCategoryAndProducts" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Query: ODS</h1>

    <div class="col-md-offset-3">
	<uc1:MessageUserControl runat="server" id="MessageUserControl" />
    <asp:Label ID="label1" runat="server" Text="Select a Category "></asp:Label>
    &nbsp;&nbsp;
    <asp:ObjectDataSource ID="CategoryListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Category_List" 
                              TypeName="GroceryListSystem.BLL.CategoryController"></asp:ObjectDataSource>
    <asp:DropDownList ID="CategoryList" runat="server"></asp:DropDownList>
    &nbsp;&nbsp;
    <asp:LinkButton ID="FetchButton" runat="server" CausesValidation="false">Fetch</asp:LinkButton>
    <br /><br />

        <asp:ObjectDataSource ID="ProductGridViewListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Category_GetByProduct" TypeName="GroceryListSystem.BLL.ProductController">
            <SelectParameters>
				<asp:ControlParameter ControlID="CategoryList" PropertyName="SelectedValue" Name="categoryid" Type="Int32" DefaultValue="0"></asp:ControlParameter>
			</SelectParameters>
		</asp:ObjectDataSource>

		<asp:GridView ID="ProductList" runat="server" AutoGenerateColumns="False" DataSourceID="ProductGridViewListODS" AllowPaging="True" CssClass="table table-striped" GridLines="Horizontal" BorderStyle="None" >
			<Columns>
				<asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID"></asp:BoundField>
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
				<asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
				<asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount"></asp:BoundField>
				<asp:BoundField DataField="UnitSize" HeaderText="UnitSize" SortExpression="UnitSize"></asp:BoundField>
				<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" Visible="false"></asp:BoundField>
				<asp:CheckBoxField DataField="Taxable" HeaderText="Taxable" SortExpression="Taxable"></asp:CheckBoxField>
				<asp:BoundField DataField="DescriptionUnitSize" HeaderText="DescriptionUnitSize" ReadOnly="True" SortExpression="DescriptionUnitSize" Visible="false"></asp:BoundField>
			</Columns>
        </asp:GridView>

        

    </div>
</asp:Content>
