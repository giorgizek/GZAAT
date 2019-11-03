<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Base.Master" AutoEventWireup="true" CodeBehind="DebtList.aspx.cs" Inherits="GZAAT.Web.SMSList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageSection" runat="server">
    <h1><%= Resources.ApplicationResources.DebtorList %></h1>
    <br />

    <telerik:RadGrid ID="gridSMS" runat="server" DataSourceID="dsMaster" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" ShowGroupPanel="True">
        <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="True" ReorderColumnsOnClient="True">
        </ClientSettings>
        <MasterTableView DataSourceID="dsMaster" DataKeyNames="ID,MobileID" AllowMultiColumnSorting="True" CommandItemDisplay="Top">
            <CommandItemSettings ShowAddNewRecordButton="False" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />

            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>

            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>

            <Columns>
                <%--<telerik:GridBoundColumn DataField="ID" DataType="System.Int32" HeaderText="ID" SortExpression="ID" UniqueName="ID" Visible="False" />
                <telerik:GridBoundColumn DataField="MobileID" DataType="System.Int32" HeaderText="MobileID" SortExpression="MobileID" UniqueName="MobileID" Visible="False" />--%>
                <telerik:GridDateTimeColumn FilterControlWidth="100px" EnableRangeFiltering="true" PickerType="DatePicker" DataField="Date" DataFormatString="{0:d}" DataType="System.DateTime" HeaderText="<%$ Resources:ApplicationResources, Date %>" SortExpression="Date" UniqueName="Date" />
                <%--<telerik:GridBoundColumn FilterControlWidth="70px" DataField="Code1C" HeaderText="<%$ Resources:ApplicationResources, Code1C %>" SortExpression="Code1C" UniqueName="Code1C" />--%>
                <telerik:GridBoundColumn DataField="Name" HeaderText="<%$ Resources:ApplicationResources, StudentName %>" SortExpression="Name" UniqueName="Name" />

                <telerik:GridNumericColumn FilterControlWidth="90px" DataField="Amount" DataType="System.Decimal" HeaderText="<%$ Resources:ApplicationResources, Debt %>" SortExpression="Amount" UniqueName="Amount" DataFormatString="{0:f0}" />

                <telerik:GridBoundColumn FilterControlWidth="100px" DataField="Mobile" HeaderText="<%$ Resources:ApplicationResources, Mobile %>" SortExpression="Mobile" UniqueName="Mobile" />
                <telerik:GridBoundColumn DataField="MobileOwner" HeaderText="<%$ Resources:ApplicationResources, MobileOwner %>" SortExpression="MobileOwner" UniqueName="MobileOwner" Visible="True" />
               <%-- <telerik:GridDropDownColumn FilterControlWidth="90px" DataField="RelationTypeID" CurrentFilterFunction="EqualTo" DataType="System.Byte" HeaderText="<%$ Resources:ApplicationResources, RelationTypeColumnHeaderText %>" SortExpression="RelationTypeID" UniqueName="RelationTypeID" DataSourceID="dsRelationType" ListTextField="Name" ListValueField="ID">
                    <FilterTemplate>
                        <telerik:RadComboBox ID="cmbRelationTypeID" runat="server" Width="90px"
                            DataSourceID="dsRelationType"
                            DataTextField="Name"
                            DataValueField="ID"
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("RelationTypeID").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="RelationTypeIDSelectedIndexChanged"
                            AppendDataBoundItems="true">
                            <Items>
                                <telerik:RadComboBoxItem />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
                            <script type="text/javascript">
                                function RelationTypeIDSelectedIndexChanged(sender, args) {
                                    var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                    tableView.filter("RelationTypeID", args.get_item().get_value(), "EqualTo");
                                }
                            </script>
                        </telerik:RadCodeBlock>
                    </FilterTemplate>
                </telerik:GridDropDownColumn>--%>
                <telerik:GridDropDownColumn FilterControlWidth="90px" DataField="StatusID" DataType="System.Byte" HeaderText="<%$ Resources:ApplicationResources, Status %>" SortExpression="StatusID" UniqueName="StatusID" DataSourceID="dsDebtStatus" ListTextField="Name" ListValueField="ID">
                    <FilterTemplate>
                        <telerik:RadComboBox ID="cmbStatusID" runat="server" Width="90px"
                            DataSourceID="dsDebtStatus"
                            DataTextField="Name"
                            DataValueField="ID"
                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("StatusID").CurrentFilterValue %>'
                            OnClientSelectedIndexChanged="StatusIDSelectedIndexChanged"
                            AppendDataBoundItems="true">
                            <Items>
                                <telerik:RadComboBoxItem />
                            </Items>
                        </telerik:RadComboBox>

                        <telerik:RadCodeBlock ID="RadScriptBlock2" runat="server">
                            <script type="text/javascript">
                                function StatusIDSelectedIndexChanged(sender, args) {
                                    var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                    tableView.filter("StatusID", args.get_item().get_value(), "EqualTo");
                                }
                            </script>
                        </telerik:RadCodeBlock>
                    </FilterTemplate>
                </telerik:GridDropDownColumn>
                <telerik:GridNumericColumn FilterControlWidth="50px" DataField="TryCount" DataType="System.Byte" HeaderText="<%$ Resources:ApplicationResources, TryCount %>" SortExpression="TryCount" UniqueName="TryCount" />
                <telerik:GridBoundColumn FilterControlWidth="250px" DataField="Message" HeaderText="<%$ Resources:ApplicationResources, Message %>" SortExpression="Message" UniqueName="Message" />
                <telerik:GridDateTimeColumn FilterControlWidth="150px" PickerType="DateTimePicker" DataField="SentDate" DataType="System.DateTime" HeaderText="<%$ Resources:ApplicationResources, SentDate %>" SortExpression="SentDate" UniqueName="SentDate" />

                <telerik:GridBoundColumn FilterControlWidth="100px" DataField="PersonalNumber" HeaderText="<%$ Resources:ApplicationResources, PersonalNumber %>" SortExpression="PersonalNumber" UniqueName="PersonalNumber" />
                <telerik:GridBoundColumn FilterControlWidth="50px" DataField="Currency" HeaderText="<%$ Resources:ApplicationResources, Currency %>" SortExpression="Currency" UniqueName="Currency" Visible="false" />
                <telerik:GridDateTimeColumn FilterControlWidth="150px" PickerType="DateTimePicker" DataField="CreateDate" DataType="System.DateTime" HeaderText="<%$ Resources:ApplicationResources, CreateDate %>" SortExpression="CreateDate" UniqueName="CreateDate" Visible="false" />
                <telerik:GridBoundColumn DataField="Grade" HeaderText="<%$ Resources:ApplicationResources, Grade %>" FilterControlAltText="Filter Grade column" UniqueName="Grade">
                </telerik:GridBoundColumn>
            </Columns>

            <SortExpressions>
                <telerik:GridSortExpression FieldName="Date" SortOrder="Descending" />
            </SortExpressions>

            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>

            <DetailTables>
                <telerik:GridTableView runat="server" DataSourceID="dsDetail" DataKeyNames="ID" AllowFilteringByColumn="true" AllowPaging="False" AllowSorting="False" GroupsDefaultExpanded="False">
                    <ParentTableRelation>
                        <telerik:GridRelationFields DetailKeyField="DebtID" MasterKeyField="ID" />
                        <telerik:GridRelationFields DetailKeyField="MobileID" MasterKeyField="MobileID" />
                    </ParentTableRelation>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="Date" DataType="System.DateTime" HeaderText="Date" UniqueName="SMSDetailLogDate" />
                        <telerik:GridBoundColumn DataField="URL" HeaderText="URL" UniqueName="SMSDetailLogURL" />
                        <telerik:GridBoundColumn DataField="Response" HeaderText="Response" UniqueName="SMSDetailLogResponse" />
                        <telerik:GridBoundColumn DataField="Exception" HeaderText="Exception" UniqueName="SMSDetailLogException" />
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </telerik:GridTableView>
            </DetailTables>
        </MasterTableView>

        <FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
    <asp:EntityDataSource ID="dsMaster" runat="server" ConnectionString="name=DBEntities" DefaultContainerName="DBEntities" EnableFlattening="False" EntitySetName="VW_DebtDetail_List" EntityTypeFilter="VW_DebtDetail_List">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="dsDetail" runat="server" ConnectionString="name=DBEntities" DefaultContainerName="DBEntities" EnableFlattening="False" EntitySetName="T_DebtDetailLog" EntityTypeFilter="T_DebtDetailLog"
        Where="it.DebtID = @DebtID AND it.MobileID = @MobileID"
        AutoGenerateWhereClause="true">
        <WhereParameters>
            <asp:Parameter Name="DebtID" Type="Int32" />
            <asp:Parameter Name="MobileID" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:ObjectDataSource ID="dsRelationType" runat="server" SelectMethod="GetRelationTypes" TypeName="GZAAT.Web.Code.CacheHelper" />
    <asp:ObjectDataSource ID="dsDebtStatus" runat="server" SelectMethod="GetDebtStatuses" TypeName="GZAAT.Web.Code.CacheHelper" />
</asp:Content>
