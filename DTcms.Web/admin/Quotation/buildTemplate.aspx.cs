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
    public partial class buildTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
        }

        private void BindDDL()
        {
            string sql = "select * from Sy_SystemType where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            ddlQuotationTemplateType.DataSource = dt;
            ddlQuotationTemplateType.DataTextField = "SystemTypeName";
            ddlQuotationTemplateType.DataValueField = "SystemTypeID";
            ddlQuotationTemplateType.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Model.manager model = new Model.manager();
            model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.manager;
            if (txtName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请填写模板名称！')", true);
                return;
            }
            if (ddlQuotationTemplateType.SelectedItem.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请填选择模板类型！')", true);
                return;
            }
            decimal RuodiananzhuangFee = 0;
            decimal QicaianzhuangFee = 0;
            decimal XitongtiaoshiFee = 0;
            decimal XiangmuguanliFee = 0;
            decimal VideoDebugFee = 0;
            decimal AudioDebugFee = 0;
            decimal AuMaterialFee = 0;
            if (txtLaborCostFee.Text.Trim() != "")
            {
                RuodiananzhuangFee = Convert.ToDecimal(txtLaborCostFee.Text);
            }
            if (txtInstallationFee.Text.Trim() != "")
            {
                QicaianzhuangFee = Convert.ToDecimal(txtInstallationFee.Text);
            }
            if (txtCommissioningFee.Text.Trim() != "")
            {
                XitongtiaoshiFee = Convert.ToDecimal(txtCommissioningFee.Text);
            }
            if (txtManagementFee.Text.Trim() != "")
            {
                XiangmuguanliFee = Convert.ToDecimal(txtManagementFee.Text);
            }
            if (txtVideoDebugFee.Text.Trim() != "")
            {
                VideoDebugFee = Convert.ToDecimal(txtVideoDebugFee.Text);
            }
            if (txtAudioDebugFee.Text.Trim() != "")
            {
                AudioDebugFee = Convert.ToDecimal(txtAudioDebugFee.Text);
            }
            if (txtAuMaterialFee.Text.Trim() != "")
            {
                AuMaterialFee = Convert.ToDecimal(txtAuMaterialFee.Text);
            }
            string sql = "insert into Q_QuotationTemplate values('" + txtName.Text + "','" + ddlQuotationTemplateType.SelectedItem.Text + "'," + ddlQuotationTemplateType.SelectedItem.Value + ",'" + txtMainBrand.Text + "','" + txtDes.Text + "','" + txtScenario.Text + "','" + txtNotes.Text + "'," + (model != null ? model.id.ToString() : "null") + ",'" + DateTime.Now.ToString() + "',0," + RuodiananzhuangFee.ToString() + "," + QicaianzhuangFee.ToString() + "," + XitongtiaoshiFee.ToString() + "," + XiangmuguanliFee.ToString() + "," + VideoDebugFee.ToString() + "," + AudioDebugFee.ToString() + "," + AuMaterialFee.ToString() + ",'" + txtLaborCostDes.Text + "','" + txtInstallationDes.Text + "','" + txtCommissioningDes.Text + "','" + txtManagementDes.Text + "','" + txtVideoDebugDes.Text + "','" + txtAudioDebugDes.Text + "','" + txtAuMaterialDes.Text + "','" + ddlTag.SelectedItem.Value + "') SELECT @@IDENTITY";
            string id = DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString();
            if (!string.IsNullOrEmpty(id))
            {
                Response.Redirect("QuotationTemplateEdit.aspx?action=add&id=" + id);
            }
        }
    }
}