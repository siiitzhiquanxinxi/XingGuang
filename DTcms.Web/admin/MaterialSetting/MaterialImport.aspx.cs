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
    public partial class MaterialImport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

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

        Sy_Material MaterialBll = new Sy_Material();
        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            if (fulImport.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(fulImport.FileName);//获取文件名的后缀
                if (fileExt.ToLower() == ".xls" || fileExt.ToLower() == ".xlsx")//判断文件后缀名是否是xls
                {
                    string path = Server.MapPath("../../upload/" + DateTime.Now.ToString("yyyyMMddHHmms"));
                    Aspose.Cells.Workbook s = new Aspose.Cells.Workbook();
                    fulImport.SaveAs(path);
                    s.Open(path);
                    Aspose.Cells.Worksheet ws = s.Worksheets[0];
                    DataTable dt = new DataTable();
                    dt = ws.Cells.ExportDataTable(1, 0, ws.Cells.Rows.Count - 1, 21);
                    System.IO.File.Delete(path);

                    string str1 = "", str2 = "", str3 = "", str4 = "", str5 = "", str6 = "", str7 = "", str8 = "", str9 = "", str10 = "", str11 = "", str12 = "", str13 = "", str14 = "", str15 = "", str16 = "", str17 = "", str18 = "", str19 = "", str20 = "", str21 = "";

                    int result = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str1 = dt.Rows[i][0].ToString();
                        str2 = dt.Rows[i][1].ToString();
                        str3 = dt.Rows[i][2].ToString();
                        str4 = dt.Rows[i][3].ToString();
                        str5 = dt.Rows[i][4].ToString();
                        str6 = dt.Rows[i][5].ToString();
                        str7 = dt.Rows[i][6].ToString();
                        str8 = dt.Rows[i][7].ToString();
                        str9 = dt.Rows[i][8].ToString();
                        str10 = dt.Rows[i][9].ToString();
                        str11 = dt.Rows[i][10].ToString();
                        str12 = dt.Rows[i][11].ToString();
                        str13 = dt.Rows[i][12].ToString();
                        str14 = dt.Rows[i][13].ToString();
                        str15 = dt.Rows[i][14].ToString();
                        str16 = dt.Rows[i][15].ToString();
                        str17 = dt.Rows[i][16].ToString();
                        str18 = dt.Rows[i][17].ToString();
                        str19 = dt.Rows[i][18].ToString();
                        str20 = dt.Rows[i][19].ToString();
                        str21 = dt.Rows[i][20].ToString();
                        //判断行数据是否完整并给出提示
                        if (str1 == "" || str4 == "" || str5 == "" || str6 == "" || str7 == "")
                        {
                            int m = i + 1;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('第" + m + "行数据不完整！')", true);
                            return;
                        }
                        else//数据完整则插入数据库
                        {
                            DTcms.Model.Sy_Material material = new DTcms.Model.Sy_Material();
                            material.MaterialTypeID = Convert.ToInt32(ddlMaterialType.SelectedValue);
                            material.MaterialType = ddlMaterialType.SelectedItem.Text;
                            material.Brand = str1;
                            material.BrandEnglish = str2;
                            material.BrandImg = "/upload/" + str3;
                            material.Mode = str4;
                            material.Name = str5;
                            material.Description = str6;
                            material.Unit = str7;
                            if (str8 == "")
                                material.UnitPrice = 0;
                            else
                                material.UnitPrice = Convert.ToDecimal(str8);
                            if (str9 == "")
                                material.CostPrice = 0;
                            else
                                material.CostPrice = Convert.ToDecimal(str9);
                            if (str11 == "")
                                material.LaborCost = 0;
                            else
                                material.LaborCost = Convert.ToDecimal(str11);
                            if (str12 == "")
                                material.InstallationFee = 0;
                            else
                                material.InstallationFee = Convert.ToDecimal(str12);
                            if (str13 == "")
                                material.CommissioningFee = 0;
                            else
                                material.CommissioningFee = Convert.ToDecimal(str13);
                            if (str14 == "")
                                material.ManagementFee = 0;
                            else
                                material.ManagementFee = Convert.ToDecimal(str14);

                            if (str15 == "")
                                material.VideoDebugFee = 0;
                            else
                                material.VideoDebugFee = Convert.ToDecimal(str15);
                            if (str16 == "")
                                material.AudioDebugFee = 0;
                            else
                                material.AudioDebugFee = Convert.ToDecimal(str16);

                            if (str17 == "")
                                material.IndoorInstallationFee = 0;
                            else
                                material.IndoorInstallationFee = Convert.ToDecimal(str17);
                            if (str18 == "")
                                material.IndoorLaborCost = 0;
                            else
                                material.IndoorLaborCost = Convert.ToDecimal(str18);
                            material.Photo = "/upload/" + str10;
                            material.MaterialID = str19;
                            material.MaterialName = str20;
                            material.Tag = str21;
                            material.State = 0;
                            result = MaterialBll.Add(material);
                        }
                    }

                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('导入成功。');", true);
                    }
                }
            }
        }
    }
}