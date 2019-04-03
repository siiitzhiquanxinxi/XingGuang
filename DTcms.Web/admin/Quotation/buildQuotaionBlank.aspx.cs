﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.Quotation
{
    public partial class buildQuotaionBlank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ViewState["GT"] = null;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))//查看报价单明细
                {
                    GetData();
                    btnSave.Visible = false;
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["tid"]))//由模板生成
                {
                    txtQuotationListNum.Text = "XG" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    CreateData();
                }
                else//空白新建
                {
                    txtQuotationListNum.Text = "XG" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
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
                lstGoodsType = new List<QuatationListTypeClass>();

                List<Model.Q_QuotationDetailType> lstQDT = new BLL.Q_QuotationDetailType().GetModelList("FK_ParentQuotationListId = " + Request.QueryString["id"]);
                foreach (Model.Q_QuotationDetailType item in lstQDT)
                {
                    QuatationListTypeClass qltc = new QuatationListTypeClass();
                    qltc.lstQuotationDetailGoods = new BLL.Q_QuotationDetailGoods().GetModelList("FK_QuotationDetailTypeId = "+ item.QuotationDetailTypeId);//每个商品
                    qltc.lstQuotationDetailLines = new BLL.Q_QuotationDetailLines().GetModelList("FK_QuotationDetailTypeId = " + item.QuotationDetailTypeId);//每个线材
                    qltc.Typeid = Convert.ToInt16(item.FK_MaterialTypeId);
                    qltc.Typename = item.MaterialTypeName;
                    lstGoodsType.Add(qltc);
                }
                rblGoodsType.DataSource = lstGoodsType;
                rblGoodsType.DataTextField = "Typename";
                rblGoodsType.DataValueField = "Typeid";
                rblGoodsType.DataBind();
                this.ViewState["GT"] = lstGoodsType;
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
                foreach (string TempId in lstTempId)//循环遍历小模板
                {
                    QuatationListTypeClass qltc = new QuatationListTypeClass();
                    Model.Q_QuotationTemplate modelTemp = new BLL.Q_QuotationTemplate().GetModel(int.Parse(TempId));

                    qltc.QuotationDetailType = new Model.Q_QuotationDetailType();
                    qltc.QuotationDetailType.FK_MaterialTypeId = modelTemp.QuotationTemplateTypeId;
                    qltc.QuotationDetailType.MaterialTypeName = modelTemp.QuotationTemplateType;
                    qltc.QuotationDetailType.RuodiananzhuangFee = modelTemp.RuodiananzhuangFee;
                    qltc.QuotationDetailType.QicaianzhuangFee = modelTemp.QicaianzhuangFee;
                    qltc.QuotationDetailType.XitongtiaoshiFee = modelTemp.XitongtiaoshiFee;
                    qltc.QuotationDetailType.XiangmuguanliFee = modelTemp.XiangmuguanliFee;

                    qltc.lstQuotationDetailGoods = new List<Model.Q_QuotationDetailGoods>();//每个模板里的商品
                    List<Model.Q_QuotationTemplateDetail> lstQTD = new BLL.Q_QuotationTemplateDetail().GetModelList("TemplateParentID = " + TempId);
                    int i = 0;
                    foreach (Model.Q_QuotationTemplateDetail item in lstQTD)
                    {
                        Model.Q_QuotationDetailGoods qdg = new Model.Q_QuotationDetailGoods();
                        Model.Sy_Material materialModel = new BLL.Sy_Material().GetModel(Convert.ToInt16(item.FK_materialID));
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
                if (hfdIsDel.Value == "1")//删除
                {
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
                Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                dtmaterial.Rows.Add(new object[] { i + needadd, hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, lblName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
            }
            if (hfdTempId.Value != "")//添加新一行
            {
                string sql = "select * from Sy_Material where ID = " + hfdTempId.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                dtmaterial.Rows.Add(new object[] { rptList1.Items.Count, dt.Rows[0]["ID"], dt.Rows[0]["Brand"], dt.Rows[0]["BrandImg"], dt.Rows[0]["Mode"], dt.Rows[0]["Name"], dt.Rows[0]["Description"], dt.Rows[0]["Unit"], dt.Rows[0]["UnitPrice"], dt.Rows[0]["Photo"], "" });
                hfdTempId.Value = "";
            }
            rptList1.DataSource = dtmaterial;
            rptList1.DataBind();
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

            for (int i = 0; i < rblGoodsType.Items.Count; i++)
            {
                if (lstGoodsType.Where(p => p.Typeid == int.Parse(rblGoodsType.Items[i].Value)).Count() <= 0)
                {
                    QuatationListTypeClass qltc = new QuatationListTypeClass();
                    qltc.Typeid = int.Parse(rblGoodsType.Items[i].Value);
                    qltc.Typename = rblGoodsType.Items[i].Text.ToString();
                    lstGoodsType.Add(qltc);
                }
            }
            if (hfdTempId2.Value != "")//添加
            {
                string sql = "select * from Sy_MaterialType where ID = " + hfdTempId2.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (lstGoodsType.Where(p => p.Typeid == int.Parse(dt.Rows[0]["ID"].ToString())).Count() <= 0)
                {
                    QuatationListTypeClass qltc = new QuatationListTypeClass();
                    qltc.Typeid = int.Parse(dt.Rows[0]["ID"].ToString());
                    qltc.Typename = dt.Rows[0]["MaterialType"].ToString();
                    lstGoodsType.Add(qltc);
                }
                hfdTempId2.Value = "";
            }
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

            Model.Q_QuotationList modelQ_QuotationList = new Model.Q_QuotationList();
            modelQ_QuotationList.QuotationListNum = txtQuotationListNum.Text;
            modelQ_QuotationList.FK_ParentProgramId = null;
            Model.manager model = new Model.manager();
            model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.manager;
            modelQ_QuotationList.CreateBy = (model != null ? model.id : -1);
            modelQ_QuotationList.CreateDate = DateTime.Now;
            modelQ_QuotationList.QuotationListState = 0;
            int Q_QuotationList_ID = new BLL.Q_QuotationList().Add(modelQ_QuotationList);

            lstGoodsType = this.ViewState["GT"] as List<QuatationListTypeClass>;
            for (int i = 0; i < lstGoodsType.Count; i++)
            {
                Model.Q_QuotationDetailType modelQ_QuotationDetailType = lstGoodsType[i].QuotationDetailType;
                modelQ_QuotationDetailType.FK_ParentQuotationListId = Q_QuotationList_ID;
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('保存成功！');window.location='QuotationListQuery.aspx'", true);
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
                    Label lblName = rptList1.Items[i].FindControl("lblName") as Label;
                    Label lblDescription = rptList1.Items[i].FindControl("lblDescription") as Label;
                    Label lblUnit = rptList1.Items[i].FindControl("lblUnit") as Label;
                    Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                    Image imgMaterial = rptList1.Items[i].FindControl("imgMaterial") as Image;
                    TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                    dtmaterial.Rows.Add(new object[] { Convert.ToInt16(hfdOrderIndex.Value), hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, lblName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
                }
                DataView dv = dtmaterial.DefaultView;
                dv.Sort = "DetailOrder asc";
                dtmaterial = dv.ToTable();

                rptList1.DataSource = dtmaterial;
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

                InitializationDtmaterial();
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
                    dtmaterial.Rows.Add(new object[] { Convert.ToInt16(hfdOrderIndex.Value), hfdMaterialId.Value, lblBrand.Text, imgBrand.ImageUrl, lblMode.Text, lblName.Text, lblDescription.Text, lblUnit.Text, lblUnitPrice.Text, imgMaterial.ImageUrl, txtQuantity.Text });
                }
                DataView dv = dtmaterial.DefaultView;
                dv.Sort = "DetailOrder asc";
                dtmaterial = dv.ToTable();

                rptList1.DataSource = dtmaterial;
                rptList1.DataBind();
            }
        }

        protected void btnUpdateLine_Click(object sender, EventArgs e)
        {
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
                    DataRow[] dr = d.Select("FK_LineId = " + dt.Rows[j]["ID"]);
                    if (dr.Length > 0)
                    {
                        dr[0]["LineTotalcount"] = Math.Round(Convert.ToDecimal(dr[0]["LineTotalcount"]) + Convert.ToDecimal(dt.Rows[j]["totalcount"]), 2).ToString();
                        dr[0]["LineTotalamount"] = Math.Round(Convert.ToDecimal(dr[0]["LineTotalamount"]) + Convert.ToDecimal(dt.Rows[j]["totalamount"]), 2).ToString();
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
        protected void btnUpdateLaborFee_Click(object sender, EventArgs e)
        {
            decimal RuodiananzhuangFee = 0;
            decimal QicaianzhuangFee = 0;
            decimal XitongtiaoshiFee = 0;
            decimal XiangmuguanliFee = 0;
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdMaterialId = rptList1.Items[i].FindControl("hfdMaterialId") as HiddenField;
                TextBox txtQuantity = rptList1.Items[i].FindControl("txtQuantity") as TextBox;
                decimal count = txtQuantity.Text != "" ? decimal.Parse(txtQuantity.Text) : 0;
                Model.Sy_Material model = new BLL.Sy_Material().GetModel(int.Parse(hfdMaterialId.Value));
                RuodiananzhuangFee += count * (model.LaborCost != null ? Convert.ToDecimal(model.LaborCost) : 0);
                QicaianzhuangFee += count * (model.InstallationFee != null ? Convert.ToDecimal(model.InstallationFee) : 0);
                XitongtiaoshiFee += count * (model.CommissioningFee != null ? Convert.ToDecimal(model.CommissioningFee) : 0);
                XiangmuguanliFee += count * (model.ManagementFee != null ? Convert.ToDecimal(model.ManagementFee) : 0);
            }
            txtRuodiananzhuangFee.Text = Math.Round(RuodiananzhuangFee, 2).ToString();
            txtQicaianzhuangFee.Text = Math.Round(QicaianzhuangFee, 2).ToString();
            txtXitongtiaoshiFee.Text = Math.Round(XitongtiaoshiFee, 2).ToString();
            txtXiangmuguanliFee.Text = Math.Round(XiangmuguanliFee, 2).ToString();
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
                qltc.QuotationDetailType.MaterialTypeName = qltc.Typename;
                qltc.QuotationDetailType.RuodiananzhuangFee = (txtRuodiananzhuangFee.Text != "" ? Convert.ToDecimal(txtRuodiananzhuangFee.Text) : 0);
                qltc.QuotationDetailType.QicaianzhuangFee = (txtQicaianzhuangFee.Text != "" ? Convert.ToDecimal(txtQicaianzhuangFee.Text) : 0);
                qltc.QuotationDetailType.XitongtiaoshiFee = (txtXitongtiaoshiFee.Text != "" ? Convert.ToDecimal(txtXitongtiaoshiFee.Text) : 0);
                qltc.QuotationDetailType.XiangmuguanliFee = (txtXiangmuguanliFee.Text != "" ? Convert.ToDecimal(txtXiangmuguanliFee.Text) : 0);

                qltc.lstQuotationDetailGoods = new List<Model.Q_QuotationDetailGoods>();
                qltc.lstQuotationDetailLines = new List<Model.Q_QuotationDetailLines>();
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

                    Model.Q_QuotationDetailGoods qdg = new Model.Q_QuotationDetailGoods();
                    qdg.FK_materialID = int.Parse(hfdMaterialId.Value);
                    qdg.Brand = lblBrand.Text;
                    qdg.BrandImg = imgBrand.ImageUrl;
                    qdg.Mode = lblMode.Text;
                    qdg.Name = lblName.Text;
                    qdg.Description = lblDescription.Text;
                    qdg.Unit = lblUnit.Text;
                    qdg.UnitPrice = Convert.ToDecimal(lblUnitPrice.Text);
                    qdg.Photo = imgMaterial.ImageUrl;
                    qdg.GoodsQuantity = Convert.ToDecimal(txtQuantity.Text != "" ? txtQuantity.Text : "0");
                    qdg.DetailOrder = Convert.ToInt16(hfdOrderIndex.Value);

                    qltc.lstQuotationDetailGoods.Add(qdg);
                }
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
                rptList1.DataSource = qltc.lstQuotationDetailGoods != null ? qltc.lstQuotationDetailGoods : null;
                rptList1.DataBind();
                rptLine.DataSource = qltc.lstQuotationDetailLines != null ? qltc.lstQuotationDetailLines : null;
                rptLine.DataBind();
                if (qltc.QuotationDetailType != null)
                {
                    decimal RuodiananzhuangFee = 0;
                    decimal QicaianzhuangFee = 0;
                    decimal XitongtiaoshiFee = 0;
                    decimal XiangmuguanliFee = 0;
                    RuodiananzhuangFee = qltc.QuotationDetailType.RuodiananzhuangFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.RuodiananzhuangFee) : 0;
                    QicaianzhuangFee = qltc.QuotationDetailType.QicaianzhuangFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.QicaianzhuangFee) : 0;
                    XitongtiaoshiFee = qltc.QuotationDetailType.XitongtiaoshiFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.XitongtiaoshiFee) : 0;
                    XiangmuguanliFee = qltc.QuotationDetailType.XiangmuguanliFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.XiangmuguanliFee) : 0;
                    txtRuodiananzhuangFee.Text = Math.Round(RuodiananzhuangFee, 2).ToString();
                    txtQicaianzhuangFee.Text = Math.Round(QicaianzhuangFee, 2).ToString();
                    txtXitongtiaoshiFee.Text = Math.Round(XitongtiaoshiFee, 2).ToString();
                    txtXiangmuguanliFee.Text = Math.Round(XiangmuguanliFee, 2).ToString();
                }
                else
                {
                    txtRuodiananzhuangFee.Text = txtQicaianzhuangFee.Text = txtXitongtiaoshiFee.Text =
                       txtXiangmuguanliFee.Text = "";
                }

            }
        }

        [Serializable]
        private class QuatationListTypeClass
        {
            public int Typeid { get; set; }
            public string Typename { get; set; }
            public Model.Q_QuotationDetailType QuotationDetailType;
            public List<Model.Q_QuotationDetailGoods> lstQuotationDetailGoods;
            public List<Model.Q_QuotationDetailLines> lstQuotationDetailLines;
        }
    }
}