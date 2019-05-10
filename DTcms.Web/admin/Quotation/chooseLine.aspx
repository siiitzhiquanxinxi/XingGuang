<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chooseLine.aspx.cs" Inherits="DTcms.Web.admin.Quotation.chooseLine" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>选择线材</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //图片延迟加载
            $(".pic img").lazyload({ effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
        });
        function ok(obj) {
            var id = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            var api = frameElement.api, W = api.opener;
            if (W.document.getElementById('<%=Request.QueryString["idTarget"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["idTarget"] %>').value = id;
            W.bindLineClick();
            api.close();
        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlBrand" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container" style="overflow-y: scroll; height: 650px;">
            <!--文字列表-->
            <asp:Repeater ID="rptList1" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="left" style="padding-left: 5px;">类型</th>
                            <th align="left">品牌</th>
                            <th align="left">型号</th>
                            <th align="left">商品名称</th>
                            <th align="center" style="width: 300px">描述</th>
                            <th align="center">单位</th>
                            <th align="right">单价</th>
                            <th width="10%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr height="80">
                        <td style="padding-left: 5px;"><%#Eval("MaterialType") %>
                            <asp:HiddenField ID="hfdId" runat="server" Value='<%#Eval("ID") %>' />
                        </td>
                        <td><%#Eval("Brand") %></td>
                        <td><%#Eval("Mode") %></td>
                        <td><%#Eval("Name") %></td>
                        <td><%#Eval("Description").ToString().Replace("\n","<br />") %></td>
                        <td align="center"><%#Eval("Unit") %></td>
                        <td align="right"><%#Eval("UnitPrice") %></td>
                        <td align="center">
                            <a href="javascript:void(0);" onclick="ok(this)">选择</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
            <!--/文字列表-->
        </div>
        <!--/列表-->
        <!--内容底部-->
        <div class="line20"></div>
        <!--/内容底部-->

    </form>
</body>
</html>
