using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// Q_QuotationList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Q_QuotationList
    {
        public Q_QuotationList()
        { }
        #region Model
        private int _quotationlistid;
        private string _quotationlistnum;
        private int? _fk_parentprogramid;
        private int? _createby;
        private DateTime? _createdate;
        private int? _quotationliststate;
        /// <summary>
        /// 
        /// </summary>
        public int QuotationListId
        {
            set { _quotationlistid = value; }
            get { return _quotationlistid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuotationListNum
        {
            set { _quotationlistnum = value; }
            get { return _quotationlistnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_ParentProgramId
        {
            set { _fk_parentprogramid = value; }
            get { return _fk_parentprogramid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreateBy
        {
            set { _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? QuotationListState
        {
            set { _quotationliststate = value; }
            get { return _quotationliststate; }
        }
        #endregion Model

    }
}
