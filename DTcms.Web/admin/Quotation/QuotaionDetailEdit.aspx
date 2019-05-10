<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotaionDetailEdit.aspx.cs" Inherits="DTcms.Web.admin.Quotation.buildQuotaionBlank" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>报价单明细</title>
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
    <script src="../../lhgdialog/lhgdialog.min.js"></script>
    <script type="text/javascript">
        function SelectMaterial() {
            var stype = document.getElementById("hfdMtype").value;
            if (stype == "" || stype == null) {
                alert("请选择系统类别!");
                return;
            }
            $.dialog({
                title: '选择商品', width: 1200, heght: 600,
                content: 'url:Quotation/chooseMaterial.aspx?stype=' + stype + '&idTarget=hfdTempId',
                lock: true
            });
        }
        function SelectSystemType() {
            $.dialog({
                title: '选择系统类型', width: 650, heght: 600,
                content: 'url:Quotation/chooseSystemType.aspx?idTarget=hfdTempId2',
                lock: true
            });
        }
        function InsertMaterial(obj) {
            var stype = document.getElementById("hfdMtype").value;
            document.getElementById("hfdInsertIndex").value = $(obj).parent().parent().find("input[type=hidden]").get(0).value;
            $.dialog({
                title: '选择商品', width: 1200, heght: 600,
                content: 'url:Quotation/chooseMaterial.aspx?stype=' + stype + '&idTarget=hfdTempId',
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
        function bindClick2() {
            document.getElementById("btnBind2").click();
        }
        function bindLineClick() {
            document.getElementById("btnBindLine").click();
        }
        function IsPrint() {
            var id = $("#hfdMtype").val();
            alert(id);
            window.open('print/printQuotaionDepart.aspx?id=' + id, '_blank');
        }
        function ShowTotalPage() {
            $.dialog({
                title: '汇总页', width: 1200, heght: 600,
                content: 'url:Quotation/showTotalPage.aspx',
                lock: true
            });
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
        <asp:HiddenField ID="hfdLineTempId" runat="server" />
        <asp:HiddenField ID="hfdLineReplaceId" runat="server" />
        <asp:HiddenField ID="hfdLineList" runat="server" />
        <asp:HiddenField ID="hfdReplaceIndex" runat="server" />
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
                <dt>操作</dt>
                <dd>
                    <input id="btnAddGoodsType" runat="server" type="button" value="添加系统类别" class="btn yellow" onclick="SelectSystemType()" />
                    <%--<asp:Button ID="btnPrintTotal" runat="server" Text="报价单打印预览" class="btn yellow" Visible="false" OnClick="btnPrintTotal_Click" />--%>
                    <%--<input id="btnShowTotal" runat="server" type="button" value="查看汇总页" class="btn yellow" onclick="ShowTotalPage()" />--%>
                </dd>
            </dl>
            <dl>
                <dt>优惠金额</dt>
                <dd>折扣：
                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="input small" Style="text-align: right;" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" Text="100"></asp:TextBox>%&nbsp;&nbsp;&nbsp;&nbsp;
                    优惠减免：
                    <asp:TextBox ID="txtReduce" runat="server" CssClass="input small" Style="text-align: right;" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" Text="0"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    税率：
                    <asp:TextBox ID="txtTax" runat="server" CssClass="input small" Style="text-align: right;" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" Text="0"></asp:TextBox>%
                </dd>
            </dl>
            <dl>
                <dt>选择类别</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblGoodsType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rblGoodsType_SelectedIndexChanged">
                        </asp:RadioButtonList>
                    </div>
                    <div style="float: left; padding-left: 10px; padding-right: 10px;">
                        <asp:LinkButton ID="lbtnToleft" runat="server" OnClick="lbtnToleft_Click"><img src="../skin/default/Toleft.png" width="32" height="32" alt="左移" /></asp:LinkButton>
                        <asp:LinkButton ID="lbtnTodel" runat="server" OnClientClick="return confirm('确认删除该系统？')" OnClick="lbtnTodel_Click"><img src="../skin/default/Del.png" width="32" height="32" alt="删除" /></asp:LinkButton>
                        <asp:LinkButton ID="lbtnToright" runat="server" OnClick="lbtnToright_Click"><img src="../skin/default/Toright.png" width="32" height="32" alt="右移" /></asp:LinkButton>
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
                        <%--<li><a href="javascript:;">线材明细</a></li>
                        <li><a href="javascript:;">人工费用明细</a></li>--%>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content" id="divContent">
            <input id="b1" runat="server" type="button" value="添加商品" class="btn green" onclick="SelectMaterial()" style="margin-bottom: 8px;" />
            <asp:Button ID="btnUpdateLine" runat="server" CssClass="btn green" Style="margin-bottom: 8px; display: none;" Text="更新线材明细" OnClick="btnUpdateLine_Click" />
            <asp:Button ID="btnUpdateLaborFee" runat="server" CssClass="btn green" Style="margin-bottom: 8px; display: none;" Text="更新人工费用" OnClick="btnUpdateLaborFee_Click" />
            <%--<asp:Button ID="btnPrintPreview" runat="server" Text="打印预览" CssClass="btn yellow" OnClick="btnPrintPreview_Click" Visible="false" />--%>
            <asp:Button ID="btnExportSheet" runat="server" Text="导出Sheet" CssClass="btn yellow" OnClick="btnExportSheet_Click" Visible="true" />
            <asp:Button ID="btnBind" runat="server" Text="绑定" OnClick="btnBind_Click" Style="display: none;" />
            <asp:Button ID="btnBind2" runat="server" Text="绑定2" OnClick="btnBind2_Click" Style="display: none;" />
            <asp:Button ID="btnBindLine" runat="server" Text="绑定" OnClick="btnBindLine_Click" Style="display: none;" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            系统模块名称：<asp:TextBox ID="txtSystemName" runat="server" CssClass="input normal" Width="150"></asp:TextBox>
            系统模块描述：<asp:TextBox ID="txtSystemDes" runat="server" CssClass="input normal"></asp:TextBox>
            <br />
            <br />
            <asp:Repeater ID="rptList1" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center" width="5%">品牌</th>
                            <th align="center" width="10%">LOGO</th>
                            <th align="left" width="5%">型号</th>
                            <th align="left" width="10%">商品名称</th>
                            <th align="left">描述</th>
                            <th align="left" width="5%">单位</th>
                            <th align="left" width="5%">单价</th>
                            <th align="center" width="10%">图片</th>
                            <th align="left" width="5%">数量</th>
                            <th align="left" width="5%">小计</th>
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
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("BrandImg") %>' Width="100" Height="50" /></td>
                        <td>
                            <asp:Label ID="lblMode" runat="server" Text='<%#Eval("Mode") %>'></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Text='<%#Eval("Name") %>'>></asp:TextBox>
                            <%--<asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>--%></td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description").ToString().Replace("\n","<br />") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("Photo") %>' Width="100" Height="50" /></td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="input small" Text='<%#Eval("GoodsQuantity").ToString()!=""?Math.Round(Convert.ToDecimal(Eval("GoodsQuantity")),0).ToString():"0" %>' onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')" onblur="bindClick()"></asp:TextBox></td>
                        <td>
                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
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
                    <tr>
                        <td colspan="8"></td>
                        <td colspan="2" align="center">合计：￥<asp:Label ID="lblTotalGoods" runat="server" Text=""></asp:Label></td>
                        <td></td>
                    </tr>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"left\" colspan=\"7\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptLine" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th colspan="10" align="center"><b>配套线材</b></th>
                        </tr>
                        <tr>
                            <th align="center" width="5%">品牌</th>
                            <th align="center" width="10%">LOGO</th>
                            <th align="left" width="5%">型号</th>
                            <th align="left" width="10%">线材名称</th>
                            <th align="left">描述</th>
                            <th align="left" width="5%">单位</th>
                            <th align="left" width="5%">单价</th>
                            <th align="center" width="10%">图片</th>
                            <th align="left" width="5%">数量</th>
                            <th align="left" width="5%">小计</th>
                            <th width="10%" align="center">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hfdMaterialId" runat="server" Value='<%#Eval("FK_LineId") %>' />
                            <asp:Label ID="lblBrand" runat="server" Text='<%#Eval("LineBrand") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("LineBrandImg") %>' Width="100" Height="50" /></td>
                        <td>
                            <asp:Label ID="lblMode" runat="server" Text='<%#Eval("LineMode") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("LineName") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("LineDescription").ToString().Replace("\n","<br />") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("LineUnit") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("LineUnitPrice") %>'></asp:Label></td>
                        <td align="center">
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("LinePhoto") %>' Width="100" Height="50" /></td>
                        <td>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("LineTotalcount") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("LineTotalamount") %>'></asp:Label></td>
                        <td align="center">
                            <a href="javascript:;" onclick="ReplaceLine(this);">替换线材</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="8"></td>
                        <td colspan="2" align="center">合计：￥<asp:Label ID="lblTotalLine" runat="server" Text=""></asp:Label></td>
                        <td></td>
                    </tr>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"left\" colspan=\"7\">暂无数据</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th colspan="6" align="center"><b>人工费用</b></th>
                </tr>
                <tr>
                    <th align="center" width="5%">品牌</th>
                    <th align="center" width="10%">LOGO</th>
                    <th align="left" width="5%">型号</th>
                    <th align="left" width="10%">项目</th>
                    <th align="left">描述</th>
                    <th align="left" width="5%">单位</th>
                    <th align="left" width="5%">比例</th>
                    <th align="center" width="10%">图片</th>
                    <th align="left" width="5%">数量</th>
                    <th align="left" width="5%">小计</th>
                    <th width="10%" width="15%">&nbsp;</th>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td></td>
                    <td>弱电布线费</td>
                    <td>
                        <asp:TextBox ID="txtRuodiananzhuangDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td></td>
                    <td align="center">
                        <asp:Image ID="imgRuodiananzhuang" runat="server" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtRuodiananzhuangFee" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td></td>
                    <td>项目管理费</td>
                    <td>
                        <asp:TextBox ID="txtXiangmuguanliDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td>
                        <asp:TextBox ID="txtXiangmuguanliRate" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td align="center">
                        <asp:Image ID="imgXiangmuguanli" runat="server" /></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtXiangmuguanliFee" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td></td>
                    <td>规划与安装</td>
                    <td>
                        <asp:TextBox ID="txtQicaianzhuangDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td>
                        <asp:TextBox ID="txtQicaianzhuangRate" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td align="center">
                        <asp:Image ID="imgQicaianzhuang" runat="server" /></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtQicaianzhuangFee" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                        <img src="../skin/default/星光.jpg" /></td>
                    <td></td>
                    <td>系统调试费</td>
                    <td>
                        <asp:TextBox ID="txtXitongtiaoshiDes" runat="server" CssClass="input normal" Width="95%" TextMode="MultiLine" Height="80" sucmsg=" " /></td>
                    <td>PCS</td>
                    <td>
                        <asp:TextBox ID="txtXitongtiaoshiRate" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td align="center">
                        <asp:Image ID="imgXitongtiaoshi" runat="server" /></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtXitongtiaoshiFee" runat="server" CssClass="input small"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan="3">人工费用合计：
                    ￥<asp:Label ID="lblRengongTotal" runat="server" Text=""></asp:Label></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div class="tab-content">
            该系统小计金额：<asp:Label ID="lblSystemSubTotal" runat="server" Text=""></asp:Label><br />
            <br />
            报价单合计总额：<asp:Label ID="lblQuotaionSubTotal" runat="server" Text=""></asp:Label>
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
