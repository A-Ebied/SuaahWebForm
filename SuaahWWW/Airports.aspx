<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Airports.aspx.cs" Inherits="Airport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" Width="1330px" CssClass="table table-hover table-condensed" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" PageSize="5">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="1260px" CssClass="table table-hover table-condensed" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSource2" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnPageIndexChanging="DetailsView1_PageIndexChanging">
            <Fields>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="Governorate" HeaderText="Governorate" SortExpression="Governorate" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>" SelectCommand="SELECT [Id], [Name], [Country] FROM [Airport]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>" DeleteCommand="DELETE FROM [Airport] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Airport] ([Name], [Country], [Governorate], [City], [Description]) VALUES (@Name, @Country, @Governorate, @City, @Description)" SelectCommand="SELECT * FROM [Airport] WHERE ([Id] = @Id)" UpdateCommand="UPDATE [Airport] SET [Name] = @Name, [Country] = @Country, [Governorate] = @Governorate, [City] = @City, [Description] = @Description WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="Governorate" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="Governorate" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>

