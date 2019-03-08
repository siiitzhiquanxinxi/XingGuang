<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialTypeEdit.aspx.cs" Inherits="DTcms.Web.admin.MaterialSetting.MaterialTypeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品分类详细页</title>
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
    
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:;" class="home"><i></i><span>商品分类详细页</span></a>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">
                        <asp:Literal ID="litNowPosition2" runat="server" Text="商品分类"></asp:Literal></a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>商品分类：</dt>
            <dd>
                <asp:TextBox ID="txtMaterialType" runat="server" CssClass="input normal" sucmsg=" "
                    minlength="1" MaxLength="100"></asp:TextBox>
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
            <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn" 
                onclick="btnSubmit_Click"  />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
            <asp:Label ID="lblError" runat="server" Text="" Style="color: Red;"></asp:Label>
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>

