using MES.module.BLL.StyleFromZYQ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MES.module.DAL.StyleDal.StyleDal;
using MES.module.BLL;

namespace MES.module.BLL
{
    public class StyleBll
    {
        /// <summary>
        /// 初始化查询Style
        /// </summary>
        /// <returns>List<Station></returns>
        public DataTable Style_SelectStyleAll()
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.getStyleList();
        }
        public DataTable Style_SelectItemAll(String Style_No)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.getItemList(Style_No);
        }
        public DataTable Style_SelectOptionAll(String Style_No, string Item_No)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.getOptionList(Style_No, Item_No);
        }
        public DataTable Style_KeyOptionAll(String Style_No)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.GetKeyOptionList(Style_No);
        }


        public int SaveOption(DataTable dt_Add, DataSet ds, string Style_No)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();

            return sd.NewStyleOption(dt_Add, ds, Style_No);


        }

        public DataTable Style_SelectSQLOptionList(String Style_No)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.GetSQLOptionList(Style_No);
        }

        public bool Style_CompareDataTable(DataTable dtA, DataTable dtB)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();

            return sd.CompareDataTable(dtA, dtB);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtA">行多的表/param>
        /// <param name="dtB">行少的表</param>
        /// <returns></returns>
        public DataTable DTDifference(DataTable dtA, DataTable dtB)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.DTDifference(dtA, dtB);
        }



        public enum StyleAddOrUpdate
        {
            新增 = 1,
            更新 = 0,
        };


        public DataTable GetStyleListFormZYQ()
        {
            DataTable dt_StyleItem = new DataTable();
            try
            {
                List<T_Style> t_Style_list = new List<T_Style>();
                List<T_Style_Item_Option> t_Style_Item_Option_List = new List<T_Style_Item_Option>();
                Return_Message return_message = new Return_Message();

                string ss = Helper.Http.Http.HttpGet($@"http://172.16.1.83:8007/api/t_style");
                return_message = Helper.Json.JsonHelper.DeserializeJsonToObject<Return_Message>(ss);

                if (return_message.State == Return_Message.Return_State.Error)
                {
                    throw new Exception(return_message.Message);
                }

                t_Style_list = Helper.Json.JsonHelper.DeserializeJsonToList<T_Style>(return_message.Return_Value);

                var qq = t_Style_list.SelectMany(a => a.T_Style_Item)
                        .SelectMany(b => b.T_Style_Item_Option)
                        .Select(c => new
                        {
                            style_no = c.Style_No,
                            item_no = c.Item_No,
                            item_name = t_Style_list.SelectMany(a => a.T_Style_Item).Where(b => b.Style_No == c.Style_No && b.Item_No == c.Item_No).FirstOrDefault().Name,
                            option_no = c.Option_No,
                            option_name = c.Name

                        })
                        .ToList();
                dt_StyleItem = Helper.Transformation.Transformation.DataConvert.ListToDataTable(qq);
            }
            catch { }
            return dt_StyleItem;
        }



        #region ZYQ返回信息的类
        /// <summary>
        /// 返回信息的类
        /// </summary>
        public class Return_Message
        {

            /// <summary>
            /// 构造函数
            /// </summary>
            public Return_Message()
            {
            }


            /// <summary>
            /// 返回的状态
            /// </summary>
            public Return_State State { get; set; }

            /// <summary>
            /// 返回的值的JSON对象
            /// </summary>
            public string Return_Value { get; set; }
            /// <summary>
            /// 返回的信息
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// 返回信息类中信息状态用的枚举
            /// </summary>
            public enum Return_State
            {
                /// <summary>
                /// OK
                /// </summary>
                OK = 1,
                /// <summary>
                /// Error
                /// </summary>
                Error = 2
            }

        }
        #endregion





        public DataSet GetItemCombination(DataTable dt_style)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.GetItemCombination(dt_style);

        }



        /// <summary>
        /// 加载指定款号的组合清单
        /// </summary>
        /// <param name="style_no">款号</param>
        /// <param name="needspacerow">0=ComboBox需要空行 1=Datagridview不需要空行</param>
        /// <returns></returns>
        public DataTable getCombinationList(string style_no, int needspacerow)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            return sd.getCombinationList(style_no, needspacerow);
        }



        /// <summary>
        /// 通过款号获取到此款式的关键选项
        /// </summary>
        /// <param name="Style_no">款号</param>
        /// <returns>此款式的关键选项</returns>
        public DataTable GetStyleItemList(string Style_no)
        {
            DataTable dt = new DataTable();
            DAL.StyleDal.StyleDal ds = new DAL.StyleDal.StyleDal();
            dt = ds.GetStyleItemList(Style_no);
            return dt;
        }
        /// <summary>
        /// 先判断ItemList.Count不等于0再调用
        /// 根据订单的选项值取得符合条件的组合
        /// </summary>
        /// <param name="Style_no"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public DataTable GetOrderCombination(String Style_no, List<string> ItemList)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            DataTable dt = sd.GetOrderCombination(Style_no, ItemList);
            return dt;
        }

        /// <summary>
        /// 先判断ItemList.Count不等于0再调用
        /// 根据订单的选项值取得符合条件的组合
        /// </summary>
        /// <param name="Style_no"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public int GetOrderCombination(String Style_no, string memo_no)
        {
            DAL.StyleDal.StyleDal sd = new DAL.StyleDal.StyleDal();
            int Combination_no = sd.GetOrderCombination(Style_no, memo_no);
            return Combination_no;
        }

    }
}
