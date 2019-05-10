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
            Model.Sy_SystemType sytype = new BLL.Sy_SystemType().GetModel(int.Parse(ddlQuotationTemplateType.SelectedItem.Value));

            Model.Q_QuotationTemplate modelTemp = new Model.Q_QuotationTemplate();
            modelTemp.QuotationTemplateName = txtName.Text;
            modelTemp.QuotationTemplateType = ddlQuotationTemplateType.SelectedItem.Text;
            modelTemp.QuotationTemplateTypeId = int.Parse(ddlQuotationTemplateType.SelectedItem.Value);
            modelTemp.QuotationTemplateMainBrand = txtMainBrand.Text;
            modelTemp.QuotationTemplateDescription = txtDes.Text;
            modelTemp.QuotationTemplateScenario = txtScenario.Text;
            modelTemp.QuotationTemplateNotes = txtNotes.Text;
            modelTemp.CreateBy = (model != null ? model.id : -1);
            modelTemp.CreateDate = DateTime.Now;
            modelTemp.QuotationTemplateState = 0;
            modelTemp.XitongtiaoshiFee = sytype.XitongtiaoshiFee;
            modelTemp.XiangmuguanliFee = sytype.XiangmuguanliFee;
            modelTemp.QicaianzhuangFee = sytype.QicaianzhuangFee;
            modelTemp.XitongtiaoshiDes = sytype.XitongtiaoshiDes;
            modelTemp.XiangmuguanliDes = sytype.XiangmuguanliDes;
            modelTemp.QicaianzhuangDes = sytype.QicaianzhuangDes;
            modelTemp.XitongtiaoshiPic = sytype.XitongtiaoshiPic;
            modelTemp.XiangmuguanliPic = sytype.XiangmuguanliPic;
            modelTemp.QicaianzhuangPic = sytype.QicaianzhuangPic;
            modelTemp.RuodiananzhuangDes = sytype.RuodiananzhuangDes;
            modelTemp.RuodiananzhuangPic = sytype.RuodiananzhuangPic;
            modelTemp.TempTag = txtName.Text;
            modelTemp.TempOrder = txtOrder.Text.Trim() != "" ? int.Parse(txtOrder.Text) : 0;
            int id = new BLL.Q_QuotationTemplate().Add(modelTemp);
            Response.Redirect("QuotationTemplateEdit.aspx?action=add&id=" + id.ToString());
            //string sql = "insert into Q_QuotationTemplate values('" + txtName.Text + "','" + ddlQuotationTemplateType.SelectedItem.Text + "'," + ddlQuotationTemplateType.SelectedItem.Value + ",'" + txtMainBrand.Text + "','" + txtDes.Text + "','" + txtScenario.Text + "','" + txtNotes.Text + "'," + (model != null ? model.id.ToString() : "null") + ",'" + DateTime.Now.ToString() + "',0," + RuodiananzhuangFee.ToString() + "," + QicaianzhuangFee.ToString() + "," + XitongtiaoshiFee.ToString() + "," + XiangmuguanliFee.ToString() + "," + VideoDebugFee.ToString() + "," + AudioDebugFee.ToString() + "," + AuMaterialFee.ToString() + ",'" + txtLaborCostDes.Text + "','" + txtInstallationDes.Text + "','" + txtCommissioningDes.Text + "','" + txtManagementDes.Text + "','" + txtVideoDebugDes.Text + "','" + txtAudioDebugDes.Text + "','" + txtAuMaterialDes.Text + "','" + ddlTag.SelectedItem.Value + "') SELECT @@IDENTITY";
            //string id = DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString();
            //if (!string.IsNullOrEmpty(id))
            //{
            //    Response.Redirect("QuotationTemplateEdit.aspx?action=add&id=" + id);
            //}
        }
    }
}