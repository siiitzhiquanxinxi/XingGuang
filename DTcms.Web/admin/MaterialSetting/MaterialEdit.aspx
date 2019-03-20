<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialEdit.aspx.cs" Inherits="DTcms.Web.admin.MaterialSetting.MaterialEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>产品详情</title>
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
    <script type="text/javascript">
        function ChooseCustomer() {
            $.dialog({ title: '选择线材', width: '800px', heght: '600px',
                content: 'url:MaterialSetting/chooseMaterial.aspx?idTarget=hidMaterialID',
                lock: true
            });
        }
       <%-- function timerStart() 
        {
            var timer = $find("<%=Timer1.ClientID%>");
            timer._startTimer();
        }
        function timerEnd() {
            var timer = $find("<%=Timer1.ClientID%>");
            timer._stopTimer();
        }--%>
    </script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "200", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });
        });
        
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:;" class="home"><i></i><span>产品新增</span></a>
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div id="floatHead" class="content-tab-wrap">
        <div class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a id="aorder"  class="selected" href="javascript:;" onclick="tabs(this);">产品信息</a></li>
                    <li><a id="aorderdetail"  href="javascript:;" onclick="tabs(this);">配套线材</a></li>
                    <%--<li><a href="javascript:;" onclick="tabs(this);">会议附件</a></li>--%>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>产品分类：</dt>
            <dd>
                <asp:HiddenField ID="hidID" runat="server" />
                <asp:DropDownList ID="ddlMaterialType" runat="server"></asp:DropDownList>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>品牌：</dt>
            <dd>
                <asp:TextBox ID="txtBrand" runat="server" CssClass="input normal" sucmsg=" "
                    minlength="1" MaxLength="100" ></asp:TextBox>
                <span class="Validform_checktip">*</span>
            </dd>
        
            <dt>品牌Logo：</dt>
            <dd>
            <asp:TextBox ID="txtBrandImg" runat="server" CssClass="input normal upload-path"  
                        AutoPostBack="True"/>
            <div class="upload-box upload-img"></div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
     <%--           <asp:Timer ID="Timer2" runat="server" Interval="1000" ></asp:Timer>--%>
                     <asp:Image ID="Image1" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 200px;" class="upload-path"/>
                    
                </ContentTemplate>
                </asp:UpdatePanel>
           
            </dd>
        </dl>
        <dl>
            <dt>型号：</dt>
            <dd>
                <asp:TextBox ID="txtMode" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                    MaxLength="100"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>品名：</dt>
            <dd>
                <asp:TextBox ID="txtName" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                     MaxLength="100"></asp:TextBox>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>产品描述及备注：</dt>
            <dd>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="input" Style="height: 200px;" TextMode="MultiLine" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip"></span>
            </dd>
        </dl>
        <dl>
            <dt>单位：</dt>
            <dd>
                <asp:TextBox ID="txtUnit" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                    MaxLength="100"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>报价：</dt>
            <dd>
                <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                    MaxLength="100"></asp:TextBox>
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>弱电布线费：</dt>
            <dd>
                <asp:TextBox ID="txtLaborCost" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                    MaxLength="100"></asp:TextBox>

            </dd>
        </dl>
        <dl>
            <dt>器材安装费：</dt>
            <dd>
                <asp:TextBox ID="txtInstallationFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                    MaxLength="100"></asp:TextBox>

            </dd>
        </dl>
        <dl>
            <dt>系统调试费：</dt>
            <dd>
                <asp:TextBox ID="txtCommissioningFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                    MaxLength="100"></asp:TextBox>
    
            </dd>
        </dl>
        <dl>
            <dt>项目管理费：</dt>
            <dd>
                <asp:TextBox ID="txtManagementFee" runat="server" CssClass="input normal" sucmsg=" " minlength="1"
                    MaxLength="100"></asp:TextBox>

            </dd>
        </dl>
        <dl>
            <dt>金蝶物料编号：</dt>
            <dd>
                <asp:TextBox ID="txtMaterialID" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                    MaxLength="100"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>金蝶物料名称：</dt>
            <dd>
                <asp:TextBox ID="txtMaterialName" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                    MaxLength="100"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>标注：</dt>
            <dd>
                <asp:DropDownList ID="ddlTag" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>热卖</asp:ListItem>
                    <asp:ListItem>滞销</asp:ListItem>
                    <asp:ListItem>赚钱</asp:ListItem>
                    <asp:ListItem>活动</asp:ListItem>
                </asp:DropDownList>
            </dd>
        </dl>
       
        <dl>
            <dt>产品图片：</dt>
            <dd>
            <asp:TextBox ID="txtPhoto" runat="server" CssClass="input normal upload-path"  
                        AutoPostBack="True"/>
            <div class="upload-box upload-img"></div>
             
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" ></asp:Timer>
                     <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 200px;" class="upload-path"/>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </dd>
        </dl>
        <dl>
         <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">--%>
        <%--<ContentTemplate>--%>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th style="width:10%" align="center">
                            品牌
                        </th>
                        <th  style="width:10%" align="center">
                            型号
                        </th>
                        <th  style="width:10%" align="center">
                            品名
                        </th>
                        <th  style="width:50%" align="center">
                            产品描述
                        </th>
                        <th align="center" align="center">
                            单位
                        </th>
                        <th  style="width:10%"align="center">
                            数量
                        </th>
                        <th align="center">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><asp:HiddenField ID="hfdID" runat="server" Value='<%#Eval("InnerID") %>' />
                        <%# Eval("Brand")%>
                    </td align="center">
                    <td align="center">
                        <%# Eval("Mode")%>
                    </td>
                    <td align="center">
                        <%# Eval("Name")%>
                    </td>
                    <td align="center">
                        <%# Eval("Description")%>
                    </td>
                    <td align="center">
                        <%# Eval("Unit")%>
                    </td>

                    <td align="center">
                        <%# Eval("Num")%>
                    </td>
                    
                    <td align="center">
                        <%--<a href='meetingedit.aspx?id=<%#Eval("id") %>'>修改</a>--%>
                        <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm('确认删除？')"
                             CommandArgument='<%#Eval("InnerID") %>' OnClick="lbtnDel_Click" >删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"18\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater> 
        </dl>
            <%--</ContentTemplate>--%>
                <%--</asp:UpdatePanel>--%>
    
       
        <div class="page-footer">
        <div class="btn-wrap">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click"  />
            <%--<asp:Button ID="btnAddDetail" runat="server" Text="添加配套线材" CssClass="btn" onclick="ChooseCustomer()" />--%>
            <%--<input name="btnAddDetail" type="button" value="添加配套线材" class="btn" onclick="ChooseCustomer() " />--%>
            
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
            
        

    </div>
        
    </div>
    <div class="tab-content" style="display: none;">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <dl>
            <dt>线材品牌：</dt>
            <dd>
                <asp:HiddenField ID="hidMaterialID" runat="server" />
                <asp:TextBox ID="txtMBrand" runat="server" CssClass="input normal" sucmsg=" " ReadOnly="true"></asp:TextBox>
                <input id="btnOpenMaterial" type="button" value="..." style="width: 25px; cursor: pointer;"
            onclick="ChooseCustomer()"/>
                <span class="Validform_checktip"></span>
            </dd>
        </dl>
        <dl>
            <dt>线材型号：</dt>
            <dd>
                <asp:TextBox ID="txtMMode" runat="server" CssClass="input normal" sucmsg=" " minlength="0" MaxLength="50" ReadOnly="true"></asp:TextBox>
            </dd>
        </dl>
        
        <dl>
            <dt>线材品名：</dt>
            <dd>
                <asp:TextBox ID="txtMName" runat="server" CssClass="input normal" sucmsg=" " minlength="0" ReadOnly="true"
                    MaxLength="50"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>产品描述：</dt>
            <dd>
                <asp:TextBox ID="txtMDescription" runat="server" CssClass="input normal" Style="height: 200px;"  sucmsg=" " minlength="0" ReadOnly="true" TextMode="MultiLine"
                    MaxLength="200"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>单位：</dt>
            <dd>
                <asp:TextBox ID="txtMUnit" runat="server" CssClass="input normal" sucmsg=" " minlength="0" ReadOnly="true"
                    MaxLength="50"></asp:TextBox>
            </dd>
        </dl>
        </ContentTemplate>
                </asp:UpdatePanel>
        <dl>
            <dt>数量：</dt>
            <dd>
                <asp:TextBox ID="txtMNum" runat="server" CssClass="input normal" sucmsg=" " minlength="0"
                    MaxLength="100"></asp:TextBox>
            </dd>
        </dl>
        
        <div class="btn-wrap">
        <asp:Button ID="btnAdd" runat="server" Text="添加配套线材" CssClass="btn" onclick="btnAdd_Click" />
        </div>
        
    </div>
    
    
    <!--/内容-->
    <!--工具栏-->
    
    <!--/工具栏-->
    </form>
</body>
</html>
