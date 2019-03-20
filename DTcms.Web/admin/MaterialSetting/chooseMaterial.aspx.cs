using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
namespace DTcms.Web.admin.MaterialSetting
{
    public partial class chooseMaterial : System.Web.UI.Page
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
            string where = "";
                where = " 1=1 order by ID";
            DTcms.BLL.Sy_Material bll = new DTcms.BLL.Sy_Material();
            DataTable dt = bll.GetList(where).Tables[0];
            rptList.DataSource = DtSelectTop(10, dt);
            rptList.DataBind();

        }
        /// <summary> 
        /// 获取DataTable前几条数据 
        /// </summary> 
        /// <param name="TopItem">前N条数据</param> 
        /// <param name="oDT">源DataTable</param> 
        /// <returns></returns> 
        public static DataTable DtSelectTop(int TopItem, DataTable oDT)
        {
            if (oDT.Rows.Count < TopItem) return oDT;

            DataTable NewTable = oDT.Clone();
            DataRow[] rows = oDT.Select("1=1");
            for (int i = 0; i < TopItem; i++)
            {
                NewTable.ImportRow((DataRow)rows[i]);
            }
            return NewTable;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeywords.Text.Trim() != "")
            {
                DTcms.BLL.Sy_Material bll = new DTcms.BLL.Sy_Material();
                DataTable dt = bll.GetList("Brand like '%" + txtKeywords.Text.Trim() + "%' or Mode like '%" + txtKeywords.Text.Trim() + "%' or Name like '%" + txtKeywords.Text.Trim() + "%' order by ID").Tables[0];
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string txt = "", value = "";
            foreach (RepeaterItem item in rptList.Items)
            {
                RadioButton ckbid = item.FindControl("chkId") as RadioButton;
                if (ckbid.Checked)
                {
                    HiddenField hfdid = item.FindControl("hidId") as HiddenField;
                    value = hfdid.Value ;
                    HiddenField hfdname = item.FindControl("hfdName") as HiddenField;
                    txt = hfdname.Value ;
                }
            }
            string where = "id='"+ value + "'";
            DTcms.BLL.Sy_Material bll = new DTcms.BLL.Sy_Material();
            DataTable dt = bll.GetList(where).Tables[0];
            if (dt.Rows.Count > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "ok('" + value + "')", true);
        }
    }
}