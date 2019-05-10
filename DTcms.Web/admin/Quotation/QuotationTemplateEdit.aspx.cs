using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DTcms.Web.admin.Quotation
{
    public partial class QuotationTemplateEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            string sql = "select * from Q_QuotationTemplate where QuotationTemplateId = " + Request.QueryString["id"];
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                hfdMtype.Value = dt.Rows[0]["QuotationTemplateTypeId"].ToString();
                txtName.Text = dt.Rows[0]["QuotationTemplateName"].ToString();
                txtMainBrand.Text = dt.Rows[0]["QuotationTemplateMainBrand"].ToString();
                txtType.Text = dt.Rows[0]["QuotationTemplateType"].ToString();
                txtDes.Text = dt.Rows[0]["QuotationTemplateDescription"].ToString();
                txtScenario.Text = dt.Rows[0]["QuotationTemplateScenario"].ToString();
                txtNotes.Text = dt.Rows[0]["QuotationTemplateNotes"].ToString();
                txtOrder.Text = dt.Rows[0]["TempOrder"].ToString();
                sql = "select DetailOrder as OrderIndex,FK_materialID as MaterialID, Brand,BrandImg,Mode,Name,Description,Unit,UnitPrice,Photo,TemplateDetailQuantity as Quantity from Q_QuotationTemplateDetail as QT inner join Sy_Material as M on M.ID = QT.FK_materialID where TemplateParentID = " + Request.QueryString["id"];
                DataTable dtDetail = DbHelperSQL.Query(sql).Tables[0];
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    dtDetail.Rows[i]["OrderIndex"] = i;
                }
                rptList1.DataSource = dtDetail;
                rptList1.DataBind();
                if (Request.QueryString["action"].ToString() == "add")
                {
                    txtQicaianzhuangFee.Text = dt.Rows[0]["QicaianzhuangFee"].ToString() != "" ? dt.Rows[0]["QicaianzhuangFee"].ToString() : "0";
                    txtXitongtiaoshiFee.Text = dt.Rows[0]["XitongtiaoshiFee"].ToString() != "" ? dt.Rows[0]["XitongtiaoshiFee"].ToString() : "0";
                    txtXiangmuguanliFee.Text = dt.Rows[0]["XiangmuguanliFee"].ToString() != "" ? dt.Rows[0]["XiangmuguanliFee"].ToString() : "0";
                    txtQicaianzhuangDes.Text = dt.Rows[0]["QicaianzhuangDes"].ToString();
                    txtXitongtiaoshiDes.Text = dt.Rows[0]["XitongtiaoshiDes"].ToString();
                    txtXiangmuguanliDes.Text = dt.Rows[0]["XiangmuguanliDes"].ToString();
                    txtRuodiananzhuangDes.Text = dt.Rows[0]["RuodiananzhuangDes"].ToString();
                    imgQicaianzhuang.ImageUrl = dt.Rows[0]["QicaianzhuangPic"].ToString();
                    imgXitongtiaoshi.ImageUrl = dt.Rows[0]["XitongtiaoshiPic"].ToString();
                    imgXiangmuguanli.ImageUrl = dt.Rows[0]["XiangmuguanliPic"].ToString();
                    imgRuodiananzhuang.ImageUrl = dt.Rows[0]["RuodiananzhuangPic"].ToString();
                    ddlTag.SelectedValue = dt.Rows[0]["TempTag"].ToString();
                }
                else if (Request.QueryString["action"].ToString() == "edit")
                {
                    txtQicaianzhuangFee.Text = dt.Rows[0]["QicaianzhuangFee"].ToString() != "" ? dt.Rows[0]["QicaianzhuangFee"].ToString() : "0";
                    txtXitongtiaoshiFee.Text = dt.Rows[0]["XitongtiaoshiFee"].ToString() != "" ? dt.Rows[0]["XitongtiaoshiFee"].ToString() : "0";
                    txtXiangmuguanliFee.Text = dt.Rows[0]["XiangmuguanliFee"].ToString() != "" ? dt.Rows[0]["XiangmuguanliFee"].ToString() : "0";
                    txtQicaianzhuangDes.Text = dt.Rows[0]["QicaianzhuangDes"].ToString();
                    txtXitongtiaoshiDes.Text = dt.Rows[0]["XitongtiaoshiDes"].ToString();
                    txtXiangmuguanliDes.Text = dt.Rows[0]["XiangmuguanliDes"].ToString();
                    txtRuodiananzhuangDes.Text = dt.Rows[0]["RuodiananzhuangDes"].ToString();
                    imgQicaianzhuang.ImageUrl = dt.Rows[0]["QicaianzhuangPic"].ToString();
                    imgXitongtiaoshi.ImageUrl = dt.Rows[0]["XitongtiaoshiPic"].ToString();
                    imgXiangmuguanli.ImageUrl = dt.Rows[0]["XiangmuguanliPic"].ToString();
                    imgRuodiananzhuang.ImageUrl = dt.Rows[0]["RuodiananzhuangPic"].ToString();
                    ddlTag.SelectedValue = dt.Rows[0]["TempTag"].ToString();
                    sql = "select FK_LineId as ID,LineBrand as Brand,LineBrandImg as BrandImg,LineMode as Mode,LineName as Name,LineDescription as Description,LineUnit as Unit,LineUnitPrice as UnitPrice,LinePhoto as Photo,LineTotalcount as totalcount,LineTotalamount as totalamount from Q_QuotationTemplateLine where FK_TemplateId = " + Request.QueryString["id"];
                    DataTable dtLine = DbHelperSQL.Query(sql).Tables[0];
                    rptLine.DataSource = dtLine;
                    rptLine.DataBind();
                }
                UpdateLine();
                UpdateLaborFee();
                decimal TotalGoods = hfdTotalGoods.Value != "" ? Convert.ToDecimal(hfdTotalGoods.Value) : 0;
                decimal TotalLine = hfdTotalLine.Value != "" ? Convert.ToDecimal(hfdTotalLine.Value) : 0;
                decimal TotalRengong = hfdTotalRengong.Value != "" ? Convert.ToDecimal(hfdTotalRengong.Value) : 0;
                lblSystemSubTotal.Text = Math.Round(TotalGoods + TotalLine + TotalRengong, 0).ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (rptList1.Items.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请至少选择一件商品！');", true);
                return;
            }
            if (Request.QueryString["action"] == "add")
            {
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                    Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    HiddenField hfdOrderIndex = rptList1.Items[i].FindControl("hfdOrderIndex") as HiddenField;
                    string sql = "insert into Q_QuotationTemplateDetail values(" + Request.QueryString["id"] + "," + hfdMaterialId.Value + "," + hfdOrderIndex.Value + "," + (txtQuantity.Text != "" ? txtQuantity.Text : "0") + ")";
                    DbHelperSQL.ExecuteSql(sql);
                }
                Model.Q_QuotationTemplate model = new BLL.Q_QuotationTemplate().GetModel(int.Parse(Request.QueryString["id"]));
                model.QicaianzhuangFee = (txtQicaianzhuangFee.Text != "" ? Convert.ToDecimal(txtQicaianzhuangFee.Text) : 0);
                model.XitongtiaoshiFee = (txtXitongtiaoshiFee.Text != "" ? Convert.ToDecimal(txtXitongtiaoshiFee.Text) : 0);
                model.XiangmuguanliFee = (txtXiangmuguanliFee.Text != "" ? Convert.ToDecimal(txtXiangmuguanliFee.Text) : 0);
                model.QicaianzhuangDes = txtQicaianzhuangDes.Text;
                model.XitongtiaoshiDes = txtXitongtiaoshiDes.Text;
                model.XiangmuguanliDes = txtXiangmuguanliDes.Text;
                model.RuodiananzhuangDes = txtRuodiananzhuangDes.Text;
                //if (FileUpload1.HasFile)
                //{
                //    string fileurl = "";
                //    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_ruodiananzhuang";
                //    if (!Directory.Exists(Server.MapPath(path)))
                //    {
                //        Directory.CreateDirectory(Server.MapPath(path));
                //    }
                //    fileurl = "../.." + path + "/" + FileUpload1.FileName;
                //    FileUpload1.SaveAs(Server.MapPath(fileurl));
                //    model.RuodiananzhuangPic = path + "/" + FileUpload1.FileName;
                //}
                model.TempTag = ddlTag.SelectedItem.Value;
                model.TempOrder = txtOrder.Text.Trim() != "" ? int.Parse(txtOrder.Text) : 0;
                model.QuotationTemplateName = txtName.Text;
                model.QuotationTemplateMainBrand = txtMainBrand.Text;
                model.QuotationTemplateDescription = txtDes.Text;
                model.QuotationTemplateScenario = txtScenario.Text;
                model.QuotationTemplateNotes = txtNotes.Text;
                model.QuotationTemplateState = 1;
                new BLL.Q_QuotationTemplate().Update(model);
                for (int i = 0; i < rptLine.Items.Count; i++)
                {
                    HiddenField hfdMaterialId = rptLine.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptLine.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptLine.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptLine.Items[i].FindControl("lblMode") as Label;
                    Label lblName = rptLine.Items[i].FindControl("lblName") as Label;
                    Label lblDescription = rptLine.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptLine.Items[i].FindControl("lblUnit") as Label;
                    Image imgMaterial = rptLine.Items[i].FindControl("imgMaterial") as Image;
                    Label lblQuantity = rptLine.Items[i].FindControl("lblQuantity") as Label;
                    Label lblUnitPrice = rptLine.Items[i].FindControl("lblUnitPrice") as Label;
                    Label lblTotalAmount = rptLine.Items[i].FindControl("lblTotalAmount") as Label;

                    string sql2 = "insert into Q_QuotationTemplateLine values(" + Request.QueryString["id"] + "," + hfdMaterialId.Value + ",'" + lblBrand.Text + "','" + imgBrand.ImageUrl.ToString() + "','" + lblMode.Text + "','" + lblName.Text + "','" + lblDescription.Text + "','" + lblUnit.Text + "','" + lblUnitPrice.Text + "','" + imgMaterial.ImageUrl.ToString() + "'," + (lblQuantity.Text != "" ? lblQuantity.Text : "0") + "," + (lblTotalAmount.Text != "" ? lblTotalAmount.Text : "0") + ")";
                    DbHelperSQL.ExecuteSql(sql2);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('模板创建完成！');window.location.href='QuotationTemplateList.aspx'", true);
            }
            else if (Request.QueryString["action"] == "edit")
            {
                string sql = "delete Q_QuotationTemplateDetail where TemplateParentID = " + Request.QueryString["id"];
                DbHelperSQL.ExecuteSql(sql);
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                    Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    HiddenField hfdOrderIndex = rptList1.Items[i].FindControl("hfdOrderIndex") as HiddenField;
                    sql = "insert into Q_QuotationTemplateDetail values(" + Request.QueryString["id"] + "," + hfdMaterialId.Value + "," + hfdOrderIndex.Value + "," + (txtQuantity.Text != "" ? txtQuantity.Text : "0") + ")";
                    DbHelperSQL.ExecuteSql(sql);
                }
                Model.Q_QuotationTemplate model = new BLL.Q_QuotationTemplate().GetModel(int.Parse(Request.QueryString["id"]));
                model.QicaianzhuangFee = (txtQicaianzhuangFee.Text != "" ? Convert.ToDecimal(txtQicaianzhuangFee.Text) : 0);
                model.XitongtiaoshiFee = (txtXitongtiaoshiFee.Text != "" ? Convert.ToDecimal(txtXitongtiaoshiFee.Text) : 0);
                model.XiangmuguanliFee = (txtXiangmuguanliFee.Text != "" ? Convert.ToDecimal(txtXiangmuguanliFee.Text) : 0);
                model.QicaianzhuangDes = txtQicaianzhuangDes.Text;
                model.XitongtiaoshiDes = txtXitongtiaoshiDes.Text;
                model.XiangmuguanliDes = txtXiangmuguanliDes.Text;
                model.RuodiananzhuangDes = txtRuodiananzhuangDes.Text;
                //if (FileUpload1.HasFile)
                //{
                //    string fileurl = "";
                //    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_ruodiananzhuang";
                //    if (!Directory.Exists(Server.MapPath(path)))
                //    {
                //        Directory.CreateDirectory(Server.MapPath(path));
                //    }
                //    fileurl = "../.." + path + "/" + FileUpload1.FileName;
                //    FileUpload1.SaveAs(Server.MapPath(fileurl));
                //    model.RuodiananzhuangPic = path + "/" + FileUpload1.FileName;
                //}
                model.TempTag = ddlTag.SelectedItem.Value;
                model.TempOrder = txtOrder.Text.Trim() != "" ? int.Parse(txtOrder.Text) : 0;
                model.QuotationTemplateName = txtName.Text;
                model.QuotationTemplateMainBrand = txtMainBrand.Text;
                model.QuotationTemplateDescription = txtDes.Text;
                model.QuotationTemplateScenario = txtScenario.Text;
                model.QuotationTemplateNotes = txtNotes.Text;
                new BLL.Q_QuotationTemplate().Update(model);

                sql = "delete Q_QuotationTemplateLine where FK_TemplateId = " + Request.QueryString["id"];
                DbHelperSQL.ExecuteSql(sql);
                for (int i = 0; i < rptLine.Items.Count; i++)
                {
                    HiddenField hfdMaterialId = rptLine.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptLine.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptLine.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptLine.Items[i].FindControl("lblMode") as Label;
                    Label lblName = rptLine.Items[i].FindControl("lblName") as Label;
                    Label lblDescription = rptLine.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptLine.Items[i].FindControl("lblUnit") as Label;
                    Image imgMaterial = rptLine.Items[i].FindControl("imgMaterial") as Image;
                    Label lblQuantity = rptLine.Items[i].FindControl("lblQuantity") as Label;
                    Label lblUnitPrice = rptLine.Items[i].FindControl("lblUnitPrice") as Label;
                    Label lblTotalAmount = rptLine.Items[i].FindControl("lblTotalAmount") as Label;

                    sql = "insert into Q_QuotationTemplateLine values(" + Request.QueryString["id"] + "," + hfdMaterialId.Value + ",'" + lblBrand.Text + "','" + imgBrand.ImageUrl.ToString() + "','" + lblMode.Text + "','" + lblName.Text + "','" + lblDescription.Text + "','" + lblUnit.Text + "','" + lblUnitPrice.Text + "','" + imgMaterial.ImageUrl.ToString() + "'," + (lblQuantity.Text != "" ? lblQuantity.Text : "0") + "," + (lblTotalAmount.Text != "" ? lblTotalAmount.Text : "0") + ")";
                    DbHelperSQL.ExecuteSql(sql);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('模板修改完成！');window.location.href='QuotationTemplateList.aspx'", true);
            }
        }

        DataTable dtgoods = new DataTable();
        private void InitializationDtgoods()
        {
            dtgoods.Columns.Add("OrderIndex", Type.GetType("System.Int32"));
            dtgoods.Columns.Add("MaterialID", Type.GetType("System.String"));
            dtgoods.Columns.Add("Brand", Type.GetType("System.String"));
            dtgoods.Columns.Add("BrandImg", Type.GetType("System.String"));
            dtgoods.Columns.Add("Mode", Type.GetType("System.String"));
            dtgoods.Columns.Add("Name", Type.GetType("System.String"));
            dtgoods.Columns.Add("Description", Type.GetType("System.String"));
            dtgoods.Columns.Add("Unit", Type.GetType("System.String"));
            dtgoods.Columns.Add("UnitPrice", Type.GetType("System.String"));
            dtgoods.Columns.Add("Photo", Type.GetType("System.String"));
            dtgoods.Columns.Add("Quantity", Type.GetType("System.String"));
        }

        private void BindData()
        {
            InitializationDtgoods();
            int needadd = 0;
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdIsDel = rptList1.Items[i].FindControl("hfdIsDel") as HiddenField;
                TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                if (hfdIsDel.Value == "1")//删除
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(hfdReplaceIndex.Value) && i == int.Parse(hfdReplaceIndex.Value) && hfdTempId.Value != "")//替换
                {
                    string sql = "select * from Sy_Material where ID = " + hfdTempId.Value;
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    dtgoods.Rows.Add(new object[] { int.Parse(hfdReplaceIndex.Value), dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], txtQuantity.Text });
                    hfdTempId.Value = hfdReplaceIndex.Value = "";
                    continue;
                }
                if (!string.IsNullOrEmpty(hfdInsertIndex.Value) && i == int.Parse(hfdInsertIndex.Value) && hfdTempId.Value != "")//插入
                {
                    string sql = "select * from Sy_Material where ID = " + hfdTempId.Value;
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    dtgoods.Rows.Add(new object[] { int.Parse(hfdInsertIndex.Value), dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], "" });
                    hfdTempId.Value = hfdInsertIndex.Value = "";
                    i--;
                    needadd++;
                    continue;
                }

                HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                dtgoods.Rows.Add(new object[] { i + needadd, hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, lblName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
            }
            if (hfdTempId.Value != "" && !hfdTempId.Value.Contains('|'))//添加新一行
            {
                string sql = "select * from Sy_Material where ID = " + hfdTempId.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                dtgoods.Rows.Add(new object[] { rptList1.Items.Count, dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], "" });
                hfdTempId.Value = "";
            }
            else if (hfdTempId.Value != "" && hfdTempId.Value.Contains('|'))//添加多行
            {
                string[] arr = hfdTempId.Value.Split('|');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Trim() != "")
                    {
                        string sql = "select * from Sy_Material where ID = " + arr[i].Trim();
                        DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                        dtgoods.Rows.Add(new object[] { rptList1.Items.Count + i, dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], "" });
                    }
                }
                hfdTempId.Value = "";
            }
            rptList1.DataSource = dtgoods;
            rptList1.DataBind();
            UpdateLine();
            UpdateLaborFee();
            decimal TotalGoods = hfdTotalGoods.Value != "" ? Convert.ToDecimal(hfdTotalGoods.Value) : 0;
            decimal TotalLine = hfdTotalLine.Value != "" ? Convert.ToDecimal(hfdTotalLine.Value) : 0;
            decimal TotalRengong = hfdTotalRengong.Value != "" ? Convert.ToDecimal(hfdTotalRengong.Value) : 0;
            lblSystemSubTotal.Text = Math.Round(TotalGoods + TotalLine + TotalRengong, 0).ToString();
        }
        protected void btnBind_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            LinkButton lbtnDel = sender as LinkButton;
            HiddenField hfdIsDel = lbtnDel.Parent.FindControl("hfdIsDel") as HiddenField;
            hfdIsDel.Value = "1";
            BindData();
        }
        protected void lbtnMoveUp_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            HiddenField thishfdOrderIndex = lbtn.Parent.FindControl("hfdOrderIndex") as HiddenField;
            int thisIndex = Convert.ToInt16(thishfdOrderIndex.Value);
            if (thisIndex != 0)
            {
                thishfdOrderIndex.Value = (thisIndex - 1).ToString();
                HiddenField lastHfdIndex = rptList1.Items[thisIndex - 1].FindControl("hfdOrderIndex") as HiddenField;
                lastHfdIndex.Value = (Convert.ToInt16(lastHfdIndex.Value) + 1).ToString();

                InitializationDtgoods();
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdOrderIndex = rptList1.Items[i].FindControl("hfdOrderIndex") as HiddenField;
                    HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                    Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    dtgoods.Rows.Add(new object[] { Convert.ToInt16(hfdOrderIndex.Value), hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, lblName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
                }
                DataView dv = dtgoods.DefaultView;
                dv.Sort = "OrderIndex asc";
                dtgoods = dv.ToTable();

                rptList1.DataSource = dtgoods;
                rptList1.DataBind();
            }
        }
        protected void lbtnMoveDown_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            HiddenField thishfdOrderIndex = lbtn.Parent.FindControl("hfdOrderIndex") as HiddenField;
            int thisIndex = Convert.ToInt16(thishfdOrderIndex.Value);
            int maxIndex = rptList1.Items.Count;
            if (thisIndex != maxIndex - 1)
            {
                thishfdOrderIndex.Value = (thisIndex + 1).ToString();
                HiddenField nextHfdIndex = rptList1.Items[thisIndex + 1].FindControl("hfdOrderIndex") as HiddenField;
                nextHfdIndex.Value = (Convert.ToInt16(nextHfdIndex.Value) - 1).ToString();

                InitializationDtgoods();
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdOrderIndex = rptList1.Items[i].FindControl("hfdOrderIndex") as HiddenField;
                    HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                    Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    dtgoods.Rows.Add(new object[] { Convert.ToInt16(hfdOrderIndex.Value), hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, lblName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
                }
                DataView dv = dtgoods.DefaultView;
                dv.Sort = "OrderIndex asc";
                dtgoods = dv.ToTable();

                rptList1.DataSource = dtgoods;
                rptList1.DataBind();
            }
        }

        /// <summary>
        /// 更新线材信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateLine_Click(object sender, EventArgs e)
        {
            UpdateLine();
        }
        /// <summary>
        /// 更新人工费用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateLaborFee_Click(object sender, EventArgs e)
        {
            UpdateLaborFee();
        }
        /// <summary>
        /// 更新人工费用
        /// </summary>
        private void UpdateLaborFee()
        {
            decimal RuodiananzhuangFee = 0;
            decimal QicaianzhuangFee = 0;
            decimal XitongtiaoshiFee = 0;
            decimal XiangmuguanliFee = 0;
            decimal TotalGoods = 0;
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                Model.Sy_Material mmodel = new BLL.Sy_Material().GetModel(int.Parse(hfdMaterialId.Value));
                TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                decimal count = txtQuantity.Text != "" ? decimal.Parse(txtQuantity.Text) : 0;
                decimal unitprice = lblUnitPrice.Text != "" ? decimal.Parse(lblUnitPrice.Text) : 0;
                QicaianzhuangFee += count * unitprice * (txtQicaianzhuangFee.Text != "" ? Convert.ToDecimal(txtQicaianzhuangFee.Text) : 0);
                XitongtiaoshiFee += count * unitprice * (txtXitongtiaoshiFee.Text != "" ? Convert.ToDecimal(txtXitongtiaoshiFee.Text) : 0);
                XiangmuguanliFee += count * unitprice * (txtXiangmuguanliFee.Text != "" ? Convert.ToDecimal(txtXiangmuguanliFee.Text) : 0);
                TotalGoods += count * unitprice;
                if (mmodel != null && mmodel.LaborCost != null && mmodel.LaborCost != 0)
                {
                    RuodiananzhuangFee += count * Convert.ToDecimal(mmodel.LaborCost);
                }
            }
            txtQicaianzhuangTotal.Text = Math.Round(QicaianzhuangFee, 0).ToString();
            txtXitongtiaoshiTotal.Text = Math.Round(XitongtiaoshiFee, 0).ToString();
            txtXiangmuguanliTotal.Text = Math.Round(XiangmuguanliFee, 0).ToString();
            txtRuodiananzhuangFee.Text = Math.Round(RuodiananzhuangFee, 0).ToString();

            hfdTotalRengong.Value = (QicaianzhuangFee + XitongtiaoshiFee + XiangmuguanliFee + RuodiananzhuangFee).ToString();
            hfdTotalGoods.Value = TotalGoods.ToString();
        }
        /// <summary>
        /// 更新线材
        /// </summary>
        private void UpdateLine()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (hfdLineList.Value != "" && hfdLineList.Value.Contains("|"))
            {
                string[] arr = hfdLineList.Value.Split('|');
                if (arr.Length > 0)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] != "")
                        {
                            string oldL = arr[i].Split('-')[0];
                            string newL = arr[i].Split('-')[1];
                            if (dic.Keys.Contains(oldL))
                            {
                                dic[oldL] = newL;
                            }
                            else
                            {
                                dic.Add(oldL, newL);
                            }
                        }
                    }
                }
            }
            string s = "select ID,Brand,BrandImg,Mode,Name,Description,Unit,UnitPrice,Photo,'' as totalcount,'' as totalamount from Sy_Material where 1=2";
            DataTable d = DbHelperSQL.Query(s).Tables[0];
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                string Quantity = (txtQuantity.Text != "" ? txtQuantity.Text : "0");
                string sql = "select Sy_Material_Detail.*,BrandImg,UnitPrice,Photo," + Quantity + "*Num as totalcount," + Quantity + "*Num*UnitPrice as totalamount from Sy_Material_Detail inner join Sy_Material on Sy_Material.ID = Sy_Material_Detail.ID where ForInnerID = " + hfdMaterialId.Value + "";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dic.Keys.Contains(dt.Rows[j]["ID"].ToString()))
                    {
                        Model.Sy_Material Lmodel = new BLL.Sy_Material().GetModel(int.Parse(dic[dt.Rows[j]["ID"].ToString()]));
                        dt.Rows[j]["ID"] = Lmodel.ID;
                        dt.Rows[j]["Brand"] = Lmodel.Brand;
                        dt.Rows[j]["BrandImg"] = Lmodel.BrandImg;
                        dt.Rows[j]["Mode"] = Lmodel.Mode;
                        dt.Rows[j]["Name"] = Lmodel.Name;
                        dt.Rows[j]["Unit"] = Lmodel.Unit;
                        dt.Rows[j]["UnitPrice"] = Lmodel.UnitPrice;
                        dt.Rows[j]["Photo"] = Lmodel.Photo;
                        //dt.Rows[j]["totalcount"] = "";
                        dt.Rows[j]["totalamount"] = (Lmodel.UnitPrice * Convert.ToDecimal(dt.Rows[j]["totalcount"])).ToString();
                    }
                }
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    DataRow[] dr = d.Select("ID = " + dt.Rows[j]["ID"]);
                    if (dr.Length > 0)
                    {
                        decimal sub = 0;
                        dr[0]["totalcount"] = Math.Round(Convert.ToDecimal(dr[0]["totalcount"]) + Convert.ToDecimal(dt.Rows[j]["totalcount"]), 0).ToString();
                        sub = Math.Round(Convert.ToDecimal(dr[0]["totalamount"]) + Convert.ToDecimal(dt.Rows[j]["totalamount"]), 0);
                        dr[0]["totalamount"] = sub.ToString();
                    }
                    else
                    {
                        d.Rows.Add(new object[] { dt.Rows[j]["ID"], dt.Rows[j]["Brand"], dt.Rows[j]["BrandImg"], dt.Rows[j]["Mode"], dt.Rows[j]["Name"], dt.Rows[j]["Description"], dt.Rows[j]["Unit"], dt.Rows[j]["UnitPrice"], dt.Rows[j]["Photo"], dt.Rows[j]["totalcount"], dt.Rows[j]["totalamount"] });
                    }
                }
            }

            rptLine.DataSource = d;
            rptLine.DataBind();

            decimal linesum = 0;//线材总价
            for (int i = 0; i < rptLine.Items.Count; i++)
            {
                Label lblTotalAmount = rptLine.Items[i].FindControl("lblTotalAmount") as Label;
                linesum += lblTotalAmount.Text != "" ? Convert.ToDecimal(lblTotalAmount.Text) : 0;
            }
            hfdTotalLine.Value = linesum.ToString();
        }

        protected void btnBindLine_Click(object sender, EventArgs e)
        {
            hfdLineList.Value += hfdLineReplaceId.Value + "-" + hfdLineTempId.Value + "|";
            UpdateLine();
            hfdLineTempId.Value = hfdLineReplaceId.Value = "";
        }
    }
}