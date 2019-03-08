using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL
{
    /// <summary>
	/// Sy_Material_Detail
	/// </summary>
	public partial class Sy_Material_Detail
    {
        private readonly DTcms.DAL.Sy_Material_Detail dal = new DTcms.DAL.Sy_Material_Detail();
        public Sy_Material_Detail()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string InnerID)
        {
            return dal.Exists(InnerID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.Sy_Material_Detail model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 增加DataTable数据
        /// </summary>
        public bool Add(DataTable dt)
        {
            return dal.Add(dt);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Sy_Material_Detail model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string InnerID)
        {

            return dal.Delete(InnerID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string InnerIDlist)
        {
            return dal.DeleteList(InnerIDlist);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeletebyWhere(string Where)
        {

            return dal.DeletebyWhere(Where);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Sy_Material_Detail GetModel(string InnerID)
        {

            return dal.GetModel(InnerID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Sy_Material_Detail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Sy_Material_Detail> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.Sy_Material_Detail> modelList = new List<DTcms.Model.Sy_Material_Detail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.Sy_Material_Detail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
