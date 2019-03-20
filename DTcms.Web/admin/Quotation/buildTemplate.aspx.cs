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
            string sql = "select * from Sy_MaterialType where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            ddlQuotationTemplateType.DataSource = dt;
            ddlQuotationTemplateType.DataTextField = "MaterialType";
            ddlQuotationTemplateType.DataValueField = "ID";
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
            string sql = "insert into Q_QuotationTemplate values('" + txtName.Text + "','" + ddlQuotationTemplateType.SelectedItem.Text + "'," + ddlQuotationTemplateType.SelectedItem.Value + ",'" + txtDes.Text + "','" + txtTag.Text + "'," + model.id + ",'" + DateTime.Now.ToString() + "',0) SELECT @@IDENTITY";
            string id = DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString();
            if (!string.IsNullOrEmpty(id))
            {
                Response.Redirect("QuotationTemplateEdit.aspx?action=add&id=" + id);
            }
        }
    }
}