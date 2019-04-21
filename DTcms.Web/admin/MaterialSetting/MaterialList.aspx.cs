using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;
using System.Text;
namespace DTcms.Web.admin.MaterialSetting
{
    public partial class MaterialList : System.Web.UI.Page
    {
        //protected int totalCount;
        //protected int page;
        //protected int pageSize;
        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindCkb();
                BindData();
                keywords = this.txtKeywords.Text.Trim();
                //this.pageSize = GetPageSize(5);
                //RptBind(CombSqlTxt(keywords), "ID desc");
                string MaterialType = DTRequest.GetQueryString("MaterialType");
                if (MaterialType != "")
                {
                    rblType.SelectedValue = MaterialType;
                    BindData();
                }
            }
        }

        private void BindCkb()
        {
            BLL.Sy_MaterialType bll = new BLL.Sy_MaterialType();
            DataTable dt = bll.GetAllList().Tables[0];
            rblType.DataSource = dt;
            rblType.DataTextField = "MaterialType";
            rblType.DataValueField = "MaterialType";
            rblType.DataBind();
        }
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  Name like  '%" + _keywords + "%' or Description like '%" + txtKeywords.Text + "%'");
            }
            //int checkindex = 0;
            //for (int i = 0; i < cblMType.Items.Count; i++)
            //{
            //    if (cblMType.Items[i].Selected == true)
            //    {
            //        if (checkindex == 0)
            //        {
            //            strTemp.Append(" and (MaterialType = '" + cblMType.Items[i].Text + "'");
            //        }
            //        if (checkindex > 0)
            //        {
            //            strTemp.Append(" or MaterialType = '" + cblMType.Items[i].Text + "'");
            //        }
            //        checkindex++;
            //    }
            //}
            //if (checkindex > 0)
            //{
            //    strTemp.Append(")");
            //}
            return strTemp.ToString();
        }
        //private void RptBind(string _strWhere, string _orderby)
        //{
        //    _strWhere = " 1=1 " + _strWhere;
        //    this.page = DTRequest.GetQueryInt("page", 1);
        //    txtKeywords.Text = this.keywords;
        //    DTcms.BLL.Sy_Material hdBll = new DTcms.BLL.Sy_Material();
        //    DataSet ds = hdBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        //    this.rptList1.DataSource = ds;
        //    this.rptList1.DataBind();

        //    //绑定页码
        //    //txtPageNum.Text = this.pageSize.ToString();
        //    //string pageUrl = Utils.CombUrlTxt("MaterialList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
        //    //PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        //}
        private void BindData()
        {
            BLL.Sy_Material bll = new BLL.Sy_Material();
            string where = " 1=1";
            if (txtKeywords.Text != "")
            {
                where += " and (Name like '%" + txtKeywords.Text + "%' or Description like '%" + txtKeywords.Text + "%' or Mode like '%" + txtKeywords.Text + "%')";
            }
            where += " and MaterialType = '" + rblType.SelectedValue + "'";
            //int checkindex = 0;
            //for (int i = 0; i < cblMType.Items.Count; i++)
            //{
            //    if (cblMType.Items[i].Selected == true)
            //    {
            //        if (checkindex == 0)
            //        {
            //            where += " and (MaterialType = '" + cblMType.Items[i].Text + "'";
            //        }
            //        if (checkindex > 0)
            //        {
            //            where += " or MaterialType = '" + cblMType.Items[i].Text + "'";
            //        }
            //        checkindex++;
            //    }
            //}
            //if (checkindex > 0)
            //{
            //    where += ")";
            //}

            //DataTable dt = bll.GetListByPage(where, "MaterialType", 0, 100).Tables[0];
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int sucCount = 0;
            int errorCount = 0;
            DTcms.BLL.Sy_Material bll = new DTcms.BLL.Sy_Material();
            DTcms.BLL.Sy_Material_Detail blldetail = new DTcms.BLL.Sy_Material_Detail();
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                string OrderNo = ((HiddenField)rptList1.Items[i].FindControl("hfdId")).Value;
                CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(Convert.ToInt32(OrderNo)))
                    {
                        if (blldetail.DeletebyWhere("ForInnerID='" + OrderNo + "'"))
                        {
                            sucCount += 1;
                        }
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            BindData();
            //Response.Redirect("MaterialList.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
            //keywords = this.txtKeywords.Text.Trim();
            //this.pageSize = GetPageSize(10);
            //RptBind(CombSqlTxt(keywords), "ID desc");
        }

        //protected void txtPageNum_TextChanged(object sender, EventArgs e)
        //{
        //    int _pagesize;
        //    if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        //    {
        //        if (_pagesize > 0)
        //        {
        //            Utils.WriteCookie("MaterialList", _pagesize.ToString(), 14400);
        //        }
        //    }
        //    Response.Redirect(Utils.CombUrlTxt("MaterialList.aspx", "keywords={0}", this.keywords));
        //}

        protected void cblMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            //this.pageSize = GetPageSize(100);
            BindData();
            //绑定页码
            //txtPageNum.Text = this.pageSize.ToString();
            //string pageUrl = Utils.CombUrlTxt("MaterialList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            //PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("MaterialList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}