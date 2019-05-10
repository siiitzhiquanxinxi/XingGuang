<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buildTemplate.aspx.cs" Inherits="DTcms.Web.admin.Quotation.buildTemplate" %>

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
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="#" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>创建模板</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">基本信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>系统分类</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlQuotationTemplateType" runat="server" datatype="*" sucmsg=" " AppendDataBoundItems="true">
                            <asp:ListItem Text="--请选择--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>模板名称</dt>
                <dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>热门标签</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlTag" runat="server" datatype="*" sucmsg=" ">
                            <asp:ListItem Text="正常产品" Value="正常产品"></asp:ListItem>
                            <asp:ListItem Text="明星产品" Value="明星产品"></asp:ListItem>
                            <asp:ListItem Text="金牛产品" Value="金牛产品"></asp:ListItem>
                            <asp:ListItem Text="瘦狗产品" Value="瘦狗产品"></asp:ListItem>
                            <asp:ListItem Text="库存" Value="库存"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>主要品牌</dt>
                <dd>
                    <asp:TextBox ID="txtMainBrand" runat="server" CssClass="input normal" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>系统描述</dt>
                <dd>
                    <asp:TextBox ID="txtDes" runat="server" CssClass="input normal" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>使用场景</dt>
                <dd>
                    <asp:TextBox ID="txtScenario" runat="server" CssClass="input normal" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>系统搭配注意事项</dt>
                <dd>
                    <asp:TextBox ID="txtNotes" runat="server" CssClass="input normal" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtOrder" runat="server" CssClass="input small" Text="0" sucmsg=" " />
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnCreate" runat="server" Text="创建" CssClass="btn" OnClick="btnCreate_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>

