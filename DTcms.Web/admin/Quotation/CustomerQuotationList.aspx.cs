using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.Quotation
{
    public partial class CustomerQuotationList : System.Web.UI.Page
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
            string sql = "select * from C_CustomerProgram where CustomerState <> 0 and datediff(day, CreateDate,GETDATE()) <= 365";
            sql += " order by CreateDate desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HiddenField hfdState = rptList.Items[i].FindControl("hfdState") as HiddenField;
                if (hfdState.Value == "2" || hfdState.Value == "3" || hfdState.Value == "4")
                {
                    LinkButton lbtnSecond = rptList.Items[i].FindControl("lbtnSecond") as LinkButton;
                    LinkButton lbtnSign = rptList.Items[i].FindControl("lbtnSign") as LinkButton;
                    LinkButton lbtnDie = rptList.Items[i].FindControl("lbtnDie") as LinkButton;
                    LinkButton lbtnGiveup = rptList.Items[i].FindControl("lbtnGiveup") as LinkButton;
                    lbtnSecond.Enabled = lbtnSign.Enabled = lbtnDie.Enabled = lbtnGiveup.Enabled = false;
                }
                Repeater rptChild = rptList.Items[i].FindControl("rptChild") as Repeater;
                HiddenField hfdId = rptList.Items[i].FindControl("hfdId") as HiddenField;
                sql = "select * from Q_QuotationList where FK_CustomerID = " + hfdId.Value;
                sql += " order by CreateDate desc";
                DataTable dd = DbHelperSQL.Query(sql).Tables[0];
                rptChild.DataSource = dd;
                rptChild.DataBind();
            }
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnSecond_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            HiddenField hfdId = btn.Parent.FindControl("hfdId") as HiddenField;

        }

        protected void lbtnSign_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            HiddenField hfdId = btn.Parent.FindControl("hfdId") as HiddenField;
            string sql = "update C_CustomerProgram set CustomerState = 2 where CustomerId = " + hfdId.Value;
            DbHelperSQL.Query(sql);
            BindData();
        }

        protected void lbtnDie_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            HiddenField hfdId = btn.Parent.FindControl("hfdId") as HiddenField;
            string sql = "update C_CustomerProgram set CustomerState = 3 where CustomerId = " + hfdId.Value;
            DbHelperSQL.Query(sql);
            BindData();

        }

        protected void lbtnGiveup_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            HiddenField hfdId = btn.Parent.FindControl("hfdId") as HiddenField;
            string sql = "update C_CustomerProgram set CustomerState = 4 where CustomerId = " + hfdId.Value;
            DbHelperSQL.Query(sql);
            BindData();

        }

        protected void lbtnShare_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            string id = lbtn.CommandArgument.ToString();
            string sql = "update Q_QuotationList set IsShare = 1 where QuotationListId = " + id;
            DbHelperSQL.ExecuteSql(sql);
            BindData();
        }
    }
}