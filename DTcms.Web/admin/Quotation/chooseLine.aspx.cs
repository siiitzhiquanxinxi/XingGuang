using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class chooseLine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                BindData();
            }
        }
        private void BindDDL()
        {
            string sql = "select distinct Brand from Sy_Material where MaterialType like '%线材%'";
            string where = "";
            sql += where;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            ddlBrand.DataSource = dt;
            ddlBrand.DataTextField = "Brand";
            ddlBrand.DataValueField = "Brand";
            ddlBrand.DataBind();
            ListItem li = new ListItem("---全部---", "-1");
            ddlBrand.Items.Insert(0, li);
        }

        private void BindData()
        {
            BLL.Sy_Material bll = new BLL.Sy_Material();
            string where = " MaterialType like '%线材%'";
            if (ddlBrand.SelectedItem.Value != "-1")
            {
                where += " and Brand = '" + ddlBrand.SelectedItem.Text + "'";
            }
            if (txtKeywords.Text != "")
            {
                where += " and (Name like '%" + txtKeywords.Text + "%' or Description like '%" + txtKeywords.Text + "%' or Mode like '%" + txtKeywords.Text + "%')";
            }
            where += " order by MaterialTypeID";
            DataTable dt = bll.GetList(where).Tables[0];

            rptList1.DataSource = dt;
            rptList1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}