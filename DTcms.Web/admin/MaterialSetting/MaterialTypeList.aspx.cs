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
    public partial class MaterialTypeList : System.Web.UI.Page
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            keywords = this.txtKeywords.Text.Trim();
            //if (!IsPostBack)
            //{
            this.pageSize = GetPageSize(10); //每页数量
            RptBind(CombSqlTxt(keywords), "ID desc");
            //}
        }
        private void RptBind(string _strWhere, string _orderby)
        {
            //Model.wx_userweixin weixin = GetWeiXinCode();
            _strWhere = " 1=1 " + _strWhere;
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            DTcms.BLL.Sy_MaterialType hdBll = new DTcms.BLL.Sy_MaterialType();
            DataSet ds = hdBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("MaterialTypeList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("MaterialTypeList", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("MaterialTypeList.aspx", "keywords={0}", this.keywords));
        }
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  MaterialType like  '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        #endregion
        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("MaterialTypeList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        DTcms.Model.manager model;

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int sucCount = 0;
            int errorCount = 0;
            DTcms.BLL.Sy_MaterialType bll = new DTcms.BLL.Sy_MaterialType();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string OrderNo = ((HiddenField)rptList.Items[i].FindControl("hidId")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(Convert.ToInt32(OrderNo)))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            Response.Redirect("ProductionTypeList.aspx");
        }

    }
}