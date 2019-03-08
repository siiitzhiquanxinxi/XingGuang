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
	/// 数据访问类:Sy_Material_Detail
	/// </summary>
	public partial class Sy_Material_Detail
    {
        public Sy_Material_Detail()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string InnerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sy_Material_Detail");
            strSql.Append(" where InnerID=@InnerID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@InnerID", SqlDbType.NVarChar,50)         };
            parameters[0].Value = InnerID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 批量添加数据
        /// </summary>
        public bool Add(DataTable dt)
        {
            int rows = DbHelperSQL.ExecuteAddDataTable(dt);
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
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.Sy_Material_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sy_Material_Detail(");
            strSql.Append("InnerID,ForInnerID,ID,Brand,Mode,Name,Description,Unit,Num)");
            strSql.Append(" values (");
            strSql.Append("@InnerID,@ForInnerID,@ID,@Brand,@Mode,@Name,@Description,@Unit,@Num)");
            SqlParameter[] parameters = {
                    new SqlParameter("@InnerID", SqlDbType.NVarChar,50),
                    new SqlParameter("@ForInnerID", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@Brand", SqlDbType.NVarChar,50),
                    new SqlParameter("@Mode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Description", SqlDbType.NVarChar,200),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,50),
                    new SqlParameter("@Num", SqlDbType.Decimal,9)};
            parameters[0].Value = model.InnerID;
            parameters[1].Value = model.ForInnerID;
            parameters[2].Value = model.ID;
            parameters[3].Value = model.Brand;
            parameters[4].Value = model.Mode;
            parameters[5].Value = model.Name;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.Unit;
            parameters[8].Value = model.Num;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Sy_Material_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sy_Material_Detail set ");
            strSql.Append("ForInnerID=@ForInnerID,");
            strSql.Append("ID=@ID,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("Mode=@Mode,");
            strSql.Append("Name=@Name,");
            strSql.Append("Description=@Description,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Num=@Num");
            strSql.Append(" where InnerID=@InnerID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ForInnerID", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@Brand", SqlDbType.NVarChar,50),
                    new SqlParameter("@Mode", SqlDbType.NVarChar,50),
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Description", SqlDbType.NVarChar,200),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,50),
                    new SqlParameter("@Num", SqlDbType.Decimal,9),
                    new SqlParameter("@InnerID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ForInnerID;
            parameters[1].Value = model.ID;
            parameters[2].Value = model.Brand;
            parameters[3].Value = model.Mode;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.Unit;
            parameters[7].Value = model.Num;
            parameters[8].Value = model.InnerID;

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
        public bool Delete(string InnerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sy_Material_Detail ");
            strSql.Append(" where InnerID=@InnerID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@InnerID", SqlDbType.NVarChar,50)         };
            parameters[0].Value = InnerID;

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
        public bool DeleteList(string InnerIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sy_Material_Detail ");
            strSql.Append(" where InnerID in (" + InnerIDlist + ")  ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeletebyWhere(string Where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sy_Material_Detail ");
            strSql.Append(" where " + Where);
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
        public DTcms.Model.Sy_Material_Detail GetModel(string InnerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 InnerID,ForInnerID,ID,Brand,Mode,Name,Description,Unit,Num from Sy_Material_Detail ");
            strSql.Append(" where InnerID=@InnerID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@InnerID", SqlDbType.NVarChar,50)         };
            parameters[0].Value = InnerID;

            DTcms.Model.Sy_Material_Detail model = new DTcms.Model.Sy_Material_Detail();
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
        public DTcms.Model.Sy_Material_Detail DataRowToModel(DataRow row)
        {
            DTcms.Model.Sy_Material_Detail model = new DTcms.Model.Sy_Material_Detail();
            if (row != null)
            {
                if (row["InnerID"] != null)
                {
                    model.InnerID = row["InnerID"].ToString();
                }
                if (row["ForInnerID"] != null && row["ForInnerID"].ToString() != "")
                {
                    model.ForInnerID = int.Parse(row["ForInnerID"].ToString());
                }
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["Brand"] != null)
                {
                    model.Brand = row["Brand"].ToString();
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
                if (row["Num"] != null && row["Num"].ToString() != "")
                {
                    model.Num = decimal.Parse(row["Num"].ToString());
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
            strSql.Append("select InnerID,ForInnerID,ID,Brand,Mode,Name,Description,Unit,Num ");
            strSql.Append(" FROM Sy_Material_Detail ");
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
            strSql.Append(" InnerID,ForInnerID,ID,Brand,Mode,Name,Description,Unit,Num ");
            strSql.Append(" FROM Sy_Material_Detail ");
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
            strSql.Append("select count(1) FROM Sy_Material_Detail ");
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
                strSql.Append("order by T.InnerID desc");
            }
            strSql.Append(")AS Row, T.*  from Sy_Material_Detail T ");
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
			parameters[0].Value = "Sy_Material_Detail";
			parameters[1].Value = "InnerID";
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
