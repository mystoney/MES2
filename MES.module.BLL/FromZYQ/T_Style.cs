
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.module.BLL.StyleFromZYQ
{
    /// <summary>
    /// 款式选项类
    /// </summary>
    public class T_Style
    {
        private string style_no;
        /// <summary>
        /// 初始化
        /// </summary>
        public T_Style()
        {

            T_Style_Item = new HashSet<T_Style_Item>();
        }


        #region 字段信息

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 款式编号
        /// </summary>
        public string Style_No 
        {
            get { return style_no; }
            set { style_no = value.ToUpper().ToString(); } 
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        public Product_Category Product_Category { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime Input_Date { get; set; }

        /// <summary>
        /// 导入的方式 0-接口导入，1-excel导入
        /// </summary>
        public Cp_Style_State Input_Mod { get; set; }



        /// <summary>
        /// 款式基本价格
        /// </summary>
        public decimal Price { get; set; }



        #endregion 主表字段




        #region 扩展信息

        /// <summary>
        /// 款式属性
        /// </summary>
        public virtual ICollection<T_Style_Item> T_Style_Item { get; set; }

        #endregion
    }


  

    /// <summary>
    /// 订单导入方式
    /// </summary>
    public enum Cp_Style_State
    {
        /// <summary>
        /// 
        /// </summary>
        接口导入 = 0,
        /// <summary>
        /// 
        /// </summary>
        Excel导入 = 1,
        /// <summary>
        /// 
        /// </summary>
        手工录入 = 2

    }

    /// <summary>
    /// 产品类型
    /// </summary>
    public enum Product_Category
    {
        /// <summary>
        /// 
        /// </summary>
        服装=1,
        /// <summary>
        /// 
        /// </summary>
        睡袋=2
    }
}
