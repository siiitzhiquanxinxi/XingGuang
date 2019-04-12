using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class chooseSystemType : System.Web.UI.Page
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
            string sql = "select * from Sy_SystemType";
            string where = " 1=1";
            if (txtKeywords.Text != "")
            {
                where += " and SystemTypeName like '%" + txtKeywords.Text + "%'";
            }
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList1.DataSource = pds;
            rptList1.DataBind();

            AspNetPager1.RecordCount = dt.Rows.Count;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void cblMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}