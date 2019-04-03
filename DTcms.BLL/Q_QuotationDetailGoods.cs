using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DTcms.BLL
{
    /// <summary>
    /// Q_QuotationDetailGoods
    /// </summary>
    public partial class Q_QuotationDetailGoods
    {
        private readonly DTcms.DAL.Q_QuotationDetailGoods dal = new DTcms.DAL.Q_QuotationDetailGoods();
        public Q_QuotationDetailGoods()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Q_QuotationDetailGoods)
        {
            return dal.Exists(Q_QuotationDetailGoods);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Q_QuotationDetailGoods model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Q_QuotationDetailGoods model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Q_QuotationDetailGoods)
        {

            return dal.Delete(Q_QuotationDetailGoods);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Q_QuotationDetailGoodslist)
        {
            return dal.DeleteList(Q_QuotationDetailGoodslist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Q_QuotationDetailGoods GetModel(int Q_QuotationDetailGoods)
        {

            return dal.GetModel(Q_QuotationDetailGoods);
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
        public List<DTcms.Model.Q_QuotationDetailGoods> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Q_QuotationDetailGoods> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.Q_QuotationDetailGoods> modelList = new List<DTcms.Model.Q_QuotationDetailGoods>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.Q_QuotationDetailGoods model;
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