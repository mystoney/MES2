namespace MES.module.BLL.StyleFromZYQ
{
    /// <summary>
    /// 款式打印数据
    /// </summary>
    public class T_Style_Item_Option_Print
    {
        private string style_no;
        private string item_no;
        private string option_no;
        /// <summary>
        /// 初始化
        /// </summary>
        public T_Style_Item_Option_Print()
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
        /// 分组号
        /// </summary>
        public string Group_No { get; set; }


        /// <summary>
        /// 分组名
        /// </summary>
        public string Group_Name { get; set; }


        /// <summary>
        /// 打印内容
        /// </summary>
        public string des { get; set; }




        #endregion


        #region 扩展信息


        /// <summary>
        /// 款式属性值类
        /// </summary>
        public virtual T_Style_Item_Option T_Style_Item_Option { get; set; }


        #endregion
    }
}
