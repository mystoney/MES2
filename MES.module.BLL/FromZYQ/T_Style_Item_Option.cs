
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.module.BLL.StyleFromZYQ
{
    /// <summary>
    /// 款式属性值类
    /// </summary>
    public class T_Style_Item_Option
    {
        private string style_no;
        private string item_no;
        private string option_no;
        /// <summary>
        /// 初始化
        /// </summary>
        public T_Style_Item_Option()
        {

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
        /// 定制化属性选项编号
        /// </summary>
        public string Option_No
        {
            get { return option_no; }
            set { option_no = value.ToUpper().ToString(); }
        }



        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 选项类型（普通选项为null，(1-文字,2-图片)）
        /// </summary>
        public int? Input_type { get; set; }


        /// <summary>
        /// 文字图案内容（文字为具体内容，图片为链接）
        /// </summary>
        public string Input_Content { get; set; }


        /// <summary>
        /// 款式基本价格
        /// </summary>
        public decimal Price { get; set; }


        #endregion


        #region 扩展信息

        /// <summary>
        /// 款式属性值类
        /// </summary>
        public virtual T_Style_Item T_Style_Item { get; set; }


        /// <summary>
        /// 打印内容
        /// </summary>
        public virtual T_Style_Item_Option_Print T_Style_Item_Option_Print { get; set; }

        #endregion
    }


}
