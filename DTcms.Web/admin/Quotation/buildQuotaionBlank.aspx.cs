using System;
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

        }

        protected void btnBind_Click(object sender, EventArgs e)
        {
            BindData();
        }

        DataTable dtmaterial = new DataTable();
        private void InitializationDtmaterial()
        {
            dtmaterial.Columns.Add("OrderIndex", Type.GetType("System.Int32"));
            dtmaterial.Columns.Add("MaterialID", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Brand", Type.GetType("System.String"));
            dtmaterial.Columns.Add("BrandImg", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Mode", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Name", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Description", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Unit", Type.GetType("System.String"));
            dtmaterial.Columns.Add("UnitPrice", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Photo", Type.GetType("System.String"));
            dtmaterial.Columns.Add("Quantity", Type.GetType("System.String"));
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
        DataTable dtGoodsType = new DataTable();

        private void InitializationDtgoodsType()
        {
            dtGoodsType.Columns.Add("ID");
            dtGoodsType.Columns.Add("MaterialType");
        }

        protected void btnBind2_Click(object sender, EventArgs e)
        {
            InitializationDtgoodsType();
            for (int i = 0; i < rblGoodsType.Items.Count; i++)
            {
                dtGoodsType.Rows.Add(new object[] { rblGoodsType.Items[i].Value.ToString(), rblGoodsType.Items[i].Text.ToString() });
            }
            if (hfdTempId2.Value != "")//添加
            {
                string sql = "select * from Sy_MaterialType where ID = " + hfdTempId2.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (dtGoodsType.Select("ID = '" + dt.Rows[0]["ID"] + "'").Length <= 0)
                {
                    dtGoodsType.Rows.Add(new object[] { dt.Rows[0]["ID"], dt.Rows[0]["MaterialType"] });
                    hfdTempId2.Value = "";
                }
            }
            rblGoodsType.DataSource = dtGoodsType;
            rblGoodsType.DataTextField = "MaterialType";
            rblGoodsType.DataValueField = "ID";
            rblGoodsType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        { }

        protected void lbtnMoveUp_Click(object sender, EventArgs e)
        { }

        protected void lbtnMoveDown_Click(object sender, EventArgs e)
        { }

        protected void btnUpdateLine_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateLaborFee_Click(object sender, EventArgs e)
        {

        }

        protected void rblGoodsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfdMtype.Value = rblGoodsType.SelectedItem.Value.ToString();
            SaveToJson();
        }

        private void SaveToJson()
        {
            Model.manager model = new Model.manager();
            model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.manager;
            qcmodel = new QuotationClass();
            qcmodel.Q_QuotationList = new Model.Q_QuotationList();
            qcmodel.Q_QuotationList.QuotationListNum = txtQuotationListNum.Text;
            qcmodel.Q_QuotationList.FK_ParentProgramId = null;
            qcmodel.Q_QuotationList.CreateBy = model.id;
            qcmodel.Q_QuotationList.CreateDate = DateTime.Now;
            qcmodel.Q_QuotationList.QuotationListState = 0;

            QuatationListTypeClass ql = new QuatationListTypeClass();
            ql.Typeid = int.Parse(hfdMtype.Value);
            ql.lstQuotationDetailGoods = new List<Model.Q_QuotationDetailGoods>();
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
                qdg.Brand = lblBrand.Text;
                qdg.BrandImg = imgBrand.ImageUrl;
                qdg.Mode = lblMode.Text;
                qdg.Name = lblName.Text;
                qdg.Description = lblDescription.Text;
                qdg.Unit = lblUnit.Text;
                qdg.UnitPrice = Convert.ToDecimal(lblUnitPrice.Text);
                qdg.Photo = imgMaterial.ImageUrl;
                qdg.GoodsQuantity = Convert.ToDecimal(txtQuantity.Text);
                qdg.DetailOrder = Convert.ToInt16(hfdOrderIndex.Value);

                ql.lstQuotationDetailGoods.Add(qdg);
            }
            qcmodel.lstQuotationDetailType.Add(ql);

            this.ViewState["Q"] = ql;
        }
        QuotationClass qcmodel;
        private class QuotationClass
        {
            public Model.Q_QuotationList Q_QuotationList;
            public List<QuatationListTypeClass> lstQuotationDetailType;
        }

        private class QuatationListTypeClass
        {
            public int Typeid;
            public Model.Q_QuotationDetailType QuotationDetailType;
            public List<Model.Q_QuotationDetailGoods> lstQuotationDetailGoods;
            public List<Model.Q_QuotationDetailLines> lstQuotationDetailLines;
        }
    }
}