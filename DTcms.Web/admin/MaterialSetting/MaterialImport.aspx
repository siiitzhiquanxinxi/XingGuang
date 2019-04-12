<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialImport.aspx.cs" Inherits="DTcms.Web.admin.MaterialSetting.MaterialImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品导入页</title>
    <script src="../../Scripts/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>产品导入页</span></a>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">
                            <asp:Literal ID="litNowPosition2" runat="server" Text="产品库导入"></asp:Literal></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="div-content">
            <dl>
                <dt>产品分类：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:DropDownList ID="ddlMaterialType" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem>--请选择--</asp:ListItem>
                        </asp:DropDownList>
                        <span class="Validform_checktip">*</span>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>导入模板：</dt>
                <dd>
                    <a href="导入模板.xlsx">导入模板下载</a>
                </dd>
            </dl>
            <dl>
                <dt>产品导入：</dt>
                <dd>
                    <asp:FileUpload ID="fulImport" runat="server" Width="612px" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <%-- 
        <dl>
            <dt>备注：</dt>
            <dd>
               
               <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" sucmsg=" "
                    minlength="" MaxLength="100"></asp:TextBox>
            </dd>
        </dl>
            --%>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer" runat="server" id="div_gongju">
            <div class="btn-list">
                <asp:Button ID="btnSubmit2" runat="server" Text="导  入" CssClass="btn" OnClick="btnSubmit2_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
                <asp:Label ID="lblError" runat="server" Text="" Style="color: Red;"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>


