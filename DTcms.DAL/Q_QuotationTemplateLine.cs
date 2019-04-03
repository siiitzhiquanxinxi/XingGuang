using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Q_QuotationTemplateLine
    /// </summary>
    public partial class Q_QuotationTemplateLine
    {
        public Q_QuotationTemplateLine()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TemplateLineId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Q_QuotationTemplateLine");
            strSql.Append(" where TemplateLineId=@TemplateLineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@TemplateLineId", SqlDbType.Int,4)
            };
            parameters[0].Value = TemplateLineId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Q_QuotationTemplateLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Q_QuotationTemplateLine(");
            strSql.Append("FK_TemplateId,FK_LineId,LineBrand,LineBrandImg,LineMode,LineName,LineDescription,LineUnit,LineUnitPrice,LinePhoto,LineTotalcount,LineTotalamount)");
            strSql.Append(" values (");
            strSql.Append("@FK_TemplateId,@FK_LineId,@LineBrand,@LineBrandImg,@LineMode,@LineName,@LineDescription,@LineUnit,@LineUnitPrice,@LinePhoto,@LineTotalcount,@LineTotalamount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@FK_TemplateId", SqlDbType.Int,4),
                    new SqlParameter("@FK_LineId", SqlDbType.Int,4),
                    new SqlParameter("@LineBrand", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineBrandImg", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineMode", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineName", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineDescription", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineUnit", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineUnitPrice", SqlDbType.NVarChar,200),
                    new SqlParameter("@LinePhoto", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineTotalcount", SqlDbType.Decimal,9),
                    new SqlParameter("@LineTotalamount", SqlDbType.Decimal,9)};
            parameters[0].Value = model.FK_TemplateId;
            parameters[1].Value = model.FK_LineId;
            parameters[2].Value = model.LineBrand;
            parameters[3].Value = model.LineBrandImg;
            parameters[4].Value = model.LineMode;
            parameters[5].Value = model.LineName;
            parameters[6].Value = model.LineDescription;
            parameters[7].Value = model.LineUnit;
            parameters[8].Value = model.LineUnitPrice;
            parameters[9].Value = model.LinePhoto;
            parameters[10].Value = model.LineTotalcount;
            parameters[11].Value = model.LineTotalamount;

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
        public bool Update(DTcms.Model.Q_QuotationTemplateLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Q_QuotationTemplateLine set ");
            strSql.Append("FK_TemplateId=@FK_TemplateId,");
            strSql.Append("FK_LineId=@FK_LineId,");
            strSql.Append("LineBrand=@LineBrand,");
            strSql.Append("LineBrandImg=@LineBrandImg,");
            strSql.Append("LineMode=@LineMode,");
            strSql.Append("LineName=@LineName,");
            strSql.Append("LineDescription=@LineDescription,");
            strSql.Append("LineUnit=@LineUnit,");
            strSql.Append("LineUnitPrice=@LineUnitPrice,");
            strSql.Append("LinePhoto=@LinePhoto,");
            strSql.Append("LineTotalcount=@LineTotalcount,");
            strSql.Append("LineTotalamount=@LineTotalamount");
            strSql.Append(" where TemplateLineId=@TemplateLineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@FK_TemplateId", SqlDbType.Int,4),
                    new SqlParameter("@FK_LineId", SqlDbType.Int,4),
                    new SqlParameter("@LineBrand", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineBrandImg", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineMode", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineName", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineDescription", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineUnit", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineUnitPrice", SqlDbType.NVarChar,200),
                    new SqlParameter("@LinePhoto", SqlDbType.NVarChar,200),
                    new SqlParameter("@LineTotalcount", SqlDbType.Decimal,9),
                    new SqlParameter("@LineTotalamount", SqlDbType.Decimal,9),
                    new SqlParameter("@TemplateLineId", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_TemplateId;
            parameters[1].Value = model.FK_LineId;
            parameters[2].Value = model.LineBrand;
            parameters[3].Value = model.LineBrandImg;
            parameters[4].Value = model.LineMode;
            parameters[5].Value = model.LineName;
            parameters[6].Value = model.LineDescription;
            parameters[7].Value = model.LineUnit;
            parameters[8].Value = model.LineUnitPrice;
            parameters[9].Value = model.LinePhoto;
            parameters[10].Value = model.LineTotalcount;
            parameters[11].Value = model.LineTotalamount;
            parameters[12].Value = model.TemplateLineId;

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
        public bool Delete(int TemplateLineId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationTemplateLine ");
            strSql.Append(" where TemplateLineId=@TemplateLineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@TemplateLineId", SqlDbType.Int,4)
            };
            parameters[0].Value = TemplateLineId;

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
        public bool DeleteList(string TemplateLineIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationTemplateLine ");
            strSql.Append(" where TemplateLineId in (" + TemplateLineIdlist + ")  ");
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
        public DTcms.Model.Q_QuotationTemplateLine GetModel(int TemplateLineId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TemplateLineId,FK_TemplateId,FK_LineId,LineBrand,LineBrandImg,LineMode,LineName,LineDescription,LineUnit,LineUnitPrice,LinePhoto,LineTotalcount,LineTotalamount from Q_QuotationTemplateLine ");
            strSql.Append(" where TemplateLineId=@TemplateLineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@TemplateLineId", SqlDbType.Int,4)
            };
            parameters[0].Value = TemplateLineId;

            DTcms.Model.Q_QuotationTemplateLine model = new DTcms.Model.Q_QuotationTemplateLine();
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
        public DTcms.Model.Q_QuotationTemplateLine DataRowToModel(DataRow row)
        {
            DTcms.Model.Q_QuotationTemplateLine model = new DTcms.Model.Q_QuotationTemplateLine();
            if (row != null)
            {
                if (row["TemplateLineId"] != null && row["TemplateLineId"].ToString() != "")
                {
                    model.TemplateLineId = int.Parse(row["TemplateLineId"].ToString());
                }
                if (row["FK_TemplateId"] != null && row["FK_TemplateId"].ToString() != "")
                {
                    model.FK_TemplateId = int.Parse(row["FK_TemplateId"].ToString());
                }
                if (row["FK_LineId"] != null && row["FK_LineId"].ToString() != "")
                {
                    model.FK_LineId = int.Parse(row["FK_LineId"].ToString());
                }
                if (row["LineBrand"] != null)
                {
                    model.LineBrand = row["LineBrand"].ToString();
                }
                if (row["LineBrandImg"] != null)
                {
                    model.LineBrandImg = row["LineBrandImg"].ToString();
                }
                if (row["LineMode"] != null)
                {
                    model.LineMode = row["LineMode"].ToString();
                }
                if (row["LineName"] != null)
                {
                    model.LineName = row["LineName"].ToString();
                }
                if (row["LineDescription"] != null)
                {
                    model.LineDescription = row["LineDescription"].ToString();
                }
                if (row["LineUnit"] != null)
                {
                    model.LineUnit = row["LineUnit"].ToString();
                }
                if (row["LineUnitPrice"] != null)
                {
                    model.LineUnitPrice = row["LineUnitPrice"].ToString();
                }
                if (row["LinePhoto"] != null)
                {
                    model.LinePhoto = row["LinePhoto"].ToString();
                }
                if (row["LineTotalcount"] != null && row["LineTotalcount"].ToString() != "")
                {
                    model.LineTotalcount = decimal.Parse(row["LineTotalcount"].ToString());
                }
                if (row["LineTotalamount"] != null && row["LineTotalamount"].ToString() != "")
                {
                    model.LineTotalamount = decimal.Parse(row["LineTotalamount"].ToString());
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
            strSql.Append("select TemplateLineId,FK_TemplateId,FK_LineId,LineBrand,LineBrandImg,LineMode,LineName,LineDescription,LineUnit,LineUnitPrice,LinePhoto,LineTotalcount,LineTotalamount ");
            strSql.Append(" FROM Q_QuotationTemplateLine ");
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
            strSql.Append(" TemplateLineId,FK_TemplateId,FK_LineId,LineBrand,LineBrandImg,LineMode,LineName,LineDescription,LineUnit,LineUnitPrice,LinePhoto,LineTotalcount,LineTotalamount ");
            strSql.Append(" FROM Q_QuotationTemplateLine ");
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
            strSql.Append("select count(1) FROM Q_QuotationTemplateLine ");
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
                strSql.Append("order by T.TemplateLineId desc");
            }
            strSql.Append(")AS Row, T.*  from Q_QuotationTemplateLine T ");
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
			parameters[0].Value = "Q_QuotationTemplateLine";
			parameters[1].Value = "TemplateLineId";
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

