using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class chooseMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLM();
                BindDDL();
                BindData();
            }
        }

        private void BindDDLM()
        {
            string sql = "select * from Sy_MaterialType where 1=1";
            string where = "";
            if (!string.IsNullOrEmpty(Request.QueryString["stype"]))
            {
                string s = "select * from Sy_SystemType where SystemTypeID = " + Request.QueryString["stype"];
                DataTable d = DbHelperSQL.Query(s).Tables[0];
                if (d != null && d.Rows.Count > 0 && d.Rows[0]["HasMaterialType"].ToString().Trim() != "")
                {
                    string[] arr = d.Rows[0]["HasMaterialType"].ToString().Split('|');
                    where += " and ID in (";
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(arr[i]))
                        {
                            where += arr[i] + ",";
                        }
                    }
                    where = where.Trim(',');
                    where += ")";
                }
                else
                {
                    where += " and 1=2";
                }
            }
            sql += where;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            ddlMaterialType.DataSource = dt;
            ddlMaterialType.DataTextField = "MaterialType";
            ddlMaterialType.DataValueField = "ID";
            ddlMaterialType.DataBind();
        }

        private void BindDDL()
        {
            string sql = "select distinct Brand from Sy_Material where 1=1";
            string where = "";
            if (!string.IsNullOrEmpty(Request.QueryString["mtype"]))
            {
                where += " and MaterialTypeID = " + Request.QueryString["mtype"];
            }
            if (!string.IsNullOrEmpty(Request.QueryString["stype"]))
            {
                string s = "select * from Sy_SystemType where SystemTypeID = " + Request.QueryString["stype"];
                DataTable d = DbHelperSQL.Query(s).Tables[0];
                if (d != null && d.Rows.Count > 0 && d.Rows[0]["HasMaterialType"].ToString().Trim() != "")
                {
                    string[] arr = d.Rows[0]["HasMaterialType"].ToString().Split('|');
                    where += " and MaterialTypeID in (";
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(arr[i]))
                        {
                            where += arr[i] + ",";
                        }
                    }
                    where = where.Trim(',');
                    where += ")";
                }
                else
                {
                    where += " and 1=2";
                }
            }
            if (ddlMaterialType.SelectedItem.Value != "-1")
            {
                where += " and MaterialTypeID = " + ddlMaterialType.SelectedItem.Value;
            }
            sql += where;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            ddlBrand.DataSource = dt;
            ddlBrand.DataTextField = "Brand";
            ddlBrand.DataValueField = "Brand";
            ddlBrand.DataBind();
            ListItem li = new ListItem("---全部---", "-1");
            ddlBrand.Items.Insert(0, li);
        }

        private void BindData()
        {
            BLL.Sy_Material bll = new BLL.Sy_Material();
            string where = " 1=1";
            if (!string.IsNullOrEmpty(Request.QueryString["mtype"]))
            {
                where += " and MaterialTypeID = " + Request.QueryString["mtype"];
            }
            if (!string.IsNullOrEmpty(Request.QueryString["stype"]))
            {
                string s = "select * from Sy_SystemType where SystemTypeID = " + Request.QueryString["stype"];
                DataTable d = DbHelperSQL.Query(s).Tables[0];
                if (d != null && d.Rows.Count > 0 && d.Rows[0]["HasMaterialType"].ToString().Trim() != "")
                {
                    string[] arr = d.Rows[0]["HasMaterialType"].ToString().Split('|');
                    where += " and MaterialTypeID in (";
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(arr[i]))
                        {
                            where += arr[i] + ",";
                        }
                    }
                    where = where.Trim(',');
                    where += ")";
                }
                else
                {
                    where += " and 1=2";
                }
            }
            if (ddlMaterialType.SelectedItem.Value != "-1")
            {
                where += " and MaterialTypeID = " + ddlMaterialType.SelectedItem.Value;
            }
            if (ddlBrand.SelectedItem.Value != "-1")
            {
                where += " and Brand = '" + ddlBrand.SelectedItem.Text + "'";
            }
            if (txtKeywords.Text != "")
            {
                where += " and (Name like '%" + txtKeywords.Text + "%' or Description like '%" + txtKeywords.Text + "%' or Mode like '%" + txtKeywords.Text + "%')";
            }
            where += " order by MaterialTypeID";
            //DataTable dt = bll.GetListByPage(where, "MaterialType", 0, 7).Tables[0];
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
            BindData();
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ddlMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDDL();
            BindData();
        }
    }
}