using System;
namespace DTcms.Model
{
    /// <summary>
    /// Q_QuotationDetailType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Q_QuotationDetailType
    {
        public Q_QuotationDetailType()
        { }
        #region Model
        private int _quotationdetailtypeid;
        private int? _fk_parentquotationlistid;
        private int? _fk_materialtypeid;
        private string _systemtypename;
        private string _systemtypedes;
        private decimal? _ruodiananzhuangfee;
        private decimal? _qicaianzhuangfee;
        private decimal? _xitongtiaoshifee;
        private decimal? _xiangmuguanlifee;
        private decimal? _videodebugfee;
        private decimal? _audiodebugfee;
        private decimal? _aumaterialfee;
        private string _ruodiananzhuangdes;
        private string _qicaianzhuangdes;
        private string _xitongtiaoshides;
        private string _xiangmuguanlides;
        private string _videodebugdes;
        private string _audiodebugdes;
        private string _aumaterialdes;
        private int? _typeorder;
        /// <summary>
        /// 
        /// </summary>
        public int QuotationDetailTypeId
        {
            set { _quotationdetailtypeid = value; }
            get { return _quotationdetailtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_ParentQuotationListId
        {
            set { _fk_parentquotationlistid = value; }
            get { return _fk_parentquotationlistid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_MaterialTypeId
        {
            set { _fk_materialtypeid = value; }
            get { return _fk_materialtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SystemTypeName
        {
            set { _systemtypename = value; }
            get { return _systemtypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SystemTypeDes
        {
            set { _systemtypedes = value; }
            get { return _systemtypedes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RuodiananzhuangFee
        {
            set { _ruodiananzhuangfee = value; }
            get { return _ruodiananzhuangfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QicaianzhuangFee
        {
            set { _qicaianzhuangfee = value; }
            get { return _qicaianzhuangfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XitongtiaoshiFee
        {
            set { _xitongtiaoshifee = value; }
            get { return _xitongtiaoshifee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XiangmuguanliFee
        {
            set { _xiangmuguanlifee = value; }
            get { return _xiangmuguanlifee; }
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
        public decimal? AuMaterialFee
        {
            set { _aumaterialfee = value; }
            get { return _aumaterialfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RuodiananzhuangDes
        {
            set { _ruodiananzhuangdes = value; }
            get { return _ruodiananzhuangdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QicaianzhuangDes
        {
            set { _qicaianzhuangdes = value; }
            get { return _qicaianzhuangdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XitongtiaoshiDes
        {
            set { _xitongtiaoshides = value; }
            get { return _xitongtiaoshides; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XiangmuguanliDes
        {
            set { _xiangmuguanlides = value; }
            get { return _xiangmuguanlides; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VideoDebugDes
        {
            set { _videodebugdes = value; }
            get { return _videodebugdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AudioDebugDes
        {
            set { _audiodebugdes = value; }
            get { return _audiodebugdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuMaterialDes
        {
            set { _aumaterialdes = value; }
            get { return _aumaterialdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeOrder
        {
            set { _typeorder = value; }
            get { return _typeorder; }
        }
        #endregion Model

    }
}

