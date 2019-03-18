using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.MaterialSetting
{
    public partial class MaterialList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCkb();
                BindData();
            }
        }

        private void BindCkb()
        {
            BLL.Sy_MaterialType bll = new BLL.Sy_MaterialType();
            DataTable dt = bll.GetAllList().Tables[0];
            cblMType.DataSource = dt;
            cblMType.DataTextField = "MaterialType";
            cblMType.DataValueField = "MaterialType";
            cblMType.DataBind();
        }

        private void BindData()
        {
            BLL.Sy_Material bll = new BLL.Sy_Material();
            string where = " 1=1";
            if (txtKeywords.Text != "")
            {
                where += " and (Name like '%" + txtKeywords.Text + "%' or Description like '%" + txtKeywords.Text + "%')";
            }
            int checkindex = 0;
            for (int i = 0; i < cblMType.Items.Count; i++)
            {
                if (cblMType.Items[i].Selected == true)
                {
                    if (checkindex == 0)
                    {
                        where += " and (MaterialType = '" + cblMType.Items[i].Text + "'";
                    }
                    if (checkindex > 0)
                    {
                        where += " or MaterialType = '" + cblMType.Items[i].Text + "'";
                    }
                    checkindex++;
                }
            }
            if (checkindex > 0)
            {
                where += ")";
            }
            DataTable dt = bll.GetListByPage(where, "MaterialType", 0, 100).Tables[0];
            rptList1.DataSource = dt;
            rptList1.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cblMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}