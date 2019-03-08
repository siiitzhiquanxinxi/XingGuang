using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// Sy_MaterialType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class Sy_MaterialType
    {
        public Sy_MaterialType()
        { }
        #region Model
        private int _id;
        private string _materialtype;
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
        public string MaterialType
        {
            set { _materialtype = value; }
            get { return _materialtype; }
        }
        #endregion Model

    }
}
