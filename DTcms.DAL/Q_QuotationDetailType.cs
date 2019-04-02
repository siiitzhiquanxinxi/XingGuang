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
    /// 数据访问类:Q_QuotationDetailType
    /// </summary>
    public partial class Q_QuotationDetailType
    {
        public Q_QuotationDetailType()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int QuotationDetailTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Q_QuotationDetailType");
            strSql.Append(" where QuotationDetailTypeId=@QuotationDetailTypeId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationDetailTypeId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationDetailTypeId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Q_QuotationDetailType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Q_QuotationDetailType(");
            strSql.Append("FK_ParentQuotationListId,FK_MaterialTypeId,MaterialTypeName,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee)");
            strSql.Append(" values (");
            strSql.Append("@FK_ParentQuotationListId,@FK_MaterialTypeId,@MaterialTypeName,@RuodiananzhuangFee,@QicaianzhuangFee,@XitongtiaoshiFee,@XiangmuguanliFee)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@FK_ParentQuotationListId", SqlDbType.Int,4),
                    new SqlParameter("@FK_MaterialTypeId", SqlDbType.Int,4),
                    new SqlParameter("@MaterialTypeName", SqlDbType.NVarChar,50),
                    new SqlParameter("@RuodiananzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QicaianzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XitongtiaoshiFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XiangmuguanliFee", SqlDbType.Decimal,9)};
            parameters[0].Value = model.FK_ParentQuotationListId;
            parameters[1].Value = model.FK_MaterialTypeId;
            parameters[2].Value = model.MaterialTypeName;
            parameters[3].Value = model.RuodiananzhuangFee;
            parameters[4].Value = model.QicaianzhuangFee;
            parameters[5].Value = model.XitongtiaoshiFee;
            parameters[6].Value = model.XiangmuguanliFee;

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
        public bool Update(DTcms.Model.Q_QuotationDetailType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Q_QuotationDetailType set ");
            strSql.Append("FK_ParentQuotationListId=@FK_ParentQuotationListId,");
            strSql.Append("FK_MaterialTypeId=@FK_MaterialTypeId,");
            strSql.Append("MaterialTypeName=@MaterialTypeName,");
            strSql.Append("RuodiananzhuangFee=@RuodiananzhuangFee,");
            strSql.Append("QicaianzhuangFee=@QicaianzhuangFee,");
            strSql.Append("XitongtiaoshiFee=@XitongtiaoshiFee,");
            strSql.Append("XiangmuguanliFee=@XiangmuguanliFee");
            strSql.Append(" where QuotationDetailTypeId=@QuotationDetailTypeId");
            SqlParameter[] parameters = {
                    new SqlParameter("@FK_ParentQuotationListId", SqlDbType.Int,4),
                    new SqlParameter("@FK_MaterialTypeId", SqlDbType.Int,4),
                    new SqlParameter("@MaterialTypeName", SqlDbType.NVarChar,50),
                    new SqlParameter("@RuodiananzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QicaianzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XitongtiaoshiFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XiangmuguanliFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QuotationDetailTypeId", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_ParentQuotationListId;
            parameters[1].Value = model.FK_MaterialTypeId;
            parameters[2].Value = model.MaterialTypeName;
            parameters[3].Value = model.RuodiananzhuangFee;
            parameters[4].Value = model.QicaianzhuangFee;
            parameters[5].Value = model.XitongtiaoshiFee;
            parameters[6].Value = model.XiangmuguanliFee;
            parameters[7].Value = model.QuotationDetailTypeId;

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
        public bool Delete(int QuotationDetailTypeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationDetailType ");
            strSql.Append(" where QuotationDetailTypeId=@QuotationDetailTypeId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationDetailTypeId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationDetailTypeId;

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
        public bool DeleteList(string QuotationDetailTypeIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationDetailType ");
            strSql.Append(" where QuotationDetailTypeId in (" + QuotationDetailTypeIdlist + ")  ");
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
        public DTcms.Model.Q_QuotationDetailType GetModel(int QuotationDetailTypeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QuotationDetailTypeId,FK_ParentQuotationListId,FK_MaterialTypeId,MaterialTypeName,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee from Q_QuotationDetailType ");
            strSql.Append(" where QuotationDetailTypeId=@QuotationDetailTypeId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationDetailTypeId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationDetailTypeId;

            DTcms.Model.Q_QuotationDetailType model = new DTcms.Model.Q_QuotationDetailType();
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
        public DTcms.Model.Q_QuotationDetailType DataRowToModel(DataRow row)
        {
            DTcms.Model.Q_QuotationDetailType model = new DTcms.Model.Q_QuotationDetailType();
            if (row != null)
            {
                if (row["QuotationDetailTypeId"] != null && row["QuotationDetailTypeId"].ToString() != "")
                {
                    model.QuotationDetailTypeId = int.Parse(row["QuotationDetailTypeId"].ToString());
                }
                if (row["FK_ParentQuotationListId"] != null && row["FK_ParentQuotationListId"].ToString() != "")
                {
                    model.FK_ParentQuotationListId = int.Parse(row["FK_ParentQuotationListId"].ToString());
                }
                if (row["FK_MaterialTypeId"] != null && row["FK_MaterialTypeId"].ToString() != "")
                {
                    model.FK_MaterialTypeId = int.Parse(row["FK_MaterialTypeId"].ToString());
                }
                if (row["MaterialTypeName"] != null)
                {
                    model.MaterialTypeName = row["MaterialTypeName"].ToString();
                }
                if (row["RuodiananzhuangFee"] != null && row["RuodiananzhuangFee"].ToString() != "")
                {
                    model.RuodiananzhuangFee = decimal.Parse(row["RuodiananzhuangFee"].ToString());
                }
                if (row["QicaianzhuangFee"] != null && row["QicaianzhuangFee"].ToString() != "")
                {
                    model.QicaianzhuangFee = decimal.Parse(row["QicaianzhuangFee"].ToString());
                }
                if (row["XitongtiaoshiFee"] != null && row["XitongtiaoshiFee"].ToString() != "")
                {
                    model.XitongtiaoshiFee = decimal.Parse(row["XitongtiaoshiFee"].ToString());
                }
                if (row["XiangmuguanliFee"] != null && row["XiangmuguanliFee"].ToString() != "")
                {
                    model.XiangmuguanliFee = decimal.Parse(row["XiangmuguanliFee"].ToString());
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
            strSql.Append("select QuotationDetailTypeId,FK_ParentQuotationListId,FK_MaterialTypeId,MaterialTypeName,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee ");
            strSql.Append(" FROM Q_QuotationDetailType ");
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
            strSql.Append(" QuotationDetailTypeId,FK_ParentQuotationListId,FK_MaterialTypeId,MaterialTypeName,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee ");
            strSql.Append(" FROM Q_QuotationDetailType ");
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
            strSql.Append("select count(1) FROM Q_QuotationDetailType ");
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
                strSql.Append("order by T.QuotationDetailTypeId desc");
            }
            strSql.Append(")AS Row, T.*  from Q_QuotationDetailType T ");
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
			parameters[0].Value = "Q_QuotationDetailType";
			parameters[1].Value = "QuotationDetailTypeId";
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