<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Airlines.aspx.cs" Inherits="Airline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1334px" CssClass="table table-hover table-condensed" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Code" DataSourceID="SqlDataSource1" PageSize="5">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" SortExpression="Code" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="1335px" CssClass="table table-hover table-condensed" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="Code" DataSourceID="SqlDataSource2" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated">
            <Fields>
                <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" SortExpression="Code" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </p>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>" SelectCommand="SELECT [Code], [Name], [Country] FROM [Airline]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>" DeleteCommand="DELETE FROM [Airline] WHERE [Code] = @Code" InsertCommand="INSERT INTO [Airline] ([Code], [Name], [Country], [Description]) VALUES (@Code, @Name, @Country, @Description)" SelectCommand="SELECT * FROM [Airline] WHERE ([Code] = @Code)" UpdateCommand="UPDATE [Airline] SET [Name] = @Name, [Country] = @Country, [Description] = @Description WHERE [Code] = @Code">
        <DeleteParameters>
            <asp:Parameter Name="Code" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Country" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="Code" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Country" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

