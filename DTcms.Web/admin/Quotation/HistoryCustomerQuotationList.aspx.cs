using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.Quotation
{
    public partial class HistoryCustomerQuotationList : System.Web.UI.Page
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
            string where = "1=1 and CustomerState <> 0 order by CreateDate desc";
            List<Model.C_CustomerProgram> lstCustomer = new BLL.C_CustomerProgram().GetModelList(where);
            rptCusotmer.DataSource = lstCustomer;
            rptCusotmer.DataBind();

            for (int i = 0; i < rptCusotmer.Items.Count; i++)
            {
                DropDownList ddl = rptCusotmer.Items[i].FindControl("ddlCustomerState") as DropDownList;
                HiddenField hfdid = rptCusotmer.Items[i].FindControl("hfdId") as HiddenField;
                ddl.SelectedValue = new BLL.C_CustomerProgram().GetModel(int.Parse(hfdid.Value)).CustomerState.ToString();
                Repeater rptQuotation = rptCusotmer.Items[i].FindControl("rptQuotation") as Repeater;
                List<Model.Q_QuotationList> lstQuotation = new BLL.Q_QuotationList().GetModelList("FK_CustomerID = " + hfdid.Value + " and QuotationListState >= 0");
                rptQuotation.DataSource = lstQuotation;
                rptQuotation.DataBind();
                if (lstQuotation.Count <= 0)
                {
                    Label lblIsNoRecord = rptQuotation.Controls[1].FindControl("lblIsNoRecord") as Label;
                    lblIsNoRecord.Visible = true;
                }
                for (int j = 0; j < rptQuotation.Items.Count; j++)
                {
                    HiddenField hfdState = rptQuotation.Items[j].FindControl("hfdState") as HiddenField;
                    if (hfdState.Value == "1")
                    {
                        LinkButton lbtnApprove = rptQuotation.Items[j].FindControl("lbtnApprove") as LinkButton;
                        LinkButton lbtnEdit = rptQuotation.Items[j].FindControl("lbtnEdit") as LinkButton;
                        lbtnApprove.Enabled = lbtnEdit.Enabled = false;
                    }

                    HiddenField hfdId = rptQuotation.Items[j].FindControl("hfdId") as HiddenField;
                    Model.Q_QuotationList model = new BLL.Q_QuotationList().GetModel(int.Parse(hfdId.Value));
                    List<Model.Q_QuotationDetailType> lstType = new BLL.Q_QuotationDetailType().GetModelList("FK_ParentQuotationListId = " + hfdId.Value);
                    decimal Q_total = 0;
                    for (int k = 0; k < lstType.Count; k++)
                    {
                        string sql = "select sum(UnitPrice*GoodsQuantity) from Q_QuotationDetailGoods where FK_QuotationDetailTypeId = " + lstType[j].QuotationDetailTypeId;
                        DataTable d = DbHelperSQL.Query(sql).Tables[0];
                        decimal sub = 0;
                        if (d != null && d.Rows.Count > 0 && d.Rows[0][0].ToString() != "")
                        {
                            sub = Convert.ToDecimal(d.Rows[0][0].ToString());
                            Q_total += sub + Convert.ToDecimal(lstType[k].RuodiananzhuangFee)
                                + Convert.ToDecimal(lstType[k].QicaianzhuangFee)
                                + Convert.ToDecimal(lstType[k].XitongtiaoshiFee)
                                + Convert.ToDecimal(lstType[k].XiangmuguanliFee)
                                + Convert.ToDecimal(lstType[k].VideoDebugFee)
                                + Convert.ToDecimal(lstType[k].AudioDebugFee);
                        }
                    }
                    Label lblTotal = rptQuotation.Items[j].FindControl("lblTotal") as Label;
                    lblTotal.Text = Math.Round(Q_total, 0).ToString();
                    Label lblAfterTotal = rptQuotation.Items[j].FindControl("lblAfterTotal") as Label;
                    Q_total = Q_total * Convert.ToDecimal(model.PreferentialRatio) / 100 - Convert.ToDecimal(model.PreferentialRelief);
                    lblAfterTotal.Text = Math.Round(Q_total, 0).ToString();
                }
            }
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            Response.Redirect("QuotaionDetailEdit.aspx?action=edit&id=" + lbtn.CommandArgument.ToString());
        }

        protected void lbtnApprove_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            string id = lbtn.CommandArgument.ToString();
            string sql = "update Q_QuotationList set QuotationListState = 1 where QuotationListId = " + id;
            DbHelperSQL.ExecuteSql(sql);
            BindData();
        }
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ddlCustomerState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            HiddenField hfdid = ddl.Parent.FindControl("hfdId") as HiddenField;
            string sql = "update C_CustomerProgram set CustomerState = " + ddl.SelectedItem.Value;
            DbHelperSQL.ExecuteSql(sql);
            BindData();
        }

        public string GetName(string id)
        {
            Model.manager model = new BLL.manager().GetModel(int.Parse(id));
            if (model != null)
            {
                return model.real_name;
            }
            else
            {
                return "";
            }
        }
    }
}