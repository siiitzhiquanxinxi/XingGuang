using System;
namespace DTcms.Model
{
    /// <summary>
    /// Q_QuotationDetailGoods:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Q_QuotationDetailGoods
    {
        public Q_QuotationDetailGoods()
        { }
        #region Model
        private int _q_quotationdetailgoodsid;
        private int? _fk_quotationdetailtypeid;
        private int? _fk_materialid;
        private int? _detailorder;
        private decimal? _goodsquantity;
        private string _brand;
        private string _brandenglish;
        private string _brandimg;
        private string _mode;
        private string _name;
        private string _description;
        private string _unit;
        private decimal? _unitprice;
        private decimal? _costprice;
        private decimal? _laborcost;
        private decimal? _installationfee;
        private decimal? _commissioningfee;
        private decimal? _managementfee;
        private decimal? _indoorinstallationfee;
        private decimal? _indoorlaborcost;
        private string _photo;
        /// <summary>
        /// 
        /// </summary>
        public int Q_QuotationDetailGoodsID
        {
            set { _q_quotationdetailgoodsid = value; }
            get { return _q_quotationdetailgoodsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_QuotationDetailTypeId
        {
            set { _fk_quotationdetailtypeid = value; }
            get { return _fk_quotationdetailtypeid; }
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
        public decimal? GoodsQuantity
        {
            set { _goodsquantity = value; }
            get { return _goodsquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BrandEnglish
        {
            set { _brandenglish = value; }
            get { return _brandenglish; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BrandImg
        {
            set { _brandimg = value; }
            get { return _brandimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mode
        {
            set { _mode = value; }
            get { return _mode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? UnitPrice
        {
            set { _unitprice = value; }
            get { return _unitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CostPrice
        {
            set { _costprice = value; }
            get { return _costprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LaborCost
        {
            set { _laborcost = value; }
            get { return _laborcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? InstallationFee
        {
            set { _installationfee = value; }
            get { return _installationfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CommissioningFee
        {
            set { _commissioningfee = value; }
            get { return _commissioningfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ManagementFee
        {
            set { _managementfee = value; }
            get { return _managementfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? IndoorInstallationFee
        {
            set { _indoorinstallationfee = value; }
            get { return _indoorinstallationfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? IndoorLaborCost
        {
            set { _indoorlaborcost = value; }
            get { return _indoorlaborcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        #endregion Model

    }
}

