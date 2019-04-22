using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class QuotationTemplateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCkb();
                if (rblSType.Items.Count > 0)
                {
                    rblSType.Items[0].Selected = true;
                    BindData();
                }
            }
        }

        private void BindCkb()
        {
            string sql = "select * from Sy_SystemType where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            rblSType.DataSource = dt;
            rblSType.DataTextField = "SystemTypeName";
            rblSType.DataValueField = "SystemTypeID";
            rblSType.DataBind();
        }

        private void BindData()
        {
            string sql = "select * from Q_QuotationTemplate where 1=1 and QuotationTemplateState = 1";
            string where = "";
            if (rblSType.SelectedItem!=null)
            {
                where += " and QuotationTemplateTypeId = " + rblSType.SelectedItem.Value;
            }
            //int checkindex = 0;
            //for (int i = 0; i < cblSType.Items.Count; i++)
            //{
            //    if (cblSType.Items[i].Selected == true)
            //    {
            //        if (checkindex == 0)
            //        {
            //            where += " and (QuotationTemplateTypeId = '" + cblSType.Items[i].Value + "'";
            //        }
            //        if (checkindex > 0)
            //        {
            //            where += " or QuotationTemplateTypeId = '" + cblSType.Items[i].Value + "'";
            //        }
            //        checkindex++;
            //    }
            //}
            //if (checkindex > 0)
            //{
            //    where += ")";
            //}
            where += " order by QuotationTemplateTypeId";
            sql += where;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;
            rptList1.DataSource = pds;
            rptList1.DataBind();
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                Label lblRuodiananzhuangFee = rptList1.Items[i].FindControl("lblRuodiananzhuangFee") as Label;
                Label lblQicaianzhuangFee = rptList1.Items[i].FindControl("lblQicaianzhuangFee") as Label;
                Label lblXitongtiaoshiFee = rptList1.Items[i].FindControl("lblXitongtiaoshiFee") as Label;
                Label lblXiangmuguanliFee = rptList1.Items[i].FindControl("lblXiangmuguanliFee") as Label;
                Label lblVideoDebugFee = rptList1.Items[i].FindControl("lblVideoDebugFee") as Label;
                Label lblAudioDebugFee = rptList1.Items[i].FindControl("lblAudioDebugFee") as Label;
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
                decimal RuodiananzhuangFee = goodsTotal * Convert.ToDecimal(model.RuodiananzhuangFee);
                decimal QicaianzhuangFee = goodsTotal * Convert.ToDecimal(model.QicaianzhuangFee);
                decimal XitongtiaoshiFee = goodsTotal * Convert.ToDecimal(model.XitongtiaoshiFee);
                decimal XiangmuguanliFee = goodsTotal * Convert.ToDecimal(model.XiangmuguanliFee);
                decimal VideoDebugFee = goodsTotal * Convert.ToDecimal(model.VideoDebugFee);
                decimal AudioDebugFee = goodsTotal * Convert.ToDecimal(model.AudioDebugFee);
                lblRuodiananzhuangFee.Text = Math.Round(RuodiananzhuangFee, 0).ToString();
                lblQicaianzhuangFee.Text = Math.Round(QicaianzhuangFee, 0).ToString();
                lblXitongtiaoshiFee.Text = Math.Round(XitongtiaoshiFee, 0).ToString();
                lblXiangmuguanliFee.Text = Math.Round(XiangmuguanliFee, 0).ToString();
                lblVideoDebugFee.Text = Math.Round(VideoDebugFee, 0).ToString();
                lblAudioDebugFee.Text = Math.Round(AudioDebugFee, 0).ToString();
                decimal total = goodsTotal + lineTotal + RuodiananzhuangFee + QicaianzhuangFee + XitongtiaoshiFee + XiangmuguanliFee + VideoDebugFee + AudioDebugFee;
                lblTotal.Text = Math.Round(total, 0).ToString();
            }

            AspNetPager1.RecordCount = dt.Rows.Count;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    string tid = ((HiddenField)rptList1.Items[i].FindControl("hfdId")).Value;
                    DbHelperSQL.ExecuteSql("delete Q_QuotationTemplate where QuotationTemplateId = " + tid);
                    DbHelperSQL.ExecuteSql("delete Q_QuotationTemplateDetail where TemplateParentID = " + tid);
                }
            }
            BindData();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        protected void rblSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindData();
        }
    }
}