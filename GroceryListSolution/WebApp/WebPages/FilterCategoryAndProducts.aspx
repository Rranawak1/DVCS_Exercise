<%@ Page Title="Filtering Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilterCategoryAndProducts.aspx.cs" Inherits="WebApp.WebPages.FilterCategoryAndProducts" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Query: ODS</h1>

    <div class="col-md-offset-3">
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
                <asp:ControlParameter ControlID="CategoryList" PropertyName="SelectedValue" Name="categoryid" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="ProductList" runat="server" AutoGenerateColumns="False" DataSourceID="ProductGridViewListODS" >
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount"></asp:BoundField>
                <asp:BoundField DataField="UnitSize" HeaderText="UnitSize" SortExpression="UnitSize"></asp:BoundField>
                <asp:CheckBoxField DataField="Taxable" HeaderText="Taxable" SortExpression="Taxable"></asp:CheckBoxField>
            </Columns>
        </asp:GridView>

        

    </div>
</asp:Content>
