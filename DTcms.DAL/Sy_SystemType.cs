using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Sy_SystemType
    /// </summary>
    public partial class Sy_SystemType
    {
        public Sy_SystemType()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SystemTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sy_SystemType");
            strSql.Append(" where SystemTypeID=@SystemTypeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SystemTypeID", SqlDbType.Int,4)
            };
            parameters[0].Value = SystemTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Sy_SystemType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sy_SystemType(");
            strSql.Append("SystemTypeName,HasMaterialType,XitongtiaoshiFee,XitongtiaoshiDes,XitongtiaoshiPic,XiangmuguanliFee,XiangmuguanliDes,XiangmuguanliPic,QicaianzhuangFee,QicaianzhuangDes,QicaianzhuangPic,RuodiananzhuangDes,RuodiananzhuangPic)");
            strSql.Append(" values (");
            strSql.Append("@SystemTypeName,@HasMaterialType,@XitongtiaoshiFee,@XitongtiaoshiDes,@XitongtiaoshiPic,@XiangmuguanliFee,@XiangmuguanliDes,@XiangmuguanliPic,@QicaianzhuangFee,@QicaianzhuangDes,@QicaianzhuangPic,@RuodiananzhuangDes,@RuodiananzhuangPic)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@SystemTypeName", SqlDbType.NVarChar,50),
                    new SqlParameter("@HasMaterialType", SqlDbType.NVarChar,50),
                    new SqlParameter("@XitongtiaoshiFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XitongtiaoshiDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@XitongtiaoshiPic", SqlDbType.NVarChar,200),
                    new SqlParameter("@XiangmuguanliFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XiangmuguanliDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@XiangmuguanliPic", SqlDbType.NVarChar,200),
                    new SqlParameter("@QicaianzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QicaianzhuangDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@QicaianzhuangPic", SqlDbType.NVarChar,200),
                    new SqlParameter("@RuodiananzhuangDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@RuodiananzhuangPic", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.SystemTypeName;
            parameters[1].Value = model.HasMaterialType;
            parameters[2].Value = model.XitongtiaoshiFee;
            parameters[3].Value = model.XitongtiaoshiDes;
            parameters[4].Value = model.XitongtiaoshiPic;
            parameters[5].Value = model.XiangmuguanliFee;
            parameters[6].Value = model.XiangmuguanliDes;
            parameters[7].Value = model.XiangmuguanliPic;
            parameters[8].Value = model.QicaianzhuangFee;
            parameters[9].Value = model.QicaianzhuangDes;
            parameters[10].Value = model.QicaianzhuangPic;
            parameters[11].Value = model.RuodiananzhuangDes;
            parameters[12].Value = model.RuodiananzhuangPic;

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
        public bool Update(DTcms.Model.Sy_SystemType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sy_SystemType set ");
            strSql.Append("SystemTypeName=@SystemTypeName,");
            strSql.Append("HasMaterialType=@HasMaterialType,");
            strSql.Append("XitongtiaoshiFee=@XitongtiaoshiFee,");
            strSql.Append("XitongtiaoshiDes=@XitongtiaoshiDes,");
            strSql.Append("XitongtiaoshiPic=@XitongtiaoshiPic,");
            strSql.Append("XiangmuguanliFee=@XiangmuguanliFee,");
            strSql.Append("XiangmuguanliDes=@XiangmuguanliDes,");
            strSql.Append("XiangmuguanliPic=@XiangmuguanliPic,");
            strSql.Append("QicaianzhuangFee=@QicaianzhuangFee,");
            strSql.Append("QicaianzhuangDes=@QicaianzhuangDes,");
            strSql.Append("QicaianzhuangPic=@QicaianzhuangPic,");
            strSql.Append("RuodiananzhuangDes=@RuodiananzhuangDes,");
            strSql.Append("RuodiananzhuangPic=@RuodiananzhuangPic");
            strSql.Append(" where SystemTypeID=@SystemTypeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SystemTypeName", SqlDbType.NVarChar,50),
                    new SqlParameter("@HasMaterialType", SqlDbType.NVarChar,50),
                    new SqlParameter("@XitongtiaoshiFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XitongtiaoshiDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@XitongtiaoshiPic", SqlDbType.NVarChar,200),
                    new SqlParameter("@XiangmuguanliFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XiangmuguanliDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@XiangmuguanliPic", SqlDbType.NVarChar,200),
                    new SqlParameter("@QicaianzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QicaianzhuangDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@QicaianzhuangPic", SqlDbType.NVarChar,200),
                    new SqlParameter("@RuodiananzhuangDes", SqlDbType.NVarChar,50),
                    new SqlParameter("@RuodiananzhuangPic", SqlDbType.NVarChar,200),
                    new SqlParameter("@SystemTypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.SystemTypeName;
            parameters[1].Value = model.HasMaterialType;
            parameters[2].Value = model.XitongtiaoshiFee;
            parameters[3].Value = model.XitongtiaoshiDes;
            parameters[4].Value = model.XitongtiaoshiPic;
            parameters[5].Value = model.XiangmuguanliFee;
            parameters[6].Value = model.XiangmuguanliDes;
            parameters[7].Value = model.XiangmuguanliPic;
            parameters[8].Value = model.QicaianzhuangFee;
            parameters[9].Value = model.QicaianzhuangDes;
            parameters[10].Value = model.QicaianzhuangPic;
            parameters[11].Value = model.RuodiananzhuangDes;
            parameters[12].Value = model.RuodiananzhuangPic;
            parameters[13].Value = model.SystemTypeID;

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
        public bool Delete(int SystemTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sy_SystemType ");
            strSql.Append(" where SystemTypeID=@SystemTypeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SystemTypeID", SqlDbType.Int,4)
            };
            parameters[0].Value = SystemTypeID;

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
        public bool DeleteList(string SystemTypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sy_SystemType ");
            strSql.Append(" where SystemTypeID in (" + SystemTypeIDlist + ")  ");
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
        public DTcms.Model.Sy_SystemType GetModel(int SystemTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SystemTypeID,SystemTypeName,HasMaterialType,XitongtiaoshiFee,XitongtiaoshiDes,XitongtiaoshiPic,XiangmuguanliFee,XiangmuguanliDes,XiangmuguanliPic,QicaianzhuangFee,QicaianzhuangDes,QicaianzhuangPic,RuodiananzhuangDes,RuodiananzhuangPic from Sy_SystemType ");
            strSql.Append(" where SystemTypeID=@SystemTypeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SystemTypeID", SqlDbType.Int,4)
            };
            parameters[0].Value = SystemTypeID;

            DTcms.Model.Sy_SystemType model = new DTcms.Model.Sy_SystemType();
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
        public DTcms.Model.Sy_SystemType DataRowToModel(DataRow row)
        {
            DTcms.Model.Sy_SystemType model = new DTcms.Model.Sy_SystemType();
            if (row != null)
            {
                if (row["SystemTypeID"] != null && row["SystemTypeID"].ToString() != "")
                {
                    model.SystemTypeID = int.Parse(row["SystemTypeID"].ToString());
                }
                if (row["SystemTypeName"] != null)
                {
                    model.SystemTypeName = row["SystemTypeName"].ToString();
                }
                if (row["HasMaterialType"] != null)
                {
                    model.HasMaterialType = row["HasMaterialType"].ToString();
                }
                if (row["XitongtiaoshiFee"] != null && row["XitongtiaoshiFee"].ToString() != "")
                {
                    model.XitongtiaoshiFee = decimal.Parse(row["XitongtiaoshiFee"].ToString());
                }
                if (row["XitongtiaoshiDes"] != null)
                {
                    model.XitongtiaoshiDes = row["XitongtiaoshiDes"].ToString();
                }
                if (row["XitongtiaoshiPic"] != null)
                {
                    model.XitongtiaoshiPic = row["XitongtiaoshiPic"].ToString();
                }
                if (row["XiangmuguanliFee"] != null && row["XiangmuguanliFee"].ToString() != "")
                {
                    model.XiangmuguanliFee = decimal.Parse(row["XiangmuguanliFee"].ToString());
                }
                if (row["XiangmuguanliDes"] != null)
                {
                    model.XiangmuguanliDes = row["XiangmuguanliDes"].ToString();
                }
                if (row["XiangmuguanliPic"] != null)
                {
                    model.XiangmuguanliPic = row["XiangmuguanliPic"].ToString();
                }
                if (row["QicaianzhuangFee"] != null && row["QicaianzhuangFee"].ToString() != "")
                {
                    model.QicaianzhuangFee = decimal.Parse(row["QicaianzhuangFee"].ToString());
                }
                if (row["QicaianzhuangDes"] != null)
                {
                    model.QicaianzhuangDes = row["QicaianzhuangDes"].ToString();
                }
                if (row["QicaianzhuangPic"] != null)
                {
                    model.QicaianzhuangPic = row["QicaianzhuangPic"].ToString();
                }
                if (row["RuodiananzhuangDes"] != null)
                {
                    model.RuodiananzhuangDes = row["RuodiananzhuangDes"].ToString();
                }
                if (row["RuodiananzhuangPic"] != null)
                {
                    model.RuodiananzhuangPic = row["RuodiananzhuangPic"].ToString();
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
            strSql.Append("select SystemTypeID,SystemTypeName,HasMaterialType,XitongtiaoshiFee,XitongtiaoshiDes,XitongtiaoshiPic,XiangmuguanliFee,XiangmuguanliDes,XiangmuguanliPic,QicaianzhuangFee,QicaianzhuangDes,QicaianzhuangPic,RuodiananzhuangDes,RuodiananzhuangPic ");
            strSql.Append(" FROM Sy_SystemType ");
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
            strSql.Append(" SystemTypeID,SystemTypeName,HasMaterialType,XitongtiaoshiFee,XitongtiaoshiDes,XitongtiaoshiPic,XiangmuguanliFee,XiangmuguanliDes,XiangmuguanliPic,QicaianzhuangFee,QicaianzhuangDes,QicaianzhuangPic,RuodiananzhuangDes,RuodiananzhuangPic ");
            strSql.Append(" FROM Sy_SystemType ");
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
            strSql.Append("select count(1) FROM Sy_SystemType ");
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
                strSql.Append("order by T.SystemTypeID desc");
            }
            strSql.Append(")AS Row, T.*  from Sy_SystemType T ");
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
			parameters[0].Value = "Sy_SystemType";
			parameters[1].Value = "SystemTypeID";
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

