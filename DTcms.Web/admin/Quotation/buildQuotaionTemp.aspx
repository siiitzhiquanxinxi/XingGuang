<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buildQuotaionTemp.aspx.cs" Inherits="DTcms.Web.admin.Quotation.buildQuotaionTemp" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>创建模板</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        function SelectTemp() {
            $.dialog({
                title: '选择商品类型', width: 800, heght: 600,
                content: 'url:Quotation/chooseTemp.aspx?idTarget=hfdTempId',
                lock: true
            });
        }
        function bindClick() {
            document.getElementById("btnBind").click();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfdTempId" runat="server" />
        <!--导航栏-->
        <div class="location">
            <a href="#" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>新建报价单</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <div class="div-content">
            <dl>
                <dt>添加模板</dt>
                <dd>
                    <input id="btnAddTemp" type="button" value="添加模板" class="btn yellow" onclick="SelectTemp()" />
                </dd>
            </dl>
        </div>
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">已选模板</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content" id="divContent">
            <asp:Button ID="btnBind" runat="server" Text="绑定" OnClick="btnBind_Click" Style="display: none;" />
            <asp:Repeater ID="rptList1" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="6%"></th>
                            <th align="left">系统分类</th>
                            <th align="left">模板名称</th>
                            <th align="left">主要品牌</th>
                            <th align="left">系统描述</th>
                            <th align="left">使用场景</th>
                            <th align="left">系统搭配注意事项</th>
                            <th align="center">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hfdQuotationTemplateId" runat="server" Value='<%#Eval("QuotationTemplateId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblQuotationTemplateType" runat="server" Text='<%#Eval("QuotationTemplateType") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblQuotationTemplateName" runat="server" Text='<%#Eval("QuotationTemplateName") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblQuotationTemplateMainBrand" runat="server" Text='<%#Eval("QuotationTemplateMainBrand") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblQuotationTemplateDescription" runat="server" Text='<%#Eval("QuotationTemplateDescription") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblQuotationTemplateScenario" runat="server" Text='<%#Eval("QuotationTemplateScenario") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblQuotationTemplateNotes" runat="server" Text='<%#Eval("QuotationTemplateNotes") %>'></asp:Label></td>
                        <td align="center">
                            <asp:HiddenField ID="hfdIsDel" runat="server" Value="0" />
                            <asp:LinkButton ID="lbtnDel" runat="server" OnClick="lbtnDel_Click">删除</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnCreate" runat="server" Text="生成报价单" CssClass="btn" OnClick="btnCreate_Click" />
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
