<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Base.Master" AutoEventWireup="true" CodeBehind="1C.aspx.cs" Inherits="GZAAT.Web._1C" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageSection" runat="server">
    <h1><%= Resources.ApplicationResources.DebtorList %></h1>
    <br />
    <telerik:RadButton ID="btnGet" runat="server" Icon-PrimaryIconCssClass="rbDownload" Text="<%$ Resources:ApplicationResources, GetDebtListFrom1C %>" OnClick="btnGet_Click" />
    <telerik:RadButton ID="btnSave" runat="server" Icon-PrimaryIconCssClass="rbSave" Text="<%$ Resources:ApplicationResources, SaveForSend %>" OnClick="btnSave_Click" />
    <br />
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" AllowSorting="True" CellSpacing="0" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" ShowGroupPanel="True" AutoGenerateColumns="False">
        <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="True" ReorderColumnsOnClient="True">
        </ClientSettings>
        <MasterTableView CommandItemDisplay="Top">
            <CommandItemSettings ShowAddNewRecordButton="False" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />

            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>

            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>

            <Columns>
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="Code" HeaderText="<%$ Resources:ApplicationResources, Code1C %>" SortExpression="Code" UniqueName="Code" />
                <telerik:GridBoundColumn DataField="LastName" HeaderText="<%$ Resources:ApplicationResources, LastName %>" SortExpression="LastName" UniqueName="LastName" />
                <telerik:GridBoundColumn DataField="FirstName" HeaderText="<%$ Resources:ApplicationResources, FirstName %>" SortExpression="FirstName" UniqueName="FirstName" />
                <telerik:GridBoundColumn DataField="Grade" HeaderText="<%$ Resources:ApplicationResources, Grade %>" SortExpression="Grade" UniqueName="Grade" />
                <telerik:GridBoundColumn FilterControlWidth="90px" DataField="StudentID" HeaderText="<%$ Resources:ApplicationResources, PersonalNumber %>" SortExpression="StudentID" UniqueName="StudentID" />
                <telerik:GridBoundColumn DataField="Parent1LastName" HeaderText="<%$ Resources:ApplicationResources, Parent1LastName %>" SortExpression="Parent1LastName" UniqueName="Parent1LastName" />
                <telerik:GridBoundColumn DataField="Parent1FirstName" HeaderText="<%$ Resources:ApplicationResources, Parent1FirstName %>" SortExpression="Parent1FirstName" UniqueName="Parent1FirstName" />
                <telerik:GridBoundColumn FilterControlWidth="100px" DataField="Parent1Mobile" HeaderText="<%$ Resources:ApplicationResources, Parent1Mobile %>" SortExpression="Parent1Mobile" UniqueName="Parent1Mobile" />
                <telerik:GridBoundColumn DataField="Parent2LastName" HeaderText="<%$ Resources:ApplicationResources, Parent2LastName %>" SortExpression="Parent2LastName" UniqueName="Parent2LastName" />
                <telerik:GridBoundColumn DataField="Parent2FirstName" HeaderText="<%$ Resources:ApplicationResources, Parent2FirstName %>" SortExpression="Parent2FirstName" UniqueName="Parent2FirstName" />
                <telerik:GridBoundColumn FilterControlWidth="100px" DataField="Parent2Mobile" HeaderText="<%$ Resources:ApplicationResources, Parent2Mobile %>" SortExpression="Parent2Mobile" UniqueName="Parent2Mobile" />
                <telerik:GridBoundColumn FilterControlWidth="90px" DataField="Debt" DataType="System.Double" HeaderText="<%$ Resources:ApplicationResources, Debt %>" SortExpression="Debt" UniqueName="Debt" DataFormatString="{0:f0}" />
            </Columns>

            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>
        </MasterTableView>

        <FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
</asp:Content>