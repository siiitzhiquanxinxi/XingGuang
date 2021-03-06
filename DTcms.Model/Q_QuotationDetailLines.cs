﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// Q_QuotationDetailLines:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Q_QuotationDetailLines
    {
        public Q_QuotationDetailLines()
        { }
        #region Model
        private int _q_quotationdetaillinesid;
        private int? _fk_quotationdetailtypeid;
        private int? _fk_lineid;
        private string _linebrand;
        private string _linebrandimg;
        private string _linemode;
        private string _linename;
        private string _linedescription;
        private string _lineunit;
        private string _lineunitprice;
        private string _linephoto;
        private decimal? _linetotalcount;
        private decimal? _linetotalamount;
        /// <summary>
        /// 
        /// </summary>
        public int Q_QuotationDetailLinesId
        {
            set { _q_quotationdetaillinesid = value; }
            get { return _q_quotationdetaillinesid; }
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
        public int? FK_LineId
        {
            set { _fk_lineid = value; }
            get { return _fk_lineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineBrand
        {
            set { _linebrand = value; }
            get { return _linebrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineBrandImg
        {
            set { _linebrandimg = value; }
            get { return _linebrandimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineMode
        {
            set { _linemode = value; }
            get { return _linemode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineName
        {
            set { _linename = value; }
            get { return _linename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineDescription
        {
            set { _linedescription = value; }
            get { return _linedescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineUnit
        {
            set { _lineunit = value; }
            get { return _lineunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineUnitPrice
        {
            set { _lineunitprice = value; }
            get { return _lineunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinePhoto
        {
            set { _linephoto = value; }
            get { return _linephoto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LineTotalcount
        {
            set { _linetotalcount = value; }
            get { return _linetotalcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LineTotalamount
        {
            set { _linetotalamount = value; }
            get { return _linetotalamount; }
        }
        #endregion Model

    }
}

