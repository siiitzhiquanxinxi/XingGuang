using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.Quotation
{
    public partial class SystemTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCBL();
                if (Request.QueryString["action"] == "edit" && !string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    GetData();
                }
            }
        }

        private void BindCBL()
        {
            string sql = "select * from Sy_MaterialType where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            cblMType.DataSource = dt;
            cblMType.DataTextField = "MaterialType";
            cblMType.DataValueField = "ID";
            cblMType.DataBind();
        }

        private void GetData()
        {
            string id = Request.QueryString["id"];
            string sql = "select * from Sy_SystemType where SystemTypeID = " + id;
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                txtSystemTypeName.Text = dt.Rows[0]["SystemTypeName"].ToString();
                if (dt.Rows[0]["HasMaterialType"].ToString() != "")
                {
                    string[] arr = dt.Rows[0]["HasMaterialType"].ToString().Split('|');
                    for (int i = 0; i < cblMType.Items.Count; i++)
                    {
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (cblMType.Items[i].Value == arr[j])
                            {
                                cblMType.Items[i].Selected = true;
                                break;
                            }
                        }
                    }

                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "edit" && !string.IsNullOrEmpty(Request.QueryString["id"]))//修改
            {
                string arrm = "";
                for (int i = 0; i < cblMType.Items.Count; i++)
                {
                    if (cblMType.Items[i].Selected == true)
                    {
                        arrm += cblMType.Items[i].Value + "|";
                    }
                }
                string sql = "update Sy_SystemType set SystemTypeName = '" + txtSystemTypeName.Text + "',HasMaterialType = '" + arrm + "' where SystemTypeID = " + Request.QueryString["id"];
                if (DbHelperSQL.ExecuteSql(sql) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('保存成功!');window.location.href='SystemTypeList.aspx';", true);
                }
            }
            else if (Request.QueryString["action"] == "add")//新增
            {
                string arrm = "";
                for (int i = 0; i < cblMType.Items.Count; i++)
                {
                    if (cblMType.Items[i].Selected == true)
                    {
                        arrm += cblMType.Items[i].Value + "|";
                    }
                }
                string sql = "insert into Sy_SystemType values('" + txtSystemTypeName.Text + "','" + arrm + "')";
                if (DbHelperSQL.ExecuteSql(sql) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('添加成功!');window.location.href='SystemTypeList.aspx';", true);
                }
            }
        }
    }
}