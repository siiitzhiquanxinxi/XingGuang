using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;
using System.IO;
namespace DTcms.Web.admin.MaterialSetting
{
    public partial class MaterialPriceEdit : DTcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Edit.ToString(); //操作类型
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
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(ID);
                }
               

            }
        }
        private int state = 1;
        private void ShowInfo(string id)
        {

            DTcms.Model.Sy_Material material = MaterialBll.GetModel(Convert.ToInt32(id));

            hidID.Value = material.ID.ToString();
            hidMaterialTypeID.Value = material.MaterialTypeID.ToString();
            txtMaterialType.Text = material.MaterialType.ToString();
            txtBrand.Text = material.Brand;
            //txtBrandImg.Text = material.BrandImg;
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
            txtIndoorInstallationFee.Text = material.IndoorInstallationFee.ToString();
            txtIndoorLaborCost.Text = material.IndoorLaborCost.ToString();
            txtVideoDebugFee.Text = material.VideoDebugFee.ToString();
            txtAudioDebugFee.Text = material.AudioDebugFee.ToString();
            //txtPhoto.Text = material.Photo;
            txtMaterialID.Text = material.MaterialID;
            txtMaterialName.Text = material.MaterialName;
            //ddlTag.SelectedItem.Text = material.Tag;
            if (material.State != null)
                state = Convert.ToInt32(material.State);
           
        }

        Sy_Material MaterialBll = new Sy_Material();

        private bool IsCheck()
        {
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
            if (this.txtIndoorInstallationFee.Text.Trim() == "")
            {
                this.txtIndoorInstallationFee.Text = "0";
            }
            if (this.txtIndoorLaborCost.Text.Trim() == "")
            {
                this.txtIndoorLaborCost.Text = "0";
            }
            if (this.txtVideoDebugFee.Text.Trim() == "")
            {
                this.txtVideoDebugFee.Text = "0";
            }
            if (this.txtAudioDebugFee.Text.Trim() == "")
            {
                this.txtAudioDebugFee.Text = "0";
            }
            return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.Sy_Material material = MaterialBll.GetModel(Convert.ToInt32(hidID.Value));
            material.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            material.LaborCost = Convert.ToDecimal(txtLaborCost.Text.Trim());
            material.InstallationFee = Convert.ToDecimal(txtInstallationFee.Text.Trim());
            material.CommissioningFee = Convert.ToDecimal(txtCommissioningFee.Text.Trim());
            material.ManagementFee = Convert.ToDecimal(txtManagementFee.Text.Trim());
            material.IndoorInstallationFee = Convert.ToDecimal(txtIndoorInstallationFee.Text.Trim());
            material.IndoorLaborCost = Convert.ToDecimal(txtIndoorLaborCost.Text.Trim());
            material.VideoDebugFee = Convert.ToDecimal(txtVideoDebugFee.Text.Trim());
            material.AudioDebugFee = Convert.ToDecimal(txtAudioDebugFee.Text.Trim());
            material.State = 0;
            bool re= MaterialBll.Update(material);
            if (re)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('价格设置成功！');window.location.href='MaterialPriceList.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('价格设置失败！');window.location.href='MaterialPriceList.aspx';", true);
            }
        }
    }
}