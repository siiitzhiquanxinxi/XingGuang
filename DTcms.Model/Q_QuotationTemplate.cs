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
        private decimal? _xitongtiaoshifee;
        private decimal? _xiangmuguanlifee;
        private decimal? _qicaianzhuangfee;
        private string _ruodiananzhuangdes;
        private string _xitongtiaoshides;
        private string _xiangmuguanlides;
        private string _qicaianzhuangdes;
        private string _ruodiananzhuangpic;
        private string _xitongtiaoshipic;
        private string _xiangmuguanlipic;
        private string _qicaianzhuangpic;
        private string _temptag;
        private int? _temporder;
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
        public decimal? QicaianzhuangFee
        {
            set { _qicaianzhuangfee = value; }
            get { return _qicaianzhuangfee; }
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
        public string QicaianzhuangDes
        {
            set { _qicaianzhuangdes = value; }
            get { return _qicaianzhuangdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RuodiananzhuangPic
        {
            set { _ruodiananzhuangpic = value; }
            get { return _ruodiananzhuangpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XitongtiaoshiPic
        {
            set { _xitongtiaoshipic = value; }
            get { return _xitongtiaoshipic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XiangmuguanliPic
        {
            set { _xiangmuguanlipic = value; }
            get { return _xiangmuguanlipic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QicaianzhuangPic
        {
            set { _qicaianzhuangpic = value; }
            get { return _qicaianzhuangpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TempTag
        {
            set { _temptag = value; }
            get { return _temptag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TempOrder
        {
            set { _temporder = value; }
            get { return _temporder; }
        }
        #endregion Model

    }
}

