using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace DTcms.Web.admin.Quotation
{
    public partial class QuotationListQuery : System.Web.UI.Page
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
            string strWhere = " 1=1";
            if (txtKeywords.Text != "")
            {
                strWhere += " and QuotationListNum like '" + txtKeywords.Text + "'";
            }
            DataTable dt = new BLL.Q_QuotationList().GetList(strWhere + " order by CreateDate desc").Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;

            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList1.DataSource = pds;
            rptList1.DataBind();

            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdState = rptList1.Items[i].FindControl("hfdState") as HiddenField;
                if (hfdState.Value == "1")
                {
                    LinkButton lbtnApprove = rptList1.Items[i].FindControl("lbtnApprove") as LinkButton;
                    LinkButton lbtnEdit = rptList1.Items[i].FindControl("lbtnEdit") as LinkButton;
                    lbtnApprove.Enabled = lbtnEdit.Enabled = false;
                }

                HiddenField hfdId = rptList1.Items[i].FindControl("hfdId") as HiddenField;
                Model.Q_QuotationList model = new BLL.Q_QuotationList().GetModel(int.Parse(hfdId.Value));
                List<Model.Q_QuotationDetailType> lstType = new BLL.Q_QuotationDetailType().GetModelList("FK_ParentQuotationListId = " + hfdId.Value);
                decimal Q_total = 0;
                for (int j = 0; j < lstType.Count; j++)
                {
                    string sql = "select sum(UnitPrice*GoodsQuantity) from Q_QuotationDetailGoods where FK_QuotationDetailTypeId = " + lstType[j].QuotationDetailTypeId;
                    decimal sub = Convert.ToDecimal(DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString());
                    Q_total += sub + Convert.ToDecimal(lstType[j].RuodiananzhuangFee)
                        + Convert.ToDecimal(lstType[j].QicaianzhuangFee)
                        + Convert.ToDecimal(lstType[j].XitongtiaoshiFee)
                        + Convert.ToDecimal(lstType[j].XiangmuguanliFee)
                        + Convert.ToDecimal(lstType[j].VideoDebugFee)
                        + Convert.ToDecimal(lstType[j].AudioDebugFee);
                }
                Label lblTotal = rptList1.Items[i].FindControl("lblTotal") as Label;
                lblTotal.Text = Math.Round(Q_total, 0).ToString();
                Label lblAfterTotal = rptList1.Items[i].FindControl("lblAfterTotal") as Label;
                Q_total = Q_total * Convert.ToDecimal(model.PreferentialRatio) / 100 - Convert.ToDecimal(model.PreferentialRelief);
                lblAfterTotal.Text = Math.Round(Q_total, 0).ToString();
            }

            AspNetPager1.RecordCount = dt.Rows.Count;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    string id = ((HiddenField)rptList1.Items[i].FindControl("hfdId")).Value;
                    DbHelperSQL.ExecuteSql("delete Q_QuotationDetailGoods where FK_QuotationDetailTypeId in (select QuotationDetailTypeId from Q_QuotationDetailType where FK_ParentQuotationListId = " + id + ") ");
                    DbHelperSQL.ExecuteSql("delete Q_QuotationDetailLines where FK_QuotationDetailTypeId in (select QuotationDetailTypeId from Q_QuotationDetailType where FK_ParentQuotationListId = " + id + ") ");
                    DbHelperSQL.ExecuteSql("delete Q_QuotationDetailType where FK_ParentQuotationListId = " + id);
                    DbHelperSQL.ExecuteSql("delete Q_QuotationList where QuotationListId = " + id);
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

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            Response.Redirect("buildQuotaionBlank.aspx?action=edit&id=" + lbtn.CommandArgument.ToString());
        }

        protected void lbtnApprove_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            string id = lbtn.CommandArgument.ToString();
            string sql = "update Q_QuotationList set QuotationListState = 1 where QuotationListId = " + id;
            DbHelperSQL.ExecuteSql(sql);
            BindData();
        }
    }
}