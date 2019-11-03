<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Base.Master" AutoEventWireup="true" CodeBehind="StaticSMS.aspx.cs" Inherits="GZAAT.Web.StaticSMS" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageSection" runat="server">
    <h1><%= Resources.ApplicationResources.StaticSMS %></h1>
    <br />
    <div class="table form">
        <div class="tbody">
            <div class="tr">
                <div class="td lbl">
                    <asp:Label ID="lblSendDate" AssociatedControlID="rdtpSendDate" runat="server" Text="<%$ Resources:ApplicationResources, SendDateLable %>" CssClass="required" />
                </div>
                <div class="td">
                    <telerik:RadDateTimePicker ID="rdtpSendDate" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvSendDate" ControlToValidate="rdtpSendDate" Display="Dynamic" runat="server" CssClass="error" ErrorMessage="<%$ Resources:ApplicationResources, SendDateRequiredErrorText %>" ToolTip="<%$ Resources:ApplicationResources, SendDateRequiredErrorText %>"
                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tr">
                <div class="td lbl">
                    <asp:Label ID="lblMobile" AssociatedControlID="txtMobiles" runat="server" Text="<%$ Resources:ApplicationResources, MobilesLable %>" CssClass="required" />
                </div>
                <div class="td">
                    <asp:TextBox ID="txtMobiles" runat="server" TextMode="MultiLine" Rows="10" ToolTip="<%$ Resources:ApplicationResources, MobilesPeerLineToolTip %>"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMobile" ControlToValidate="txtMobiles" Display="Dynamic" runat="server" CssClass="error" ErrorMessage="<%$ Resources:ApplicationResources, MobileRequiredErrorText %>" ToolTip="<%$ Resources:ApplicationResources, MobileRequiredErrorText %>"
                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tr">
                <div class="td lbl">
                    <asp:Label ID="lblMessage" AssociatedControlID="txtMessage" runat="server" Text="<%$ Resources:ApplicationResources, MessageTextLable %>" CssClass="required" />
                </div>
                <div class="td">
                    <asp:TextBox ID="txtMessage" runat="server" Width="500px" />
                    <asp:RequiredFieldValidator ID="rfvMessageText" ControlToValidate="txtMessage" Display="Dynamic" runat="server" CssClass="error" ErrorMessage="<%$ Resources:ApplicationResources, MessageTextRequiredErrorText %>" ToolTip="<%$ Resources:ApplicationResources, MessageTextRequiredErrorText %>"
                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tr">
                <div class="td lbl">
                </div>
                <div class="td">
                    <asp:Button ID="btnSaveForSend" runat="server" Text="<%$ Resources:ApplicationResources, SaveForSend %>" OnClick="btnSaveForSend_Click" ValidationGroup="Save" />
                </div>
            </div>
        </div>
    </div>

    <telerik:RadGrid ID="gridSMS" runat="server" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" DataSourceID="dsMaster" GridLines="None" ShowGroupPanel="True">
        <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="True" ReorderColumnsOnClient="True">
            <Resizing />
        </ClientSettings>
        <MasterTableView DataKeyNames="ID,MobileID" DataSourceID="dsMaster" CommandItemDisplay="Top">
            <CommandItemSettings ShowAddNewRecordButton="False" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />

            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>

            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>

            <Columns>
<%--                <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" HeaderText="ID" SortExpression="ID" UniqueName="ID" />
                <telerik:GridBoundColumn DataField="MobileID" DataType="System.Int32" HeaderText="MobileID" SortExpression="MobileID" UniqueName="MobileID" />--%>
                <telerik:GridDateTimeColumn EnableRangeFiltering="true" DataField="Date" DataType="System.DateTime" HeaderText="<%$ Resources:ApplicationResources, Date %>" SortExpression="Date" UniqueName="Date" />
                <telerik:GridBoundColumn DataField="Mobile" HeaderText="<%$ Resources:ApplicationResources, Mobile %>" SortExpression="Mobile" UniqueName="Mobile" />
                <telerik:GridBoundColumn DataField="MobileOwner" HeaderText="<%$ Resources:ApplicationResources, MobileOwner %>" SortExpression="MobileOwner" UniqueName="MobileOwner" />
                <telerik:GridDropDownColumn FilterControlWidth="90px" DataField="StatusID" DataType="System.Byte" HeaderText="<%$ Resources:ApplicationResources, Status %>" SortExpression="StatusID" UniqueName="StatusID" DataSourceID="dsStatus" ListTextField="Name" ListValueField="ID">
                    <FilterTemplate>
                        <telerik:RadComboBox ID="cmbStatusID" runat="server" Width="90px"
                            DataSourceID="dsStatus"
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
                <telerik:GridBoundColumn DataField="SentDate" DataType="System.DateTime" HeaderText="<%$ Resources:ApplicationResources, SentDate %>" SortExpression="SentDate" UniqueName="SentDate" />
                <telerik:GridBoundColumn DataField="TryCount" DataType="System.Byte" HeaderText="<%$ Resources:ApplicationResources, TryCount %>" SortExpression="TryCount" UniqueName="TryCount" />
                <telerik:GridBoundColumn DataField="Message" HeaderText="<%$ Resources:ApplicationResources, Message %>" SortExpression="Message" UniqueName="Message" />
            </Columns>

            <SortExpressions>
                <telerik:GridSortExpression FieldName="Date" SortOrder="Descending" />
            </SortExpressions>

            <EditFormSettings>
                <EditColumn></EditColumn>
            </EditFormSettings>

            <DetailTables>
                <telerik:GridTableView runat="server" DataSourceID="dsDetail" DataKeyNames="ID" AllowFilteringByColumn="true" AllowPaging="False" AllowSorting="False" GroupsDefaultExpanded="False">
                    <ParentTableRelation>
                        <telerik:GridRelationFields DetailKeyField="SMSID" MasterKeyField="ID" />
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
    <asp:EntityDataSource ID="dsMaster" runat="server" ConnectionString="name=DBEntities" DefaultContainerName="DBEntities" EnableFlattening="False" EntitySetName="VW_SMSDetail_List" EntityTypeFilter="VW_SMSDetail_List" />
    <asp:EntityDataSource ID="dsDetail" runat="server" ConnectionString="name=DBEntities" DefaultContainerName="DBEntities" EnableFlattening="False" EntitySetName="T_SMSDetailLog" EntityTypeFilter="T_SMSDetailLog"
        Where="it.SMSID = @SMSID AND it.MobileID = @MobileID"
        AutoGenerateWhereClause="true">
        <WhereParameters>
            <asp:Parameter Name="SMSID" Type="Int32" />
            <asp:Parameter Name="MobileID" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:ObjectDataSource ID="dsStatus" runat="server" SelectMethod="GetDebtStatuses" TypeName="GZAAT.Web.Code.CacheHelper" />
</asp:Content>
