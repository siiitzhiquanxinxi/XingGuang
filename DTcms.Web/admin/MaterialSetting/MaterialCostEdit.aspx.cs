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
    public partial class MaterialCostEdit : DTcms.Web.UI.ManagePage
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
            txtCostPrice.Text = material.CostPrice.ToString();
            
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
            if (this.txtCostPrice.Text.Trim() == "")
            {
                this.txtCostPrice.Text = "0";
            }
           
            return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.Sy_Material material = MaterialBll.GetModel(Convert.ToInt32(hidID.Value));
            material.CostPrice = Convert.ToDecimal(txtCostPrice.Text.Trim());
            
            bool re = MaterialBll.Update(material);
            if (re)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('成本价设置成功！');window.location.href='MaterialPriceList.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('成本价设置失败！');window.location.href='MaterialPriceList.aspx';", true);
            }
        }
    }
}