<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buildQuotaionBlank.aspx.cs" Inherits="DTcms.Web.admin.Quotation.buildQuotaionBlank1" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>由模板创建报价单</title>
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
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">客户信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>客户编号</dt>
                <dd>
                    <asp:TextBox ID="txtCustomerNum" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>客户名称</dt>
                <dd>
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>客户电话</dt>
                <dd>
                    <asp:TextBox ID="txtCustomerTel" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>项目地址</dt>
                <dd>
                    <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>项目面积</dt>
                <dd>
                    <asp:TextBox ID="txtProgramAreaNum" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>销售设计师</dt>
                <dd>
                    <asp:TextBox ID="txtSalePeople" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>业务员</dt>
                <dd>
                    <asp:TextBox ID="txtBussinessPeople" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>客户来源</dt>
                <dd>
                    <asp:TextBox ID="txtCustomerSource" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
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
