using System;
namespace DTcms.Model
{
    /// <summary>
    /// Q_QuotationTemplateDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Q_QuotationTemplateDetail
    {
        public Q_QuotationTemplateDetail()
        { }
        #region Model
        private int _quotationtemplatedetailid;
        private int? _templateparentid;
        private int? _fk_materialid;
        private int? _detailorder;
        private decimal? _templatedetailquantity;
        /// <summary>
        /// 
        /// </summary>
        public int QuotationTemplateDetailId
        {
            set { _quotationtemplatedetailid = value; }
            get { return _quotationtemplatedetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TemplateParentID
        {
            set { _templateparentid = value; }
            get { return _templateparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_materialID
        {
            set { _fk_materialid = value; }
            get { return _fk_materialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DetailOrder
        {
            set { _detailorder = value; }
            get { return _detailorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TemplateDetailQuantity
        {
            set { _templatedetailquantity = value; }
            get { return _templatedetailquantity; }
        }
        #endregion Model

    }
}

