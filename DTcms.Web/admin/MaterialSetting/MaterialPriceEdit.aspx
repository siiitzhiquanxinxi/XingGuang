<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialPriceEdit.aspx.cs" Inherits="DTcms.Web.admin.MaterialSetting.MaterialPriceEdit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>销售价格设置</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>


</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>销售价格设置</span></a>
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a id="aorder" class="selected" href="javascript:;" onclick="tabs(this);">产品信息</a></li>

                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>产品分类：</dt>
                <dd>

                    <asp:HiddenField ID="hidID" runat="server" />
                    <asp:HiddenField ID="hidMaterialTypeID" runat="server" />
                    <asp:Label ID="txtMaterialType" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>品牌：</dt>
                <dd>
                    <%--<asp:TextBox ID="txtBrand" runat="server" CssClass="input normal" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>--%>
                    <asp:Label ID="txtBrand" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>品牌（英文）：</dt>
                <dd>
                    <%--<asp:TextBox ID="txtBrandEn" runat="server" CssClass="input normal" sucmsg=" "
                        minlength="1" MaxLength="100"></asp:TextBox>--%>
                    <asp:Label ID="txtBrandEn" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>品牌Logo：</dt>
                <dd>
                    <asp:Image ID="Image1" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 200px;" class="upload-path" />
                </dd>
            </dl>
            <dl>
                <dt>型号：</dt>
                <dd>
                    <%--  <asp:TextBox ID="txtMode" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                        MaxLength="100"></asp:TextBox>--%>
                    <asp:Label ID="txtMode" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>品名：</dt>
                <dd>
                    <%--                    <asp:TextBox ID="txtName" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>--%>
                    <asp:Label ID="txtName" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>产品描述及备注：</dt>
                <dd>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="input" Style="height: 200px;" TextMode="MultiLine" sucmsg=" " ReadOnly="true"></asp:TextBox>


                </dd>
            </dl>
            <dl>
                <dt>单位：</dt>
                <dd>
                    <%--<asp:TextBox ID="txtUnit" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                        MaxLength="100"></asp:TextBox>--%>
                    <asp:Label ID="txtUnit" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt style="color:red">报价：</dt>
                <dd>
                    <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt style="color:red">弱电布线费：</dt>
                <dd>
                    <asp:TextBox ID="txtLaborCost" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt style="color:red">器材安装费：</dt>
                <dd>
                    <asp:TextBox ID="txtInstallationFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt style="color:red">系统调试费：</dt>
                <dd>
                    <asp:TextBox ID="txtCommissioningFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt style="color:red">项目管理费：</dt>
                <dd>
                    <asp:TextBox ID="txtManagementFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt style="color:red">内部安装费用：</dt>
                <dd>
                    <asp:TextBox ID="txtIndoorInstallationFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt style="color:red">内部布线费用：</dt>
                <dd>
                    <asp:TextBox ID="txtIndoorLaborCost" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt style="color:red">视频调试费用：</dt>
                <dd>
                    <asp:TextBox ID="txtVideoDebugFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt style="color:red">音频调试费用：</dt>
                <dd>
                    <asp:TextBox ID="txtAudioDebugFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                        MaxLength="100"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt>金蝶物料编号：</dt>
                <dd>
                    <%--<asp:TextBox ID="txtMaterialID" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                        MaxLength="100"></asp:TextBox>--%>
                    <asp:Label ID="txtMaterialID" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>金蝶物料名称：</dt>
                <dd>
                    <%--<asp:TextBox ID="txtMaterialName" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                        MaxLength="100"></asp:TextBox>--%>
                    <asp:Label ID="txtMaterialName" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>


            <dl>
                <dt>产品图片：</dt>
                <dd>
                    <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 200px;" class="upload-path" />
                </dd>
            </dl>

            <%--</ContentTemplate>--%>
            <%--</asp:UpdatePanel>--%>


            <div class="page-footer">
                <div class="btn-wrap">
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click" />
                    <%--<asp:Button ID="btnAddDetail" runat="server" Text="添加配套线材" CssClass="btn" onclick="ChooseCustomer()" />--%>
                    <%--<input name="btnAddDetail" type="button" value="添加配套线材" class="btn" onclick="ChooseCustomer() " />--%>

                    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
                </div>



            </div>

        </div>



        <!--/内容-->
        <!--工具栏-->

        <!--/工具栏-->
    </form>
</body>
</html>
