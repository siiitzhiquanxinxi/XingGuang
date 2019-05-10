using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using System.IO;

namespace DTcms.Web.admin.Quotation
{
    public partial class buildQuotaionBlank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.manager mo = Session["dt_session_admin_info"] as Model.manager;
                this.ViewState["GT"] = null;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))//查看报价单明细
                {
                    GetData();
                    if (Request.QueryString["action"] == "view")
                    {
                        btnSave.Visible = false;
                        //btnPrintPreview.Visible = btnPrintTotal.Visible = true;
                        btnAddGoodsType.Visible = b1.Visible = false;
                        btnUpdateLaborFee.Visible = btnUpdateLine.Visible = false;
                    }
                    if (Request.QueryString["action"] == "edit")
                    {

                    }
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["tid"]))//由模板生成
                {
                    if (mo != null)
                    {
                        txtQuotationListNum.Text = GetSpellCode(mo.real_name) + DateTime.Now.ToString("yyyyMMdd") + GetQNum();
                    }
                    CreateData();
                }
                else//空白新建
                {
                    if (mo != null)
                    {
                        txtQuotationListNum.Text = GetSpellCode(mo.real_name) + DateTime.Now.ToString("yyyyMMdd") + GetQNum();
                    }
                    //txtQuotationListNum.Text = "XG" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
            }
        }
        /// <summary>
        /// 读取报价单数据
        /// </summary>
        private void GetData()
        {
            Model.Q_QuotationList Q_model = new BLL.Q_QuotationList().GetModel(int.Parse(Request.QueryString["id"]));
            if (Q_model != null)
            {
                txtQuotationListNum.Text = Q_model.QuotationListNum;
                txtDiscount.Text = Q_model.PreferentialRatio.ToString();
                txtReduce.Text = Math.Round(Convert.ToDecimal(Q_model.PreferentialRelief), 0).ToString();
                txtTax.Text = Q_model.Tax.ToString();
                lstGoodsType = new List<QuatationListTypeClass>();
                List<Model.Q_QuotationDetailType> lstQDT = new BLL.Q_QuotationDetailType().GetModelList("FK_ParentQuotationListId = " + Request.QueryString["id"] + " order by TypeOrder");
                decimal total = 0;
                foreach (Model.Q_QuotationDetailType item in lstQDT)
                {
                    QuatationListTypeClass qltc = new QuatationListTypeClass();
                    qltc.Keyid = item.QuotationDetailTypeId;
                    qltc.lstQuotationDetailGoods = new BLL.Q_QuotationDetailGoods().GetModelList("FK_QuotationDetailTypeId = " + item.QuotationDetailTypeId);//每个商品
                    qltc.lstQuotationDetailLines = new BLL.Q_QuotationDetailLines().GetModelList("FK_QuotationDetailTypeId = " + item.QuotationDetailTypeId);//每个线材
                    qltc.Typeid = Convert.ToInt16(item.FK_MaterialTypeId);
                    qltc.Typename = item.SystemTypeName;
                    qltc.Typedes = item.SystemTypeDes;
                    qltc.QuotationDetailType = new BLL.Q_QuotationDetailType().GetModel(item.QuotationDetailTypeId);
                    qltc.order_index = Convert.ToInt16(qltc.QuotationDetailType.TypeOrder);
                    decimal subTotal = 0;
                    string sql = "select sum(UnitPrice*GoodsQuantity) from Q_QuotationDetailGoods where FK_QuotationDetailTypeId = " + item.QuotationDetailTypeId.ToString();
                    DataTable d = DbHelperSQL.Query(sql).Tables[0];
                    if (d != null && d.Rows.Count > 0 && d.Rows[0][0].ToString() != "")
                    {
                        subTotal = Convert.ToDecimal(d.Rows[0][0].ToString());
                        total += subTotal;
                    }
                    qltc.SubTotal = subTotal;
                    lstGoodsType.Add(qltc);
                }
                rblGoodsType.DataSource = lstGoodsType;
                rblGoodsType.DataTextField = "Typename";
                rblGoodsType.DataValueField = "Typeid";
                rblGoodsType.DataBind();
                this.ViewState["GT"] = lstGoodsType;
                if (txtDiscount.Text != "")
                {
                    total = total * int.Parse(txtDiscount.Text) / 100;
                }
                if (txtReduce.Text != "")
                {
                    total = total - Convert.ToDecimal(txtReduce.Text);
                }
                if (txtTax.Text != "")
                {
                    total = total * (1 + Convert.ToDecimal(txtTax.Text) / 100);
                }
                lblQuotaionSubTotal.Text = Math.Round(total, 0).ToString();
            }
        }
        /// <summary>
        /// 由模板拼成报价单
        /// </summary>
        private void CreateData()
        {
            List<string> lstTempId = new List<string>();
            string[] arr = Request.QueryString["tid"].ToString().Split('|');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "")
                {
                    lstTempId.Add(arr[i]);
                }
            }
            if (lstTempId.Count > 0)
            {
                lstGoodsType = new List<QuatationListTypeClass>();
                int order_index = 0;
                foreach (string TempId in lstTempId)//循环遍历小模板
                {
                    QuatationListTypeClass qltc = new QuatationListTypeClass();
                    Model.Q_QuotationTemplate modelTemp = new BLL.Q_QuotationTemplate().GetModel(int.Parse(TempId));
                    qltc.order_index = order_index;
                    qltc.QuotationDetailType = new Model.Q_QuotationDetailType();
                    qltc.QuotationDetailType.FK_MaterialTypeId = modelTemp.QuotationTemplateTypeId;
                    qltc.QuotationDetailType.SystemTypeName = modelTemp.QuotationTemplateName;
                    qltc.QuotationDetailType.SystemTypeDes = modelTemp.QuotationTemplateDescription;
                    //qltc.QuotationDetailType.RuodiananzhuangFee
                    qltc.QuotationDetailType.QicaianzhuangFee = modelTemp.QicaianzhuangFee;
                    qltc.QuotationDetailType.XitongtiaoshiFee = modelTemp.XitongtiaoshiFee;
                    qltc.QuotationDetailType.XiangmuguanliFee = modelTemp.XiangmuguanliFee;
                    qltc.QuotationDetailType.RuodiananzhuangDes = modelTemp.RuodiananzhuangDes;
                    qltc.QuotationDetailType.QicaianzhuangDes = modelTemp.QicaianzhuangDes;
                    qltc.QuotationDetailType.XitongtiaoshiDes = modelTemp.XitongtiaoshiDes;
                    qltc.QuotationDetailType.XiangmuguanliDes = modelTemp.XiangmuguanliDes;
                    qltc.QuotationDetailType.RuodiananzhuangPic = modelTemp.RuodiananzhuangPic;
                    qltc.QuotationDetailType.QicaianzhuangPic = modelTemp.QicaianzhuangPic;
                    qltc.QuotationDetailType.XitongtiaoshiPic = modelTemp.XitongtiaoshiPic;
                    qltc.QuotationDetailType.XiangmuguanliPic = modelTemp.XiangmuguanliPic;

                    qltc.lstQuotationDetailGoods = new List<Model.Q_QuotationDetailGoods>();//每个模板里的商品
                    List<Model.Q_QuotationTemplateDetail> lstQTD = new BLL.Q_QuotationTemplateDetail().GetModelList("TemplateParentID = " + TempId);
                    int i = 0;
                    foreach (Model.Q_QuotationTemplateDetail item in lstQTD)
                    {
                        Model.Q_QuotationDetailGoods qdg = new Model.Q_QuotationDetailGoods();
                        Model.Sy_Material materialModel = new BLL.Sy_Material().GetModel(Convert.ToInt16(item.FK_materialID));
                        if (materialModel == null)
                        {
                            continue;
                        }
                        qdg.FK_materialID = item.FK_materialID;
                        qdg.DetailOrder = i; i++;
                        qdg.GoodsQuantity = item.TemplateDetailQuantity;
                        qdg.Brand = materialModel.Brand;
                        qdg.BrandImg = materialModel.BrandImg;
                        qdg.Mode = materialModel.Mode;
                        qdg.Name = materialModel.Name;
                        qdg.Description = materialModel.Description;
                        qdg.Unit = materialModel.Unit;
                        qdg.UnitPrice = materialModel.UnitPrice;
                        qdg.CostPrice = materialModel.CostPrice;
                        qdg.LaborCost = materialModel.LaborCost;
                        qdg.InstallationFee = materialModel.InstallationFee;
                        qdg.CommissioningFee = materialModel.CommissioningFee;
                        qdg.ManagementFee = materialModel.ManagementFee;
                        qdg.IndoorInstallationFee = materialModel.IndoorInstallationFee;
                        qdg.IndoorLaborCost = materialModel.IndoorLaborCost;
                        qdg.Photo = materialModel.Photo;
                        qltc.lstQuotationDetailGoods.Add(qdg);
                    }

                    qltc.lstQuotationDetailLines = new List<Model.Q_QuotationDetailLines>();//每个模板里的线材
                    List<Model.Q_QuotationTemplateLine> lstQTL = new BLL.Q_QuotationTemplateLine().GetModelList("FK_TemplateId = " + TempId);
                    foreach (Model.Q_QuotationTemplateLine item in lstQTL)
                    {
                        Model.Q_QuotationDetailLines qdl = new Model.Q_QuotationDetailLines();
                        Model.Sy_Material LineModel = new BLL.Sy_Material().GetModel(Convert.ToInt16(item.FK_LineId));
                        qdl.FK_LineId = item.FK_LineId;
                        qdl.LineBrand = LineModel.Brand;
                        qdl.LineBrandImg = LineModel.BrandImg;
                        qdl.LineMode = LineModel.Mode;
                        qdl.LineName = LineModel.Name;
                        qdl.LineDescription = LineModel.Description;
                        qdl.LineUnit = LineModel.Unit;
                        qdl.LineUnitPrice = LineModel.UnitPrice.ToString();
                        qdl.LinePhoto = LineModel.Photo;
                        qdl.LineTotalcount = item.LineTotalcount;
                        qdl.LineTotalamount = item.LineTotalamount;
                        qltc.lstQuotationDetailLines.Add(qdl);
                    }
                    qltc.Typeid = Convert.ToInt16(modelTemp.QuotationTemplateTypeId);
                    qltc.Typename = modelTemp.QuotationTemplateType;
                    lstGoodsType.Add(qltc);
                    order_index++;
                }

                rblGoodsType.DataSource = lstGoodsType;
                rblGoodsType.DataTextField = "Typename";
                rblGoodsType.DataValueField = "Typeid";
                rblGoodsType.DataBind();
                this.ViewState["GT"] = lstGoodsType;
            }
        }

        DataTable dtmaterial = new DataTable();
        private void InitializationDtmaterial()
        {
            dtmaterial.Columns.Add("DetailOrder", Type.GetType("System.Int32"));
            dtmaterial.Columns.Add("FK_materialID", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Brand", Type.GetType("System.String"));
            dtmaterial.Columns.Add("BrandImg", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Mode", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Name", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Description", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Unit", Type.GetType("System.String"));
            dtmaterial.Columns.Add("UnitPrice", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Photo", Type.GetType("System.String"));
            dtmaterial.Columns.Add("GoodsQuantity", Type.GetType("System.String"));
        }
        private void BindData()
        {
            InitializationDtmaterial();

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
                    dtmaterial.Rows.Add(new object[] { int.Parse(hfdReplaceIndex.Value), dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], txtQuantity.Text });
                    hfdTempId.Value = hfdReplaceIndex.Value = "";
                    continue;
                }
                if (!string.IsNullOrEmpty(hfdInsertIndex.Value) && i == int.Parse(hfdInsertIndex.Value) && hfdTempId.Value != "")//插入
                {
                    string sql = "select * from Sy_Material where ID = " + hfdTempId.Value;
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    dtmaterial.Rows.Add(new object[] { int.Parse(hfdInsertIndex.Value), dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], "" });
                    hfdTempId.Value = hfdInsertIndex.Value = "";
                    i--;
                    needadd++;
                    continue;
                }
                HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                //Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                TextBox txtName = rptList1.Items[i].FindControl("txtName") as TextBox;
                Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                dtmaterial.Rows.Add(new object[] { i + needadd, hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, txtName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
            }
            if (hfdTempId.Value != "" && !hfdTempId.Value.Contains('|'))//添加新一行
            {
                string sql = "select * from Sy_Material where ID = " + hfdTempId.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                dtmaterial.Rows.Add(new object[] { rptList1.Items.Count, dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], "" });
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
                        dtmaterial.Rows.Add(new object[] { rptList1.Items.Count + i, dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], "" });
                    }
                }
                hfdTempId.Value = "";
            }

            rptList1.DataSource = dtmaterial;
            rptList1.DataBind();
            UpdateLine();
            CalculateSubTotal();
        }

        protected void btnBind_Click(object sender, EventArgs e)
        {
            BindData();
        }
        List<QuatationListTypeClass> lstGoodsType;
        protected void btnBind2_Click(object sender, EventArgs e)
        {
            if (this.ViewState["GT"] != null)
            {
                lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
            }
            else
            {
                lstGoodsType = new List<QuatationListTypeClass>();
            }
            //for (int i = 0; i < rblGoodsType.Items.Count; i++)
            //{
            //    if (lstGoodsType.Where(p => p.Typeid == int.Parse(rblGoodsType.Items[i].Value)).Count() <= 0)
            //    {
            //        QuatationListTypeClass qltc = new QuatationListTypeClass();
            //        qltc.Typeid = int.Parse(rblGoodsType.Items[i].Value);
            //        qltc.Typename = rblGoodsType.Items[i].Text.ToString();
            //        lstGoodsType.Add(qltc);
            //    }
            //}
            if (hfdTempId2.Value != "")//添加
            {
                string sql = "select * from Sy_SystemType where SystemTypeID = " + hfdTempId2.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (lstGoodsType.Where(p => p.Typeid == int.Parse(dt.Rows[0]["SystemTypeID"].ToString())).Count() <= 0)
                {
                    QuatationListTypeClass qltc = new QuatationListTypeClass();
                    qltc.Typeid = int.Parse(dt.Rows[0]["SystemTypeID"].ToString());
                    qltc.Typename = dt.Rows[0]["SystemTypeName"].ToString();
                    qltc.order_index = lstGoodsType.Count;
                    lstGoodsType.Add(qltc);
                }
                hfdTempId2.Value = "";
            }
            lstGoodsType = lstGoodsType.OrderBy(u => u.order_index).ToList();
            rblGoodsType.DataSource = lstGoodsType;
            rblGoodsType.DataTextField = "Typename";
            rblGoodsType.DataValueField = "Typeid";
            rblGoodsType.DataBind();
            this.ViewState["GT"] = lstGoodsType;
            for (int i = 0; i < rblGoodsType.Items.Count; i++)
            {
                if (rblGoodsType.Items[i].Value == hfdMtype.Value)
                {
                    rblGoodsType.Items[i].Selected = true;
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveToViewstate();

            Model.Q_QuotationList modelQ_QuotationList;
            int Q_QuotationList_ID;
            if (Request.QueryString["action"] == "add")//新增
            {
                modelQ_QuotationList = new Model.Q_QuotationList();
                modelQ_QuotationList.FK_CustomerID = int.Parse(Request.QueryString["cid"]);
                modelQ_QuotationList.QuotationListNum = txtQuotationListNum.Text;
                modelQ_QuotationList.FK_ParentProgramId = null;
                Model.manager model = new Model.manager();
                model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.manager;
                modelQ_QuotationList.CreateBy = (model != null ? model.id : -1);
                modelQ_QuotationList.CreateDate = DateTime.Now;
                modelQ_QuotationList.QuotationListState = 0;
                modelQ_QuotationList.PreferentialRatio = int.Parse(txtDiscount.Text);
                modelQ_QuotationList.PreferentialRelief = Convert.ToDecimal(txtReduce.Text);
                modelQ_QuotationList.Tax = int.Parse(txtTax.Text);
                modelQ_QuotationList.IsShare = 0;
                Q_QuotationList_ID = new BLL.Q_QuotationList().Add(modelQ_QuotationList);
                string sql = "update C_CustomerProgram set CustomerState = 1 where CustomerId = " + Request.QueryString["cid"];
                DbHelperSQL.ExecuteSql(sql);
            }
            else//修改
            {
                Q_QuotationList_ID = int.Parse(Request.QueryString["id"]);
                modelQ_QuotationList = new BLL.Q_QuotationList().GetModel(Q_QuotationList_ID);
                modelQ_QuotationList.QuotationListNum = txtQuotationListNum.Text;
                modelQ_QuotationList.PreferentialRatio = int.Parse(txtDiscount.Text);
                modelQ_QuotationList.PreferentialRelief = Convert.ToDecimal(txtReduce.Text);
                modelQ_QuotationList.Tax = int.Parse(txtTax.Text);
                modelQ_QuotationList.FK_ParentProgramId = null;
            }
            DbHelperSQL.ExecuteSql("delete Q_QuotationDetailGoods where FK_QuotationDetailTypeId in (select QuotationDetailTypeId from Q_QuotationDetailType where FK_ParentQuotationListId = " + Q_QuotationList_ID + ") ");
            DbHelperSQL.ExecuteSql("delete Q_QuotationDetailLines where FK_QuotationDetailTypeId in (select QuotationDetailTypeId from Q_QuotationDetailType where FK_ParentQuotationListId = " + Q_QuotationList_ID + ") ");
            DbHelperSQL.ExecuteSql("delete Q_QuotationDetailType where FK_ParentQuotationListId = " + Q_QuotationList_ID);

            lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
            for (int i = 0; i < lstGoodsType.Count; i++)
            {
                Model.Q_QuotationDetailType modelQ_QuotationDetailType = lstGoodsType[i].QuotationDetailType;
                modelQ_QuotationDetailType.FK_ParentQuotationListId = Q_QuotationList_ID;
                modelQ_QuotationDetailType.TypeOrder = lstGoodsType[i].order_index;
                int Q_QuotationDetailType_ID = new BLL.Q_QuotationDetailType().Add(modelQ_QuotationDetailType);
                for (int j = 0; j < lstGoodsType[i].lstQuotationDetailGoods.Count; j++)
                {
                    Model.Q_QuotationDetailGoods modelQ_QuotationDetailGoods = lstGoodsType[i].lstQuotationDetailGoods[j];
                    modelQ_QuotationDetailGoods.FK_QuotationDetailTypeId = Q_QuotationDetailType_ID;
                    new BLL.Q_QuotationDetailGoods().Add(modelQ_QuotationDetailGoods);
                }
                for (int j = 0; j < lstGoodsType[i].lstQuotationDetailLines.Count; j++)
                {
                    Model.Q_QuotationDetailLines modelQ_QuotationDetailLines = lstGoodsType[i].lstQuotationDetailLines[j];
                    modelQ_QuotationDetailLines.FK_QuotationDetailTypeId = Q_QuotationDetailType_ID;
                    new BLL.Q_QuotationDetailLines().Add(modelQ_QuotationDetailLines);
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('保存成功！');window.location='CustomerQuotationList.aspx'", true);
        }

        //计算总价
        private void CalculateSubTotal()
        {
            decimal sum = 0;//该系统商品总价
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                Label lblSubTotal = rptList1.Items[i].FindControl("lblSubTotal") as Label;
                decimal Quantity = txtQuantity.Text != "" ? Convert.ToDecimal(txtQuantity.Text) : 0;
                decimal UnitPrice = lblUnitPrice.Text != "" ? Convert.ToDecimal(lblUnitPrice.Text) : 0;
                decimal subTotal = Quantity * UnitPrice;
                lblSubTotal.Text = Math.Round(subTotal, 0).ToString();
                sum += subTotal;
            }
            if (rptList1.Controls.Count > 0)
            {
                Label lblTotalGoods = rptList1.Controls[rptList1.Controls.Count - 1].FindControl("lblTotalGoods") as Label;
                lblTotalGoods.Text = Math.Round(sum, 0).ToString();
            }
            decimal linesum = 0;//线材总价
            for (int i = 0; i < rptLine.Items.Count; i++)
            {
                Label lblTotalAmount = rptLine.Items[i].FindControl("lblTotalAmount") as Label;
                linesum += lblTotalAmount.Text != "" ? Convert.ToDecimal(lblTotalAmount.Text) : 0;
            }
            if (rptLine.Controls.Count > 0)
            {
                Label lblTotalLine = rptLine.Controls[rptLine.Controls.Count - 1].FindControl("lblTotalLine") as Label;
                lblTotalLine.Text = Math.Round(linesum, 0).ToString();
            }
            //人工费总价
            //decimal rengongsum = lblRengongTotal.Text != "" ? Convert.ToDecimal(lblRengongTotal.Text) : 0;
            decimal rengongsum = 0;
            decimal ruodiananzhuangFee = 0;
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                string Quantity = (txtQuantity.Text != "" ? txtQuantity.Text : "0");

                decimal unitRuodianFee = 0;
                Model.Sy_Material mmodel = new BLL.Sy_Material().GetModel(int.Parse(hfdMaterialId.Value));
                if (mmodel != null && mmodel.LaborCost != null)
                {
                    unitRuodianFee = Convert.ToDecimal(mmodel.LaborCost);
                }
                ruodiananzhuangFee += Convert.ToDecimal(Quantity) * unitRuodianFee;
            }
            decimal QicaianzhuangRate = txtQicaianzhuangRate.Text != "" ? Convert.ToDecimal(txtQicaianzhuangRate.Text) : 0;
            decimal XitongtiaoshiRate = txtXitongtiaoshiRate.Text != "" ? Convert.ToDecimal(txtXitongtiaoshiRate.Text) : 0;
            decimal XiangmuguanliRate = txtXiangmuguanliRate.Text != "" ? Convert.ToDecimal(txtXiangmuguanliRate.Text) : 0;

            decimal QicaianzhuangFee = QicaianzhuangRate * sum;
            decimal XitongtiaoshiFee = XitongtiaoshiRate * sum;
            decimal XiangmuguanliFee = XiangmuguanliRate * sum;
            txtRuodiananzhuangFee.Text = Math.Round(ruodiananzhuangFee, 0).ToString();
            txtQicaianzhuangFee.Text = Math.Round(QicaianzhuangFee, 0).ToString();
            txtXitongtiaoshiFee.Text = Math.Round(XitongtiaoshiFee, 0).ToString();
            txtXiangmuguanliFee.Text = Math.Round(XiangmuguanliFee, 0).ToString();
            rengongsum = QicaianzhuangFee + XitongtiaoshiFee + XiangmuguanliFee + ruodiananzhuangFee;
            lblRengongTotal.Text = Math.Round(rengongsum, 0).ToString();

            //系统总价
            decimal totalsum = sum + linesum + rengongsum;
            lblSystemSubTotal.Text = Math.Round(totalsum, 0).ToString();
            if (this.ViewState["GT"] != null)
            {
                lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
                lstGoodsType.Where(p => p.Typeid == Convert.ToDecimal(hfdMtype.Value)).First().SubTotal = totalsum;

                decimal total = 0;
                for (int i = 0; i < lstGoodsType.Count; i++)
                {
                    total += lstGoodsType[i].SubTotal;
                }
                if (txtDiscount.Text != "")
                {
                    total = total * int.Parse(txtDiscount.Text) / 100;
                }
                if (txtReduce.Text != "")
                {
                    total = total - Convert.ToDecimal(txtReduce.Text);
                }
                if (txtTax.Text != "")
                {
                    total = total * (1 + Convert.ToDecimal(txtTax.Text) / 100);
                }
                lblQuotaionSubTotal.Text = Math.Round(total, 0).ToString();
            }
        }

        //更新线材
        protected void btnUpdateLine_Click(object sender, EventArgs e)
        {
            UpdateLine();
            CalculateSubTotal();
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
            string s = "select ID as FK_LineId,Brand as LineBrand,BrandImg as LineBrandImg,Mode as LineMode,Name as LineName,Description as LineDescription,Unit as LineUnit,UnitPrice as LineUnitPrice,Photo as LinePhoto,'' as LineTotalcount,'' as LineTotalamount from Sy_Material where 1=2";
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
                        dt.Rows[j]["totalamount"] = (Lmodel.UnitPrice * Convert.ToDecimal(dt.Rows[j]["totalcount"])).ToString();
                    }
                }
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    DataRow[] dr = d.Select("FK_LineId = " + dt.Rows[j]["ID"]);
                    if (dr.Length > 0)
                    {
                        dr[0]["LineTotalcount"] = Math.Round(Convert.ToDecimal(dr[0]["LineTotalcount"]) + Convert.ToDecimal(dt.Rows[j]["totalcount"]), 0).ToString();
                        dr[0]["LineTotalamount"] = Math.Round(Convert.ToDecimal(dr[0]["LineTotalamount"]) + Convert.ToDecimal(dt.Rows[j]["totalamount"]), 0).ToString();
                    }
                    else
                    {
                        d.Rows.Add(new object[] { dt.Rows[j]["ID"], dt.Rows[j]["Brand"], dt.Rows[j]["BrandImg"], dt.Rows[j]["Mode"], dt.Rows[j]["Name"], dt.Rows[j]["Description"], dt.Rows[j]["Unit"], dt.Rows[j]["UnitPrice"], dt.Rows[j]["Photo"], dt.Rows[j]["totalcount"], dt.Rows[j]["totalamount"] });
                    }
                }
            }
            rptLine.DataSource = d;
            rptLine.DataBind();
        }
        /// <summary>
        /// 更新人工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateLaborFee_Click(object sender, EventArgs e)
        {
            CalculateSubTotal();
        }

        /// <summary>
        /// 切换商品类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblGoodsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveToViewstate();
            hfdMtype.Value = rblGoodsType.SelectedItem.Value.ToString();
            ShowByViewstate();
        }
        //保存商品信息
        private void SaveToViewstate()
        {
            if (hfdMtype.Value != "" && this.ViewState["GT"] != null)
            {
                lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
                QuatationListTypeClass qltc = lstGoodsType.Where(p => p.Typeid == int.Parse(hfdMtype.Value)).First();
                qltc.QuotationDetailType = new Model.Q_QuotationDetailType();
                qltc.QuotationDetailType.FK_MaterialTypeId = qltc.Typeid;
                qltc.QuotationDetailType.SystemTypeName = txtSystemName.Text;
                qltc.QuotationDetailType.SystemTypeDes = txtSystemDes.Text;

                qltc.QuotationDetailType.QicaianzhuangFee = (txtQicaianzhuangRate.Text != "" ? Convert.ToDecimal(txtQicaianzhuangRate.Text) : 0);
                qltc.QuotationDetailType.XitongtiaoshiFee = (txtXitongtiaoshiRate.Text != "" ? Convert.ToDecimal(txtXitongtiaoshiRate.Text) : 0);
                qltc.QuotationDetailType.XiangmuguanliFee = (txtXiangmuguanliRate.Text != "" ? Convert.ToDecimal(txtXiangmuguanliRate.Text) : 0);

                qltc.QuotationDetailType.RuodiananzhuangDes = txtRuodiananzhuangDes.Text;
                qltc.QuotationDetailType.QicaianzhuangDes = txtQicaianzhuangDes.Text;
                qltc.QuotationDetailType.XitongtiaoshiDes = txtXitongtiaoshiDes.Text;
                qltc.QuotationDetailType.XiangmuguanliDes = txtXiangmuguanliDes.Text;

                qltc.QuotationDetailType.RuodiananzhuangPic = imgRuodiananzhuang.ImageUrl;
                qltc.QuotationDetailType.QicaianzhuangPic = imgQicaianzhuang.ImageUrl;
                qltc.QuotationDetailType.XitongtiaoshiPic = imgXitongtiaoshi.ImageUrl;
                qltc.QuotationDetailType.XiangmuguanliPic = imgXiangmuguanli.ImageUrl;

                qltc.lstQuotationDetailGoods = new List<Model.Q_QuotationDetailGoods>();
                qltc.lstQuotationDetailLines = new List<Model.Q_QuotationDetailLines>();
                //商品
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                    TextBox txtName = rptList1.Items[i].FindControl("txtName") as TextBox;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    HiddenField hfdOrderIndex = rptList1.Items[i].FindControl("hfdOrderIndex") as HiddenField;

                    Model.Q_QuotationDetailGoods qdg = new Model.Q_QuotationDetailGoods();
                    qdg.FK_materialID = int.Parse(hfdMaterialId.Value);
                    qdg.Brand = lblBrand.Text;
                    qdg.BrandImg = imgBrand.ImageUrl;
                    qdg.Mode = lblMode.Text;
                    qdg.Name = txtName.Text;
                    qdg.Description = lblDescription.Text;
                    qdg.Unit = lblUnit.Text;
                    qdg.UnitPrice = Convert.ToDecimal(lblUnitPrice.Text);
                    qdg.Photo = imgMaterial.ImageUrl;
                    qdg.GoodsQuantity = Convert.ToDecimal(txtQuantity.Text != "" ? txtQuantity.Text : "0");
                    qdg.DetailOrder = Convert.ToInt16(hfdOrderIndex.Value);

                    qltc.lstQuotationDetailGoods.Add(qdg);
                }
                //线材
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

                    Model.Q_QuotationDetailLines qdl = new Model.Q_QuotationDetailLines();
                    qdl.FK_LineId = int.Parse(hfdMaterialId.Value);
                    qdl.LineBrand = lblBrand.Text;
                    qdl.LineBrandImg = imgBrand.ImageUrl;
                    qdl.LineMode = lblMode.Text;
                    qdl.LineName = lblName.Text;
                    qdl.LineDescription = lblDescription.Text;
                    qdl.LineUnit = lblUnit.Text;
                    qdl.LinePhoto = imgMaterial.ImageUrl;
                    qdl.LineTotalcount = Convert.ToDecimal(lblQuantity.Text);
                    qdl.LineUnitPrice = lblUnitPrice.Text;
                    qdl.LineTotalamount = Convert.ToDecimal(lblTotalAmount.Text);

                    qltc.lstQuotationDetailLines.Add(qdl);
                }
                this.ViewState["GT"] = lstGoodsType;
            }
        }
        //显示之前编辑的商品信息
        private void ShowByViewstate()
        {
            if (hfdMtype.Value != "" && this.ViewState["GT"] != null)
            {
                lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
                QuatationListTypeClass qltc = lstGoodsType.Where(p => p.Typeid == int.Parse(hfdMtype.Value)).First();
                //显示商品列表
                rptList1.DataSource = qltc.lstQuotationDetailGoods != null ? qltc.lstQuotationDetailGoods : null;
                rptList1.DataBind();
                //显示线材列表
                rptLine.DataSource = qltc.lstQuotationDetailLines != null ? qltc.lstQuotationDetailLines : null;
                rptLine.DataBind();
                if (qltc.QuotationDetailType != null)
                {
                    if (!string.IsNullOrEmpty(qltc.QuotationDetailType.SystemTypeName))
                    {
                        txtSystemName.Text = qltc.QuotationDetailType.SystemTypeName;
                    }
                    else
                    {
                        txtSystemName.Text = rblGoodsType.SelectedItem.Text;
                    }
                    txtSystemDes.Text = qltc.QuotationDetailType.SystemTypeDes;

                    //显示人工费用比例和描述
                    decimal QicaianzhuangRate = qltc.QuotationDetailType.QicaianzhuangFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.QicaianzhuangFee) : 0;
                    decimal XitongtiaoshiRate = qltc.QuotationDetailType.XitongtiaoshiFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.XitongtiaoshiFee) : 0;
                    decimal XiangmuguanliRate = qltc.QuotationDetailType.XiangmuguanliFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.XiangmuguanliFee) : 0;

                    txtQicaianzhuangRate.Text = Math.Round(QicaianzhuangRate, 2).ToString();
                    txtXitongtiaoshiRate.Text = Math.Round(XitongtiaoshiRate, 2).ToString();
                    txtXiangmuguanliRate.Text = Math.Round(XiangmuguanliRate, 2).ToString();

                    txtRuodiananzhuangDes.Text = qltc.QuotationDetailType.RuodiananzhuangDes;
                    txtQicaianzhuangDes.Text = qltc.QuotationDetailType.QicaianzhuangDes;
                    txtXitongtiaoshiDes.Text = qltc.QuotationDetailType.XitongtiaoshiDes;
                    txtXiangmuguanliDes.Text = qltc.QuotationDetailType.XiangmuguanliDes;

                    imgRuodiananzhuang.ImageUrl = qltc.QuotationDetailType.RuodiananzhuangPic;
                    imgQicaianzhuang.ImageUrl = qltc.QuotationDetailType.QicaianzhuangPic;
                    imgXitongtiaoshi.ImageUrl = qltc.QuotationDetailType.XitongtiaoshiPic;
                    imgXiangmuguanli.ImageUrl = qltc.QuotationDetailType.XiangmuguanliPic;

                    decimal sum = 0;//该系统商品总价
                    for (int i = 0; i < rptList1.Items.Count; i++)
                    {
                        TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                        Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                        Label lblSubTotal = rptList1.Items[i].FindControl("lblSubTotal") as Label;
                        decimal Quantity = txtQuantity.Text != "" ? Convert.ToDecimal(txtQuantity.Text) : 0;
                        decimal UnitPrice = lblUnitPrice.Text != "" ? Convert.ToDecimal(lblUnitPrice.Text) : 0;
                        decimal subTotal = Quantity * UnitPrice;
                        sum += subTotal;
                    }
                    //txtQicaianzhuangFee.Text = Math.Round(sum * QicaianzhuangRate, 0).ToString();
                    //txtXitongtiaoshiFee.Text = Math.Round(sum * XitongtiaoshiRate, 0).ToString();
                    //txtXiangmuguanliFee.Text = Math.Round(sum * XiangmuguanliRate, 0).ToString();

                    ////显示人工费用总计
                    //lblRengongTotal.Text = Math.Round(sum * RuodiananzhuangRate + sum * QicaianzhuangRate + sum * XitongtiaoshiRate + sum * XiangmuguanliRate + sum * VideoDebugRate + sum * AudioDebugRate, 0).ToString();
                }
                else
                {
                    if (rblGoodsType.SelectedItem != null)
                    {
                        txtSystemName.Text = rblGoodsType.SelectedItem.Text;
                    }
                    txtSystemDes.Text = txtRuodiananzhuangFee.Text = txtQicaianzhuangFee.Text = txtXitongtiaoshiFee.Text = txtXiangmuguanliFee.Text = "";
                    txtQicaianzhuangRate.Text = txtXitongtiaoshiRate.Text = txtXiangmuguanliRate.Text = "";
                    txtRuodiananzhuangDes.Text = txtQicaianzhuangDes.Text = txtXitongtiaoshiDes.Text = txtXiangmuguanliDes.Text = "";
                }
                CalculateSubTotal();

            }
        }

        //打印
        protected void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfdMtype.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请选择系统类型')", true);
                return;
            }
            lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
            string id = lstGoodsType.Where(p => p.Typeid == Convert.ToInt32(hfdMtype.Value)).First().Keyid.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "window.open('print/printQuotaionDepart.aspx?id=" + id + "', '_blank');", true);
        }
        protected void btnPrintTotal_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "window.open('print/printQuotaionTotal.aspx?id=" + id + "', '_blank');", true);
        }

        [Serializable]
        private class QuatationListTypeClass
        {
            /// <summary>
            /// 主键
            /// </summary>
            public int Keyid { get; set; }
            /// <summary>
            /// 系统类别id
            /// </summary>
            public int Typeid { get; set; }
            /// <summary>
            /// 系统类别名称
            /// </summary>
            public string Typename { get; set; }
            public string Typedes { get; set; }
            /// <summary>
            /// 该系统分类小计金额
            /// </summary>
            public decimal SubTotal = 0;
            /// <summary>
            /// 排序
            /// </summary>
            public int order_index { get; set; }
            public Model.Q_QuotationDetailType QuotationDetailType;
            public List<Model.Q_QuotationDetailGoods> lstQuotationDetailGoods;
            public List<Model.Q_QuotationDetailLines> lstQuotationDetailLines;
        }

        #region 商品的移动、删除
        protected void lbtnToleft_Click(object sender, EventArgs e)
        {
            if (this.ViewState["GT"] != null)
            {
                lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
                if (!string.IsNullOrEmpty(hfdMtype.Value))
                {
                    QuatationListTypeClass qltc = lstGoodsType.Where(p => p.Typeid == int.Parse(hfdMtype.Value)).First();
                    if (qltc.order_index != 0)
                    {
                        QuatationListTypeClass last = lstGoodsType.Where(p => p.order_index == qltc.order_index - 1).First();
                        qltc.order_index--;
                        last.order_index++;
                        lstGoodsType = lstGoodsType.OrderBy(u => u.order_index).ToList();
                        rblGoodsType.DataSource = lstGoodsType;
                        rblGoodsType.DataTextField = "Typename";
                        rblGoodsType.DataValueField = "Typeid";
                        rblGoodsType.DataBind();
                        for (int i = 0; i < rblGoodsType.Items.Count; i++)
                        {
                            if (rblGoodsType.Items[i].Value == qltc.Typeid.ToString())
                            {
                                rblGoodsType.Items[i].Selected = true;
                                break;
                            }
                        }
                        this.ViewState["GT"] = lstGoodsType;
                    }
                }
            }
        }
        protected void lbtnToright_Click(object sender, EventArgs e)
        {
            if (this.ViewState["GT"] != null)
            {
                lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
                if (!string.IsNullOrEmpty(hfdMtype.Value))
                {
                    QuatationListTypeClass qltc = lstGoodsType.Where(p => p.Typeid == int.Parse(hfdMtype.Value)).First();
                    if (qltc.order_index != lstGoodsType.Count - 1)
                    {
                        QuatationListTypeClass next = lstGoodsType.Where(p => p.order_index == qltc.order_index + 1).First();
                        qltc.order_index++;
                        next.order_index--;
                        lstGoodsType = lstGoodsType.OrderBy(u => u.order_index).ToList();
                        rblGoodsType.DataSource = lstGoodsType;
                        rblGoodsType.DataTextField = "Typename";
                        rblGoodsType.DataValueField = "Typeid";
                        rblGoodsType.DataBind();
                        for (int i = 0; i < rblGoodsType.Items.Count; i++)
                        {
                            if (rblGoodsType.Items[i].Value == qltc.Typeid.ToString())
                            {
                                rblGoodsType.Items[i].Selected = true;
                                break;
                            }
                        }
                        this.ViewState["GT"] = lstGoodsType;
                    }
                }
            }
        }
        protected void lbtnTodel_Click(object sender, EventArgs e)
        {
            if (this.ViewState["GT"] != null)
            {
                lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
                if (!string.IsNullOrEmpty(hfdMtype.Value))
                {
                    QuatationListTypeClass qltc = lstGoodsType.Where(p => p.Typeid == int.Parse(hfdMtype.Value)).First();
                    lstGoodsType.Remove(qltc);
                    lstGoodsType = lstGoodsType.OrderBy(u => u.order_index).ToList();
                    rblGoodsType.DataSource = lstGoodsType;
                    rblGoodsType.DataTextField = "Typename";
                    rblGoodsType.DataValueField = "Typeid";
                    rblGoodsType.DataBind();
                    hfdMtype.Value = "";
                    rptList1.DataSource = null;
                    rptList1.DataBind();
                    this.ViewState["GT"] = lstGoodsType;
                }
            }
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

                InitializationDtmaterial();
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdOrderIndex = rptList1.Items[i].FindControl("hfdOrderIndex") as HiddenField;
                    HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                    //Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                    TextBox txtName = rptList1.Items[i].FindControl("txtName") as TextBox;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    dtmaterial.Rows.Add(new object[] { Convert.ToInt16(hfdOrderIndex.Value), hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, txtName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
                }
                DataView dv = dtmaterial.DefaultView;
                dv.Sort = "DetailOrder asc";
                dtmaterial = dv.ToTable();

                rptList1.DataSource = dtmaterial;
                rptList1.DataBind();
                CalculateSubTotal();
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

                InitializationDtmaterial();
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdOrderIndex = rptList1.Items[i].FindControl("hfdOrderIndex") as HiddenField;
                    HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                    Label lblBrand = rptList1.Items[i].FindControl("lblBrand") as Label;
                    Image imgBrand = rptList1.Items[i].FindControl("imgBrand") as Image;
                    Label lblMode = rptList1.Items[i].FindControl("lblMode") as Label;
                    //Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                    TextBox txtName = rptList1.Items[i].FindControl("txtName") as TextBox;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    dtmaterial.Rows.Add(new object[] { Convert.ToInt16(hfdOrderIndex.Value), hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, txtName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
                }
                DataView dv = dtmaterial.DefaultView;
                dv.Sort = "DetailOrder asc";
                dtmaterial = dv.ToTable();

                rptList1.DataSource = dtmaterial;
                rptList1.DataBind();
                CalculateSubTotal();
            }
        }
        #endregion

        private string GetQNum()
        {
            string sql = "select QuotationListId from Q_QuotationList where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null)
            {
                int count = dt.Rows.Count + 1;
                if (count <= 9)
                {
                    return "000" + count;
                }
                else if (count <= 99)
                {
                    return "00" + count;
                }
                else if (count <= 999)
                {
                    return "0" + count;
                }
                else
                {
                    return count.ToString();
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 在指定的字符串列表CnStr中检索符合拼音索引字符串
        /// </summary>
        /// <param name="CnStr">汉字字符串</param>
        /// <returns>相对应的汉语拼音首字母串</returns>
        public static string GetSpellCode(string CnStr)
        {
            string strTemp = "";
            int iLen = CnStr.Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
            }
            return strTemp;

        }
        /// <summary>
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
        /// </summary>
        /// <param name="CnChar">单个汉字</param>
        /// <returns>单个大写字母</returns>
        private static string GetCharSpellCode(string CnChar)
        {

            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回

            if (ZW.Length == 1)
            {

                return CnChar.ToUpper();

            }

            else
            {

                // get the array of byte from the single char

                int i1 = (short)(ZW[0]);

                int i2 = (short)(ZW[1]);

                iCnChar = i1 * 256 + i2;

            }

            // iCnChar match the constant

            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {

                return "A";

            }

            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {

                return "B";

            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {

                return "C";

            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {

                return "D";

            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {

                return "E";

            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {

                return "F";

            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {

                return "G";

            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {

                return "H";

            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {

                return "J";

            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {

                return "K";

            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {

                return "L";

            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {

                return "M";

            }
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {

                return "N";

            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {

                return "O";

            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {

                return "P";

            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {

                return "Q";

            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {

                return "R";

            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {

                return "S";

            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {

                return "T";

            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {

                return "W";

            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {

                return "X";

            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {

                return "Y";

            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {

                return "Z";

            }
            else

                return ("?");

        }

        protected void btnBindLine_Click(object sender, EventArgs e)
        {
            hfdLineList.Value += hfdLineReplaceId.Value + "-" + hfdLineTempId.Value + "|";
            UpdateLine();
            hfdLineTempId.Value = hfdLineReplaceId.Value = "";
        }

        protected void btnExportTotal_Click(object sender, EventArgs e)
        {
            DataTable dt = DbHelperSQL.Query("select * from Sy_SystemType where 1=1").Tables[0];
            dt.Columns.Add("pic");

            byte[] bytes = SaveImage(Server.MapPath(@"../../" + dt.Rows[0]["RuodiananzhuangPic"].ToString()));
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);




            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
            workbook.Open(Server.MapPath(@"muban.xls"));
            Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Cells.SetRowHeight(1, 60);
            worksheet.Cells.SetColumnWidth(14, 20);
            worksheet.Cells.ImportDataTable(dt, false, 1, 0, dt.Rows.Count, dt.Columns.Count, true);
            worksheet.Pictures.Add(1, 14, ms, 500, 300);
            string title = DateTime.Now.ToString("yyyyMMddHHmm");
            workbook.Save(Server.MapPath(@"../../upload/" + title + ".xls"));
            DTcms.Common.Utils.down(Server.MapPath(@"../../upload/" + title + ".xls"), Response);
            if (File.Exists(Server.MapPath(@"../../upload/" + title + ".xls")))
            {
                File.Delete(Server.MapPath(@"../../upload/" + title + ".xls"));
            }
        }

        public byte[] SaveImage(String path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
            BinaryReader br = new BinaryReader(fs);
            byte[] imgBytesIn = br.ReadBytes((int)fs.Length); //将流读入到字节数组中
            return imgBytesIn;
        }
        /// <summary>
        /// 导出sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExportSheet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfdMtype.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请选择系统类型')", true);
                return;
            }
            lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
            string id = lstGoodsType.Where(p => p.Typeid == Convert.ToInt32(hfdMtype.Value)).First().Keyid.ToString();
            Model.Q_QuotationDetailType qdt = new BLL.Q_QuotationDetailType().GetModel(int.Parse(id));
            if (qdt != null)
            {
                string sql = "select * from Q_QuotationDetailGoods where FK_QuotationDetailTypeId = " + id + " order by DetailOrder";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                workbook.Open(Server.MapPath(@"sheet.xlsx"));
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                decimal total = 0;
                Aspose.Cells.Style style = workbook.Styles[workbook.Styles.Add()];//新增样式
                //style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;//文字居中
                style.Font.Name = "宋体";//文字字体
                style.Font.Size = 10;//文字大小
                style.IsTextWrapped = true;//单元格内容自动换行
                style.VerticalAlignment = Aspose.Cells.TextAlignmentType.Center;
                worksheet.Cells[0, 0].PutValue(qdt.SystemTypeName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["BrandImg"].ToString().Trim() != "")
                    {
                        byte[] bytes = SaveImage(Server.MapPath(@"../../" + dt.Rows[0]["BrandImg"].ToString()));
                        MemoryStream ms = new MemoryStream(bytes);
                        worksheet.Pictures.Add(i + 5, 1, ms, 110, 25);
                    }
                    if (dt.Rows[i]["Photo"].ToString().Trim() != "")
                    {
                        byte[] bytes = SaveImage(Server.MapPath(@"../../" + dt.Rows[0]["Photo"].ToString()));
                        MemoryStream ms = new MemoryStream(bytes);
                        worksheet.Pictures.Add(i + 5, 9, ms, 110, 25);
                    }
                    decimal qty = 0;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["GoodsQuantity"].ToString()))
                    {
                        qty = Convert.ToDecimal(dt.Rows[0]["GoodsQuantity"].ToString());
                    }
                    decimal unitptice = 0;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["UnitPrice"].ToString()))
                    {
                        unitptice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"].ToString());
                    }
                    decimal subTotal = qty * unitptice;
                    total += subTotal;
                    worksheet.Cells[i + 5, 0].PutValue((i + 1).ToString());
                    worksheet.Cells[i + 5, 2].PutValue(dt.Rows[0]["Mode"].ToString());
                    worksheet.Cells[i + 5, 3].PutValue(dt.Rows[0]["Name"].ToString());
                    worksheet.Cells[i + 5, 4].PutValue(dt.Rows[0]["Description"].ToString().Replace("<br />", "\r\n"));
                    worksheet.Cells[i + 5, 5].PutValue(Math.Round(qty, 0).ToString());
                    worksheet.Cells[i + 5, 6].PutValue(dt.Rows[0]["Unit"].ToString());
                    worksheet.Cells[i + 5, 7].PutValue(Math.Round(unitptice, 0).ToString());
                    worksheet.Cells[i + 5, 8].PutValue("￥" + Math.Round(subTotal, 0).ToString());
                    worksheet.Cells[i + 5, 0].Style = style;
                    worksheet.Cells[i + 5, 1].Style = style;
                    worksheet.Cells[i + 5, 2].Style = style;
                    worksheet.Cells[i + 5, 3].Style = style;
                    worksheet.Cells[i + 5, 4].Style = style;
                    worksheet.Cells[i + 5, 5].Style = style;
                    worksheet.Cells[i + 5, 6].Style = style;
                    worksheet.Cells[i + 5, 7].Style = style;
                    worksheet.Cells[i + 5, 8].Style = style;
                    worksheet.Cells.SetRowHeight(i + 5, 55);
                }
                string title = DateTime.Now.ToString("yyyyMMddHHmm");
                workbook.Save(Server.MapPath(@"../../upload/" + title + ".xls"));
                DTcms.Common.Utils.down(Server.MapPath(@"../../upload/" + title + ".xls"), Response);
                if (File.Exists(Server.MapPath(@"../../upload/" + title + ".xls")))
                {
                    File.Delete(Server.MapPath(@"../../upload/" + title + ".xls"));
                }
            }
        }
    }
}