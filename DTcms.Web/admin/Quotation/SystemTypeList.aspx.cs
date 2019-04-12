using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace DTcms.Web.admin.Quotation
{
    public partial class SystemTypeList : System.Web.UI.Page
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
            string sql = "select * from Sy_SystemType where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;

            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList.DataSource = pds;
            rptList.DataBind();

            AspNetPager1.RecordCount = dt.Rows.Count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    string id = ((HiddenField)rptList.Items[i].FindControl("hidId")).Value;
                    DbHelperSQL.ExecuteSql("delete Sy_SystemType where SystemTypeID = " + id);
                }
            }
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}