using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class QuotationTemplateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCkb();
                if (cblSType.Items.Count > 0)
                {
                    cblSType.Items[0].Selected = true;
                    BindData();
                }
            }
        }

        private void BindCkb()
        {
            string sql = "select * from Sy_SystemType where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            cblSType.DataSource = dt;
            cblSType.DataTextField = "SystemTypeName";
            cblSType.DataValueField = "SystemTypeID";
            cblSType.DataBind();
        }

        private void BindData()
        {
            string sql = "select * from Q_QuotationTemplate where 1=1 and QuotationTemplateState = 1";
            string where = "";

            int checkindex = 0;
            for (int i = 0; i < cblSType.Items.Count; i++)
            {
                if (cblSType.Items[i].Selected == true)
                {
                    if (checkindex == 0)
                    {
                        where += " and (QuotationTemplateTypeId = '" + cblSType.Items[i].Value + "'";
                    }
                    if (checkindex > 0)
                    {
                        where += " or QuotationTemplateTypeId = '" + cblSType.Items[i].Value + "'";
                    }
                    checkindex++;
                }
            }
            if (checkindex > 0)
            {
                where += ")";
            }
            where += " order by QuotationTemplateTypeId";
            sql += where;
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    string tid = ((HiddenField)rptList1.Items[i].FindControl("hfdId")).Value;
                    DbHelperSQL.ExecuteSql("delete Q_QuotationTemplate where QuotationTemplateId = " + tid);
                    DbHelperSQL.ExecuteSql("delete Q_QuotationTemplateDetail where TemplateParentID = " + tid);
                }
            }
            BindData();
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
            AspNetPager1.CurrentPageIndex = 1;
            BindData();
        }
    }
}