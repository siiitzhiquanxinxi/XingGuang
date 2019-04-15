using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation.print
{
    public partial class printQuotaionDepart : System.Web.UI.Page
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
                Model.Q_QuotationDetailType qdt = new BLL.Q_QuotationDetailType().GetModel(int.Parse(id));
                lblTypeName.Text = qdt.SystemTypeName;
                if (qdt != null)
                {
                    List<Model.Q_QuotationDetailGoods> lstDetailGoods = new BLL.Q_QuotationDetailGoods().GetModelList("FK_QuotationDetailTypeId = " + id);
                    rptList1.DataSource = lstDetailGoods;
                    rptList1.DataBind();
                    decimal total = 0;
                    for (int i = 0; i < rptList1.Items.Count; i++)
                    {
                        decimal qty = 0;
                        Label lblQuantity = rptList1.Items[i].FindControl("lblQuantity") as Label;
                        if (!string.IsNullOrEmpty(lblQuantity.Text))
                        {
                            qty = Convert.ToDecimal(lblQuantity.Text);
                        }
                        decimal unitptice = 0;
                        Label lblUnitPrice = rptList1.Items[i].FindControl("lblUnitPrice") as Label;
                        if (!string.IsNullOrEmpty(lblUnitPrice.Text))
                        {
                            unitptice = Convert.ToDecimal(lblUnitPrice.Text);
                        }
                        Label lblSubTotal = rptList1.Items[i].FindControl("lblSubTotal") as Label;
                        lblSubTotal.Text = Math.Round(qty * unitptice, 2).ToString();
                        total += qty * unitptice;
                    }
                    Label lblTotal = rptList1.Controls[rptList1.Controls.Count - 1].FindControl("lblTotal") as Label;
                    lblTotal.Text = Math.Round(total, 2).ToString();

                }
                //List<QuatationListTypeClass> lstGoodsType = this.Session["GT"] as List<QuatationListTypeClass>;
                //QuatationListTypeClass qltc = lstGoodsType.Where(p => p.Typeid == int.Parse(Request.QueryString["id"])).First();
                //rptList1.DataSource = qltc.lstQuotationDetailGoods != null ? qltc.lstQuotationDetailGoods : null;
                //rptList1.DataBind();
                //rptLine.DataSource = qltc.lstQuotationDetailLines != null ? qltc.lstQuotationDetailLines : null;
                //rptLine.DataBind();
                //if (qltc.QuotationDetailType != null)
                //{
                //    decimal RuodiananzhuangFee = 0;
                //    decimal QicaianzhuangFee = 0;
                //    decimal XitongtiaoshiFee = 0;
                //    decimal XiangmuguanliFee = 0;
                //    RuodiananzhuangFee = qltc.QuotationDetailType.RuodiananzhuangFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.RuodiananzhuangFee) : 0;
                //    QicaianzhuangFee = qltc.QuotationDetailType.QicaianzhuangFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.QicaianzhuangFee) : 0;
                //    XitongtiaoshiFee = qltc.QuotationDetailType.XitongtiaoshiFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.XitongtiaoshiFee) : 0;
                //    XiangmuguanliFee = qltc.QuotationDetailType.XiangmuguanliFee != null ? Convert.ToDecimal(qltc.QuotationDetailType.XiangmuguanliFee) : 0;
                //    txtRuodiananzhuangFee.Text = Math.Round(RuodiananzhuangFee, 2).ToString();
                //    txtQicaianzhuangFee.Text = Math.Round(QicaianzhuangFee, 2).ToString();
                //    txtXitongtiaoshiFee.Text = Math.Round(XitongtiaoshiFee, 2).ToString();
                //    txtXiangmuguanliFee.Text = Math.Round(XiangmuguanliFee, 2).ToString();
                //}
                //else
                //{
                //    txtRuodiananzhuangFee.Text = txtQicaianzhuangFee.Text = txtXitongtiaoshiFee.Text =
                //       txtXiangmuguanliFee.Text = "";
                //}
            }
        }

        [Serializable]
        private class QuatationListTypeClass
        {
            public int Typeid { get; set; }
            public string Typename { get; set; }
            public Model.Q_QuotationDetailType QuotationDetailType;
            public List<Model.Q_QuotationDetailGoods> lstQuotationDetailGoods;
            public List<Model.Q_QuotationDetailLines> lstQuotationDetailLines;
        }
    }
}