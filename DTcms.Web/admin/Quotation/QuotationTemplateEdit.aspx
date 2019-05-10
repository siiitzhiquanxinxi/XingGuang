<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotationTemplateEdit.aspx.cs" Inherits="DTcms.Web.admin.Quotation.QuotationTemplateEdit" %>


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
            $.dialog({
                title: '选择商品', width: 1024, heght: 600,
                content: 'url:Quotation/chooseMaterial.aspx?stype=' + mtype + '&idTarget=hfdTempId',
                lock: true
            });
        }
        function InsertMaterial(obj) {
            var mtype = document.getElementById("hfdMtype").value;
            document.getElementById("hfdInsertIndex").value = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '选择商品', width: 1024, heght: 600,
                content: 'url:Quotation/chooseMaterial.aspx?stype=' + mtype + '&idTarget=hfdTempId',
                lock: true
            });
        }
        function ReplaceMaterial(obj) {
            var mtype = document.getElementById("hfdMtype").value;
            document.getElementById("hfdReplaceIndex").value = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '选择商品', width: 1024, heght: 600,
                content: 'url:Quotation/chooseMaterial.aspx?stype=' + mtype + '&idTarget=hfdTempId',
                lock: true
            });
        }
        function ReplaceLine(obj) {
            var thisLineId = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            document.getElementById("hfdLineReplaceId").value = thisLineId;
            $.dialog({
                title: '选择线材', width: 1024, heght: 600,
                content: 'url:Quotation/chooseLine.aspx?&idTarget=hfdLineTempId',
                lock: true
            });
        }
        function bindClick() {
            document.getElementById("btnBind").click();
        }
        function bindLineClick() {
            document.getElementById("btnBindLine").click();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfdTempId" runat="server" />
        <asp:HiddenField ID="hfdLineTempId" runat="server" />
        <asp:HiddenField ID="hfdLineReplaceId" runat="server" />
        <asp:HiddenField ID="hfdLineList" runat="server" />
        <asp:HiddenField ID="hfdMtype" runat="server" />
        <asp:HiddenField ID="hfdInsertIndex" runat="server" />
        <asp:HiddenField ID="hfdReplaceIndex" runat="server" />
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
                        <li><a class="selected" href="javascript:;">商品明细</a></li>
                        <li><a href="javascript:;">模板信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content" id="divContent">
            <input id="b1" type="button" value="添加商品" class="btn green" onclick="SelectMaterial()" style="margin-bottom: 8px;" />
            <asp:Button ID="btnUpdateLine" runat="server" CssClass="btn green" Style="margin-bottom: 8px; display: none;" Text="更新线材明细" OnClick="btnUpdateLine_Click" />
            <asp:Button ID="btnUpdateLaborFee" runat="server" CssClass="btn green" Style="margin-bottom: 8px; display: none" Text="更新人工费用" OnClick="btnUpdateLaborFee_Click" />
            <asp:Button ID="btnBind" runat="server" Text="绑定" OnClick="btnBind_Click" Style="display: none;" />
            <asp:Button ID="btnBindLine" runat="server" Text="绑定" OnClick="btnBindLine_Click" Style="display: none;" />
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
                            <asp:HiddenField ID="hfdOrderIndex" runat="server" Value='<%#Eval("OrderIndex") %>' />
                            <asp:HiddenField ID="hfdMaterialId" runat="server" Value='<%#Eval("MaterialID") %>' />
                            <asp:Label ID="lblBrand" runat="server" Text='<%#Eval("Brand") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("BrandImg") %>' Width="100" Height="50" /></td>
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
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("Photo") %>' Width="100" Height="50" /></td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="input small" Text='<%#Eval("Quantity").ToString()!=""?Math.Round(Convert.ToDecimal(Eval("Quantity")),0).ToString():"0" %>'
                                onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')" onblur="bindClick()"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:HiddenField ID="hfdIsDel" runat="server" Value="0" />
                            <asp:LinkButton ID="lbtnDel" runat="server" OnClick="lbtnDel_Click">删除</asp:LinkButton>
                            <a href="javascript:;" onclick="InsertMaterial(this);">插入</a>
                            <a href="javascript:;" onclick="ReplaceMaterial(this);">替换</a>
                            <br />
                            <asp:LinkButton ID="lbtnMoveUp" runat="server" OnClick="lbtnMoveUp_Click">上移</asp:LinkButton>
                            <asp:LinkButton ID="lbtnMoveDown" runat="server" OnClick="lbtnMoveDown_Click">下移</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hfdTotalGoods" runat="server" Value="0" />
            <asp:Repeater ID="rptLine" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th colspan="10" align="center"><b>配套线材</b></th>
                        </tr>
                        <tr>
                            <th align="center">品牌</th>
                            <th align="center">LOGO</th>
                            <th align="left">型号</th>
                            <th align="left">商品名称</th>
                            <th align="left" style="width: 280px">描述</th>
                            <th align="left">单位</th>
                            <th align="center">图片</th>
                            <th align="left">数量</th>
                            <th align="left">单价</th>
                            <th align="left">小计</th>
                            <th align="center">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hfdMaterialId" runat="server" Value='<%#Eval("ID") %>' />
                            <asp:Label ID="lblBrand" runat="server" Text='<%#Eval("Brand") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("BrandImg") %>' Width="100" Height="50" /></td>
                        <td>
                            <asp:Label ID="lblMode" runat="server" Text='<%#Eval("Mode") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description").ToString().Replace("\n","<br />") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("Photo") %>' Width="100" Height="50" /></td>
                        <td>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("totalcount") %>'></asp:Label>
                        <td>
                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("totalamount") %>'></asp:Label></td>
                        <td align="center">
                            <a href="javascript:;" onclick="ReplaceLine(this);">替换线材</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无数据</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hfdTotalLine" runat="server" Value="0" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th colspan="8" align="center"><b>人工费用</b></th>
                </tr>
                <tr>
                    <th align="left" width="35px">&nbsp;&nbsp;</th>
                    <th align="left" width="10%">项目</th>
                    <th align="center" width="10%">LOGO</th>
                    <th align="left">描述</th>
                    <th align="left" width="10%">单位</th>
                    <th align="left" width="10%">图片</th>
                    <th align="left" width="10%">比例</th>
                    <th align="left" width="10%">价格</th>
                </tr>
                <tr>
                    <td></td>
                    <td>弱电布线费</td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td>
                        <asp:TextBox ID="txtRuodiananzhuangDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td colspan="2">
                        <asp:Image ID="imgRuodiananzhuang" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtRuodiananzhuangFee" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>项目管理费</td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td>
                        <asp:TextBox ID="txtXiangmuguanliDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td>
                        <asp:Image ID="imgXiangmuguanli" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtXiangmuguanliFee" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtXiangmuguanliTotal" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>规划与安装</td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td>
                        <asp:TextBox ID="txtQicaianzhuangDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td>
                        <asp:Image ID="imgQicaianzhuang" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtQicaianzhuangFee" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtQicaianzhuangTotal" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>系统调试费</td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td>
                        <asp:TextBox ID="txtXitongtiaoshiDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td>
                        <asp:Image ID="imgXitongtiaoshi" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtXitongtiaoshiFee" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtXitongtiaoshiTotal" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <asp:HiddenField ID="hfdTotalRengong" runat="server" Value="0" />
        </div>
        <div class="tab-content" style="display: none">
            <dl>
                <dt>系统分类</dt>
                <dd>
                    <asp:TextBox ID="txtType" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*</span>
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
                <dt>标注</dt>
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
                    <asp:TextBox ID="txtMainBrand" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>系统描述</dt>
                <dd>
                    <asp:TextBox ID="txtDes" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>使用场景</dt>
                <dd>
                    <asp:TextBox ID="txtScenario" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>系统搭配注意事项</dt>
                <dd>
                    <asp:TextBox ID="txtNotes" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                </dd>
            </dl>
            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtOrder" runat="server" CssClass="input small" Text="0" sucmsg=" " />
                </dd>
            </dl>
        </div>
        <div class="tab-content">
            该系统金额总计：<asp:Label ID="lblSystemSubTotal" runat="server" Text="" Font-Size="Large"></asp:Label>元<br />

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

