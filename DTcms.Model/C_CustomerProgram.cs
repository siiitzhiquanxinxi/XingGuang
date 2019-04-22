using System;
namespace DTcms.Model
{
    /// <summary>
    /// C_CustomerProgram:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class C_CustomerProgram
    {
        public C_CustomerProgram()
        { }
        #region Model
        private int _customerid;
        private string _customernum;
        private string _customername;
        private string _customertel;
        private string _customeraddress;
        private string _programareanum;
        private DateTime? _createdate;
        private int? _createby;
        private string _salepeople;
        private string _bussinesspeople;
        private string _customersource;
        private int? _customerstate;
        /// <summary>
        /// 
        /// </summary>
        public int CustomerId
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerNum
        {
            set { _customernum = value; }
            get { return _customernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerTel
        {
            set { _customertel = value; }
            get { return _customertel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerAddress
        {
            set { _customeraddress = value; }
            get { return _customeraddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProgramAreaNum
        {
            set { _programareanum = value; }
            get { return _programareanum; }
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
        public int? CreateBy
        {
            set { _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SalePeople
        {
            set { _salepeople = value; }
            get { return _salepeople; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BussinessPeople
        {
            set { _bussinesspeople = value; }
            get { return _bussinesspeople; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerSource
        {
            set { _customersource = value; }
            get { return _customersource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CustomerState
        {
            set { _customerstate = value; }
            get { return _customerstate; }
        }
        #endregion Model

    }
}

