using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.Quotation
{
    public partial class buildQuotaionBlank1 : System.Web.UI.Page
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
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (checkTxt())
            {
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
                Response.Redirect("QuotaionDetailEdit.aspx?action=add&cid=" + cid.ToString());
            }
        }
    }
}