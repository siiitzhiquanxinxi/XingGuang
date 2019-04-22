using System;
namespace DTcms.Model
{
    /// <summary>
    /// Q_QuotationTemplate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Q_QuotationTemplate
    {
        public Q_QuotationTemplate()
        { }
        #region Model
        private int _quotationtemplateid;
        private string _quotationtemplatename;
        private string _quotationtemplatetype;
        private int? _quotationtemplatetypeid;
        private string _quotationtemplatemainbrand;
        private string _quotationtemplatedescription;
        private string _quotationtemplatescenario;
        private string _quotationtemplatenotes;
        private int? _createby;
        private DateTime? _createdate;
        private int? _quotationtemplatestate;
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
        private string _termptag;
        /// <summary>
        /// 
        /// </summary>
        public int QuotationTemplateId
        {
            set { _quotationtemplateid = value; }
            get { return _quotationtemplateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuotationTemplateName
        {
            set { _quotationtemplatename = value; }
            get { return _quotationtemplatename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuotationTemplateType
        {
            set { _quotationtemplatetype = value; }
            get { return _quotationtemplatetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? QuotationTemplateTypeId
        {
            set { _quotationtemplatetypeid = value; }
            get { return _quotationtemplatetypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuotationTemplateMainBrand
        {
            set { _quotationtemplatemainbrand = value; }
            get { return _quotationtemplatemainbrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuotationTemplateDescription
        {
            set { _quotationtemplatedescription = value; }
            get { return _quotationtemplatedescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuotationTemplateScenario
        {
            set { _quotationtemplatescenario = value; }
            get { return _quotationtemplatescenario; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuotationTemplateNotes
        {
            set { _quotationtemplatenotes = value; }
            get { return _quotationtemplatenotes; }
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
        public int? QuotationTemplateState
        {
            set { _quotationtemplatestate = value; }
            get { return _quotationtemplatestate; }
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
        public string TermpTag
        {
            set { _termptag = value; }
            get { return _termptag; }
        }
        #endregion Model

    }
}

