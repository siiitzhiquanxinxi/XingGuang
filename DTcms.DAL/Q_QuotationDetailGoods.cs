using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Q_QuotationDetailGoods
    /// </summary>
    public partial class Q_QuotationDetailGoods
    {
        public Q_QuotationDetailGoods()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Q_QuotationDetailGoods)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Q_QuotationDetailGoods");
            strSql.Append(" where Q_QuotationDetailGoods=@Q_QuotationDetailGoods");
            SqlParameter[] parameters = {
                    new SqlParameter("@Q_QuotationDetailGoods", SqlDbType.Int,4)
            };
            parameters[0].Value = Q_QuotationDetailGoods;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Q_QuotationDetailGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Q_QuotationDetailGoods(");
            strSql.Append("FK_QuotationDetailTypeId,FK_materialID,DetailOrder,GoodsQuantity,Brand,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,Photo)");
            strSql.Append(" values (");
            strSql.Append("@FK_QuotationDetailTypeId,@FK_materialID,@DetailOrder,@GoodsQuantity,@Brand,@BrandImg,@Mode,@Name,@Description,@Unit,@UnitPrice,@CostPrice,@LaborCost,@InstallationFee,@CommissioningFee,@ManagementFee,@IndoorInstallationFee,@IndoorLaborCost,@Photo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@FK_QuotationDetailTypeId", SqlDbType.Int,4),
                    new SqlParameter("@FK_materialID", SqlDbType.Int,4),
                    new SqlParameter("@DetailOrder", SqlDbType.Int,4),
                    new SqlParameter("@GoodsQuantity", SqlDbType.Decimal,9),
                    new SqlParameter("@Brand", SqlDbType.NVarChar,50),
                    new SqlParameter("@BrandImg", SqlDbType.NVarChar,50),
                    new SqlParameter("@Mode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Description", SqlDbType.NVarChar,200),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,50),
                    new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@LaborCost", SqlDbType.Decimal,9),
                    new SqlParameter("@InstallationFee", SqlDbType.Decimal,9),
                    new SqlParameter("@CommissioningFee", SqlDbType.Decimal,9),
                    new SqlParameter("@ManagementFee", SqlDbType.Decimal,9),
                    new SqlParameter("@IndoorInstallationFee", SqlDbType.Decimal,9),
                    new SqlParameter("@IndoorLaborCost", SqlDbType.Decimal,9),
                    new SqlParameter("@Photo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.FK_QuotationDetailTypeId;
            parameters[1].Value = model.FK_materialID;
            parameters[2].Value = model.DetailOrder;
            parameters[3].Value = model.GoodsQuantity;
            parameters[4].Value = model.Brand;
            parameters[5].Value = model.BrandImg;
            parameters[6].Value = model.Mode;
            parameters[7].Value = model.Name;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Unit;
            parameters[10].Value = model.UnitPrice;
            parameters[11].Value = model.CostPrice;
            parameters[12].Value = model.LaborCost;
            parameters[13].Value = model.InstallationFee;
            parameters[14].Value = model.CommissioningFee;
            parameters[15].Value = model.ManagementFee;
            parameters[16].Value = model.IndoorInstallationFee;
            parameters[17].Value = model.IndoorLaborCost;
            parameters[18].Value = model.Photo;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Q_QuotationDetailGoods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Q_QuotationDetailGoods set ");
            strSql.Append("FK_QuotationDetailTypeId=@FK_QuotationDetailTypeId,");
            strSql.Append("FK_materialID=@FK_materialID,");
            strSql.Append("DetailOrder=@DetailOrder,");
            strSql.Append("GoodsQuantity=@GoodsQuantity,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("BrandImg=@BrandImg,");
            strSql.Append("Mode=@Mode,");
            strSql.Append("Name=@Name,");
            strSql.Append("Description=@Description,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("UnitPrice=@UnitPrice,");
            strSql.Append("CostPrice=@CostPrice,");
            strSql.Append("LaborCost=@LaborCost,");
            strSql.Append("InstallationFee=@InstallationFee,");
            strSql.Append("CommissioningFee=@CommissioningFee,");
            strSql.Append("ManagementFee=@ManagementFee,");
            strSql.Append("IndoorInstallationFee=@IndoorInstallationFee,");
            strSql.Append("IndoorLaborCost=@IndoorLaborCost,");
            strSql.Append("Photo=@Photo");
            strSql.Append(" where Q_QuotationDetailGoods=@Q_QuotationDetailGoods");
            SqlParameter[] parameters = {
                    new SqlParameter("@FK_QuotationDetailTypeId", SqlDbType.Int,4),
                    new SqlParameter("@FK_materialID", SqlDbType.Int,4),
                    new SqlParameter("@DetailOrder", SqlDbType.Int,4),
                    new SqlParameter("@GoodsQuantity", SqlDbType.Decimal,9),
                    new SqlParameter("@Brand", SqlDbType.NVarChar,50),
                    new SqlParameter("@BrandImg", SqlDbType.NVarChar,50),
                    new SqlParameter("@Mode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Description", SqlDbType.NVarChar,200),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,50),
                    new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@LaborCost", SqlDbType.Decimal,9),
                    new SqlParameter("@InstallationFee", SqlDbType.Decimal,9),
                    new SqlParameter("@CommissioningFee", SqlDbType.Decimal,9),
                    new SqlParameter("@ManagementFee", SqlDbType.Decimal,9),
                    new SqlParameter("@IndoorInstallationFee", SqlDbType.Decimal,9),
                    new SqlParameter("@IndoorLaborCost", SqlDbType.Decimal,9),
                    new SqlParameter("@Photo", SqlDbType.NVarChar,50),
                    new SqlParameter("@Q_QuotationDetailGoods", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_QuotationDetailTypeId;
            parameters[1].Value = model.FK_materialID;
            parameters[2].Value = model.DetailOrder;
            parameters[3].Value = model.GoodsQuantity;
            parameters[4].Value = model.Brand;
            parameters[5].Value = model.BrandImg;
            parameters[6].Value = model.Mode;
            parameters[7].Value = model.Name;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Unit;
            parameters[10].Value = model.UnitPrice;
            parameters[11].Value = model.CostPrice;
            parameters[12].Value = model.LaborCost;
            parameters[13].Value = model.InstallationFee;
            parameters[14].Value = model.CommissioningFee;
            parameters[15].Value = model.ManagementFee;
            parameters[16].Value = model.IndoorInstallationFee;
            parameters[17].Value = model.IndoorLaborCost;
            parameters[18].Value = model.Photo;
            parameters[19].Value = model.Q_QuotationDetailGoodsID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Q_QuotationDetailGoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationDetailGoods ");
            strSql.Append(" where Q_QuotationDetailGoodsID=@Q_QuotationDetailGoodsID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Q_QuotationDetailGoodsID", SqlDbType.Int,4)
            };
            parameters[0].Value = Q_QuotationDetailGoodsID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Q_QuotationDetailGoodslist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationDetailGoods ");
            strSql.Append(" where Q_QuotationDetailGoodsID in (" + Q_QuotationDetailGoodslist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Q_QuotationDetailGoods GetModel(int Q_QuotationDetailGoodsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Q_QuotationDetailGoodsID,FK_QuotationDetailTypeId,FK_materialID,DetailOrder,GoodsQuantity,Brand,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,Photo from Q_QuotationDetailGoods ");
            strSql.Append(" where Q_QuotationDetailGoodsID=@Q_QuotationDetailGoodsID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Q_QuotationDetailGoodsID", SqlDbType.Int,4)
            };
            parameters[0].Value = Q_QuotationDetailGoodsID;

            DTcms.Model.Q_QuotationDetailGoods model = new DTcms.Model.Q_QuotationDetailGoods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Q_QuotationDetailGoods DataRowToModel(DataRow row)
        {
            DTcms.Model.Q_QuotationDetailGoods model = new DTcms.Model.Q_QuotationDetailGoods();
            if (row != null)
            {
                if (row["Q_QuotationDetailGoodsID"] != null && row["Q_QuotationDetailGoodsID"].ToString() != "")
                {
                    model.Q_QuotationDetailGoodsID = int.Parse(row["Q_QuotationDetailGoodsID"].ToString());
                }
                if (row["FK_QuotationDetailTypeId"] != null && row["FK_QuotationDetailTypeId"].ToString() != "")
                {
                    model.FK_QuotationDetailTypeId = int.Parse(row["FK_QuotationDetailTypeId"].ToString());
                }
                if (row["FK_materialID"] != null && row["FK_materialID"].ToString() != "")
                {
                    model.FK_materialID = int.Parse(row["FK_materialID"].ToString());
                }
                if (row["DetailOrder"] != null && row["DetailOrder"].ToString() != "")
                {
                    model.DetailOrder = int.Parse(row["DetailOrder"].ToString());
                }
                if (row["GoodsQuantity"] != null && row["GoodsQuantity"].ToString() != "")
                {
                    model.GoodsQuantity = decimal.Parse(row["GoodsQuantity"].ToString());
                }
                if (row["Brand"] != null)
                {
                    model.Brand = row["Brand"].ToString();
                }
                if (row["BrandImg"] != null)
                {
                    model.BrandImg = row["BrandImg"].ToString();
                }
                if (row["Mode"] != null)
                {
                    model.Mode = row["Mode"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["UnitPrice"] != null && row["UnitPrice"].ToString() != "")
                {
                    model.UnitPrice = decimal.Parse(row["UnitPrice"].ToString());
                }
                if (row["CostPrice"] != null && row["CostPrice"].ToString() != "")
                {
                    model.CostPrice = decimal.Parse(row["CostPrice"].ToString());
                }
                if (row["LaborCost"] != null && row["LaborCost"].ToString() != "")
                {
                    model.LaborCost = decimal.Parse(row["LaborCost"].ToString());
                }
                if (row["InstallationFee"] != null && row["InstallationFee"].ToString() != "")
                {
                    model.InstallationFee = decimal.Parse(row["InstallationFee"].ToString());
                }
                if (row["CommissioningFee"] != null && row["CommissioningFee"].ToString() != "")
                {
                    model.CommissioningFee = decimal.Parse(row["CommissioningFee"].ToString());
                }
                if (row["ManagementFee"] != null && row["ManagementFee"].ToString() != "")
                {
                    model.ManagementFee = decimal.Parse(row["ManagementFee"].ToString());
                }
                if (row["IndoorInstallationFee"] != null && row["IndoorInstallationFee"].ToString() != "")
                {
                    model.IndoorInstallationFee = decimal.Parse(row["IndoorInstallationFee"].ToString());
                }
                if (row["IndoorLaborCost"] != null && row["IndoorLaborCost"].ToString() != "")
                {
                    model.IndoorLaborCost = decimal.Parse(row["IndoorLaborCost"].ToString());
                }
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Q_QuotationDetailGoodsID,FK_QuotationDetailTypeId,FK_materialID,DetailOrder,GoodsQuantity,Brand,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,Photo ");
            strSql.Append(" FROM Q_QuotationDetailGoods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Q_QuotationDetailGoodsID,FK_QuotationDetailTypeId,FK_materialID,DetailOrder,GoodsQuantity,Brand,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,Photo ");
            strSql.Append(" FROM Q_QuotationDetailGoods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Q_QuotationDetailGoods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Q_QuotationDetailGoodsID desc");
            }
            strSql.Append(")AS Row, T.*  from Q_QuotationDetailGoods T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Q_QuotationDetailGoodsID";
			parameters[1].Value = "Q_QuotationDetailGoodsID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
