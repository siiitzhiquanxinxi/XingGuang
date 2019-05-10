using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class chooseTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCkb();
                if (rblType.Items.Count > 0)
                {
                    rblType.Items[0].Selected = true;
                    BindData();
                }
            }
        }

        private void BindCkb()
        {
            string sql = "select * from Sy_SystemType where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            rblType.DataSource = dt;
            rblType.DataTextField = "SystemTypeName";
            rblType.DataValueField = "SystemTypeID";
            rblType.DataBind();
        }

        private void BindData()
        {
            string sql = "select * from Q_QuotationTemplate where 1=1 and QuotationTemplateState = 1";
            string where = "";
            where += "and QuotationTemplateTypeId = " + rblType.SelectedItem.Value;
          
            sql += where;
            sql += " order by TempOrder";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
           
            rptList1.DataSource = dt;
            rptList1.DataBind();
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                Label lblTotal = rptList1.Items[i].FindControl("lblTotal") as Label;
                HiddenField hfdId = rptList1.Items[i].FindControl("hfdId") as HiddenField;

                string s = "select SUM(TemplateDetailQuantity*UnitPrice) from Q_QuotationTemplateDetail inner join Sy_Material on Sy_Material.ID = Q_QuotationTemplateDetail.FK_materialID where TemplateParentID =" + hfdId.Value;
                decimal goodsTotal = 0;
                DataTable d = DbHelperSQL.Query(s).Tables[0];
                if (d != null && d.Rows.Count > 0 && d.Rows[0][0].ToString() != "")
                {
                    goodsTotal = Convert.ToDecimal(d.Rows[0][0].ToString());
                }
                decimal lineTotal = 0;
                s = "select LineTotalamount from Q_QuotationTemplateLine where FK_TemplateId = " + hfdId.Value;
                d = DbHelperSQL.Query(s).Tables[0];
                if (d != null && d.Rows.Count > 0 && d.Rows[0][0].ToString() != "")
                {
                    lineTotal = Convert.ToDecimal(d.Rows[0][0].ToString());
                }
                Model.Q_QuotationTemplate model = new BLL.Q_QuotationTemplate().GetModel(int.Parse(hfdId.Value));
                decimal QicaianzhuangFee = goodsTotal * Convert.ToDecimal(model.QicaianzhuangFee);
                decimal XitongtiaoshiFee = goodsTotal * Convert.ToDecimal(model.XitongtiaoshiFee);
                decimal XiangmuguanliFee = goodsTotal * Convert.ToDecimal(model.XiangmuguanliFee);
                decimal total = goodsTotal + lineTotal + QicaianzhuangFee + XitongtiaoshiFee + XiangmuguanliFee;
                lblTotal.Text = Math.Round(total, 0).ToString();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void cblMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}