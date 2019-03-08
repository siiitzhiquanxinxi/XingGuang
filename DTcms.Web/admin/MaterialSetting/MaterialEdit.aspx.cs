using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;
namespace DTcms.Web.admin.MaterialSetting
{
    public partial class MaterialEdit : DTcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            string ID = "";
            if (!string.IsNullOrEmpty(_action) && _action != DTEnums.ActionEnum.Add.ToString())
            {

                this.action = _action;//修改操作类型
                ID = Request.QueryString["ID"] as string;
                if (ID != "")
                {
                    if (!MaterialBll.Exists(Convert.ToInt32(ID)))
                    {
                        JscriptMsg("记录不存在或已被删除！", "back", "Error");
                        return;
                    }
                }
                
            }
            if (!IsPostBack)
            {
                BindList();
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(ID);
                }
                else if (action == DTEnums.ActionEnum.Add.ToString())//新增
                {

                    dtdatail = MaterialDetailBll.GetList("1=2").Tables[0];
                    this.rptList.DataSource = dtdatail;
                    rptList.DataBind();
                }
                else
                {
                    ShowInfo(ID);
                    this.btnSave.Enabled = false;
                }

            }
        }
        private int state = 0;
        private static DataTable dtdatail = null;
        private void ShowInfo(string id)
        {

            DTcms.Model.Sy_Material material = MaterialBll.GetModel(Convert.ToInt32(id));

            hidID.Value = material.ID.ToString();
            txtBrand.Text = material.Brand;
            txtBrandImg.Text = material.BrandImg;
            txtMode.Text = material.Mode;
            txtName.Text = material.Name;
            txtDescription.Text = material.Description;
            txtUnit.Text = material.Unit;
            txtUnitPrice.Text = material.UnitPrice.ToString();
            //txtCostPrice.Text = material.CostPrice.ToString();
            txtLaborCost.Text = material.LaborCost.ToString();
            txtPhoto.Text = material.Photo;
            txtMaterialID.Text = material.MaterialID;
            txtMaterialName.Text = material.MaterialName;
            ddlTag.SelectedItem.Text = material.Tag;
            if(material.State!=null)
            state = Convert.ToInt32(material.State);
            dtdatail = MaterialDetailBll.GetList("ForInnerID='" + material.ID + "'").Tables[0];
            this.rptList.DataSource = dtdatail;
            rptList.DataBind();
        }

        Sy_Material MaterialBll = new Sy_Material();
        Sy_Material_Detail MaterialDetailBll = new Sy_Material_Detail();

        private void BindList()
        {
            //分组
            DTcms.BLL.Sy_MaterialType pgroupbll = new DTcms.BLL.Sy_MaterialType();
            DataTable dt1 = pgroupbll.GetAllList().Tables[0];
            dt1.Rows.InsertAt(dt1.NewRow(), 0);
            this.ddlMaterialType.DataSource = dt1;
            this.ddlMaterialType.DataTextField = "MaterialType";
            this.ddlMaterialType.DataValueField = "ID";
            this.ddlMaterialType.DataBind();
        }
        private bool IsCheck()
        {
            if (this.txtName.Text.Trim() == "")
            {
                JscriptMsg("品名不能为空", "back", "Error");
                return false;
            }
            if (this.txtUnitPrice.Text.Trim() == "")
            {
                this.txtUnitPrice.Text = "0";
            }
            if (this.txtLaborCost.Text.Trim() == "")
            {
                this.txtLaborCost.Text = "0";
            }
            return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.Sy_Material material = new DTcms.Model.Sy_Material();
            material.MaterialTypeID = Convert.ToInt32( ddlMaterialType.SelectedValue);
            material.MaterialType = ddlMaterialType.SelectedItem.Text;
            material.Brand = txtBrand.Text.Trim();
            material.BrandImg = txtBrandImg.Text.Trim();
            material.Mode = txtMode.Text.Trim();
            material.Name = txtName.Text.Trim();
            material.Description = txtDescription.Text.Trim();
            material.Unit = txtUnit.Text.Trim();
            material.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            material.CostPrice = 0;
            material.LaborCost = Convert.ToDecimal(txtLaborCost.Text.Trim());
            material.Photo = txtPhoto.Text.Trim();
            material.MaterialID = txtMaterialID.Text.Trim();
            material.MaterialName = txtMaterialName.Text.Trim();
            material.Tag = ddlTag.SelectedItem.Text;
            material.State = 0;
            if (action == DTEnums.ActionEnum.Add.ToString())
            {  //新增
                int id=MaterialBll.Add(material);
                if (dtdatail != null)
                {
                    if (dtdatail.Rows.Count > 0)
                    {
                        foreach (RepeaterItem item in rptList.Items)
                        {
                            HiddenField hfdID = item.FindControl("hfdID") as HiddenField;
                            TextBox txtNum = item.FindControl("txtNum") as TextBox;
                            dtdatail.Select("InnerID='" + hfdID.Value + "'")[0]["Num"] = txtNum.Text.Trim();
                        }
                        for (int i = 0; i < dtdatail.Rows.Count; i++)
                        {
                            dtdatail.Rows[i]["ForInnerID"] = id;
                        }
                        dtdatail.TableName = "Sy_Material_Detail";
                        MaterialDetailBll.Add(dtdatail);
                    }
                }
                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                MaterialBll.Update(material);
                if (dtdatail.Rows.Count > 0)
                {
                    dtdatail.TableName = "Sy_Material_Detail";
                    MaterialDetailBll.Add(dtdatail);
                }
                MessageBox.Show(this, "修改成功！");
            }
        }
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            MaterialDetailBll.DeletebyWhere("InnerID='" + id + "'");
            dtdatail.Rows.Remove(dtdatail.Select("InnerID='" + id + "'")[0]);
            this.rptList.DataSource = dtdatail;
            rptList.DataBind();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (txtPhoto.Text.Trim() != "")
            {
                this.imgbeginPic.ImageUrl = txtPhoto.Text.Trim();
            }
            if (txtBrandImg.Text.Trim() != "")
            {
                this.Image1.ImageUrl = txtBrandImg.Text.Trim();
            }
            if (hidMaterialID.Value != "")
            {
                
                DTcms.Model.Sy_Material material = MaterialBll.GetModel(Convert.ToInt32(hidMaterialID.Value));
                DataRow dr=dtdatail.NewRow();
                dr["InnerID"] = Guid.NewGuid();
                dr["ForInnerID"] = 0;
                dr["ID"] = material.ID;
                dr["Brand"] = material.Brand;
                dr["Mode"] = material.Mode;
                dr["Name"] = material.Name;
                dr["Description"] = material.Description;
                dr["Unit"] = material.Unit;
                dtdatail.Rows.Add(dr);
                this.rptList.DataSource = dtdatail;
                rptList.DataBind();
                hidMaterialID.Value = "";
            }
        }

    }
}