using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;
using System.Text;
namespace DTcms.Web.admin.MaterialSetting
{
    public partial class MaterialCostList : System.Web.UI.Page
    {
        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCkb();
                BindData();
                keywords = this.txtKeywords.Text.Trim();

            }
        }
        private void BindCkb()
        {
            BLL.Sy_MaterialType bll = new BLL.Sy_MaterialType();
            DataTable dt = bll.GetAllList().Tables[0];
            rblType.DataSource = dt;
            rblType.DataTextField = "MaterialType";
            rblType.DataValueField = "MaterialType";
            rblType.DataBind();
        }

        private void BindData()
        {
            BLL.Sy_Material bll = new BLL.Sy_Material();
            string where = " 1=1";
            if (txtKeywords.Text != "")
            {
                where += " and (Name like '%" + txtKeywords.Text + "%' or Description like '%" + txtKeywords.Text + "%' or Mode like '%" + txtKeywords.Text + "%')";
            }
            where += " and MaterialType = '" + rblType.SelectedValue + "'";

            DataTable dt = bll.GetList(where).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;

            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList1.DataSource = pds;
            rptList1.DataBind();

            AspNetPager1.RecordCount = dt.Rows.Count;
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void rptList1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")  
            {
                TextBox txtUnitPrice = e.Item.FindControl("txtUnitPrice") as TextBox;
                TextBox txtCostPrice = e.Item.FindControl("txtCostPrice") as TextBox;
                BLL.Sy_Material bll = new BLL.Sy_Material();
                int id = Convert.ToInt32(e.CommandArgument);
                Model.Sy_Material model = bll.GetModel(id);
                model.UnitPrice = Convert.ToDecimal( txtUnitPrice.Text.Trim());
                model.CostPrice = Convert.ToDecimal(txtCostPrice.Text.Trim());
                bll.Update(model);

            }
        }
    }
}