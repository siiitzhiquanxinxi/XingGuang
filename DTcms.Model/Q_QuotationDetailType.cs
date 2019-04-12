﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private string _materialtypename;
        private decimal? _ruodiananzhuangfee;
        private decimal? _qicaianzhuangfee;
        private decimal? _xitongtiaoshifee;
        private decimal? _xiangmuguanlifee;
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
        public string MaterialTypeName
        {
            set { _materialtypename = value; }
            get { return _materialtypename; }
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
        #endregion Model

    }
}