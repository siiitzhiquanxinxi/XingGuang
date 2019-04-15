using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Q_QuotationTemplate
    /// </summary>
    public partial class Q_QuotationTemplate
    {
        public Q_QuotationTemplate()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int QuotationTemplateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Q_QuotationTemplate");
            strSql.Append(" where QuotationTemplateId=@QuotationTemplateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationTemplateId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Q_QuotationTemplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Q_QuotationTemplate(");
            strSql.Append("QuotationTemplateName,QuotationTemplateType,QuotationTemplateTypeId,QuotationTemplateMainBrand,QuotationTemplateDescription,QuotationTemplateScenario,QuotationTemplateNotes,CreateBy,CreateDate,QuotationTemplateState,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee,VideoDebugFee,AudioDebugFee)");
            strSql.Append(" values (");
            strSql.Append("@QuotationTemplateName,@QuotationTemplateType,@QuotationTemplateTypeId,@QuotationTemplateMainBrand,@QuotationTemplateDescription,@QuotationTemplateScenario,@QuotationTemplateNotes,@CreateBy,@CreateDate,@QuotationTemplateState,@RuodiananzhuangFee,@QicaianzhuangFee,@XitongtiaoshiFee,@XiangmuguanliFee,@VideoDebugFee,@AudioDebugFee)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateName", SqlDbType.NVarChar,50),
                    new SqlParameter("@QuotationTemplateType", SqlDbType.NVarChar,50),
                    new SqlParameter("@QuotationTemplateTypeId", SqlDbType.Int,4),
                    new SqlParameter("@QuotationTemplateMainBrand", SqlDbType.NChar,10),
                    new SqlParameter("@QuotationTemplateDescription", SqlDbType.NVarChar,200),
                    new SqlParameter("@QuotationTemplateScenario", SqlDbType.NVarChar,200),
                    new SqlParameter("@QuotationTemplateNotes", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateBy", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@QuotationTemplateState", SqlDbType.Int,4),
                    new SqlParameter("@RuodiananzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QicaianzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XitongtiaoshiFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XiangmuguanliFee", SqlDbType.Decimal,9),
                    new SqlParameter("@VideoDebugFee", SqlDbType.Decimal,9),
                    new SqlParameter("@AudioDebugFee", SqlDbType.Decimal,9)};
            parameters[0].Value = model.QuotationTemplateName;
            parameters[1].Value = model.QuotationTemplateType;
            parameters[2].Value = model.QuotationTemplateTypeId;
            parameters[3].Value = model.QuotationTemplateMainBrand;
            parameters[4].Value = model.QuotationTemplateDescription;
            parameters[5].Value = model.QuotationTemplateScenario;
            parameters[6].Value = model.QuotationTemplateNotes;
            parameters[7].Value = model.CreateBy;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.QuotationTemplateState;
            parameters[10].Value = model.RuodiananzhuangFee;
            parameters[11].Value = model.QicaianzhuangFee;
            parameters[12].Value = model.XitongtiaoshiFee;
            parameters[13].Value = model.XiangmuguanliFee;
            parameters[14].Value = model.VideoDebugFee;
            parameters[15].Value = model.AudioDebugFee;

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
        public bool Update(DTcms.Model.Q_QuotationTemplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Q_QuotationTemplate set ");
            strSql.Append("QuotationTemplateName=@QuotationTemplateName,");
            strSql.Append("QuotationTemplateType=@QuotationTemplateType,");
            strSql.Append("QuotationTemplateTypeId=@QuotationTemplateTypeId,");
            strSql.Append("QuotationTemplateMainBrand=@QuotationTemplateMainBrand,");
            strSql.Append("QuotationTemplateDescription=@QuotationTemplateDescription,");
            strSql.Append("QuotationTemplateScenario=@QuotationTemplateScenario,");
            strSql.Append("QuotationTemplateNotes=@QuotationTemplateNotes,");
            strSql.Append("CreateBy=@CreateBy,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("QuotationTemplateState=@QuotationTemplateState,");
            strSql.Append("RuodiananzhuangFee=@RuodiananzhuangFee,");
            strSql.Append("QicaianzhuangFee=@QicaianzhuangFee,");
            strSql.Append("XitongtiaoshiFee=@XitongtiaoshiFee,");
            strSql.Append("XiangmuguanliFee=@XiangmuguanliFee,");
            strSql.Append("VideoDebugFee=@VideoDebugFee,");
            strSql.Append("AudioDebugFee=@AudioDebugFee");
            strSql.Append(" where QuotationTemplateId=@QuotationTemplateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateName", SqlDbType.NVarChar,50),
                    new SqlParameter("@QuotationTemplateType", SqlDbType.NVarChar,50),
                    new SqlParameter("@QuotationTemplateTypeId", SqlDbType.Int,4),
                    new SqlParameter("@QuotationTemplateMainBrand", SqlDbType.NChar,10),
                    new SqlParameter("@QuotationTemplateDescription", SqlDbType.NVarChar,200),
                    new SqlParameter("@QuotationTemplateScenario", SqlDbType.NVarChar,200),
                    new SqlParameter("@QuotationTemplateNotes", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateBy", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@QuotationTemplateState", SqlDbType.Int,4),
                    new SqlParameter("@RuodiananzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QicaianzhuangFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XitongtiaoshiFee", SqlDbType.Decimal,9),
                    new SqlParameter("@XiangmuguanliFee", SqlDbType.Decimal,9),
                    new SqlParameter("@VideoDebugFee", SqlDbType.Decimal,9),
                    new SqlParameter("@AudioDebugFee", SqlDbType.Decimal,9),
                    new SqlParameter("@QuotationTemplateId", SqlDbType.Int,4)};
            parameters[0].Value = model.QuotationTemplateName;
            parameters[1].Value = model.QuotationTemplateType;
            parameters[2].Value = model.QuotationTemplateTypeId;
            parameters[3].Value = model.QuotationTemplateMainBrand;
            parameters[4].Value = model.QuotationTemplateDescription;
            parameters[5].Value = model.QuotationTemplateScenario;
            parameters[6].Value = model.QuotationTemplateNotes;
            parameters[7].Value = model.CreateBy;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.QuotationTemplateState;
            parameters[10].Value = model.RuodiananzhuangFee;
            parameters[11].Value = model.QicaianzhuangFee;
            parameters[12].Value = model.XitongtiaoshiFee;
            parameters[13].Value = model.XiangmuguanliFee;
            parameters[14].Value = model.VideoDebugFee;
            parameters[15].Value = model.AudioDebugFee;
            parameters[16].Value = model.QuotationTemplateId;

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
        public bool Delete(int QuotationTemplateId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationTemplate ");
            strSql.Append(" where QuotationTemplateId=@QuotationTemplateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationTemplateId;

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
        public bool DeleteList(string QuotationTemplateIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Q_QuotationTemplate ");
            strSql.Append(" where QuotationTemplateId in (" + QuotationTemplateIdlist + ")  ");
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
        public DTcms.Model.Q_QuotationTemplate GetModel(int QuotationTemplateId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QuotationTemplateId,QuotationTemplateName,QuotationTemplateType,QuotationTemplateTypeId,QuotationTemplateMainBrand,QuotationTemplateDescription,QuotationTemplateScenario,QuotationTemplateNotes,CreateBy,CreateDate,QuotationTemplateState,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee,VideoDebugFee,AudioDebugFee from Q_QuotationTemplate ");
            strSql.Append(" where QuotationTemplateId=@QuotationTemplateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuotationTemplateId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuotationTemplateId;

            DTcms.Model.Q_QuotationTemplate model = new DTcms.Model.Q_QuotationTemplate();
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
        public DTcms.Model.Q_QuotationTemplate DataRowToModel(DataRow row)
        {
            DTcms.Model.Q_QuotationTemplate model = new DTcms.Model.Q_QuotationTemplate();
            if (row != null)
            {
                if (row["QuotationTemplateId"] != null && row["QuotationTemplateId"].ToString() != "")
                {
                    model.QuotationTemplateId = int.Parse(row["QuotationTemplateId"].ToString());
                }
                if (row["QuotationTemplateName"] != null)
                {
                    model.QuotationTemplateName = row["QuotationTemplateName"].ToString();
                }
                if (row["QuotationTemplateType"] != null)
                {
                    model.QuotationTemplateType = row["QuotationTemplateType"].ToString();
                }
                if (row["QuotationTemplateTypeId"] != null && row["QuotationTemplateTypeId"].ToString() != "")
                {
                    model.QuotationTemplateTypeId = int.Parse(row["QuotationTemplateTypeId"].ToString());
                }
                if (row["QuotationTemplateMainBrand"] != null)
                {
                    model.QuotationTemplateMainBrand = row["QuotationTemplateMainBrand"].ToString();
                }
                if (row["QuotationTemplateDescription"] != null)
                {
                    model.QuotationTemplateDescription = row["QuotationTemplateDescription"].ToString();
                }
                if (row["QuotationTemplateScenario"] != null)
                {
                    model.QuotationTemplateScenario = row["QuotationTemplateScenario"].ToString();
                }
                if (row["QuotationTemplateNotes"] != null)
                {
                    model.QuotationTemplateNotes = row["QuotationTemplateNotes"].ToString();
                }
                if (row["CreateBy"] != null && row["CreateBy"].ToString() != "")
                {
                    model.CreateBy = int.Parse(row["CreateBy"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["QuotationTemplateState"] != null && row["QuotationTemplateState"].ToString() != "")
                {
                    model.QuotationTemplateState = int.Parse(row["QuotationTemplateState"].ToString());
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
                if (row["VideoDebugFee"] != null && row["VideoDebugFee"].ToString() != "")
                {
                    model.VideoDebugFee = decimal.Parse(row["VideoDebugFee"].ToString());
                }
                if (row["AudioDebugFee"] != null && row["AudioDebugFee"].ToString() != "")
                {
                    model.AudioDebugFee = decimal.Parse(row["AudioDebugFee"].ToString());
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
            strSql.Append("select QuotationTemplateId,QuotationTemplateName,QuotationTemplateType,QuotationTemplateTypeId,QuotationTemplateMainBrand,QuotationTemplateDescription,QuotationTemplateScenario,QuotationTemplateNotes,CreateBy,CreateDate,QuotationTemplateState,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee,VideoDebugFee,AudioDebugFee ");
            strSql.Append(" FROM Q_QuotationTemplate ");
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
            strSql.Append(" QuotationTemplateId,QuotationTemplateName,QuotationTemplateType,QuotationTemplateTypeId,QuotationTemplateMainBrand,QuotationTemplateDescription,QuotationTemplateScenario,QuotationTemplateNotes,CreateBy,CreateDate,QuotationTemplateState,RuodiananzhuangFee,QicaianzhuangFee,XitongtiaoshiFee,XiangmuguanliFee,VideoDebugFee,AudioDebugFee ");
            strSql.Append(" FROM Q_QuotationTemplate ");
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
            strSql.Append("select count(1) FROM Q_QuotationTemplate ");
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
                strSql.Append("order by T.QuotationTemplateId desc");
            }
            strSql.Append(")AS Row, T.*  from Q_QuotationTemplate T ");
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
			parameters[0].Value = "Q_QuotationTemplate";
			parameters[1].Value = "QuotationTemplateId";
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

