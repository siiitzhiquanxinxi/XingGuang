<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryCustomerQuotationList.aspx.cs" Inherits="DTcms.Web.admin.Quotation.HistoryCustomerQuotationList" %>

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
            <span>历史客户报价单</span>
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
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="lbtnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <div class="table-container">
            <!--文字列表-->
            <asp:Repeater ID="rptCusotmer" runat="server">
                <HeaderTemplate>
                    <table border="0" cellspacing="0" cellpadding="0" class="ltable" style="width: 95%;">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: cadetblue;">
                        <td style="padding-left: 5px; text-align: right; color: white;">客户名称：
                        </td>
                        <td align="left" style="color: white;">
                            <asp:HiddenField ID="hfdId" runat="server" Value='<%#Eval("CustomerId") %>' />
                            <%#Eval("CustomerName") %>
                        </td>
                        <td align="right" style="color: white;">客户编号：
                        </td>
                        <td align="left" style="color: white;">
                            <%#Eval("CustomerNum") %>
                        </td>
                        <td align="right" style="color: white;">客户电话：
                        </td>
                        <td align="left" style="color: white;">
                            <%#Eval("CustomerTel") %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-left: 5px;">项目地址：</td>
                        <td colspan="3" align="left">
                            <%#Eval("CustomerAddress") %>
                        </td>
                        <td align="right">面积：</td>
                        <td align="left">
                            <%#Eval("ProgramAreaNum") %>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 5px;" align="right">创建日期：
                        </td>
                        <td align="left">
                            <%#Eval("CreateDate") %>
                        </td>
                        <td align="right">销售设计师：
                        </td>
                        <td align="left">
                            <%#Eval("SalePeople") %>
                        </td>
                        <td align="right">业务员：
                        </td>
                        <td align="left">
                            <%#Eval("BussinessPeople") %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">客户状态：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCustomerState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomerState_SelectedIndexChanged">
                                <asp:ListItem Text="跟单中" Value="1"></asp:ListItem>
                                <asp:ListItem Text="签单" Value="2"></asp:ListItem>
                                <asp:ListItem Text="死单" Value="3"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div style="margin: 0 auto; width: 90%;">
                                <asp:Repeater ID="rptQuotation" runat="server">
                                    <HeaderTemplate>
                                        <table border="0" cellspacing="0" cellpadding="0" class="ltable" style="width: 90%; margin-left: 10px; margin-bottom: 20px;">
                                            <tr>
                                                <th align="left" style="background-color: cyan; padding-left: 10px; color: black;">报价单编号</th>
                                                <th align="left" style="background-color: cyan; color: black;">创建日期</th>
                                                <th align="left" style="background-color: cyan; color: black;">创建人</th>
                                                <th align="left" style="background-color: cyan; color: black;">金额</th>
                                                <th align="left" style="background-color: cyan; color: black;">折扣</th>
                                                <th align="left" style="background-color: cyan; color: black;">优惠减免</th>
                                                <th align="left" style="background-color: cyan; color: black;">税率</th>
                                                <th align="left" style="background-color: cyan; color: black;">优惠后金额</th>
                                                <th align="left" style="background-color: cyan; color: black;">报价单状态</th>
                                                <th width="10%" style="background-color: cyan; color: black;">操作</th>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hfdId" runat="server" Value='<%#Eval("QuotationListId") %>' />
                                                <%#Eval("QuotationListNum") %></td>
                                            <td><%#Eval("CreateDate") %></td>
                                            <td><%#GetName(Eval("CreateBy").ToString()) %></td>
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
                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblIsNoRecord" runat="server" Text="暂无记录" Visible="false"></asp:Label></td>
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptCusotmer.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
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
