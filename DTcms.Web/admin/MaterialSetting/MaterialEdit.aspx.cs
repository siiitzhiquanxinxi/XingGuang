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
            ddlMaterialType.SelectedValue = material.MaterialTypeID.ToString();
            txtBrand.Text = material.Brand;
            txtBrandImg.Text = material.BrandImg;
            txtMode.Text = material.Mode;
            txtName.Text = material.Name;
            txtDescription.Text = material.Description;
            txtUnit.Text = material.Unit;
            txtUnitPrice.Text = material.UnitPrice.ToString();
            //txtCostPrice.Text = material.CostPrice.ToString();
            txtLaborCost.Text = material.LaborCost.ToString();
            txtInstallationFee.Text = material.InstallationFee.ToString();
            txtCommissioningFee.Text = material.CommissioningFee.ToString();
            txtManagementFee.Text = material.ManagementFee.ToString();
            txtPhoto.Text = material.Photo;
            txtMaterialID.Text = material.MaterialID;
            txtMaterialName.Text = material.MaterialName;
            ddlTag.SelectedItem.Text = material.Tag;
            if (material.State != null)
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
            if (this.txtInstallationFee.Text.Trim() == "")
            {
                this.txtInstallationFee.Text = "0";
            }
            if (this.txtCommissioningFee.Text.Trim() == "")
            {
                this.txtCommissioningFee.Text = "0";
            }
            if (this.txtManagementFee.Text.Trim() == "")
            {
                this.txtManagementFee.Text = "0";
            }
            return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.Sy_Material material = new DTcms.Model.Sy_Material();
            material.MaterialTypeID = Convert.ToInt32(ddlMaterialType.SelectedValue);
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
            material.InstallationFee = Convert.ToDecimal(txtInstallationFee.Text.Trim());
            material.CommissioningFee = Convert.ToDecimal(txtCommissioningFee.Text.Trim());
            material.ManagementFee = Convert.ToDecimal(txtManagementFee.Text.Trim());
            material.Photo = txtPhoto.Text.Trim();
            material.MaterialID = txtMaterialID.Text.Trim();
            material.MaterialName = txtMaterialName.Text.Trim();
            material.Tag = ddlTag.SelectedItem.Text;
            material.State = 0;
            if (action == DTEnums.ActionEnum.Add.ToString())
            {  //新增
                int id = MaterialBll.Add(material);
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
                material.ID = Convert.ToInt32(hidID.Value);
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
                txtMBrand.Text = material.Brand;
                txtMMode.Text = material.Mode;
                txtMName.Text = material.Name;
                txtMDescription.Text = material.Description;
                txtMUnit.Text = material.Unit;
                //DataRow dr = dtdatail.NewRow();
                //dr["InnerID"] = Guid.NewGuid();
                //dr["ForInnerID"] = 0;
                //dr["ID"] = material.ID;
                //dr["Brand"] = material.Brand;
                //dr["Mode"] = material.Mode;
                //dr["Name"] = material.Name;
                //dr["Description"] = material.Description;
                //dr["Unit"] = material.Unit;
                //dtdatail.Rows.Add(dr);
                //this.rptList.DataSource = dtdatail;
                //rptList.DataBind();
                //hidMaterialID.Value = "";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            DataRow dr = dtdatail.NewRow();
            dr["InnerID"] = Guid.NewGuid();
            dr["ForInnerID"] = hidID.Value;
            dr["ID"] = hidMaterialID.Value;
            dr["Brand"] = txtMBrand.Text;
            dr["Mode"] = txtMMode.Text;
            dr["Name"] = txtMName.Text;
            dr["Description"] = txtMDescription.Text;
            dr["Unit"] = txtMUnit.Text;
            if (this.txtMNum.Text.Trim() == "")
            {
                this.txtMNum.Text = "0";
            }
            else
            {
                try
                {
                    decimal num = Convert.ToDecimal(txtMNum.Text.Trim());
                    dr["Num"] = num;
                }
                catch
                {
                    MessageBox.Show(this, "数量应为数字类型！");
                }
            }
            dtdatail.Rows.Add(dr);
            this.rptList.DataSource = dtdatail;
            rptList.DataBind();
            hidMaterialID.Value = "";
        }


    }
}