<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotationListQuery.aspx.cs" Inherits="DTcms.Web.admin.Quotation.QuotationListQuery" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>模板列表</title>
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
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>报价单列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
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
                            <th width="6%">选择</th>
                            <th align="left">报价单编号</th>
                            <th align="left">所属项目</th>
                            <th align="left">创建日期</th>
                            <th align="left">创建人</th>
                            <th align="left">金额</th>
                            <th align="left">折扣</th>
                            <th align="left">优惠减免</th>
                            <th align="left">税率</th>
                            <th align="left">优惠后金额</th>
                            <th align="left">报价单状态</th>
                            <th width="10%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hfdId" runat="server" Value='<%#Eval("QuotationListId") %>' />
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        </td>
                        <td><%#Eval("QuotationListNum") %></td>
                        <td><%#Eval("FK_ParentProgramId") %></td>
                        <td><%#Eval("CreateDate") %></td>
                        <td><%#Eval("CreateBy") %></td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>
                        <td><%#Eval("PreferentialRatio") %>%</td>
                        <td><%#Eval("PreferentialRelief") %></td>
                        <td><%#Eval("Tax") %>%</td>
                        <td>
                            <asp:Label ID="lblAfterTotal" runat="server" Text=""></asp:Label></td>
                        <td><%#Eval("QuotationListState").ToString()=="0"?"已保存":Eval("QuotationListState").ToString()=="1"?"已审核":"" %></td>
                        <td align="center">
                            <asp:HiddenField ID="hfdState" runat="server" Value='<%#Eval("QuotationListState") %>' />
                            <a href='QuotaionDetailEdit.aspx?action=view&id=<%#Eval("QuotationListId") %>'>查看</a>
                            <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%#Eval("QuotationListId") %>' OnClick="lbtnEdit_Click">编辑</asp:LinkButton>
                            <asp:LinkButton ID="lbtnApprove" runat="server" OnClientClick="return confirm('确认审核？审核无法修改')" CommandArgument='<%#Eval("QuotationListId") %>' OnClick="lbtnApprove_Click">审核</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
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
            PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always"
            Width="100%" OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="5">
        </webdiyer:AspNetPager>
        <!--/内容底部-->

    </form>
</body>
</html>
