<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="DTcms.Web.admin.center" %>

<%@ Import Namespace="DTcms.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>管理首页</title>
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/layindex.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/common.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <div style="display: none;">
            <!--导航栏-->
            <div class="location">
                <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
                <a class="home"><i></i><span>首页</span></a>
                <i class="arrow"></i>
                <span>管理中心</span>
            </div>
            <!--/导航栏-->
            <!--内容-->
            <div class="line10"></div>
            <div class="nlist-1"></div>
            <div class="line10"></div>
            <div class="line20"></div>
            <div class="nlist-3">
                <ul>
                    <%--<li><a onclick="parent.linkMenuTree(true, 'sys_config');" class="icon-setting" href="javascript:;"></a><span>系统设置</span></li>--%>
                    <li><a onclick="parent.linkMenuTree(true, 'sys_site_manage');" class="icon-channel" href="MaterialSetting/MaterialList.aspx"></a><span>产品库</span></li>
                    <li><a onclick="parent.linkMenuTree(true, 'sys_site_templet');" class="icon-templet" href="Quotation/QuotationTemplateList.aspx"></a><span>模板管理</span></li>
                    <%--<li><a onclick="parent.linkMenuTree(true, 'sys_builder_html');" class="icon-mark" href="javascript:;"></a><span>生成静态</span></li>--%>
                    <li><a onclick="parent.linkMenuTree(true, ' sys_plugin_config ');" class="icon-plugin" href="Quotation/buildQuotaionBlank.aspx"></a><span>新建报价单</span></li>
                    <%--<li><a onclick="parent.linkMenuTree(true, 'user_list');" class="icon-user" href="javascript:;"></a><span>已报方案客户</span></li>--%>
                    <%-- <li><a onclick="parent.linkMenuTree(true, 'manager_list');" class="icon-manaer" href="javascript:;"></a><span>管理员</span></li>--%>
                    <li><a onclick="parent.linkMenuTree(true, 'manager_log');" class="icon-log" href="Quotation/QuotationListQuery.aspx"></a><span>历史报价单</span></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
