﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buildQuotaionBlank.aspx.cs" Inherits="DTcms.Web.admin.Quotation.buildQuotaionBlank" %>

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
        function SelectMaterial() {
            var mtype = document.getElementById("hfdMtype").value;
            if (mtype == "" || mtype == null) {
                alert("请选择商品类别!");
                return;
            }
            $.dialog({
                title: '选择商品', width: 1024, heght: 600,
                content: 'url:Quotation/chooseMaterial.aspx?mtype=' + mtype + '&idTarget=hfdTempId',
                lock: true
            });
        }
        function SelectGoodsType() {
            $.dialog({
                title: '选择商品类型', width: 650, heght: 600,
                content: 'url:Quotation/chooseGoodsType.aspx?idTarget=hfdTempId2',
                lock: true
            });
        }
        function InsertMaterial(obj) {
            var mtype = document.getElementById("hfdMtype").value;
            document.getElementById("hfdInsertIndex").value = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '选择商品', width: 1024, heght: 600,
                content: 'url:Quotation/chooseMaterial.aspx?mtype=' + mtype + '&idTarget=hfdTempId',
                lock: true
            });
        }
        function bindClick() {
            document.getElementById("btnBind").click();
        }
        function bindClick2() {
            document.getElementById("btnBind2").click();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfdTempId" runat="server" />
        <asp:HiddenField ID="hfdTempId2" runat="server" />
        <asp:HiddenField ID="hfdMtype" runat="server" />
        <asp:HiddenField ID="hfdJsonContent" runat="server" />
        <%--当前选中的商品类别id--%>
        <asp:HiddenField ID="hfdInsertIndex" runat="server" />
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
                <dt>报价单号</dt>
                <dd>
                    <asp:TextBox ID="txtQuotationListNum" runat="server" CssClass="input normal" Width="200"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>添加商品类别</dt>
                <dd>
                    <input id="btnAddGoodsType" type="button" value="添加商品类别" class="btn yellow" onclick="SelectGoodsType()" />
                </dd>
            </dl>
            <dl>
                <dt>选择类别</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblGoodsType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rblGoodsType_SelectedIndexChanged">
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
        </div>
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">商品明细</a></li>
                        <li><a href="javascript:;">线材明细</a></li>
                        <li><a href="javascript:;">人工费用明细</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content" id="divContent">
            <input id="b1" type="button" value="添加商品" class="btn green" onclick="SelectMaterial()" style="margin-bottom: 8px;" />
            <asp:Button ID="btnBind" runat="server" Text="绑定" OnClick="btnBind_Click" Style="display: none;" />
            <asp:Button ID="btnBind2" runat="server" Text="绑定2" OnClick="btnBind2_Click" Style="display: none;" />
            <asp:Repeater ID="rptList1" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center">品牌</th>
                            <th align="center">LOGO</th>
                            <th align="left">型号</th>
                            <th align="left">商品名称</th>
                            <th align="left" style="width: 280px">描述</th>
                            <th align="left">单位</th>
                            <th align="left">单价</th>
                            <th align="center">图片</th>
                            <th align="left">数量</th>
                            <th width="10%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hfdOrderIndex" runat="server" Value='<%#Eval("DetailOrder") %>' />
                            <asp:HiddenField ID="hfdMaterialId" runat="server" Value='<%#Eval("FK_materialID") %>' />
                            <asp:Label ID="lblBrand" runat="server" Text='<%#Eval("Brand") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("BrandImg") %>' Height="75" /></td>
                        <td>
                            <asp:Label ID="lblMode" runat="server" Text='<%#Eval("Mode") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description").ToString().Replace("\n","<br />") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("Photo") %>' Height="75" /></td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%#Eval("GoodsQuantity") %>' onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')"></asp:TextBox></td>
                        <td align="center">
                            <asp:HiddenField ID="hfdIsDel" runat="server" Value="0" />
                            <asp:LinkButton ID="lbtnDel" runat="server" OnClick="lbtnDel_Click">删除</asp:LinkButton>
                            <asp:LinkButton ID="lbtnMoveUp" runat="server" OnClick="lbtnMoveUp_Click">上移</asp:LinkButton>
                            <asp:LinkButton ID="lbtnMoveDown" runat="server" OnClick="lbtnMoveDown_Click">下移</asp:LinkButton>
                            <a href="javascript:;" onclick="InsertMaterial(this);">插入</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="tab-content" style="display: none">
            <asp:Button ID="btnUpdateLine" runat="server" CssClass="btn green" Style="margin-bottom: 8px;" Text="更新线材明细" OnClick="btnUpdateLine_Click" />
            <asp:Repeater ID="rptLine" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center">品牌</th>
                            <th align="center">LOGO</th>
                            <th align="left">型号</th>
                            <th align="left">线材名称</th>
                            <th align="left" style="width: 280px">描述</th>
                            <th align="left">单位</th>
                            <th align="center">图片</th>
                            <th align="left">数量</th>
                            <th align="left">单价</th>
                            <th align="left">小计</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hfdMaterialId" runat="server" Value='<%#Eval("FK_LineId") %>' />
                            <asp:Label ID="lblBrand" runat="server" Text='<%#Eval("LineBrand") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("LineBrandImg") %>' Height="75" /></td>
                        <td>
                            <asp:Label ID="lblMode" runat="server" Text='<%#Eval("LineMode") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("LineName") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("LineDescription").ToString().Replace("\n","<br />") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("LineUnit") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("LinePhoto") %>' Height="75" /></td>
                        <td>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("LineTotalcount") %>'></asp:Label>
                        <td>
                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("LineUnitPrice") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("LineTotalamount") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无数据</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>
        <div class="tab-content" style="display: none">
            <asp:Button ID="btnUpdateLaborFee" runat="server" CssClass="btn green" Style="margin-bottom: 8px;" Text="更新人工费用" OnClick="btnUpdateLaborFee_Click" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th align="left">&nbsp;&nbsp;</th>
                    <th align="left">项目</th>
                    <th align="left" style="width: 280px">描述</th>
                    <th align="left">单位</th>
                    <th align="left">数量</th>
                    <th align="left">价格</th>
                </tr>
                <tr>
                    <td></td>
                    <td>弱电布线费</td>
                    <td></td>
                    <td>项目</td>
                    <td>1</td>
                    <td>
                        <asp:TextBox ID="txtRuodiananzhuangFee" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>器材安装费</td>
                    <td></td>
                    <td>项目</td>
                    <td>1</td>
                    <td>
                        <asp:TextBox ID="txtQicaianzhuangFee" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>系统调试费</td>
                    <td></td>
                    <td>项目</td>
                    <td>1</td>
                    <td>
                        <asp:TextBox ID="txtXitongtiaoshiFee" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>项目管理费</td>
                    <td></td>
                    <td>项目</td>
                    <td>1</td>
                    <td>
                        <asp:TextBox ID="txtXiangmuguanliFee" runat="server"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click" />
                <%--<input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />--%>
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
