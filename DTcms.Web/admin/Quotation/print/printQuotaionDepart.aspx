<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printQuotaionDepart.aspx.cs" Inherits="DTcms.Web.admin.Quotation.print.printQuotaionDepart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <title>报价单打印预览</title>
    <style type="text/css">
        @page {
            size: landscape;
            margin: 0mm;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            preview();
        })
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--startprint-->
        <div class="tab-content" id="divContent" style="border: none;">
            <div style="text-align: center; width: 100%; padding-bottom: 5px;">
                <asp:Label ID="lblTypeName" runat="server" Text="" Style="font-size: 18px; font-weight: bolder;"></asp:Label>
            </div>
            <asp:Repeater ID="rptList1" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center" style="background-color: aquamarine;">品牌<br />
                                Brand</th>
                            <th align="left" style="background-color: aquamarine;">型号<br />
                                Mode</th>
                            <th align="left" style="background-color: aquamarine;">名称<br />
                                Name</th>
                            <th align="left" style="width: 280px; background-color: aquamarine;">产品描述<br />
                                Description</th>
                            <th align="left" style="background-color: aquamarine;">单位<br />
                                Unit</th>
                            <th align="left" style="background-color: aquamarine;">单价<br />
                                Price</th>
                            <th align="left" style="background-color: aquamarine;">数量<br />
                                Qty</th>
                            <th align="left" style="background-color: aquamarine;">小计<br />
                                Sub Total</th>
                            <th align="center" style="background-color: aquamarine;">图片<br />
                                Photo</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:HiddenField ID="hfdOrderIndex" runat="server" Value='<%#Eval("DetailOrder") %>' />
                            <asp:HiddenField ID="hfdMaterialId" runat="server" Value='<%#Eval("FK_materialID") %>' />
                            <asp:Image ID="imgBrand" runat="server" ImageUrl='<%#Eval("BrandImg") %>' />
                        </td>
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
                        <td>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("GoodsQuantity") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Image ID="imgMaterial" runat="server" ImageUrl='<%#Eval("Photo") %>' Height="50" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td align="right" colspan="9" style="padding-right: 20px; font-size: 15px;">合计：￥<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>元</td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--endprint-->
    </form>
</body>
</html>
