using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.Quotation
{
    public partial class chooseGoodsType : System.Web.UI.Page
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
            BLL.Sy_MaterialType bll = new BLL.Sy_MaterialType();
            string where = " 1=1";
            if (txtKeywords.Text != "")
            {
                where += " and MaterialType like '%" + txtKeywords.Text + "%'";
            }
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