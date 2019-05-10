<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerQuotationList.aspx.cs" Inherits="DTcms.Web.admin.Quotation.CustomerQuotationList" %>

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>历史客户报价单列表</title>
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
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="95%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th>客户编号</th>
                            <th>客户名称</th>
                            <th>联系电话</th>
                            <th>销售工程师</th>
                            <th>业务</th>
                            <th>客户来源</th>
                            <th>状态</th>
                            <th style="width: 200px;">报价单号</th>
                            <th style="width: 180px;">报价单创建日期</th>
                            <th style="width: 120px;">报价单总额</th>
                            <th align="center" style="width: 120px;">&nbsp;</th>
                            <th>折扣</th>
                            <th>实际签单金额</th>
                            <th>签单日期</th>
                            <th align="center">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Eval("CustomerNum")%>
                            <asp:HiddenField ID="hfdId" runat="server" Value='<%#Eval("CustomerId") %>' />
                        </td>
                        <td align="center"><%#Eval("CustomerName")%></td>
                        <td align="center"><%#Eval("CustomerTel")%></td>
                        <td align="center"><%#Eval("SalePeople")%></td>
                        <td align="center"><%#Eval("BussinessPeople")%></td>
                        <td align="center"><%#Eval("CustomerSource")%></td>
                        <td align="center">
                            <asp:HiddenField ID="hfdState" runat="server" Value='<%#Eval("CustomerState") %>' />
                            <%#Eval("CustomerState").ToString()=="1"?"跟单中":Eval("CustomerState").ToString()=="2"?"签单":Eval("CustomerState").ToString()=="3"?"死单":Eval("CustomerState").ToString()=="4"?"弃单":""%></td>
                        <td align="center" colspan="4" style="padding: 0 0 0 0;">
                            <asp:Repeater ID="rptChild" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center" style="width: 200px;"><%#Eval("QuotationListNum") %></td>
                                        <td align="center" style="width: 180px;"><%#Eval("CreateDate") %></td>
                                        <td align="center" style="width: 120px;">￥<asp:Label ID="lblTotalMoney" runat="server" Text=""></asp:Label></td>
                                        <td align="center" style="width: 120px;"><a href='QuotaionDetailEdit.aspx?action=view&id=<%#Eval("QuotationListId") %>'>查看</a>&nbsp;<a href='QuotaionDetailEdit.aspx?action=edit&id=<%#Eval("QuotationListId") %>'>编辑</a><br />
                                            <a href="#">审核</a>&nbsp;<asp:LinkButton ID="lbtnShare" runat="server" CommandArgument='<%#Eval("QuotationListId") %>' OnClientClick="confirm('确认共享该报价单？')" OnClick="lbtnShare_Click">共享</asp:LinkButton></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblZhekou" runat="server" Text=""></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblDealMoney" runat="server" Text=""></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lblDealDate" runat="server" Text=""></asp:Label></td>
                        <td align="center">
                            <asp:LinkButton ID="lbtnSecond" runat="server" OnClick="lbtnSecond_Click">二次报价</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lbtnSign" runat="server" OnClientClick="return confirm('确认签单？')" OnClick="lbtnSign_Click">签单</asp:LinkButton><br />
                            <asp:LinkButton ID="lbtnDie" runat="server" OnClientClick="return confirm('确认死单？')" OnClick="lbtnDie_Click">死单</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lbtnGiveup" runat="server" OnClientClick="return confirm('确认弃单？')" OnClick="lbtnGiveup_Click">弃单</asp:LinkButton>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <!--/内容底部-->
    </form>
</body>
</html>

