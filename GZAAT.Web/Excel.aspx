<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Base.Master" AutoEventWireup="true" CodeBehind="Excel.aspx.cs" Inherits="GZAAT.Web.Excel" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageSection" runat="server">
    <h1><%= Resources.ApplicationResources.UploadExcel %></h1>
    <br />
    <telerik:RadUpload ID="RadUpload1" runat="server"
        AllowedFileExtensions=".xls,.xlsx"
        AllowedMimeTypes="application/excel,application/vnd.ms-excel,application/x-excel,application/x-msexcel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        ControlObjectsVisibility="None"
        MaxFileInputsCount="1"
        >

    </telerik:RadUpload>
    <telerik:RadButton ID="btnGet" runat="server" Icon-PrimaryIconCssClass="rbUpload" Text="<%$ Resources:ApplicationResources, Upload %>" OnClick="btnGet_Click" />
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
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="LastName" HeaderText="<%$ Resources:ApplicationResources, LastName %>" SortExpression="LastName" UniqueName="LastName" FilterControlAltText="Filter LastName column" />
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="FirstName" HeaderText="<%$ Resources:ApplicationResources, FirstName %>"  SortExpression="FirstName" UniqueName="FirstName" FilterControlAltText="Filter FirstName column" />
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="Grade" HeaderText="<%$ Resources:ApplicationResources, Grade %>"  FilterControlAltText="Filter Grade column" SortExpression="StudentID" UniqueName="Grade">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="StudentID" HeaderText="<%$ Resources:ApplicationResources, PersonalNumber %>" FilterControlAltText="Filter StudentID column" SortExpression="StudentID" UniqueName="StudentID">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="Parent1LastName" HeaderText="<%$ Resources:ApplicationResources, Parent1LastName %>" FilterControlAltText="Filter Parent1LastName column" UniqueName="Parent1LastName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="Parent1FirstName" HeaderText="<%$ Resources:ApplicationResources, Parent1FirstName %>" FilterControlAltText="Filter Parent1FirstName column" UniqueName="Parent1FirstName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px"  DataField="Parent1Mobile" HeaderText="<%$ Resources:ApplicationResources, Parent1Mobile %>" FilterControlAltText="Filter Parent1Mobile column" UniqueName="Parent1Mobile">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="Parent2LastName" HeaderText="<%$ Resources:ApplicationResources, Parent2LastName %>" FilterControlAltText="Filter Parent2LastName column" UniqueName="Parent2LastName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="Parent2FirstName" HeaderText="<%$ Resources:ApplicationResources, Parent2FirstName %>" FilterControlAltText="Filter Parent2FirstName column" UniqueName="Parent2FirstName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px"  DataField="Parent2Mobile"  HeaderText="<%$ Resources:ApplicationResources, Parent2Mobile %>"  FilterControlAltText="Filter Parent2Mobile column" UniqueName="Parent2Mobile">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px"  DataField="CurrencyCode" HeaderText="<%$ Resources:ApplicationResources, Currency %>" FilterControlAltText="Filter CurrencyCode column" UniqueName="CurrencyCode">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlWidth="70px" DataField="Debt" DataType="System.Decimal" HeaderText="<%$ Resources:ApplicationResources, Debt %>" SortExpression="Debt" UniqueName="Debt" DataFormatString="{0:f0}" />
            </Columns>

            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>
        </MasterTableView>

        <FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
</asp:Content>
