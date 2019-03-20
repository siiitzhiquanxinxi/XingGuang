using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class chooseMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        

        private void BindData()
        {
            BLL.Sy_Material bll = new BLL.Sy_Material();
            string where = " 1=1";
            if (txtKeywords.Text != "")
            {
                where += " and (Name like '%" + txtKeywords.Text + "%' or Description like '%" + txtKeywords.Text + "%')";
            }
            DataTable dt = bll.GetListByPage(where, "MaterialType", 0, 7).Tables[0];
            rptList1.DataSource = dt;
            rptList1.DataBind();
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