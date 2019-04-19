using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.Quotation.print
{
    public partial class printQuotionTotal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"];

                List<Model.Q_QuotationDetailType> lstType = new BLL.Q_QuotationDetailType().GetModelList("FK_ParentQuotationListId = " + id);
                rptTotal.DataSource = lstType;
                rptTotal.DataBind();
                decimal Q_total = 0;
                for (int i = 0; i < rptTotal.Items.Count; i++)
                {
                    HiddenField hfdQuotationDetailTypeId = rptTotal.Items[i].FindControl("hfdQuotationDetailTypeId") as HiddenField;
                    Label txtBroundCN = rptTotal.Items[i].FindControl("txtBroundCN") as Label;
                    Label txtBroundEN = rptTotal.Items[i].FindControl("txtBroundEN") as Label;
                    List<Model.Q_QuotationDetailGoods> lstG = new BLL.Q_QuotationDetailGoods().GetModelList("FK_QuotationDetailTypeId = " + hfdQuotationDetailTypeId.Value + " order by DetailOrder");
                    if (lstG != null && lstG.Count > 0)
                    {
                        txtBroundCN.Text = lstG[0].Brand;
                        txtBroundEN.Text = lstG[0].BrandEnglish;
                    }
                    Label lblSubTotal = rptTotal.Items[i].FindControl("lblSubTotal") as Label;
                    string sql = "select sum(UnitPrice*GoodsQuantity) from Q_QuotationDetailGoods where FK_QuotationDetailTypeId = " + hfdQuotationDetailTypeId.Value;
                    decimal sub = Convert.ToDecimal(DbHelperSQL.Query(sql).Tables[0].Rows[0][0].ToString());
                    Model.Q_QuotationDetailType model = new BLL.Q_QuotationDetailType().GetModel(int.Parse(hfdQuotationDetailTypeId.Value));
                    sub += Convert.ToDecimal(model.RuodiananzhuangFee)
                        + Convert.ToDecimal(model.QicaianzhuangFee)
                        + Convert.ToDecimal(model.XitongtiaoshiFee)
                        + Convert.ToDecimal(model.XiangmuguanliFee)
                        + Convert.ToDecimal(model.VideoDebugFee)
                        + Convert.ToDecimal(model.AudioDebugFee);
                    lblSubTotal.Text = Math.Round(sub, 2).ToString();
                    Q_total += lblSubTotal.Text != "" ? Convert.ToDecimal(lblSubTotal.Text) : 0;
                }
                Label QlblTotal = rptTotal.Controls[rptTotal.Controls.Count - 1].FindControl("lblTotal") as Label;
                QlblTotal.Text = Math.Round(Q_total, 2).ToString();


                rptParent.DataSource = lstType;
                rptParent.DataBind();

                for (int i = 0; i < rptParent.Items.Count; i++)
                {
                    Repeater rpt = rptParent.Items[i].FindControl("rptList1") as Repeater;
                    HiddenField hfdQuotationDetailTypeId = rptParent.Items[i].FindControl("hfdQuotationDetailTypeId") as HiddenField;
                    List<Model.Q_QuotationDetailGoods> lstDetailGoods = new BLL.Q_QuotationDetailGoods().GetModelList("FK_QuotationDetailTypeId = " + hfdQuotationDetailTypeId.Value);
                    rpt.DataSource = lstDetailGoods;
                    rpt.DataBind();
                    decimal total = 0;
                    for (int j = 0; j < rpt.Items.Count; j++)
                    {
                        decimal qty = 0;
                        Label lblQuantity = rpt.Items[j].FindControl("lblQuantity") as Label;
                        if (!string.IsNullOrEmpty(lblQuantity.Text))
                        {
                            qty = Convert.ToDecimal(lblQuantity.Text);
                        }
                        decimal unitptice = 0;
                        Label lblUnitPrice = rpt.Items[j].FindControl("lblUnitPrice") as Label;
                        if (!string.IsNullOrEmpty(lblUnitPrice.Text))
                        {
                            unitptice = Convert.ToDecimal(lblUnitPrice.Text);
                        }
                        Label lblSubTotal = rpt.Items[j].FindControl("lblSubTotal") as Label;
                        lblSubTotal.Text = Math.Round(qty * unitptice, 2).ToString();
                        total += qty * unitptice;
                    }
                    Label lblTotal = rpt.Controls[rpt.Controls.Count - 1].FindControl("lblTotal") as Label;
                    lblTotal.Text = Math.Round(total, 2).ToString();
                }
            }
        }

        //protected void rptList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //    {
        //        decimal qty = 0;
        //        Label lblQuantity = e.Item.FindControl("lblQuantity") as Label;
        //        if (!string.IsNullOrEmpty(lblQuantity.Text))
        //        {
        //            qty = Convert.ToDecimal(lblQuantity.Text);
        //        }
        //        decimal unitptice = 0;
        //        Label lblUnitPrice = e.Item.FindControl("lblUnitPrice") as Label;
        //        if (!string.IsNullOrEmpty(lblUnitPrice.Text))
        //        {
        //            unitptice = Convert.ToDecimal(lblUnitPrice.Text);
        //        }
        //        Label lblSubTotal = e.Item.FindControl("lblSubTotal") as Label;
        //        lblSubTotal.Text = Math.Round(qty * unitptice, 2).ToString();
        //    }
        //}
    }
}