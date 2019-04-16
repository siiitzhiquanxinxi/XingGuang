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
    public partial class MaterialPriceCheck : System.Web.UI.Page
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
            string where = " state=0";
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

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            int sucCount = 0;
            int errorCount = 0;
            DTcms.BLL.Sy_Material bll = new DTcms.BLL.Sy_Material();
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                string OrderNo = ((HiddenField)rptList1.Items[i].FindControl("hfdId")).Value;
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    DTcms.Model.Sy_Material mmodel=bll.GetModel(Convert.ToInt32(OrderNo));
                    mmodel.State = 1;
                    if (bll.Update(mmodel))
                    {
                       sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            BindData();
        }
    }
}