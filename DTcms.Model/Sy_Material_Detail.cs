using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// Sy_Material_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class Sy_Material_Detail
    {
        public Sy_Material_Detail()
        { }
        #region Model
        private string _innerid;
        private int _forinnerid;
        private string _id;
        private string _brand;
        private string _mode;
        private string _name;
        private string _description;
        private string _unit;
        private decimal? _num;
        /// <summary>
        /// 
        /// </summary>
        public string InnerID
        {
            set { _innerid = value; }
            get { return _innerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ForInnerID
        {
            set { _forinnerid = value; }
            get { return _forinnerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
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
        public decimal? Num
        {
            set { _num = value; }
            get { return _num; }
        }
        #endregion Model

    }
}
