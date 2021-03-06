﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:Sy_Material
    /// </summary>
    public partial class Sy_Material
    {
        public Sy_Material()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sy_Material");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Sy_Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sy_Material(");
            strSql.Append("MaterialTypeID,MaterialType,Brand,BrandEnglish,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,VideoDebugFee,AudioDebugFee,Photo,MaterialID,MaterialName,Tag,State)");
            strSql.Append(" values (");
            strSql.Append("@MaterialTypeID,@MaterialType,@Brand,@BrandEnglish,@BrandImg,@Mode,@Name,@Description,@Unit,@UnitPrice,@CostPrice,@LaborCost,@InstallationFee,@CommissioningFee,@ManagementFee,@IndoorInstallationFee,@IndoorLaborCost,@VideoDebugFee,@AudioDebugFee,@Photo,@MaterialID,@MaterialName,@Tag,@State)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@MaterialTypeID", SqlDbType.Int,4),
                    new SqlParameter("@MaterialType", SqlDbType.NVarChar,50),
                    new SqlParameter("@Brand", SqlDbType.NVarChar,50),
                    new SqlParameter("@BrandEnglish", SqlDbType.NVarChar,50),
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
                    new SqlParameter("@VideoDebugFee", SqlDbType.Decimal,9),
                    new SqlParameter("@AudioDebugFee", SqlDbType.Decimal,9),
                    new SqlParameter("@Photo", SqlDbType.NVarChar,50),
                    new SqlParameter("@MaterialID", SqlDbType.NVarChar,50),
                    new SqlParameter("@MaterialName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Tag", SqlDbType.NVarChar,20),
                    new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.MaterialTypeID;
            parameters[1].Value = model.MaterialType;
            parameters[2].Value = model.Brand;
            parameters[3].Value = model.BrandEnglish;
            parameters[4].Value = model.BrandImg;
            parameters[5].Value = model.Mode;
            parameters[6].Value = model.Name;
            parameters[7].Value = model.Description;
            parameters[8].Value = model.Unit;
            parameters[9].Value = model.UnitPrice;
            parameters[10].Value = model.CostPrice;
            parameters[11].Value = model.LaborCost;
            parameters[12].Value = model.InstallationFee;
            parameters[13].Value = model.CommissioningFee;
            parameters[14].Value = model.ManagementFee;
            parameters[15].Value = model.IndoorInstallationFee;
            parameters[16].Value = model.IndoorLaborCost;
            parameters[17].Value = model.VideoDebugFee;
            parameters[18].Value = model.AudioDebugFee;
            parameters[19].Value = model.Photo;
            parameters[20].Value = model.MaterialID;
            parameters[21].Value = model.MaterialName;
            parameters[22].Value = model.Tag;
            parameters[23].Value = model.State;

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
        public bool Update(DTcms.Model.Sy_Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sy_Material set ");
            strSql.Append("MaterialTypeID=@MaterialTypeID,");
            strSql.Append("MaterialType=@MaterialType,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("BrandEnglish=@BrandEnglish,");
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
            strSql.Append("VideoDebugFee=@VideoDebugFee,");
            strSql.Append("AudioDebugFee=@AudioDebugFee,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("MaterialID=@MaterialID,");
            strSql.Append("MaterialName=@MaterialName,");
            strSql.Append("Tag=@Tag,");
            strSql.Append("State=@State");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MaterialTypeID", SqlDbType.Int,4),
                    new SqlParameter("@MaterialType", SqlDbType.NVarChar,50),
                    new SqlParameter("@Brand", SqlDbType.NVarChar,50),
                    new SqlParameter("@BrandEnglish", SqlDbType.NVarChar,50),
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
                    new SqlParameter("@VideoDebugFee", SqlDbType.Decimal,9),
                    new SqlParameter("@AudioDebugFee", SqlDbType.Decimal,9),
                    new SqlParameter("@Photo", SqlDbType.NVarChar,50),
                    new SqlParameter("@MaterialID", SqlDbType.NVarChar,50),
                    new SqlParameter("@MaterialName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Tag", SqlDbType.NVarChar,20),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MaterialTypeID;
            parameters[1].Value = model.MaterialType;
            parameters[2].Value = model.Brand;
            parameters[3].Value = model.BrandEnglish;
            parameters[4].Value = model.BrandImg;
            parameters[5].Value = model.Mode;
            parameters[6].Value = model.Name;
            parameters[7].Value = model.Description;
            parameters[8].Value = model.Unit;
            parameters[9].Value = model.UnitPrice;
            parameters[10].Value = model.CostPrice;
            parameters[11].Value = model.LaborCost;
            parameters[12].Value = model.InstallationFee;
            parameters[13].Value = model.CommissioningFee;
            parameters[14].Value = model.ManagementFee;
            parameters[15].Value = model.IndoorInstallationFee;
            parameters[16].Value = model.IndoorLaborCost;
            parameters[17].Value = model.VideoDebugFee;
            parameters[18].Value = model.AudioDebugFee;
            parameters[19].Value = model.Photo;
            parameters[20].Value = model.MaterialID;
            parameters[21].Value = model.MaterialName;
            parameters[22].Value = model.Tag;
            parameters[23].Value = model.State;
            parameters[24].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sy_Material ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sy_Material ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public DTcms.Model.Sy_Material GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MaterialTypeID,MaterialType,Brand,BrandEnglish,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,VideoDebugFee,AudioDebugFee,Photo,MaterialID,MaterialName,Tag,State from Sy_Material ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            DTcms.Model.Sy_Material model = new DTcms.Model.Sy_Material();
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
        public DTcms.Model.Sy_Material DataRowToModel(DataRow row)
        {
            DTcms.Model.Sy_Material model = new DTcms.Model.Sy_Material();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["MaterialTypeID"] != null && row["MaterialTypeID"].ToString() != "")
                {
                    model.MaterialTypeID = int.Parse(row["MaterialTypeID"].ToString());
                }
                if (row["MaterialType"] != null)
                {
                    model.MaterialType = row["MaterialType"].ToString();
                }
                if (row["Brand"] != null)
                {
                    model.Brand = row["Brand"].ToString();
                }
                if (row["BrandEnglish"] != null)
                {
                    model.BrandEnglish = row["BrandEnglish"].ToString();
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
                if (row["VideoDebugFee"] != null && row["VideoDebugFee"].ToString() != "")
                {
                    model.VideoDebugFee = decimal.Parse(row["VideoDebugFee"].ToString());
                }
                if (row["AudioDebugFee"] != null && row["AudioDebugFee"].ToString() != "")
                {
                    model.AudioDebugFee = decimal.Parse(row["AudioDebugFee"].ToString());
                }
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
                }
                if (row["MaterialID"] != null)
                {
                    model.MaterialID = row["MaterialID"].ToString();
                }
                if (row["MaterialName"] != null)
                {
                    model.MaterialName = row["MaterialName"].ToString();
                }
                if (row["Tag"] != null)
                {
                    model.Tag = row["Tag"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
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
            strSql.Append("select ID,MaterialTypeID,MaterialType,Brand,BrandEnglish,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,VideoDebugFee,AudioDebugFee,Photo,MaterialID,MaterialName,Tag,State ");
            strSql.Append(" FROM Sy_Material ");
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
            strSql.Append(" ID,MaterialTypeID,MaterialType,Brand,BrandEnglish,BrandImg,Mode,Name,Description,Unit,UnitPrice,CostPrice,LaborCost,InstallationFee,CommissioningFee,ManagementFee,IndoorInstallationFee,IndoorLaborCost,VideoDebugFee,AudioDebugFee,Photo,MaterialID,MaterialName,Tag,State ");
            strSql.Append(" FROM Sy_Material ");
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
            strSql.Append("select count(1) FROM Sy_Material ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Sy_Material T ");
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
			parameters[0].Value = "Sy_Material";
			parameters[1].Value = "ID";
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

