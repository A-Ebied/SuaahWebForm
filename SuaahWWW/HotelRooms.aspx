<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HotelRooms.aspx.cs" Inherits="HotelRooms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <br />
    <br />

    <%--<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>--%>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="text-center m-5">

                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" CssClass="btn btn-danger dropdown-toggle" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>


                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Load Combo" CssClass="btn btn-primary"/>
            </div>
            <br />

            <asp:GridView ID="GridView4" runat="server" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" CssClass="table table-hover table-condensed"></asp:GridView>
            <br />

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

