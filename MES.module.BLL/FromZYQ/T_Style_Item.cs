
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.module.BLL.StyleFromZYQ
{
    /// <summary>
    /// 款式属性模型
    /// </summary>
   public class T_Style_Item
    {

        private string style_no;
        private string item_no;

        /// <summary>
        /// 初始化
        /// </summary>
        public T_Style_Item()
        {
            T_Style_Item_Option = new HashSet<T_Style_Item_Option>();

        }

        #region 字段信息
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }





        /// <summary>
        /// 款式号
        /// </summary>
        public string Style_No
        {
            get { return style_no; }
            set { style_no = value.ToUpper().ToString(); }
        }



        /// <summary>
        /// 定制属性编号
        /// </summary>
        public string Item_No
        {
            get { return item_no; }
            set { item_no = value.ToUpper().ToString(); }
        }



        /// <summary>
        /// 部件名
        /// </summary>
        public string Name { get; set; }




        /// <summary>
        /// 属性分组
        /// </summary>
        public string Group_No { get; set; }
        #endregion


        #region 扩展信息

        /// <summary>
        /// 款式类
        /// </summary>
        public virtual T_Style T_Style { get; set; }


        /// <summary>
        /// 款式属性值类
        /// </summary>
        public virtual ICollection<T_Style_Item_Option> T_Style_Item_Option { get; set; }
        #endregion
    }

   

}
