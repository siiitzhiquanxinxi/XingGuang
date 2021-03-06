﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

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
                txtXitongtiaoshiFee.Text = dt.Rows[0]["XitongtiaoshiFee"].ToString();
                txtXitongtiaoshiDes.Text = dt.Rows[0]["XitongtiaoshiDes"].ToString();
                txtXiangmuguanliFee.Text = dt.Rows[0]["XiangmuguanliFee"].ToString();
                txtXiangmuguanliDes.Text = dt.Rows[0]["XiangmuguanliDes"].ToString();
                txtQicaianzhuangFee.Text = dt.Rows[0]["QicaianzhuangFee"].ToString();
                txtQicaianzhuangDes.Text = dt.Rows[0]["QicaianzhuangDes"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            IsCheck();
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
                Model.Sy_SystemType model = new BLL.Sy_SystemType().GetModel(int.Parse(Request.QueryString["id"]));
                model.SystemTypeName = txtSystemTypeName.Text;
                model.HasMaterialType = arrm;
                model.XitongtiaoshiFee = Convert.ToDecimal(txtXitongtiaoshiFee.Text);
                model.XiangmuguanliFee = Convert.ToDecimal(txtXiangmuguanliFee.Text);
                model.QicaianzhuangFee = Convert.ToDecimal(txtQicaianzhuangFee.Text);
                model.XitongtiaoshiDes = txtXitongtiaoshiDes.Text;
                model.XiangmuguanliDes = txtXiangmuguanliDes.Text;
                model.QicaianzhuangDes = txtQicaianzhuangDes.Text;
                model.RuodiananzhuangDes = txtRuodiananzhuangDes.Text;
                if (FileUpload1.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_xitongtiaoshi";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath(fileurl));
                    model.XitongtiaoshiPic = path + "/" + FileUpload1.FileName;
                }
                if (FileUpload2.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_xiangmuguanli";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload2.FileName;
                    FileUpload2.SaveAs(Server.MapPath(fileurl));
                    model.XiangmuguanliPic = path + "/" + FileUpload2.FileName;
                }
                if (FileUpload3.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_qicaianzhuang";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload3.FileName;
                    FileUpload3.SaveAs(Server.MapPath(fileurl));
                    model.QicaianzhuangPic = path + "/" + FileUpload3.FileName;
                }
                if (FileUpload4.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_qicaianzhuang";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload4.FileName;
                    FileUpload4.SaveAs(Server.MapPath(fileurl));
                    model.RuodiananzhuangPic = path + "/" + FileUpload4.FileName;
                }
                new BLL.Sy_SystemType().Update(model);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('保存成功!');window.location.href='SystemTypeList.aspx';", true);

                //string sql = "update Sy_SystemType set SystemTypeName = '" + txtSystemTypeName.Text + "',HasMaterialType = '" + arrm + "' where SystemTypeID = " + Request.QueryString["id"];
                //if (DbHelperSQL.ExecuteSql(sql) > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('保存成功!');window.location.href='SystemTypeList.aspx';", true);
                //}
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
                Model.Sy_SystemType model = new Model.Sy_SystemType();
                model.SystemTypeName = txtSystemTypeName.Text;
                model.HasMaterialType = arrm;
                model.XitongtiaoshiFee = Convert.ToDecimal(txtXitongtiaoshiFee.Text);
                model.XiangmuguanliFee = Convert.ToDecimal(txtXiangmuguanliFee.Text);
                model.QicaianzhuangFee = Convert.ToDecimal(txtQicaianzhuangFee.Text);
                model.XitongtiaoshiDes = txtXitongtiaoshiDes.Text;
                model.XiangmuguanliDes = txtXiangmuguanliDes.Text;
                model.QicaianzhuangDes = txtQicaianzhuangDes.Text;
                model.RuodiananzhuangDes = txtRuodiananzhuangDes.Text;
                if (FileUpload1.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_xitongtiaoshi";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath(fileurl));
                    model.XitongtiaoshiPic = path + "/" + FileUpload1.FileName;
                }
                if (FileUpload2.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_xiangmuguanli";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload2.FileName;
                    FileUpload2.SaveAs(Server.MapPath(fileurl));
                    model.XiangmuguanliPic = path + "/" + FileUpload2.FileName;
                }
                if (FileUpload3.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_qicaianzhuang";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload3.FileName;
                    FileUpload3.SaveAs(Server.MapPath(fileurl));
                    model.QicaianzhuangPic = path + "/" + FileUpload3.FileName;
                }
                if (FileUpload4.HasFile)
                {
                    string fileurl = "";
                    string path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_qicaianzhuang";
                    if (!Directory.Exists(Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(Server.MapPath(path));
                    }
                    fileurl = "../.." + path + "/" + FileUpload4.FileName;
                    FileUpload4.SaveAs(Server.MapPath(fileurl));
                    model.RuodiananzhuangPic = path + "/" + FileUpload4.FileName;
                }
                new BLL.Sy_SystemType().Add(model);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('添加成功!');window.location.href='SystemTypeList.aspx';", true);

                //string sql = "insert into Sy_SystemType values('" + txtSystemTypeName.Text + "','" + arrm + "')";
                //if (DbHelperSQL.ExecuteSql(sql) > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('添加成功!');window.location.href='SystemTypeList.aspx';", true);
                //}
            }
        }

        private void IsCheck()
        {
            if (txtXitongtiaoshiFee.Text.Trim() == "")
            {
                txtXitongtiaoshiFee.Text = "0";
            }
            if (txtXiangmuguanliFee.Text.Trim() == "")
            {
                txtXiangmuguanliFee.Text = "0";
            }
            if (txtQicaianzhuangFee.Text.Trim() == "")
            {
                txtQicaianzhuangFee.Text = "0";
            }
        }
    }
}