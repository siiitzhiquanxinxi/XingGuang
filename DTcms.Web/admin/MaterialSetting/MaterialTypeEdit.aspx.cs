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
    public partial class MaterialTypeEdit : DTcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型

        Sy_MaterialType Bll = new Sy_MaterialType();
        protected void Page_Load(object sender, EventArgs e)
        {

            string _action = DTRequest.GetQueryString("action");
            int ID = 0;
            if (!string.IsNullOrEmpty(_action) && _action != DTEnums.ActionEnum.Add.ToString())
            {

                this.action = _action;//修改操作类型
                ID = Convert.ToInt32(Request.QueryString["ID"] as string);
                if (!Bll.Exists(ID))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }

            }
            if (!IsPostBack)
            {
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(ID);
                }
                else if (action == DTEnums.ActionEnum.Add.ToString())//新增
                {
                    //txtCheckDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    ShowInfo(ID);
                    this.btnSubmit.Enabled = false;
                }

            }
        }
        private void ShowInfo(int id)
        {
            DTcms.Model.Sy_MaterialType order = Bll.GetModel(id);
            hidId.Value = order.ID.ToString();
            txtMaterialType.Text = order.MaterialType;

        }
        private bool IsCheck()
        {
            if (action == DTEnums.ActionEnum.Add.ToString())
            {
                if (Bll.GetList("MaterialType='" + txtMaterialType.Text.Trim() + "'").Tables[0].Rows.Count > 0)
                {
                    JscriptMsg("产品分类已存在", "back", "Error");
                    return false;
                }
            }
            if (txtMaterialType.Text.Trim() == "")
            {
                JscriptMsg("分类不能为空", "back", "Error");
                return false;
            }

            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.Sy_MaterialType model = new DTcms.Model.Sy_MaterialType();
            model.MaterialType = txtMaterialType.Text.Trim();


            if (action == DTEnums.ActionEnum.Add.ToString())
            {  //新增

                Bll.Add(model);
                MessageBox.Show(this, "添加成功！");
            }
            else
            {   //修改
                string oldType = new BLL.Sy_MaterialType().GetModel(Convert.ToInt32(hidId.Value)).MaterialType;
                model.ID = Convert.ToInt32(hidId.Value);
                Bll.Update(model);
                string sql = "update Sy_Material set MaterialType = '" + txtMaterialType.Text.Trim() + "' where MaterialType = '" + oldType + "'";
                DbHelperSQL.ExecuteSql(sql);
                MessageBox.Show(this, "修改成功！");
            }
        }
    }
}