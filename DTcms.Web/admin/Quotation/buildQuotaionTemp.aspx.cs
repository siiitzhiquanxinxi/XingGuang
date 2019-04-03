using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.Quotation
{
    public partial class buildQuotaionTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (rptList1.Items.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('至少选择一个模板！')", true);
                return;
            }
            string tempidArr = "";
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdQuotationTemplateId = rptList1.Items[i].FindControl("hfdQuotationTemplateId") as HiddenField;
                tempidArr += (hfdQuotationTemplateId.Value + "|");
            }
            Response.Redirect("buildQuotaionBlank.aspx?tid=" + tempidArr);
        }

        DataTable dttemp = new DataTable();
        private void InitializationDtgoods()
        {
            dttemp.Columns.Add("QuotationTemplateId", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateType", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateName", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateMainBrand", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateDescription", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateScenario", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateNotes", Type.GetType("System.String"));
        }
        private void BindData()
        {
            InitializationDtgoods();
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdIsDel = rptList1.Items[i].FindControl("hfdIsDel") as HiddenField;
                if (hfdIsDel.Value == "1")//删除
                {
                    continue;
                }
                HiddenField hfdQuotationTemplateId = rptList1.Items[i].FindControl("hfdQuotationTemplateId") as HiddenField;
                Label lblQuotationTemplateType = rptList1.Items[i].FindControl("lblQuotationTemplateType") as Label;
                Label lblQuotationTemplateName = rptList1.Items[i].FindControl("lblQuotationTemplateName") as Label;
                Label lblQuotationTemplateMainBrand = rptList1.Items[i].FindControl("lblQuotationTemplateMainBrand") as Label;
                Label lblQuotationTemplateDescription = rptList1.Items[i].FindControl("lblQuotationTemplateDescription") as Label;
                Label lblQuotationTemplateScenario = rptList1.Items[i].FindControl("lblQuotationTemplateScenario") as Label;
                Label lblQuotationTemplateNotes = rptList1.Items[i].FindControl("lblQuotationTemplateNotes") as Label;
                dttemp.Rows.Add(new object[] { hfdQuotationTemplateId.Value, lblQuotationTemplateType.Text, lblQuotationTemplateName.Text, lblQuotationTemplateMainBrand.Text, lblQuotationTemplateDescription.Text, lblQuotationTemplateScenario.Text, lblQuotationTemplateNotes.Text });
            }
            if (hfdTempId.Value != "")//添加新一行
            {
                string sql = "select * from Q_QuotationTemplate where QuotationTemplateId = " + hfdTempId.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                dttemp.Rows.Add(new object[] { dt.Rows[0]["QuotationTemplateId"], dt.Rows[0]["QuotationTemplateType"], dt.Rows[0]["QuotationTemplateName"], dt.Rows[0]["QuotationTemplateMainBrand"], dt.Rows[0]["QuotationTemplateDescription"], dt.Rows[0]["QuotationTemplateScenario"], dt.Rows[0]["QuotationTemplateNotes"] });
                hfdTempId.Value = "";
            }
            rptList1.DataSource = dttemp;
            rptList1.DataBind();
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
    }
}