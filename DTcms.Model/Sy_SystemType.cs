using System;
namespace DTcms.Model
{
    /// <summary>
    /// Sy_SystemType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sy_SystemType
    {
        public Sy_SystemType()
        { }
        #region Model
        private int _systemtypeid;
        private string _systemtypename;
        private string _hasmaterialtype;
        private decimal? _xitongtiaoshifee;
        private string _xitongtiaoshides;
        private string _xitongtiaoshipic;
        private decimal? _xiangmuguanlifee;
        private string _xiangmuguanlides;
        private string _xiangmuguanlipic;
        private decimal? _qicaianzhuangfee;
        private string _qicaianzhuangdes;
        private string _qicaianzhuangpic;
        private string _ruodiananzhuangdes;
        private string _ruodiananzhuangpic;
        /// <summary>
        /// 
        /// </summary>
        public int SystemTypeID
        {
            set { _systemtypeid = value; }
            get { return _systemtypeid; }
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
        public string HasMaterialType
        {
            set { _hasmaterialtype = value; }
            get { return _hasmaterialtype; }
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
        public string XitongtiaoshiDes
        {
            set { _xitongtiaoshides = value; }
            get { return _xitongtiaoshides; }
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
        public decimal? XiangmuguanliFee
        {
            set { _xiangmuguanlifee = value; }
            get { return _xiangmuguanlifee; }
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
        public string XiangmuguanliPic
        {
            set { _xiangmuguanlipic = value; }
            get { return _xiangmuguanlipic; }
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
        public string QicaianzhuangDes
        {
            set { _qicaianzhuangdes = value; }
            get { return _qicaianzhuangdes; }
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
        public string RuodiananzhuangDes
        {
            set { _ruodiananzhuangdes = value; }
            get { return _ruodiananzhuangdes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RuodiananzhuangPic
        {
            set { _ruodiananzhuangpic = value; }
            get { return _ruodiananzhuangpic; }
        }
        #endregion Model

    }
}

