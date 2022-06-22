using MES.module.DAL.OrderDal;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MES.module.BLL
{
    public class OrderBll    
    {
        #region 老版本代码
        /// <summary>
        /// 老版本-新建工单
        /// </summary>
        /// <param name="Order_No"></param>
        /// <param name="SchemeNo"></param>
        /// <param name="Order_qty"></param>
        /// <returns></returns>
        public int SaveOrder(string Order_No, string SchemeNo, int Order_qty)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            int i = 0;
            od.NewOrder(Order_No, SchemeNo, Order_qty);
            i = 1;
            return i;
        }


        /// <summary>
        /// 老版本-NewOrder
        /// </summary>
        /// <param name="StageProduct"></param>
        /// <returns></returns>
        public DataTable GetOrderList(int StageProduct)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            DataTable dt = new DataTable();
            dt=od.GetOrderList(StageProduct);
            return dt;
        }

        /// <summary>
        /// 老版本-NewOrder
        /// </summary>
        /// <param name="Order_No"></param>
        /// <returns></returns>
        public bool OrderBeAllowed(string Order_No)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            bool available = false;
            if (od.OrderNumberOfExisting(Order_No) == 0)
            {
                available = true;
            }
            return available;
        }
        #endregion



        #region 新版-保存ZYQ提供的工单信息
        public int SaveOrderZYQ(DataTable dt)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            return od.SaveOrderZYQ(dt);
        }
        #endregion

        #region  新版-加载订单-ZYQ
        /// <summary>
        /// 加载订单
        /// </summary>
        /// <param name="StageProduct">1测试订单 =0正式订单</param>
        /// <returns></returns>
        public DataTable nMES_GetOrderList_ZYQ(int customer_state)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            DataTable dt = od.nMES_GetOrderList_ZYQ(customer_state);
            return dt;
        }
        #endregion

        #region  新版-加载订单-MES
        /// <summary>
        /// 加载订单
        /// </summary>
        /// <param name="StageProduct">1测试订单 =2正式订单</param>
        /// <returns></returns>
        public DataTable nMES_GetOrderList_MES(int customer_state, bool ContainUPSDone,string SelectOrderDate)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            DataTable dt = od.nMES_GetOrderList_MES(customer_state, ContainUPSDone,SelectOrderDate);
            return dt;
        }
        #endregion

        #region 新版-加载工单选项OrderItemOptionZYQ
        /// <summary>
        /// 接收到的订单选项表
        /// </summary>
        public class OrderItemOptionZYQ
        {
            public string Item_No { get; set; }
            public string Option_No { get; set; }
            public string Item_Name { get; set; }
            public string Option_Name { get; set; }
        }



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

        #region 新版-更新OpListNo，UPS_prun，SchemeNo，Combination_no,GetProductList,OrderLock
        /// <summary>
        /// 更新OpListNo，UPS_prun，SchemeNo，Combination_no
        /// </summary>
        /// <param name="字段名">要更改的字段</param>
        /// <param name="字段值">值</param>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">行号</param>
        /// <returns></returns>
        public int UpdateOrderInfo(string 字段名, int 字段值, string job_num, int suffix)
        {
            try
            {
                DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
                return od.UpdateOrderInfo(字段名, 字段值, job_num, suffix);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        #endregion

        #region 新版-更新nMES_Order_detail_ProductList，PushState_CAOBO，PushState_JINGYUAN
        /// <summary>
        /// 更新nMES_Order_detail_ProductList，PushState_CAOBO，PushState_JINGYUAN
        /// </summary>
        /// <param name="id">产品清单行id</param>
        /// <returns>1成功 0不成功</returns>
        public int UpdateProductListInfo(string 字段名,int 字段值, int id)
        {
            try
            {
                DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
                return od.UpdateProductListInfo(字段名, 字段值, id);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        #endregion

        #region 新版-获取并保存工单-主表-ALL
        /// <summary>
        /// 获取到ZYQmaster中包含，但是MESmaster中没有的工单 
        /// 款号已维护的同时保存选项 没维护款号的只保存工单其他信息
        /// </summary>
        public void InsertOrderMaster()
        {
            OrderDal od = new OrderDal();
            DataTable dt_OrderMaster = od.GetZYQOrderInfo();//ZYQmaster中包含，但是MESmaster中没有的工单


            if (dt_OrderMaster.Rows.Count > 0)
            {    
                //获取到Order_Master表结构
                DataTable dt_InsertToMesOrderMaster = od.GetMESOrderInfo();//主表结构
                //DataTable dt_Insert_Order_detail_OptionList = od.GetMESOrderOptionListInfo();//OptionList结构
                //如果有需要保存的工单：
                for (int j = 0; j < dt_OrderMaster.Rows.Count; j++)
                {
                    ////判断款号是否已经维护 如果没有，跳过此行
                    //StyleBll sb = new StyleBll();
                    //string style_no = dt_OrderMaster.Rows[j]["Style_num"].ToString().Trim();
                    //DataTable dt = sb.GetStyleItemList(style_no);//获取到此款号必须的选项
                    //if (dt.Rows.Count != 0)//如果款号已维护
                    //{
                    //    string order_no = dt_OrderMaster.Rows[j]["job_num"].ToString().Trim() + "-" + dt_OrderMaster.Rows[j]["suffix"].ToString().Trim().PadLeft(3, '0');
                    //    Return_Message rm = new Return_Message();
                    //    string getordermodel = $@"http://172.16.1.83:8024/api/CpOrderSubDetailByJobNum/" + order_no;
                    //    rm = Helper.Json.JsonHelper.DeserializeJsonToObject<Return_Message>(Helper.Http.Http.HttpGet(getordermodel));
                    //    if (rm.State == Return_Message.Return_State.Error)
                    //    {
                    //        throw new Exception(rm.Message);
                    //    }
                    //    //DataTable dt = Helper.Json.JsonHelper.DeserializeJsonToObject<DataTable>(rm.Return_Value);
                    //    OrderItemOptionZYQ o = new OrderItemOptionZYQ();
                    //    List<OrderItemOptionZYQ> ol = new List<OrderItemOptionZYQ>();
                    //    ol = Helper.Json.JsonHelper.DeserializeJsonToObject<List<OrderItemOptionZYQ>>(rm.Return_Value);
                    //    string memo_no = "";
                    //    string memo_name = "";
                    //    List<string> lst = new List<string>();
                    //    for (int k = 0; k < dt.Rows.Count; k++)
                    //    {
                    //        string item_no = dt.Rows[k][0].ToString();
                    //        string option_no = ol.Find(x => x.Item_No == item_no).Option_No;
                    //        memo_no = memo_no + item_no + "=" + option_no + " ";
                    //        string item_name = ol.Find(x => x.Item_No == item_no).Item_Name;
                    //        string option_name = ol.Find(x => x.Item_No == item_no).Option_Name;
                    //        memo_name = memo_name + item_name + "=" + option_name + " ";
                    //        //选项值组合    
                    //        lst.Add(item_no + "=" + option_no);
                    //    }
                    //    //获取到选项符合的组合号
                    //    int Combination_no = sb.GetOrderCombination(style_no, memo_no);
                    //    DataRow dr = dt_InsertToMesOrderMaster.NewRow();
                    //    dr["job_num"] = dt_OrderMaster.Rows[j]["job_num"].ToString().Trim();
                    //    dr["suffix"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["suffix"].ToString().Trim());
                    //    //dr["order_date"] = "20" + dt_OrderMaster.Rows[j]["job_num"].ToString().Trim().Substring(1, 2) + "-" + dt_OrderMaster.Rows[j]["job_num"].ToString().Trim().Substring(3, 2) + "-" + dt_OrderMaster.Rows[j]["job_num"].ToString().Trim().Substring(5, 2);
                    //    dr["input_date"] = DateTime.Today;
                    //    dr["style_no"] = dt_OrderMaster.Rows[j]["style_num"].ToString().Trim();
                    //    dr["style_des"] = dt_OrderMaster.Rows[j]["style_des"].ToString().Trim();
                    //    dr["Combination_no"] = Combination_no;
                    //    dr["job_qty"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["job_qty"].ToString().Trim());
                    //    dr["manhour"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["manhour"].ToString().Trim());
                    //    dr["memo_no"] = memo_no;
                    //    dr["memo_name"] = memo_name;
                    //    dr["customer_state"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["customer_state"].ToString().Trim());
                    //    dr["customer_state_des"] = dt_OrderMaster.Rows[j]["customer_state_des"].ToString().Trim();
                    //    dt_InsertToMesOrderMaster.Rows.Add(dr);

                    //    for (int z = 0; z < lst.Count; z++)
                    //    {
                    //        DataRow dr_OptionList = dt_Insert_Order_detail_OptionList.NewRow();
                    //        dr_OptionList["job_num"] = dt_OrderMaster.Rows[j]["job_num"].ToString().Trim();
                    //        dr_OptionList["suffix"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["suffix"].ToString().Trim());
                    //        dr_OptionList["Item_No"] = lst[z].Split("=".ToCharArray())[0];
                    //        dr_OptionList["Option_No"] = lst[z].Split("=".ToCharArray())[1];
                    //        dt_Insert_Order_detail_OptionList.Rows.Add(dr_OptionList);
                    //    }
                    //}
                    //else//款号没有维护
                    //{
                        DataRow dr = dt_InsertToMesOrderMaster.NewRow();
                        dr["job_num"] = dt_OrderMaster.Rows[j]["job_num"].ToString().Trim();
                        dr["suffix"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["suffix"].ToString().Trim());
                        dr["input_date"] = DateTime.Today;
                        dr["style_no"] = dt_OrderMaster.Rows[j]["style_num"].ToString().Trim();
                        dr["style_des"] = dt_OrderMaster.Rows[j]["style_des"].ToString().Trim();
                        dr["job_qty"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["job_qty"].ToString().Trim());
                        dr["manhour"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["manhour"].ToString().Trim());
                        dr["customer_state"] = Convert.ToInt16(dt_OrderMaster.Rows[j]["customer_state"].ToString().Trim());
                        dr["customer_state_des"] = dt_OrderMaster.Rows[j]["customer_state_des"].ToString().Trim();
                        dr["Combination_no"] = 0;
                        dr["memo_no"] = "";
                        dr["memo_name"] = "";
                        dt_InsertToMesOrderMaster.Rows.Add(dr);
                    //}
                }
                if (dt_InsertToMesOrderMaster.Rows.Count > 0)
                {                
                    //1-保存nMES_order_master
                    od.SaveOrderMaster(dt_InsertToMesOrderMaster);
                    //2-保存产品清单
                    for (int k = 0; k < dt_InsertToMesOrderMaster.Rows.Count; k++)
                    {
                        SaveOrderProductList(dt_InsertToMesOrderMaster.Rows[k]["job_num"].ToString().Trim(), Convert.ToInt16(dt_InsertToMesOrderMaster.Rows[k]["suffix"].ToString().Trim()), Convert.ToInt16(dt_InsertToMesOrderMaster.Rows[k]["job_qty"].ToString().Trim()));
                    }
                    ////3-保存nMES_Order_detail_OptionList
                    //if (dt_Insert_Order_detail_OptionList.Rows.Count > 0) { od.SaveOrderOptionList(dt_Insert_Order_detail_OptionList); }
                }
            }
        }
        #endregion

        #region 新版-Update订单选项-全部
        /// <summary>
        /// Update订单的选项-全部
        /// </summary>
        public void UpdateOrderOption()
        {
            OrderDal od = new OrderDal();
            DataTable dt_NoOption = od.GetOrder_NoOption_All();
            UpdateOrderOption(dt_NoOption);
        }
        #endregion

        #region 新版-Update订单选项-单个工单
        /// <summary>
        /// Update订单的选项-单个工单
        /// </summary>
        /// <param name="job_num"></param>
        /// <param name="suffix"></param>
        public void UpdateOrderOption(string job_num, int suffix)
        {
            OrderDal od = new OrderDal();
            DataTable dt_NoOption = od.GetOrder_NoOption_Single(job_num, suffix);
            UpdateOrderOption(dt_NoOption);
        }
        #endregion

       

        #region 新版-保存工单-UpdateMaster选项及选项表(自动匹配-全部)
        /// <summary>
        /// 取master表中没有填入选项的行 判断款号是否维护，已维护的取订单选项并保存 没有的跳过
        /// </summary>
        public void UpdateOrderOption(DataTable dt_NoOption)
        {
            OrderDal od = new OrderDal();
            if (dt_NoOption.Rows.Count > 0)
            {
                DataTable dt_UpdateOption = dt_NoOption.Clone();
                DataTable dt_Insert_Order_detail_OptionList = od.GetMESOrderOptionListInfo();//OptionList结构
                //如果有需要保存的工单：
                for (int j = 0; j < dt_NoOption.Rows.Count; j++)
                {
                    //判断款号是否已经维护 如果没有，跳过此行
                    StyleBll sb = new StyleBll();
                    string style_no = dt_NoOption.Rows[j]["Style_no"].ToString().Trim();
                    DataTable dt = sb.GetStyleItemList(style_no);//获取到此款号必须的选项
                    if (dt.Rows.Count != 0)//如果款号已维护
                    {
                        string order_no = dt_NoOption.Rows[j]["job_num"].ToString().Trim() + "-" + dt_NoOption.Rows[j]["suffix"].ToString().Trim().PadLeft(3, '0');
                        Return_Message rm = new Return_Message();
                        string getordermodel = $@"http://172.16.1.83:8024/api/CpOrderSubDetailByJobNum/" + order_no;
                        rm = Helper.Json.JsonHelper.DeserializeJsonToObject<Return_Message>(Helper.Http.Http.HttpGet(getordermodel));
                        if (rm.State == Return_Message.Return_State.Error)
                        {
                            throw new Exception(rm.Message);
                        }
                        //DataTable dt = Helper.Json.JsonHelper.DeserializeJsonToObject<DataTable>(rm.Return_Value);
                        OrderItemOptionZYQ o = new OrderItemOptionZYQ();
                        List<OrderItemOptionZYQ> ol = new List<OrderItemOptionZYQ>();
                        ol = Helper.Json.JsonHelper.DeserializeJsonToObject<List<OrderItemOptionZYQ>>(rm.Return_Value);
                        string memo_no = "";
                        string memo_name = "";
                        List<string> lst = new List<string>();
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            string item_no = dt.Rows[k][0].ToString();
                            string option_no = ol.Find(x => x.Item_No == item_no).Option_No;
                            memo_no = memo_no + item_no + "=" + option_no + " ";
                            string item_name = ol.Find(x => x.Item_No == item_no).Item_Name;
                            string option_name = ol.Find(x => x.Item_No == item_no).Option_Name;
                            memo_name = memo_name + item_name + "=" + option_name + " ";
                            //选项值组合    
                            lst.Add(item_no + "=" + option_no);
                        }
                        //获取到选项符合的组合号
                        int Combination_no = sb.GetOrderCombination(style_no, memo_no);
                        DataRow dr = dt_UpdateOption.NewRow();
                        dr["job_num"] = dt_NoOption.Rows[j]["job_num"].ToString().Trim();
                        dr["suffix"] = Convert.ToInt16(dt_NoOption.Rows[j]["suffix"].ToString().Trim());
                        //dr["order_date"] = "20" + dt_OrderMaster.Rows[j]["job_num"].ToString().Trim().Substring(1, 2) + "-" + dt_OrderMaster.Rows[j]["job_num"].ToString().Trim().Substring(3, 2) + "-" + dt_OrderMaster.Rows[j]["job_num"].ToString().Trim().Substring(5, 2);
                        dr["style_no"] = dt_NoOption.Rows[j]["style_no"].ToString().Trim();
                        dr["style_des"] = dt_NoOption.Rows[j]["style_des"].ToString().Trim();
                        dr["Combination_no"] = Combination_no;
                        dr["memo_no"] = memo_no;
                        dr["memo_name"] = memo_name;
                        dt_UpdateOption.Rows.Add(dr);

                        for (int z = 0; z < lst.Count; z++)
                        {
                            DataRow dr_OptionList = dt_Insert_Order_detail_OptionList.NewRow();
                            dr_OptionList["job_num"] = dt_NoOption.Rows[j]["job_num"].ToString().Trim();
                            dr_OptionList["suffix"] = Convert.ToInt16(dt_NoOption.Rows[j]["suffix"].ToString().Trim());
                            dr_OptionList["Item_No"] = lst[z].Split("=".ToCharArray())[0];
                            dr_OptionList["Option_No"] = lst[z].Split("=".ToCharArray())[1];
                            dt_Insert_Order_detail_OptionList.Rows.Add(dr_OptionList);
                        }
                    }

                }
                if (dt_UpdateOption.Rows.Count > 0) { od.UpdateOrderOptionList(dt_UpdateOption); }
                if (dt_Insert_Order_detail_OptionList.Rows.Count > 0) { od.SaveOrderOptionList(dt_Insert_Order_detail_OptionList); }
            }
        }
        #endregion

        #region 获取订单OptionList的结构-返回一个空表格
        public DataTable GetMESOrderOptionListInfo(string job_num, int suffix)
        {

            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            DataTable dt_OrderOptionList = od.GetMESOrderOptionListInfo(job_num, suffix);
            return dt_OrderOptionList;
        }
        #endregion




        #region 新版-保存工单-主表-款号选项

        public int SaveOrderOption(OrderBll.SelectOrderInfo soi,List<string> lst)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            try
            {
                //保存nMES_order_master表的memo_no,memo_name
                DataTable dt_NoOption = od.GetOrder_NoOption_All();
                DataTable dt_UpdateOption = dt_NoOption.Clone();
                DataRow dr = dt_UpdateOption.NewRow();
                dr["job_num"] = soi.job_num.ToString().Trim();
                dr["suffix"] = soi.suffix.ToString().Trim();
                dr["Combination_no"] = soi.Combination_no;
                dr["memo_no"] = soi.memo_no;
                dr["memo_name"] = soi.memo_name;
                dt_UpdateOption.Rows.Add(dr);
                if (od.UpdateOrderOptionList(dt_UpdateOption) == 1)
                { //插入工单子表nMES_Order_detail_OptionList
                    DataTable dt_Insert_Order_detail_OptionList = od.GetMESOrderOptionListInfo();//OptionList结构
                    for (int z = 0; z < lst.Count; z++)
                    {
                        DataRow dr_OptionList = dt_Insert_Order_detail_OptionList.NewRow();
                        dr_OptionList["job_num"] = soi.job_num.ToString().Trim();
                        dr_OptionList["suffix"] = soi.suffix.ToString().Trim();
                        dr_OptionList["Item_No"] = lst[z].Split("=".ToCharArray())[0];
                        dr_OptionList["Option_No"] = lst[z].Split("=".ToCharArray())[1];
                        dt_Insert_Order_detail_OptionList.Rows.Add(dr_OptionList);
                    }
                    if (dt_Insert_Order_detail_OptionList.Rows.Count > 0)
                    {
                        od.SaveOrderOptionList(dt_Insert_Order_detail_OptionList);
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else { return 0; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region 新版-通过调用接口获取产品清单并保存nMES_Order_detail_ProductList-Single
        public void SaveOrderProductList(string job_num, int suffix,int job_qty)
        {
            string order_no = job_num + "-" + suffix.ToString().Trim().PadLeft(3, '0');
            Return_Message rm = new OrderBll.Return_Message();
            string getordermodel = $@"http://172.16.1.83:7041/ProductionOrderProductListGet?JobNo=" + order_no;
            rm = Helper.Json.JsonHelper.DeserializeJsonToObject<OrderBll.Return_Message>(Helper.Http.Http.HttpGet(getordermodel));
            if (rm.State == OrderBll.Return_Message.Return_State.Error)
            {
                //throw new Exception(rm.Message);
                return;
            }
            DataTable dt = Helper.Json.JsonHelper.DeserializeJsonToObject<DataTable>(rm.Return_Value);
            if (dt.Rows.Count > 0)
            {
                SaveProductList(job_num, suffix, job_qty, dt);
            }
        }
        #endregion

        #region 新版-保存工单-子表-产品编码明细（按单件推送）
        /// <summary>
        /// 保存工单-子表-产品编码明细（按单件推送）
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <param name="dt">产品编码明细</param>
        /// <returns></returns>
        public int SaveProductList(string job_num, int suffix,int job_qty, DataTable dt)
        {
            int i = 0;
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            try
            {
                return i = od.SaveProductList(job_num, suffix, job_qty,dt);            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 新版-保存工单-子表-产品编码明细（保存所有订单的为保存的产品清单）
        /// <summary>
        /// 保存工单-子表-产品编码明细（按单件推送）
        /// </summary>
        public void SaveProductListAll()
        {

            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            DataTable dt_ProductCode = od.GetOrderNoProductList();
            if (dt_ProductCode.Rows.Count == 0) { return; }
            //try
            //{
                for (int k = 0; k < dt_ProductCode.Rows.Count; k++)
                {
                    string job_num = dt_ProductCode.Rows[k]["job_num"].ToString().Trim();
                    int suffix = Convert.ToInt16(dt_ProductCode.Rows[k]["suffix"].ToString().Trim());
                    int job_qty= Convert.ToInt16(dt_ProductCode.Rows[k]["job_qty"].ToString().Trim());
                    SaveOrderProductList(job_num, suffix, job_qty);
                }                    
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        #endregion

        #region 新版-保存工单-方案
        /// <summary>
        /// 新版-保存订单信息-方案
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <param name="SchemeNo">方案号</param>
        /// <returns>0不成功 1成功 2已存在</returns>
        public int SaveOrderSchemeList(string job_num, int suffix, int SchemeNo)
        {
            int i = 0;
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            try
            {
                return i = od.SaveOrderSchemeList(job_num, suffix, SchemeNo);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #region 新版-保存工单-工序清单
        /// <summary>
        ///  新版-保存工单-工序清单  0代表工序清单没找到过平缝工时超过工单公式   1代表保存成功
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <param name="OpListNo">工序清单号</param>
        /// <returns>0不成功 1成功 2已存在</returns>
        public int SaveOrderOperationList(string job_num, int suffix, int OpListNo, int Combination_no)
        {
            int i = 0;
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();

            try
            {
                int CheckOpListManhour = od.CheckOpListManhour(job_num, suffix, Combination_no);
                if (CheckOpListManhour != 1)
                {
                    return 0;
                }
                else
                {
                    i = od.SaveOrderOperationList(job_num, suffix, OpListNo);
                    return i;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 新版-保存工单-工序清单-所有
        /// <summary>
        ///  新版-保存工单-工序清单-查找所有有工单选项但没绑定工序清单的行
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <param name="OpListNo">工序清单号</param>
        /// <returns>0不成功 1成功 2已存在</returns>
        public void SaveOrderOpListNo()
        {
            
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            try
            {
                od.SaveOrderOpListNo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 新版-保存工单-工序清单-指定工单
        /// <summary>
        ///  新版-保存工单-工序清单-查找指定工单有选项但没绑定工序清单的行
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <param name="OpListNo">工序清单号</param>
        /// <returns>0不成功 1成功 2已存在</returns>
        public int SaveOrderOpListNo_Single(string job_num, int suffix)
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            try
            {
                return od.SaveOrderOpListNo_Single(job_num, suffix);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion





        #region 工具-DataTable转实体类集合
        /// <summary>
        /// DataTable转实体类集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class DataTableToEntity<T> where T : new()
        {
            //            调用示例：

            //DataTable转成实体类集合示例：

            //List<Peak> peaks = new DataTableToEntity<Peak>().FillModel(peakDt);//Peak为实体类  peakDt为DataTable

            //            实体类转成DataTable示例：

            //string abifilePath = Application.StartupPath + "\\outFiles\\peak\\peak_111.json";
            //            List<Abifile> abifiles = new DataTableToEntity<Abifile>().ReadDataToModel(abifilePath);
            //            DataTable abifileDt = new DataTableToEntity<Abifile>().FillDataTable(abifiles);




            /// <summary>
            /// table转实体集合
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public List<T> FillModel(DataTable dt)
            {
                if (dt == null || dt.Rows.Count == 0)
                    return null;
                List<T> result = new List<T>();
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        T res = new T();
                        for (int i = 0; i < dr.Table.Columns.Count; i++)
                        {
                            PropertyInfo propertyInfo = res.GetType().GetProperty(dr.Table.Columns[i].ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            if (propertyInfo != null && dr[i] != DBNull.Value)
                            {
                                var value = dr[i];
                                switch (propertyInfo.PropertyType.FullName)
                                {
                                    case "System.Decimal":
                                        propertyInfo.SetValue(res, Convert.ToDecimal(value), null); break;
                                    case "System.String":
                                        propertyInfo.SetValue(res, value, null); break;
                                    case "System.Int32":
                                        propertyInfo.SetValue(res, Convert.ToInt32(value), null); break;
                                    default:
                                        propertyInfo.SetValue(res, value, null); break;
                                }
                            }
                        }
                        result.Add(res);
                    }
                    catch (Exception ex)
                    {
                       // CommonMethod.SaveText(dr.Table.TableName + "表id：" + dr[0] + "表第二项值：" + dr[1] + " 导出异常,异常信息：" + ex.Message + "\r\n", Application.StartupPath + "\\outFiles" + "\\ErrorLog.txt");
                        continue;
                    }

                }
                return result;
            }

            /// <summary>
            /// 读取json内容转成实体类集合
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public List<T> ReadDataToModel(string path)
            {
                StreamReader sr = new StreamReader(path);
                try
                {
                    string temp = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<T>>(temp);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sr.Dispose();
                    sr.Close();
                }
            }

            /// <summary>
            /// 实体类集合转table
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            public DataTable FillDataTable(List<T> modelList)
            {
                if (modelList == null || modelList.Count == 0)
                    return null;
                DataTable dt = CreatTable(modelList[0]);
                foreach (T model in modelList)
                {
                    DataRow dr = dt.NewRow();
                    foreach (PropertyInfo p in typeof(T).GetProperties())
                    {
                        dr[p.Name] = p.GetValue(model, null);
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }

            /// <summary>
            /// 根据实体创建table
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            private DataTable CreatTable(T model)
            {
                DataTable dt = new DataTable(typeof(T).Name);
                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    dt.Columns.Add(new DataColumn(p.Name, p.PropertyType));
                }
                return dt;
            }
        }
        #endregion

        #region 工单类SelectOrderInfo
        public class SelectOrderInfo
        {
            /// <summary>
            /// 工单号
            /// </summary>
            public string job_num { get; set; }
            /// <summary>
            /// 工单行号
            /// </summary>
            public int suffix { get; set; }
            /// <summary>
            /// 款号
            /// </summary>
            public string Style_no { get; set; }
            /// <summary>
            /// 款号描述
            /// </summary>
            public string style_des { get; set; }
            /// <summary>
            /// 工单数量
            /// </summary>
            public int job_qty { get; set; }
            /// <summary>
            /// 选项值
            /// </summary>
            public string memo_no { get; set; }
            /// <summary>
            /// 选项说明
            /// </summary>
            public string memo_name { get; set; }

            public int  customer_state { get; set; }

            public string customer_state_des {get; set; }
            
            /// <summary>
            /// 总工时
            /// </summary>
            public int manhour { get; set; }


            /// <summary>
            /// 生产路线号
            /// </summary>
            public int SchemeNo { get; set; }

            /// <summary>
            /// 工序清单号
            /// </summary>
            public int OpListNo { get; set; }



            /// <summary>
            /// 选项组合号
            /// </summary>
            public int Combination_no { get; set; }
            /// <summary>
            /// 产品清单
            /// </summary>
            public int GetProductList { get; set; }
            public int OrderLock { get; set; }
        }
        #endregion

        #region JSON新版-给曹博推送工单对应的工序清单
        /// <summary>
        /// 给曹博推送工单对应的工序清单
        /// </summary>
        /// <param name="Order_no">工单号</param>
        /// <returns>Json</returns>
        public string GetJson_OperationList(int OpListNo)
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            string json = od.GetJson_OperationList(OpListNo);
            return json;
        }
        #endregion

        #region JSON新版-给敬元推送工单对应的生产路线
        /// <summary>
        /// 给敬元推送工单对应的生产路线
        /// </summary>
        /// <param name="Order_no">工单号</param>
        /// <returns>Json</returns>
        public string GetJson_Order_Scheme(string SchemeNo)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            string json = od.GetJson_Order_Scheme(SchemeNo);
            return json;
        }
        #endregion

        #region JSON新版-给敬元推送吊挂订单和ERP工单对应

        public string GetJson_Order_Eton(List<ProductUPS> productUPS)
        { 
            DataTable dt = ListProductUPsToDT(productUPS);
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            string json = od.GetJson_Order_Eton(dt);
            return json;
        }
        #endregion

        #region JSON新版-给吊挂推送吊挂工序和工单
        /// <summary>
        /// 推送到吊挂线-生成订单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns>json语句</returns>
        public string ToETON_Order(string job_num, int suffix)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            string json = od.ToETON_Order(job_num, suffix);
            return json;
        }
        /// <summary>
        /// 推送到吊挂线-方案
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns>json语句</returns>
        public string ToETON_SchemeList(string job_num, int suffix)
        {
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            string json = od.ToETON_SchemeList(job_num, suffix);
            return json;
        }
        #endregion

        #region 新版-获取到当前工单未推送至吊挂系统的产品清单
        /// <summary>
        /// 获取到当前工单未推送至吊挂系统的产品清单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public List<int> GetProductListNOTEton(string job_num, int suffix)
        {
            List<int> L_ProductCode = new List<int>();

            DAL.OrderDal.OrderDal ob = new DAL.OrderDal.OrderDal();
            L_ProductCode = ob.GetProductListNOTEton(job_num, suffix);
            return L_ProductCode;
        }
        #endregion

        #region 新版-获取到当前工单的产品清单-ALL-List
        /// <summary>
        /// 获取到当前工单的产品清单-ALL
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public List<ProductUPS> GetProductList(string job_num, int suffix)
        {
            List<ProductUPS> L_ProductCode = new List<ProductUPS>();

            DAL.OrderDal.OrderDal ob = new DAL.OrderDal.OrderDal();
            DataTable dt = ob.GetProductList(job_num, suffix);
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                    ProductUPS p = new ProductUPS();
                    p.id = Convert.ToInt32(dt.Rows[k]["id"].ToString().Trim());
                    p.ProductCode = dt.Rows[k]["ProductCode"].ToString().Trim();
                    p.UPS_prun = Convert.ToInt32(dt.Rows[k]["UPS_prun"].ToString().Trim());
                    L_ProductCode.Add(p);
            }
            return L_ProductCode;
        }
        #endregion

        #region 新版-获取到当前工单的产品清单-ALL-DataTable
        /// <summary>
        /// 获取到当前工单的产品清单-ALL
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public DataTable GetProductListDT(string job_num, int suffix)
        {
            List<ProductUPS> L_ProductCode = new List<ProductUPS>();

            DAL.OrderDal.OrderDal ob = new DAL.OrderDal.OrderDal();
            DataTable dt = ob.GetProductList(job_num, suffix);            
            return dt;
        }
        #endregion

        #region 新版-获取到当前工单的产品清单-未成功推送给敬元的
        /// <summary>
        /// 获取到当前工单的产品清单-未成功推送给敬元的
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public List<ProductUPS> GetProductList_NOTJINGYUAN(string job_num, int suffix)
        {
            List<ProductUPS> L_ProductCode = new List<ProductUPS>();

            DAL.OrderDal.OrderDal ob = new DAL.OrderDal.OrderDal();
            DataTable dt = ob.GetProductList_NoJINGYUAN(job_num, suffix);
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                    ProductUPS p = new ProductUPS();
                    p.id = Convert.ToInt32(dt.Rows[k]["id"].ToString().Trim());
                    p.ProductCode = dt.Rows[k]["ProductCode"].ToString().Trim();
                    p.UPS_prun = Convert.ToInt32(dt.Rows[k]["UPS_prun"].ToString().Trim());
                    L_ProductCode.Add(p);
            }
            return L_ProductCode;
        }
        #endregion

        #region 新版-获取到当前工单的产品清单-未成功推送给曹博的
        /// <summary>
        /// 获取到当前工单的产品清单-未成功推送给曹博的
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public List<ProductUPS> GetProductList_NOTCAOBO(string job_num, int suffix)
        {
            List<ProductUPS> L_ProductCode = new List<ProductUPS>();

            DAL.OrderDal.OrderDal ob = new DAL.OrderDal.OrderDal();
            DataTable dt = ob.GetProductList_NoCAOBO(job_num, suffix);
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                ProductUPS p = new ProductUPS();
                p.id = Convert.ToInt32(dt.Rows[k]["id"].ToString().Trim());
                p.ProductCode = dt.Rows[k]["ProductCode"].ToString().Trim();
                p.UPS_prun = Convert.ToInt32(dt.Rows[k]["UPS_prun"].ToString().Trim());
                L_ProductCode.Add(p);
            }
            return L_ProductCode;
        }
        #endregion

        #region 新版-保存吊挂订单号
        /// <summary>
        /// 保存吊挂订单号
        /// </summary>
        /// <param name="id">产品id</param>
        /// <param name="UPS_prun">吊挂订单</param>
        /// <returns></returns>
        public int SaveUPS_purn(int id, int UPS_prun)
        {
            int i = 0;
            DAL.OrderDal.OrderDal od = new DAL.OrderDal.OrderDal();
            return i = od.SaveUPS_purn(id, UPS_prun);        
        }
        #endregion

        #region 新版-将Product类 转为DataTable
        /// <summary>
        /// 将Product DataTable转为类
        /// </summary>
        /// <param name="productUPS">DataTable</param>
        /// <returns></returns>
        public DataTable ListProductUPsToDT(List<ProductUPS> productUPS)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductCode");
            dt.Columns.Add("UPS_prun");
            for (int k = 0; k < productUPS.Count; k++)
            {
                DataRow dr = dt.NewRow();
                dr["ProductCode"] = productUPS[k].ProductCode;
                dr["UPS_prun"] = productUPS[k].UPS_prun;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public class ProductUPS
        {
            public int id { get; set; }
            public string ProductCode { get; set; }
            public int UPS_prun { get; set; }
        }
        #endregion

    }
}
