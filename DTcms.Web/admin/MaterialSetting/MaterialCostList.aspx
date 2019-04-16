<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialCostList.aspx.cs" Inherits="DTcms.Web.admin.MaterialSetting.MaterialCostList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>产品成本价设置</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //图片延迟加载
            $(".pic img").lazyload({ effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
        });
    </script>
    <style type="text/css">
        .textarea {
            width: 99%;
            min-height: 20px;
            _height: 120px;
            margin-left: auto;
            margin-right: auto;
            padding: 3px;
            outline: 0;
            border: 1px solid #a0b3d6;
            font-size: 12px;
            line-height: 24px;
            padding: 2px;
            word-wrap: break-word;
            overflow-x: hidden;
            overflow-y: auto;
            border: none;
            BORDER-BOTTOM: 0px solid;
            BORDER-LEFT: 0px solid;
            BORDER-RIGHT: 0px solid;
            BORDER-TOP: 0px solid;
        }
    </style>
    <script type="text/javascript">
        var observe;
        if (window.attachEvent) {
            observe = function (element, event, handler) {
                element.attachEvent('on' + event, handler);
            };
        }
        else {
            observe = function (element, event, handler) {
                element.addEventListener(event, handler, false);
            };
        }
        function init() {
            var text = document.getElementById('text');
            function resize() {
                text.style.width = '350px';
                text.style.height = 'auto';
                var vHeight = text.scrollHeight + 2;
                text.style.height = vHeight + 'px';
                text.readOnly = true;

            }
            /* 0-timeout to get the already changed text */
            function delayedResize() {
                window.setTimeout(resize, 0);
            }
            observe(text, 'change', resize);
            observe(text, 'cut', delayedResize);
            observe(text, 'paste', delayedResize);
            observe(text, 'drop', delayedResize);
            observe(text, 'keydown', delayedResize);

            text.focus();
            text.select();
            resize();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>产品成本价设置</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                           <%-- <li><a class="add" href='MaterialEdit.aspx?action=Add'><i></i><span>新增</span></a></li>--%>
                            <%--<li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>--%>
                            <%--<li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                            <li>
                                <a class="add" href='MaterialImport.aspx'><i></i><span>导入</span></a></li>--%>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-multi-radio">
                                <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rblType_SelectedIndexChanged"></asp:RadioButtonList>
                            </div>
                            <%--<div class="rule-multi-checkbox">
                                <asp:CheckBoxList ID="cblMType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="cblMType_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>--%>
                        </div>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <!--文字列表-->
            <asp:Repeater ID="rptList1" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="left">类型</th>
                            <th align="left">品牌</th>
                            <th align="center">LOGO</th>
                            <th align="left">型号</th>
                            <th align="left">商品名称</th>
                            <th align="left">描述</th>
                            <th align="left">单位</th>
                            <th align="center">图片</th>
                            <th align="left"  width="5%">销售价</th>
                            <th align="left"  width="5%">成本价</th>
                            <th align="center">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr height="80">
                        
                        <td><asp:HiddenField ID="hfdId" runat="server" Value='<%#Eval("ID") %>' /><%#Eval("MaterialType") %></td>
                        <td><%#Eval("Brand") %></td>
                        <td align="center">
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("BrandImg") %>' /></td>
                        <td><%#Eval("Mode") %></td>
                        <td><%#Eval("Name") %></td>
                        <td><%#Eval("Description").ToString().Replace("\n","<br />") %></td>
                        <%--<td>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Text='<%#Eval("Description") %>' BorderStyle="None" Width="350px" Height="80px" ReadOnly="true"></asp:TextBox></td>--%>
                        <td><%#Eval("Unit") %></td>
                        
                        <td align="center">
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("Photo") %>' Height="50" /></td>
                        <td><%#Eval("UnitPrice") %></td>
                        <td><%#Eval("CostPrice") %></td>
                        <td align="center">
                            <a href='MaterialCostEdit.aspx?action=Edit&id=<%#Eval("ID") %>'>编辑</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
            <!--/文字列表-->
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="当前页:%CurrentPageIndex%/%PageCount% 共有%RecordCount%条记录 %PageCount%/页"
            FirstPageText="首页" HorizontalAlign="Center" InvalidPageIndexErrorMessage="页索引不是有效的数值！"
            LastPageText="末页" NextPageText="下一页" PageIndexOutOfRangeErrorMessage="页索引超出范围！"
            PageSize="50" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always"
            Width="100%" OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="5">
        </webdiyer:AspNetPager>
        <!--/内容底部-->

    </form>
</body>
</html>


