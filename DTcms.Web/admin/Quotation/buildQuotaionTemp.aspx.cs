using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.Quotation
{
    public partial class buildQuotaionTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.manager mo = Session["dt_session_admin_info"] as Model.manager;
                if (mo != null)
                {
                    txtSalePeople.Text = mo.real_name;
                    txtCustomerNum.Text = GetSpellCode(mo.real_name) + DateTime.Now.ToString("yyyyMMdd") + GetCustomerNum();
                }
            }
        }

        private string GetCustomerNum()
        {
            string sql = "select CustomerId from C_CustomerProgram where 1=1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null)
            {
                int count = dt.Rows.Count + 1;
                if (count <= 9)
                {
                    return "000" + count;
                }
                else if (count <= 99)
                {
                    return "00" + count;
                }
                else if (count <= 999)
                {
                    return "0" + count;
                }
                else
                {
                    return count.ToString();
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 在指定的字符串列表CnStr中检索符合拼音索引字符串
        /// </summary>
        /// <param name="CnStr">汉字字符串</param>
        /// <returns>相对应的汉语拼音首字母串</returns>
        public static string GetSpellCode(string CnStr)
        {
            string strTemp = "";
            int iLen = CnStr.Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
            }
            return strTemp;

        }
        /// <summary>
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
        /// </summary>
        /// <param name="CnChar">单个汉字</param>
        /// <returns>单个大写字母</returns>
        private static string GetCharSpellCode(string CnChar)
        {

            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回

            if (ZW.Length == 1)
            {

                return CnChar.ToUpper();

            }

            else
            {

                // get the array of byte from the single char

                int i1 = (short)(ZW[0]);

                int i2 = (short)(ZW[1]);

                iCnChar = i1 * 256 + i2;

            }

            // iCnChar match the constant

            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {

                return "A";

            }

            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {

                return "B";

            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {

                return "C";

            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {

                return "D";

            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {

                return "E";

            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {

                return "F";

            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {

                return "G";

            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {

                return "H";

            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {

                return "J";

            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {

                return "K";

            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {

                return "L";

            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {

                return "M";

            }
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {

                return "N";

            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {

                return "O";

            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {

                return "P";

            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {

                return "Q";

            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {

                return "R";

            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {

                return "S";

            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {

                return "T";

            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {

                return "W";

            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {

                return "X";

            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {

                return "Y";

            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {

                return "Z";

            }
            else

                return ("?");

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (checkTxt())
            {
                if (rptList1.Items.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('至少选择一个模板！')", true);
                    return;
                }
                Model.C_CustomerProgram cmodel = new Model.C_CustomerProgram();
                cmodel.CustomerName = txtCustomerName.Text;
                cmodel.CustomerTel = txtCustomerTel.Text;
                cmodel.CustomerAddress = txtCustomerAddress.Text;
                cmodel.ProgramAreaNum = txtProgramAreaNum.Text;
                cmodel.CreateDate = DateTime.Now;
                Model.manager mo = Session["dt_session_admin_info"] as Model.manager;
                cmodel.CreateBy = mo != null ? mo.id : -1;
                cmodel.CustomerNum = mo != null ? (GetSpellCode(mo.real_name) + DateTime.Now.ToString("yyyyMMdd") + GetCustomerNum()) : DateTime.Now.ToString("yyyyMMdd") + GetCustomerNum();
                cmodel.SalePeople = txtSalePeople.Text;
                cmodel.BussinessPeople = txtBussinessPeople.Text;
                cmodel.CustomerSource = txtCustomerSource.Text;
                cmodel.CustomerState = 0;
                int cid = new BLL.C_CustomerProgram().Add(cmodel);

                string tempidArr = "";
                for (int i = 0; i < rptList1.Items.Count; i++)
                {
                    HiddenField hfdQuotationTemplateId = rptList1.Items[i].FindControl("hfdQuotationTemplateId") as HiddenField;
                    tempidArr += (hfdQuotationTemplateId.Value + "|");
                }
                Response.Redirect("QuotaionDetailEdit.aspx?action=add&cid=" + cid.ToString() + "&tid=" + tempidArr);
            }

        }

        DataTable dttemp = new DataTable();
        private void InitializationDtgoods()
        {
            dttemp.Columns.Add("QuotationTemplateId", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateType", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateName", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateMainBrand", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateDescription", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateScenario", Type.GetType("System.String"));
            dttemp.Columns.Add("QuotationTemplateNotes", Type.GetType("System.String"));
        }
        private void BindData()
        {
            InitializationDtgoods();
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                HiddenField hfdIsDel = rptList1.Items[i].FindControl("hfdIsDel") as HiddenField;
                if (hfdIsDel.Value == "1")//删除
                {
                    continue;
                }
                HiddenField hfdQuotationTemplateId = rptList1.Items[i].FindControl("hfdQuotationTemplateId") as HiddenField;
                Label lblQuotationTemplateType = rptList1.Items[i].FindControl("lblQuotationTemplateType") as Label;
                Label lblQuotationTemplateName = rptList1.Items[i].FindControl("lblQuotationTemplateName") as Label;
                Label lblQuotationTemplateMainBrand = rptList1.Items[i].FindControl("lblQuotationTemplateMainBrand") as Label;
                Label lblQuotationTemplateDescription = rptList1.Items[i].FindControl("lblQuotationTemplateDescription") as Label;
                Label lblQuotationTemplateScenario = rptList1.Items[i].FindControl("lblQuotationTemplateScenario") as Label;
                Label lblQuotationTemplateNotes = rptList1.Items[i].FindControl("lblQuotationTemplateNotes") as Label;
                dttemp.Rows.Add(new object[] { hfdQuotationTemplateId.Value, lblQuotationTemplateType.Text, lblQuotationTemplateName.Text, lblQuotationTemplateMainBrand.Text, lblQuotationTemplateDescription.Text, lblQuotationTemplateScenario.Text, lblQuotationTemplateNotes.Text });
            }
            if (hfdTempId.Value != "")//添加新一行
            {
                string sql = "select * from Q_QuotationTemplate where QuotationTemplateId = " + hfdTempId.Value;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                dttemp.Rows.Add(new object[] { dt.Rows[0]["QuotationTemplateId"], dt.Rows[0]["QuotationTemplateType"], dt.Rows[0]["QuotationTemplateName"], dt.Rows[0]["QuotationTemplateMainBrand"], dt.Rows[0]["QuotationTemplateDescription"], dt.Rows[0]["QuotationTemplateScenario"], dt.Rows[0]["QuotationTemplateNotes"] });
                hfdTempId.Value = "";
            }
            rptList1.DataSource = dttemp;
            rptList1.DataBind();
            for (int i = 0; i < rptList1.Items.Count; i++)
            {
                Label lblTotal = rptList1.Items[i].FindControl("lblTotal") as Label;
                HiddenField hfdId = rptList1.Items[i].FindControl("hfdQuotationTemplateId") as HiddenField;

                string s = "select SUM(TemplateDetailQuantity*UnitPrice) from Q_QuotationTemplateDetail inner join Sy_Material on Sy_Material.ID = Q_QuotationTemplateDetail.FK_materialID where TemplateParentID =" + hfdId.Value;
                decimal goodsTotal = 0;
                DataTable d = DbHelperSQL.Query(s).Tables[0];
                if (d != null && d.Rows.Count > 0 && d.Rows[0][0].ToString() != "")
                {
                    goodsTotal = Convert.ToDecimal(d.Rows[0][0].ToString());
                }
                decimal lineTotal = 0;
                s = "select LineTotalamount from Q_QuotationTemplateLine where FK_TemplateId = " + hfdId.Value;
                d = DbHelperSQL.Query(s).Tables[0];
                if (d != null && d.Rows.Count > 0 && d.Rows[0][0].ToString() != "")
                {
                    lineTotal = Convert.ToDecimal(d.Rows[0][0].ToString());
                }
                Model.Q_QuotationTemplate model = new BLL.Q_QuotationTemplate().GetModel(int.Parse(hfdId.Value));
                decimal QicaianzhuangFee = goodsTotal * Convert.ToDecimal(model.QicaianzhuangFee);
                decimal XitongtiaoshiFee = goodsTotal * Convert.ToDecimal(model.XitongtiaoshiFee);
                decimal XiangmuguanliFee = goodsTotal * Convert.ToDecimal(model.XiangmuguanliFee);
                decimal total = goodsTotal + lineTotal + QicaianzhuangFee + XitongtiaoshiFee + XiangmuguanliFee;
                lblTotal.Text = Math.Round(total, 0).ToString();
            }
        }

        protected void btnBind_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            LinkButton lbtnDel = sender as LinkButton;
            HiddenField hfdIsDel = lbtnDel.Parent.FindControl("hfdIsDel") as HiddenField;
            hfdIsDel.Value = "1";
            BindData();
        }

        private bool checkTxt()
        {
            if (txtCustomerNum.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('客户编号不能为空！');", true);
                return false;
            }
            if (txtCustomerName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('客户名称不能为空！');", true);
                return false;
            }
            if (txtSalePeople.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('销售不能为空！');", true);
                return false;
            }
            if (txtBussinessPeople.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('业务员不能为空！');", true);
                return false;
            }
            return true;
        }
    }
}