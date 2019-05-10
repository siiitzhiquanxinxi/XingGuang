using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class ShareQuotationList : System.Web.UI.Page
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
            string sql = "select * from Q_QuotationList inner join C_CustomerProgram on FK_CustomerID = C_CustomerProgram.CustomerId where 1=1";
            string strWhere = " and IsShare = 1";
            if (txtKeywords.Text != "")
            {
                strWhere += " and QuotationListNum like '" + txtKeywords.Text + "'";
            }
            sql += strWhere;
            sql += " order by Q_QuotationList.CreateDate desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            rptList1.DataSource = dt;
            rptList1.DataBind();

        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}