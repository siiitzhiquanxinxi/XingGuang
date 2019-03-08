<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chooseMaterial.aspx.cs" Inherits="DTcms.Web.admin.MaterialSetting.chooseMaterial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function ok(txt, value) {
            var api = frameElement.api, W = api.opener;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget"] %>').value = txt;
            if (W.document.getElementById('<%=Request.QueryString["idTarget"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["idTarget"] %>').value = value;
            api.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="floatHead" class="toolbar-wrap">
        <div class="toolbar">
            <div class="box-wrap">
                <a class="menu-btn"></a>
                <div class="r-list" style="padding-right: 20px;">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeholder="按拼音首字母查询" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="lbtnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div class="table-container">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="8%">
                            选择
                        </th>
                        <th align="left" width="12%">
                            品牌
                        </th>
                        <th align="left" width="12%">
                            型号
                        </th>
                        <th align="left" width="12%">
                            品名
                        </th>
                        <th align="left" width="12%">
                            产品描述
                        </th>
                        <th align="left" width="12%">
                            单位
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                        <asp:HiddenField ID="hfdName" Value='<%#Eval("Name")%>' runat="server" />
                    </td>
                    <td>
                        <%# Eval("Brand")%>
                    </td>
                    <td>
                        <%# Eval("Mode")%>
                    </td>
                    <td>
                        <%# Eval("Name")%>
                    </td>
                    <td>
                        <%# Eval("Description")%>
                    </td>
                    <td>
                        <%# Eval("Unit")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <!--/列表-->
    <!--内容底部-->
    <div class="line20">
    </div>
    <div class="pagelist" style="display: none;">
        <div class="l-btns">
            <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                AutoPostBack="True"></asp:TextBox><span>条/页</span>
        </div>
        <div id="PageContent" runat="server" class="default">
        </div>
    </div>
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="确认" CssClass="btn" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
