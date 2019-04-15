using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Q_QuotationList
    /// </summary>
    public partial class Q_QuotationList
    {
        public Q_QuotationList()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int QuotationListId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Q_QuotationList");
            strSql.Append(" where QuotationListId=@QuotationListId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationListId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationListId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Q_QuotationList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Q_QuotationList(");
            strSql.Append("QuotationListNum,FK_ParentProgramId,CreateBy,CreateDate,QuotationListState,PreferentialRatio,PreferentialRelief,Tax)");
            strSql.Append(" values (");
            strSql.Append("@QuotationListNum,@FK_ParentProgramId,@CreateBy,@CreateDate,@QuotationListState,@PreferentialRatio,@PreferentialRelief,@Tax)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationListNum", SqlDbType.NVarChar,50),
                    new SqlParameter("@FK_ParentProgramId", SqlDbType.Int,4),
                    new SqlParameter("@CreateBy", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@QuotationListState", SqlDbType.Int,4),
                    new SqlParameter("@PreferentialRatio", SqlDbType.Int,4),
                    new SqlParameter("@PreferentialRelief", SqlDbType.Decimal,9),
                    new SqlParameter("@Tax", SqlDbType.Int,4)};
            parameters[0].Value = model.QuotationListNum;
            parameters[1].Value = model.FK_ParentProgramId;
            parameters[2].Value = model.CreateBy;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.QuotationListState;
            parameters[5].Value = model.PreferentialRatio;
            parameters[6].Value = model.PreferentialRelief;
            parameters[7].Value = model.Tax;

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
        public bool Update(DTcms.Model.Q_QuotationList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Q_QuotationList set ");
            strSql.Append("QuotationListNum=@QuotationListNum,");
            strSql.Append("FK_ParentProgramId=@FK_ParentProgramId,");
            strSql.Append("CreateBy=@CreateBy,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("QuotationListState=@QuotationListState,");
            strSql.Append("PreferentialRatio=@PreferentialRatio,");
            strSql.Append("PreferentialRelief=@PreferentialRelief,");
            strSql.Append("Tax=@Tax");
            strSql.Append(" where QuotationListId=@QuotationListId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationListNum", SqlDbType.NVarChar,50),
                    new SqlParameter("@FK_ParentProgramId", SqlDbType.Int,4),
                    new SqlParameter("@CreateBy", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@QuotationListState", SqlDbType.Int,4),
                    new SqlParameter("@PreferentialRatio", SqlDbType.Int,4),
                    new SqlParameter("@PreferentialRelief", SqlDbType.Decimal,9),
                    new SqlParameter("@Tax", SqlDbType.Int,4),
                    new SqlParameter("@QuotationListId", SqlDbType.Int,4)};
            parameters[0].Value = model.QuotationListNum;
            parameters[1].Value = model.FK_ParentProgramId;
            parameters[2].Value = model.CreateBy;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.QuotationListState;
            parameters[5].Value = model.PreferentialRatio;
            parameters[6].Value = model.PreferentialRelief;
            parameters[7].Value = model.Tax;
            parameters[8].Value = model.QuotationListId;

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
        public bool Delete(int QuotationListId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationList ");
            strSql.Append(" where QuotationListId=@QuotationListId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationListId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationListId;

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
        public bool DeleteList(string QuotationListIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationList ");
            strSql.Append(" where QuotationListId in (" + QuotationListIdlist + ")  ");
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
        public DTcms.Model.Q_QuotationList GetModel(int QuotationListId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QuotationListId,QuotationListNum,FK_ParentProgramId,CreateBy,CreateDate,QuotationListState,PreferentialRatio,PreferentialRelief,Tax from Q_QuotationList ");
            strSql.Append(" where QuotationListId=@QuotationListId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationListId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationListId;

            DTcms.Model.Q_QuotationList model = new DTcms.Model.Q_QuotationList();
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
        public DTcms.Model.Q_QuotationList DataRowToModel(DataRow row)
        {
            DTcms.Model.Q_QuotationList model = new DTcms.Model.Q_QuotationList();
            if (row != null)
            {
                if (row["QuotationListId"] != null && row["QuotationListId"].ToString() != "")
                {
                    model.QuotationListId = int.Parse(row["QuotationListId"].ToString());
                }
                if (row["QuotationListNum"] != null)
                {
                    model.QuotationListNum = row["QuotationListNum"].ToString();
                }
                if (row["FK_ParentProgramId"] != null && row["FK_ParentProgramId"].ToString() != "")
                {
                    model.FK_ParentProgramId = int.Parse(row["FK_ParentProgramId"].ToString());
                }
                if (row["CreateBy"] != null && row["CreateBy"].ToString() != "")
                {
                    model.CreateBy = int.Parse(row["CreateBy"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["QuotationListState"] != null && row["QuotationListState"].ToString() != "")
                {
                    model.QuotationListState = int.Parse(row["QuotationListState"].ToString());
                }
                if (row["PreferentialRatio"] != null && row["PreferentialRatio"].ToString() != "")
                {
                    model.PreferentialRatio = int.Parse(row["PreferentialRatio"].ToString());
                }
                if (row["PreferentialRelief"] != null && row["PreferentialRelief"].ToString() != "")
                {
                    model.PreferentialRelief = decimal.Parse(row["PreferentialRelief"].ToString());
                }
                if (row["Tax"] != null && row["Tax"].ToString() != "")
                {
                    model.Tax = int.Parse(row["Tax"].ToString());
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
            strSql.Append("select QuotationListId,QuotationListNum,FK_ParentProgramId,CreateBy,CreateDate,QuotationListState,PreferentialRatio,PreferentialRelief,Tax ");
            strSql.Append(" FROM Q_QuotationList ");
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
            strSql.Append(" QuotationListId,QuotationListNum,FK_ParentProgramId,CreateBy,CreateDate,QuotationListState,PreferentialRatio,PreferentialRelief,Tax ");
            strSql.Append(" FROM Q_QuotationList ");
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
            strSql.Append("select count(1) FROM Q_QuotationList ");
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
                strSql.Append("order by T.QuotationListId desc");
            }
            strSql.Append(")AS Row, T.*  from Q_QuotationList T ");
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
			parameters[0].Value = "Q_QuotationList";
			parameters[1].Value = "QuotationListId";
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

