using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;
using System.Data.OleDb;
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
        /// <summary>
        /// 获取Excel数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private DataSet GetExcelData(string strFilePath)
        {
            try
            {
                //获取连接字符串
                // @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;HDR=YES;";
                string strConn = GetOleDbConnectionString(strFilePath);

                DataSet ds = new DataSet();
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    //打开连接
                    conn.Open();
                    System.Data.DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    // 取得Excel工作簿中所有工作表  
                    System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    OleDbDataAdapter sqlada = new OleDbDataAdapter();

                    foreach (DataRow dr in schemaTable.Rows)
                    {
                        try
                        {
                            string strSql = "Select * From [" + dr[2].ToString().Trim() + "]";
                            if (strSql.Contains("$"))
                            {
                                OleDbCommand objCmd = new OleDbCommand(strSql, conn);
                                sqlada.SelectCommand = objCmd;
                                sqlada.Fill(ds, dr[2].ToString().Trim());
                            }
                        }
                        catch { }
                    }
                    //关闭连接
                    conn.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "err", "alert('" + ex.Message + "');", false);
                return null;
            }
        }
        /// <summary>
        /// 唯一需要注意的是，如果目标机器的操作系统，是64位的话。
        /// 项目需要 编译为 x86，而不是简单的使用默认的 Any CPU.
        /// </summary>
        /// <param name="strExcelFileName"></param>
        /// <returns></returns>
        private string GetOleDbConnectionString(string strExcelFileName)
        {
            // Office 2007 以及 以下版本使用.
            string strJETConnString =
              String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", strExcelFileName);
            // xlsx 扩展名 使用.
            string strASEConnXlsxString =
              String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"", strExcelFileName);
            // xls 扩展名 使用.
            string strACEConnXlsString =
              String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\"", strExcelFileName);
            //其他
            string strOtherConnXlsString =
              String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", strExcelFileName);

            //尝试使用 ACE. 假如不发生错误的话，使用 ACE 驱动.
            try
            {
                System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection(strACEConnXlsString);
                cn.Open();
                cn.Close();
                // 使用 ACE
                return strACEConnXlsString;
            }
            catch (Exception)
            {
                // 启动 ACE 失败.
            }

            // 尝试使用 Jet. 假如不发生错误的话，使用 Jet 驱动.
            try
            {
                System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection(strJETConnString);
                cn.Open();
                cn.Close();
                // 使用 Jet
                return strJETConnString;
            }
            catch (Exception)
            {
                // 启动 Jet 失败.
            }

            // 尝试使用 Jet. 假如不发生错误的话，使用 Jet 驱动.
            try
            {
                System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection(strASEConnXlsxString);
                cn.Open();
                cn.Close();
                // 使用 Jet
                return strASEConnXlsxString;
            }
            catch (Exception)
            {
                // 启动 Jet 失败.
            }
            // 假如 ACE 与 JET 都失败了，默认使用 JET.
            return strOtherConnXlsString;
        }
        Sy_Material MaterialBll = new Sy_Material();
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //文件名
                string strFileName = fulImport.FileName;

                //验证是否选择了文件
                if ("" == strFileName.Trim())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('请选择文件！');", true);
                    return;
                }

                //验证文件类型是不是Excel
                if (strFileName.Substring(strFileName.LastIndexOf('.')) != ".xlsx" && strFileName.Substring(strFileName.LastIndexOf('.')) != ".xls")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('文件类型错误！'", true);
                    return;
                }

                //获取上载文件内容

                //string strFilePath = ConfigurationManager.AppSettings["tempFilePath"].ToString();
                string strPath = "../../upload/";
                string strFilePath = Server.MapPath(strPath);
                string fileName = DateTime.Now.ToString("yyyyMMddHHssmm");
                strFilePath += fileName;
                fulImport.SaveAs(strFilePath);
                DataSet ds = GetExcelData(strFilePath);

                //判断文件内容是否为空
                if (ds == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('这个文件没有数据！');", true);
                    return;
                }

                int i_count = 0;//计算行数
                //IdioSoft.Common.Method.DbSQLAccess objDbSQLAccess = new IdioSoft.Common.Method.DbSQLAccess(SqlCon);
                //导入到数据库
                try
                {
                    int result = 0;
                    foreach (DataTable dt in ds.Tables)
                    {
                        try
                        {
                            string strRow = dt.Rows[0]["品牌"].ToString();//判断行是否存在
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        //行数存在,累加行数
                        i_count++;
                        string str1 = "", str2="", str3 = "", str4 = "", str5 = "", str6 = "", str7 = "",str8 = "", str9 = "", str10 = "", str11 = "", str12 = "", str13 = "", str14 = "", str15 = "", str16 = "", str17 = "", str18 = "";
                      
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            str1 = dt.Rows[i]["品牌"].ToString();
                            str2 = dt.Rows[i]["品牌logo"].ToString();
                            str3 = dt.Rows[i]["型号"].ToString();
                            str4 = dt.Rows[i]["品名"].ToString();
                            str5 = dt.Rows[i]["产品描述"].ToString();
                            str6 = dt.Rows[i]["单位"].ToString();
                            str7 = dt.Rows[i]["单价"].ToString();
                            str8 = dt.Rows[i]["成本价"].ToString();
                            str9 = dt.Rows[i]["弱电布线费"].ToString();
                            str10 = dt.Rows[i]["器材安装费"].ToString();
                            str11 = dt.Rows[i]["系统调试费"].ToString();
                            str12 = dt.Rows[i]["项目管理费"].ToString();
                            str13 = dt.Rows[i]["内部安装费用"].ToString();
                            str14 = dt.Rows[i]["内部布线费用"].ToString();
                            str15 = dt.Rows[i]["产品图片"].ToString();
                            str16 = dt.Rows[i]["金蝶物料编号"].ToString();
                            str17 = dt.Rows[i]["金蝶物料名称"].ToString();
                            str18 = dt.Rows[i]["标注"].ToString();
                            //判断行数据是否完整并给出提示
                            if (str1 == "" || str3 == "" || str4 == "" || str5 == "" || str6 == "" )
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
                                material.BrandImg = str2;
                                material.Mode = str3;
                                material.Name = str4;
                                material.Description = str5;
                                material.Unit = str6;
                                if (str7 == "")
                                    material.UnitPrice = 0;
                                else
                                    material.UnitPrice = Convert.ToDecimal(str7);
                                if (str8 == "")
                                    material.CostPrice = 0;
                                else
                                    material.CostPrice = Convert.ToDecimal(str8);
                                if (str9 == "")
                                    material.LaborCost = 0;
                                else
                                    material.LaborCost = Convert.ToDecimal(str9);
                                if (str10 == "")
                                    material.InstallationFee = 0;
                                else
                                    material.InstallationFee = Convert.ToDecimal(str10);
                                if (str11 == "")
                                    material.CommissioningFee = 0;
                                else
                                    material.CommissioningFee = Convert.ToDecimal(str11);
                                if (str12 == "")
                                    material.ManagementFee = 0;
                                else
                                    material.ManagementFee = Convert.ToDecimal(str12);
                                if (str13 == "")
                                    material.IndoorInstallationFee = 0;
                                else
                                    material.IndoorInstallationFee = Convert.ToDecimal(str13);
                                if (str14 == "")
                                    material.IndoorLaborCost =0;
                                else
                                    material.IndoorLaborCost = Convert.ToDecimal(str14);
                                material.Photo = str15;
                                material.MaterialID = str16;
                                material.MaterialName = str17;
                                material.Tag = str18;
                                material.State = 0;
                                result = MaterialBll.Add(material);
                            }
                        }
                    }
                    if (result > 0 )
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('导入成功。');", true);
                    }
                    else if (i_count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('EXEC中的列名不符合规则。');", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('Fail:" + ex.Message + "');", true);
                }
            }
            catch (Exception exp)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "JsError", "alert('Fail:" + exp.Message + "');", true);
            }
        }
    }
}