<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemTypeEdit.aspx.cs" Inherits="DTcms.Web.admin.Quotation.SystemTypeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统分类</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>

</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>系统分类</span></a>
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
                <dt>系统分类：</dt>
                <dd>
                    <asp:TextBox ID="txtSystemTypeName" runat="server" CssClass="input normal" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>包含产品分类：</dt>
                <dd>
                    <div class="menu-list">
                        <div class="rule-multi-checkbox">
                            <asp:CheckBoxList ID="cblMType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>弱电布线费-描述：</dt>
                <dd>
                    <asp:TextBox ID="txtRuodiananzhuangDes" runat="server" CssClass="input normal" TextMode="MultiLine" Height="60" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>弱电布线费-图例：</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>项目管理费-比例：</dt>
                <dd>
                    <asp:TextBox ID="txtXiangmuguanliFee" runat="server" CssClass="input small" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>项目管理费-描述：</dt>
                <dd>
                    <asp:TextBox ID="txtXiangmuguanliDes" runat="server" CssClass="input normal" TextMode="MultiLine" Height="60" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>项目管理费-图例：</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>规划与安装-比例：</dt>
                <dd>
                    <asp:TextBox ID="txtQicaianzhuangFee" runat="server" CssClass="input small" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>规划与安装-描述：</dt>
                <dd>
                    <asp:TextBox ID="txtQicaianzhuangDes" runat="server" CssClass="input normal" TextMode="MultiLine" Height="60" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>规划与安装-图例：</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>系统调试费-比例：</dt>
                <dd>
                    <asp:TextBox ID="txtXitongtiaoshiFee" runat="server" CssClass="input small" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>系统调试费-描述：</dt>
                <dd>
                    <asp:TextBox ID="txtXitongtiaoshiDes" runat="server" CssClass="input normal" TextMode="MultiLine" Height="60" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>系统调试费-图例：</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer" runat="server" id="div_gongju">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn"
                    OnClick="btnSubmit_Click" />
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
