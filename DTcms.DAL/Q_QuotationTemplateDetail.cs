using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Q_QuotationTemplateDetail
    /// </summary>
    public partial class Q_QuotationTemplateDetail
    {
        public Q_QuotationTemplateDetail()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int QuotationTemplateDetailId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Q_QuotationTemplateDetail");
            strSql.Append(" where QuotationTemplateDetailId=@QuotationTemplateDetailId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateDetailId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationTemplateDetailId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Q_QuotationTemplateDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Q_QuotationTemplateDetail(");
            strSql.Append("TemplateParentID,FK_materialID,DetailOrder,TemplateDetailQuantity)");
            strSql.Append(" values (");
            strSql.Append("@TemplateParentID,@FK_materialID,@DetailOrder,@TemplateDetailQuantity)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@TemplateParentID", SqlDbType.Int,4),
                    new SqlParameter("@FK_materialID", SqlDbType.Int,4),
                    new SqlParameter("@DetailOrder", SqlDbType.Int,4),
                    new SqlParameter("@TemplateDetailQuantity", SqlDbType.Decimal,9)};
            parameters[0].Value = model.TemplateParentID;
            parameters[1].Value = model.FK_materialID;
            parameters[2].Value = model.DetailOrder;
            parameters[3].Value = model.TemplateDetailQuantity;

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
        public bool Update(DTcms.Model.Q_QuotationTemplateDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Q_QuotationTemplateDetail set ");
            strSql.Append("TemplateParentID=@TemplateParentID,");
            strSql.Append("FK_materialID=@FK_materialID,");
            strSql.Append("DetailOrder=@DetailOrder,");
            strSql.Append("TemplateDetailQuantity=@TemplateDetailQuantity");
            strSql.Append(" where QuotationTemplateDetailId=@QuotationTemplateDetailId");
            SqlParameter[] parameters = {
                    new SqlParameter("@TemplateParentID", SqlDbType.Int,4),
                    new SqlParameter("@FK_materialID", SqlDbType.Int,4),
                    new SqlParameter("@DetailOrder", SqlDbType.Int,4),
                    new SqlParameter("@TemplateDetailQuantity", SqlDbType.Decimal,9),
                    new SqlParameter("@QuotationTemplateDetailId", SqlDbType.Int,4)};
            parameters[0].Value = model.TemplateParentID;
            parameters[1].Value = model.FK_materialID;
            parameters[2].Value = model.DetailOrder;
            parameters[3].Value = model.TemplateDetailQuantity;
            parameters[4].Value = model.QuotationTemplateDetailId;

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
        public bool Delete(int QuotationTemplateDetailId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationTemplateDetail ");
            strSql.Append(" where QuotationTemplateDetailId=@QuotationTemplateDetailId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateDetailId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationTemplateDetailId;

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
        public bool DeleteList(string QuotationTemplateDetailIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationTemplateDetail ");
            strSql.Append(" where QuotationTemplateDetailId in (" + QuotationTemplateDetailIdlist + ")  ");
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
        public DTcms.Model.Q_QuotationTemplateDetail GetModel(int QuotationTemplateDetailId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QuotationTemplateDetailId,TemplateParentID,FK_materialID,DetailOrder,TemplateDetailQuantity from Q_QuotationTemplateDetail ");
            strSql.Append(" where QuotationTemplateDetailId=@QuotationTemplateDetailId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateDetailId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationTemplateDetailId;

            DTcms.Model.Q_QuotationTemplateDetail model = new DTcms.Model.Q_QuotationTemplateDetail();
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
        public DTcms.Model.Q_QuotationTemplateDetail DataRowToModel(DataRow row)
        {
            DTcms.Model.Q_QuotationTemplateDetail model = new DTcms.Model.Q_QuotationTemplateDetail();
            if (row != null)
            {
                if (row["QuotationTemplateDetailId"] != null && row["QuotationTemplateDetailId"].ToString() != "")
                {
                    model.QuotationTemplateDetailId = int.Parse(row["QuotationTemplateDetailId"].ToString());
                }
                if (row["TemplateParentID"] != null && row["TemplateParentID"].ToString() != "")
                {
                    model.TemplateParentID = int.Parse(row["TemplateParentID"].ToString());
                }
                if (row["FK_materialID"] != null && row["FK_materialID"].ToString() != "")
                {
                    model.FK_materialID = int.Parse(row["FK_materialID"].ToString());
                }
                if (row["DetailOrder"] != null && row["DetailOrder"].ToString() != "")
                {
                    model.DetailOrder = int.Parse(row["DetailOrder"].ToString());
                }
                if (row["TemplateDetailQuantity"] != null && row["TemplateDetailQuantity"].ToString() != "")
                {
                    model.TemplateDetailQuantity = decimal.Parse(row["TemplateDetailQuantity"].ToString());
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
            strSql.Append("select QuotationTemplateDetailId,TemplateParentID,FK_materialID,DetailOrder,TemplateDetailQuantity ");
            strSql.Append(" FROM Q_QuotationTemplateDetail ");
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
            strSql.Append(" QuotationTemplateDetailId,TemplateParentID,FK_materialID,DetailOrder,TemplateDetailQuantity ");
            strSql.Append(" FROM Q_QuotationTemplateDetail ");
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
            strSql.Append("select count(1) FROM Q_QuotationTemplateDetail ");
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
                strSql.Append("order by T.QuotationTemplateDetailId desc");
            }
            strSql.Append(")AS Row, T.*  from Q_QuotationTemplateDetail T ");
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
			parameters[0].Value = "Q_QuotationTemplateDetail";
			parameters[1].Value = "QuotationTemplateDetailId";
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

