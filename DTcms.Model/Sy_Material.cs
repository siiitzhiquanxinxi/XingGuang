using System;
namespace DTcms.Model
{
    /// <summary>
    /// Sy_Material:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sy_Material
    {
        public Sy_Material()
        { }
        #region Model
        private int _id;
        private int? _materialtypeid;
        private string _materialtype;
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
        private decimal? _videodebugfee;
        private decimal? _audiodebugfee;
        private string _photo;
        private string _materialid;
        private string _materialname;
        private string _tag;
        private int? _state;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MaterialTypeID
        {
            set { _materialtypeid = value; }
            get { return _materialtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialType
        {
            set { _materialtype = value; }
            get { return _materialtype; }
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
        public decimal? VideoDebugFee
        {
            set { _videodebugfee = value; }
            get { return _videodebugfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AudioDebugFee
        {
            set { _audiodebugfee = value; }
            get { return _audiodebugfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialID
        {
            set { _materialid = value; }
            get { return _materialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag
        {
            set { _tag = value; }
            get { return _tag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}

