using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MES.module.DAL.OrderDal
{
    public class OrderDal
    {
        #region 旧版--检查相同工单号的数量
        /// <summary>
        /// 旧版--检查相同工单号的数量
        /// </summary>
        /// <param name="Order_no">工单号</param>
        /// <returns>查询到的已存在工单的数量</returns>
        public int OrderNumberOfExisting(string Order_no)
        {
            //默认工单号已存在，不可用
            int n = 0;
            string sqlcmd = "SELECT COUNT(order_no) AS Expr1 FROM MES_order_master WHERE order_no = '" + Order_no + "'";
            n = Convert.ToInt16(DBConn.DataAcess.SqlConn.GetSingle(sqlcmd));
            return n;
        }
        #endregion
        #region  旧版-加载订单
        /// <summary>
        /// 加载订单
        /// </summary>
        /// <param name="StageProduct">0测试订单 =1正式订单</param>
        /// <returns></returns>
        public DataTable GetOrderList(int StageProduct)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Clear();
            str.AppendLine(" declare @StageProduct int ");
            str.AppendLine(" set @StageProduct="+ StageProduct);
            str.AppendLine(" SELECT id ");
            str.AppendLine("       ,order_no ");
            str.AppendLine("       ,style_no ");
            str.AppendLine("       ,order_qty ");
            str.AppendLine("       ,input_date ");
            str.AppendLine("       ,StageProduct ");
            str.AppendLine("       ,ToOrderMasterTable ");
            str.AppendLine("   FROM MES_GetOrder ");
            str.AppendLine("   where ToOrderMasterTable=0 and StageProduct=@StageProduct order by order_no desc");
            dt = DBConn.DataAcess.SqlConn.Query(str.ToString()).Tables[0];
            return dt;
        }
        #endregion
        #region 旧版--生成新的工单
        /// <summary>
        /// 旧版--生成新的工单
        /// </summary>
        /// <param name="Order_No">订单号</param>
        /// <param name="SchemeNo">方案号</param>
        /// <param name="Order_qty">订单数量</param>
        /// <returns></returns>
        public int NewOrder(string Order_No,string SchemeNo,int Order_qty)
        {
            ArrayList SQLList = new ArrayList();

            StringBuilder sqlstr_OrderMaster = new StringBuilder();
            sqlstr_OrderMaster.Clear();
            sqlstr_OrderMaster.AppendLine(" 	declare @OrderNo varchar(50) ");
            sqlstr_OrderMaster.AppendLine(" 	declare @SchemeNo int ");
            sqlstr_OrderMaster.AppendLine(" 	declare @order_qty int ");
            sqlstr_OrderMaster.AppendLine(" 	set @OrderNo='"+ Order_No + "' ");
            sqlstr_OrderMaster.AppendLine(" 	set @SchemeNo="+ SchemeNo + " ");
            sqlstr_OrderMaster.AppendLine(" 	set @order_qty="+ Order_qty + " ");
            sqlstr_OrderMaster.AppendLine(" 	INSERT INTO MES_order_master ");
            sqlstr_OrderMaster.AppendLine("            (order_no ");
            sqlstr_OrderMaster.AppendLine("            ,order_date ");
            sqlstr_OrderMaster.AppendLine("            ,input_date ");
            sqlstr_OrderMaster.AppendLine("            ,style_no ");
            sqlstr_OrderMaster.AppendLine("            ,SchemeNo ");
            sqlstr_OrderMaster.AppendLine("            ,order_qty) ");
            sqlstr_OrderMaster.AppendLine("      VALUES ");
            sqlstr_OrderMaster.AppendLine("            (@OrderNo ");
            sqlstr_OrderMaster.AppendLine("            , '20'+substring(@OrderNo,2,6) ");
            sqlstr_OrderMaster.AppendLine("            ,getdate()");
            sqlstr_OrderMaster.AppendLine("            ,(select style_no from MES_station_operation_master where SchemeNo=@SchemeNo) ");
            sqlstr_OrderMaster.AppendLine("            ,@SchemeNo ");
            sqlstr_OrderMaster.AppendLine("            ,@order_qty) ");


            StringBuilder sqlstr_OrderDetail = new StringBuilder();
            sqlstr_OrderDetail.Clear();
            sqlstr_OrderDetail.AppendLine(" declare @SchemeNo int ");
            sqlstr_OrderDetail.AppendLine(" declare @OrderNo varchar(50) ");
            sqlstr_OrderDetail.AppendLine(" set @SchemeNo=" + SchemeNo + " ");
            sqlstr_OrderDetail.AppendLine(" set @OrderNo='" + Order_No + "' ");
            sqlstr_OrderDetail.AppendLine(" INSERT INTO [dbo].[MES_order_detail_operation] ");
            sqlstr_OrderDetail.AppendLine("            ([order_no] ");
            sqlstr_OrderDetail.AppendLine("            ,[OpCodeAlpha1] ");
            sqlstr_OrderDetail.AppendLine("            ,[operation_addr] ");
            sqlstr_OrderDetail.AppendLine("            ,[operation_des] ");
            sqlstr_OrderDetail.AppendLine("            ,[price] ");
            sqlstr_OrderDetail.AppendLine("            ,[Time_unit] ");
            sqlstr_OrderDetail.AppendLine("            ,[OpQualityRequirement] ");
            sqlstr_OrderDetail.AppendLine("            ,[StyleQualityRequirement] ");
            sqlstr_OrderDetail.AppendLine("            ,[Technology_picture] ");
            sqlstr_OrderDetail.AppendLine("            ,[standard_time] ");
            sqlstr_OrderDetail.AppendLine("            ,[EQ_ID] ");
            sqlstr_OrderDetail.AppendLine("            ,[EQ_des] ");
            sqlstr_OrderDetail.AppendLine("            ,[GST_gxDJ] ");
            sqlstr_OrderDetail.AppendLine("            ,[GST_xh] ");
            sqlstr_OrderDetail.AppendLine("            ,[GST_XCBJ] ");
            sqlstr_OrderDetail.AppendLine("            ,[GST_GZDM]) ");
            sqlstr_OrderDetail.AppendLine("            SELECT @OrderNo as OrderNo ");
            sqlstr_OrderDetail.AppendLine(" 					,OpCodeAlpha1 ");
            sqlstr_OrderDetail.AppendLine(" 					,operation_addr ");
            sqlstr_OrderDetail.AppendLine(" 					,operation_des ");
            sqlstr_OrderDetail.AppendLine(" 					,0.00 as price ");
            sqlstr_OrderDetail.AppendLine(" 					,'s' as Time_unit ");
            sqlstr_OrderDetail.AppendLine(" 				    ,OpQualityRequirement ");
            sqlstr_OrderDetail.AppendLine(" 					,StyleQualityRequirement ");
            sqlstr_OrderDetail.AppendLine(" 					,Technology_picture ");
            sqlstr_OrderDetail.AppendLine(" 					,standard_time ");
            sqlstr_OrderDetail.AppendLine(" 					,EQ_ID ");
            sqlstr_OrderDetail.AppendLine(" 					,EQ_des ");
            sqlstr_OrderDetail.AppendLine(" 					,GST_gxDJ ");
            sqlstr_OrderDetail.AppendLine(" 					,GST_xh ");
            sqlstr_OrderDetail.AppendLine(" 					,GST_XCBJ ");
            sqlstr_OrderDetail.AppendLine(" 					,GST_GZDM ");
            sqlstr_OrderDetail.AppendLine(" 			FROM [mes].[dbo].[MES_station_operation_detail] ");
            sqlstr_OrderDetail.AppendLine(" 			where SchemeNo=@SchemeNo order by id ");

            StringBuilder sqlstr_GetOrder = new StringBuilder();
            sqlstr_GetOrder.Clear();
            sqlstr_GetOrder.AppendLine(" UPDATE MES_GetOrder    ");
            sqlstr_GetOrder.AppendLine(" SET ToOrderMasterTable = 1 ");
            sqlstr_GetOrder.AppendLine("  WHERE order_no ='" + Order_No + "'");

            SQLList.Add(sqlstr_OrderMaster.ToString());
            SQLList.Add(sqlstr_OrderDetail.ToString());
            SQLList.Add(sqlstr_GetOrder.ToString());
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        #endregion



        #region 新版-从ZYQ处获取清单后保存到nMES_Order_zyq_master表
        public int SaveOrderZYQ(DataTable dt)
        {

            ArrayList SQLList = new ArrayList();
            for (int i = dt.Rows.Count-1; i >=0; i--)
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Clear();
                sqlstr.AppendLine(" SELECT job_num,suffix FROM nMES_Order_zyq_master where job_num='"+dt.Rows[i]["job_num"].ToString().Trim() + "' and suffix="+ dt.Rows[i]["suffix"] + "");

                DataTable dt_order = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
                if (dt_order.Rows.Count == 0)
                {
                    StringBuilder sqlstr_saveorder = new StringBuilder();
                    sqlstr_saveorder.Clear();
                    sqlstr_saveorder.AppendLine(" INSERT INTO nMES_Order_zyq_master ");
                    sqlstr_saveorder.AppendLine("            ( ");
                    sqlstr_saveorder.AppendLine("            job_num ");
                    sqlstr_saveorder.AppendLine("            ,suffix ");
                    sqlstr_saveorder.AppendLine("            ,style_num ");
                    sqlstr_saveorder.AppendLine("            ,style_des ");
                    sqlstr_saveorder.AppendLine("            ,job_qty ");
                    sqlstr_saveorder.AppendLine("            ,customer_state ");
                    sqlstr_saveorder.AppendLine("            ,customer_state_des ");
                    sqlstr_saveorder.AppendLine("            ,manhour) ");
                    sqlstr_saveorder.AppendLine("      VALUES ");
                    sqlstr_saveorder.AppendLine("            (");
                    sqlstr_saveorder.AppendLine("            '"+ dt.Rows[i]["job_num"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ,"+ dt.Rows[i]["suffix"] + " ");
                    sqlstr_saveorder.AppendLine("            ,'" + dt.Rows[i]["style_num"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ,'" + dt.Rows[i]["style_des"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ," + dt.Rows[i]["job_qty"] + "");
                    sqlstr_saveorder.AppendLine("            ," + dt.Rows[i]["customer_state"] + "");
                    sqlstr_saveorder.AppendLine("            ,'" + dt.Rows[i]["customer_state_des"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ," + dt.Rows[i]["manhour"] + ")");

                    SQLList.Add(sqlstr_saveorder.ToString());
                }
            }
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }     
        }
        #endregion

        #region 新版-从ZYQ处获取清单后保存到nMES_Order_zyq_master和nMES_Order_master表
        public int SaveOrderZYQtoMES(DataTable dt)
        {

            ArrayList SQLList = new ArrayList();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Clear();
                sqlstr.AppendLine(" SELECT job_num,suffix FROM nMES_Order_zyq_master where job_num='" + dt.Rows[i]["job_num"].ToString().Trim() + "' and suffix=" + dt.Rows[i]["suffix"] + "");

                DataTable dt_order = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
                if (dt_order.Rows.Count == 0)
                {
                    StringBuilder sqlstr_saveorder = new StringBuilder();
                    sqlstr_saveorder.Clear();
                    sqlstr_saveorder.AppendLine(" INSERT INTO nMES_Order_zyq_master ");
                    sqlstr_saveorder.AppendLine("            ( ");
                    sqlstr_saveorder.AppendLine("            job_num ");
                    sqlstr_saveorder.AppendLine("            ,suffix ");
                    sqlstr_saveorder.AppendLine("            ,style_num ");
                    sqlstr_saveorder.AppendLine("            ,style_des ");
                    sqlstr_saveorder.AppendLine("            ,job_qty ");
                    sqlstr_saveorder.AppendLine("            ,customer_state ");
                    sqlstr_saveorder.AppendLine("            ,customer_state_des ");
                    sqlstr_saveorder.AppendLine("            ,manhour) ");
                    sqlstr_saveorder.AppendLine("      VALUES ");
                    sqlstr_saveorder.AppendLine("            (");
                    sqlstr_saveorder.AppendLine("            '" + dt.Rows[i]["job_num"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ," + dt.Rows[i]["suffix"] + " ");
                    sqlstr_saveorder.AppendLine("            ,'" + dt.Rows[i]["style_num"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ,'" + dt.Rows[i]["style_des"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ," + dt.Rows[i]["job_qty"] + "");
                    sqlstr_saveorder.AppendLine("            ," + dt.Rows[i]["customer_state"] + "");
                    sqlstr_saveorder.AppendLine("            ,'" + dt.Rows[i]["customer_state_des"].ToString().Trim() + "' ");
                    sqlstr_saveorder.AppendLine("            ," + dt.Rows[i]["manhour"] + ")");

                    SQLList.Add(sqlstr_saveorder.ToString());
                }
            }
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        #endregion



        #region  新版-加载订单-ZYQ
        /// <summary>
        /// 加载订单 zyq
        /// </summary>
        /// <param name="StageProduct">1测试订单 =0正式订单</param>
        /// <returns></returns>
        public DataTable nMES_GetOrderList_ZYQ(int customer_state)
        {
            DataTable dt = new DataTable();
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine("  SELECT id       ");
            sqlstr.AppendLine("        ,job_num+'-'+right('000' + cast(suffix as varchar),3) as order_no  ");
            sqlstr.AppendLine("        ,style_num as style_no ");
            sqlstr.AppendLine("        ,style_des  ");
            sqlstr.AppendLine("        ,job_qty  ");
            sqlstr.AppendLine(" 	   ,'' as memo_no ");
            sqlstr.AppendLine(" 	   ,'' as memo_name ");
            sqlstr.AppendLine("        ,customer_state  ");
            sqlstr.AppendLine("        ,customer_state_des  ");
            sqlstr.AppendLine("        ,manhour  ");
            sqlstr.AppendLine(" 	   ,0 as SchemeNo ");
            sqlstr.AppendLine(" 	   ,0 as OpListNo ");
            sqlstr.AppendLine(" 	   ,0 as GetProductList ");
            sqlstr.AppendLine(" 	   ,0 as Combination_no ");

            sqlstr.AppendLine("  FROM nMES_Order_zyq_master  ");
            sqlstr.AppendLine("    where SaveToMes=0 and customer_state=" + customer_state + " ");
            dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            return dt;
        }
        #endregion

        #region  新版-加载订单-MES
        /// <summary>
        /// 加载订单 MES
        /// </summary>
        /// <param name="StageProduct">1测试订单 =2正式订单</param>
        /// <returns></returns>
        public DataTable nMES_GetOrderList_MES(int customer_state,bool ContainUPSDone,string SelectOrderDate)
        {
            

            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine("   SELECT   nMES_order_master.id, nMES_order_master.job_num + '-' + RIGHT('000' + CAST(nMES_order_master.suffix AS varchar), 3) AS order_no, order_date, style_no,    ");
            sqlstr.AppendLine("                   style_des, job_qty, memo_no, memo_name, customer_state, customer_state_des, manhour, SchemeNo, OpListNo,    ");
            sqlstr.AppendLine("                   Combination_no, GetProductList, OrderLock,PushState_CAOBOqty,nMES_order_master.job_num,nMES_order_master.suffix   ");
            sqlstr.AppendLine("   FROM      nMES_order_master   ");
            sqlstr.AppendLine("   left join   ");
            sqlstr.AppendLine("   (select job_num,suffix, count(nMES_Order_detail_ProductList.PushState_CAOBO) as PushState_CAOBOqty from  nMES_Order_detail_ProductList WHERE PushState_CAOBO<>0 group by job_num,suffix) as aaa   ");
            sqlstr.AppendLine("   	on nMES_order_master.job_num=aaa.job_num and nMES_order_master.suffix=aaa.suffix  ");
            StringBuilder sqlstr_where = new StringBuilder();
            sqlstr_where.Clear();
            if (ContainUPSDone == true) //成功推送到吊挂/敬元/曹博的
            {
                sqlstr_where.AppendLine(" WHERE   (customer_state = "+ customer_state + " and PushState_CAOBOqty>=1)");                
            }
            else//推送过的不显示
            {
                sqlstr_where.AppendLine(" WHERE   (customer_state =  " + customer_state + ") and (PushState_CAOBOqty<1 or PushState_CAOBOqty is null) ");
            }

            if (SelectOrderDate == "") { sqlstr_where.AppendLine("and 1=1");  }
            else { sqlstr_where.AppendLine(" and nMES_order_master.job_num='Z" + SelectOrderDate + "'"); }
            

            sqlstr_where.AppendLine(" ORDER BY order_date DESC, id ");
            DataTable dt = new DataTable();           

            dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()+ sqlstr_where.ToString()).Tables[0];
            return dt;
        }
        #endregion

        #region 更新OpListNo，UPS_prun，SchemeNo，Combination_no
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
            string sqlstr = "UPDATE nMES_order_master   SET " + 字段名.ToString().Trim() + " = "+ 字段值 + " where job_num='" + job_num + "' and suffix=" + suffix + "";
            try
            {
                DBConn.DataAcess.SqlConn.Query(sqlstr);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 更新nMES_Order_detail_ProductList，PushState_CAOBO，PushState_JINGYUAN
        /// <summary>
        /// 更新nMES_Order_detail_ProductList，PushState_CAOBO，PushState_JINGYUAN
        /// </summary>
        /// <param name="id">产品清单行id</param>
        /// <returns>1成功 0不成功</returns>
        public int UpdateProductListInfo(string 字段名, int 字段值, int id)
        {
            OrderDal od = new OrderDal();
            string sqlstr = "UPDATE nMES_Order_detail_ProductList   SET " + 字段名.ToString().Trim() + " = '" + 字段值 + "' where id=" + id;
            try
            {
                DBConn.DataAcess.SqlConn.Query(sqlstr);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        #endregion

        #region 新版-保存工单-主表-款号数量等
        public void SaveOrderMaster(DataTable dt_OrderMaster)
        {
 
            if (dt_OrderMaster.Rows.Count > 0)
            {

                for (int k = 0; k < dt_OrderMaster.Rows.Count; k++)
                {
                    ArrayList SQLList = new ArrayList();
                    StringBuilder sqlstr = new StringBuilder();
                    sqlstr.Clear();
                    string job_num = dt_OrderMaster.Rows[k]["job_num"].ToString().Trim();
                    sqlstr.AppendLine(" declare @job_num nvarchar(50) ");
                    sqlstr.AppendLine(" declare @suffix int ");
                    sqlstr.AppendLine(" declare @order_date datetime ");
                    sqlstr.AppendLine(" declare @input_date datetime ");
                    sqlstr.AppendLine(" declare @style_no nvarchar(50) ");
                    sqlstr.AppendLine(" declare @style_des nvarchar(50) ");
                    sqlstr.AppendLine(" declare @Combination_no int ");
                    sqlstr.AppendLine(" declare @job_qty int ");
                    sqlstr.AppendLine(" declare @manhour int ");
                    sqlstr.AppendLine(" declare @memo_no nvarchar(50) ");
                    sqlstr.AppendLine(" declare @memo_name nvarchar(50) ");
                    sqlstr.AppendLine(" declare @customer_state int ");
                    sqlstr.AppendLine(" declare @customer_state_des nvarchar(50) ");
                    sqlstr.AppendLine(" set @job_num='" + job_num.Trim() + "' ");
                    sqlstr.AppendLine(" set @suffix=" + dt_OrderMaster.Rows[k]["suffix"].ToString().Trim() + " ");
                    sqlstr.AppendLine(" set @order_date= '20' + substring(@job_num, 2, 2) + '-' + substring(@job_num, 4, 2) + '-' + substring(@job_num, 6, 2)");
                    sqlstr.AppendLine(" set @input_date=getdate() ");
                    sqlstr.AppendLine(" set @style_no='" + dt_OrderMaster.Rows[k]["Style_no"].ToString().Trim() + "'");
                    sqlstr.AppendLine(" set @style_des='" + dt_OrderMaster.Rows[k]["style_des"].ToString().Trim() + "'");
                    sqlstr.AppendLine(" set @Combination_no=" + dt_OrderMaster.Rows[k]["Combination_no"].ToString().Trim() + "");
                    sqlstr.AppendLine(" set @job_qty=" + dt_OrderMaster.Rows[k]["job_qty"].ToString().Trim() + "");
                    sqlstr.AppendLine(" set @manhour=" + dt_OrderMaster.Rows[k]["manhour"].ToString().Trim() + "");
                    sqlstr.AppendLine(" set @memo_no='" + dt_OrderMaster.Rows[k]["memo_no"].ToString().Trim() + "'");
                    sqlstr.AppendLine(" set @memo_name='" + dt_OrderMaster.Rows[k]["memo_name"].ToString().Trim() + "'");
                    sqlstr.AppendLine(" set @customer_state='" + dt_OrderMaster.Rows[k]["customer_state"].ToString().Trim() + "'");
                    sqlstr.AppendLine(" set @customer_state_des='" + dt_OrderMaster.Rows[k]["customer_state_des"].ToString().Trim() + "'");
                    sqlstr.AppendLine(" INSERT INTO nMES_order_master ");
                    sqlstr.AppendLine("            (job_num ");
                    sqlstr.AppendLine("            ,suffix ");
                    sqlstr.AppendLine("            ,order_date ");
                    sqlstr.AppendLine("            ,input_date ");
                    sqlstr.AppendLine("            ,style_no ");
                    sqlstr.AppendLine("            ,style_des ");
                    sqlstr.AppendLine("            ,Combination_no ");
                    sqlstr.AppendLine("            ,job_qty ");
                    sqlstr.AppendLine("            ,memo_no ");
                    sqlstr.AppendLine("            ,memo_name ");
                    sqlstr.AppendLine("            ,customer_state ");
                    sqlstr.AppendLine("            ,customer_state_des ");
                    sqlstr.AppendLine("            ,manhour) ");
                    sqlstr.AppendLine("      VALUES ");
                    sqlstr.AppendLine("            (@job_num ");
                    sqlstr.AppendLine("            ,@suffix ");
                    sqlstr.AppendLine("            ,@order_date ");
                    sqlstr.AppendLine("            ,@input_date ");
                    sqlstr.AppendLine("            ,@style_no ");
                    sqlstr.AppendLine("            ,@style_des ");
                    sqlstr.AppendLine("            ,@Combination_no ");
                    sqlstr.AppendLine("            ,@job_qty ");
                    sqlstr.AppendLine("            ,@memo_no ");
                    sqlstr.AppendLine("            ,@memo_name ");
                    sqlstr.AppendLine("            ,@customer_state ");
                    sqlstr.AppendLine("            ,@customer_state_des ");
                    sqlstr.AppendLine("            ,@manhour) ");


                    SQLList.Add(sqlstr.ToString());

                    StringBuilder sqlstr_zyq_master = new StringBuilder();
                    sqlstr_zyq_master.Clear();
                    sqlstr_zyq_master.AppendLine(" UPDATE nMES_Order_zyq_master SET SaveToMes=1 WHERE job_num='" + job_num + "' and suffix=" + dt_OrderMaster.Rows[k]["suffix"].ToString().Trim() + " ");
                    SQLList.Add(sqlstr_zyq_master.ToString());
                    try
                    {
                        DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }              

            }        
        }
        #endregion

        #region 获取需要更新到订单主表的数据
        public DataTable GetZYQOrderInfo()
        {
            string sqlstring = "select * from nMES_Order_zyq_master where not exists (select 'a' from nMES_Order_master where nMES_Order_zyq_master.job_num=nMES_Order_master.job_num and nMES_Order_zyq_master.suffix=nMES_Order_master.suffix) ";
            DataTable dt_OrderMaster = DBConn.DataAcess.SqlConn.Query(sqlstring).Tables[0];
            return dt_OrderMaster;
        }
        #endregion
        #region 获取订单主表中需要更新选项的数据
        public DataTable GetOrder_NoOption_All()
        {
            string sqlstring = "SELECT job_num,suffix,style_no,style_des,Combination_no,memo_no,memo_name  FROM nMES_order_master  where Combination_no=0  and OrderLock=0";
            DataTable dt_NoOption = DBConn.DataAcess.SqlConn.Query(sqlstring).Tables[0];
            return dt_NoOption;
        }
        #endregion



        #region 新版-获取订单主表中需要更新选项的数据
        public DataTable GetOrder_NoOption_Single(string job_num,int suffix)
        {
            string sqlstring = "SELECT job_num,suffix,style_no,style_des,Combination_no,memo_no,memo_name  FROM nMES_order_master  where Combination_no=0 and job_num='"+ job_num + "' and suffix="+ suffix + " and OrderLock=0";
            DataTable dt_NoOption = DBConn.DataAcess.SqlConn.Query(sqlstring).Tables[0];
            return dt_NoOption;
        }
        #endregion

        #region 新版-获取工序清单中的平缝工时 - 2021.11.18
        /// <summary>
        /// 0没有获取到工序清单 1合格(小于工单工时) 2不合格(大于工单工时)
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行</param>
        /// <returns></returns>
        public int CheckOpListManhour(string job_num, int suffix, int Combination_no)
        {
             StringBuilder StringOpListManhour = new StringBuilder();
            StringOpListManhour.Clear();
            StringOpListManhour.AppendLine(" select sum(a.manhour) as PFmanhour_OpList ");
            StringOpListManhour.AppendLine(" from nMES_OperationList_detail a ");
            StringOpListManhour.AppendLine(" left join nMES_OperationList_master b ");
            StringOpListManhour.AppendLine(" 	on a.OpListNo=b.OpListNo ");
            StringOpListManhour.AppendLine(" where a.OperationType='PF' and b.Combination_no=" + Combination_no);

            int OpListManhour = Convert.ToInt32(DBConn.DataAcess.SqlConn.GetSingle(StringOpListManhour.ToString()));

            StringBuilder StringOrderManhour = new StringBuilder();
            StringOrderManhour.Clear();
            StringOrderManhour.AppendLine("  select manhour from nMES_order_master   ");
            StringOrderManhour.AppendLine("  where job_num='" + job_num + "' and suffix=" + suffix);

            int OrderManhour = Convert.ToInt32(DBConn.DataAcess.SqlConn.GetSingle(StringOpListManhour.ToString()));

            if (OpListManhour == 0)
            {
                return 0;
            }
            else if (OrderManhour <= OpListManhour)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        #endregion



        #region 获取订单主表的结构-返回一个空表格
        public DataTable GetMESOrderInfo()
        {
            string sqlstring = "select * from nMES_Order_master where job_num=''";
            DataTable dt_OrderMaster = DBConn.DataAcess.SqlConn.Query(sqlstring).Tables[0];
            return dt_OrderMaster;
        }
        #endregion

        #region 获取订单OptionList的结构-返回一个空表格
        public DataTable GetMESOrderOptionListInfo()
        {
            string sqlstring = "select job_num,suffix,Item_No,Option_No from nMES_Order_detail_OptionList where job_num=''";
            DataTable dt_OrderOptionList = DBConn.DataAcess.SqlConn.Query(sqlstring).Tables[0];
            return dt_OrderOptionList;
        }
        #endregion

        #region 获取订单OptionList的结构-返回一个空表格
        public DataTable GetMESOrderOptionListInfo(string job_num,int suffix)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine(" SELECT a.id ");
            sqlstr.AppendLine("       ,a.job_num ");
            sqlstr.AppendLine("       ,a.suffix ");
            sqlstr.AppendLine(" 	  ,b.style_no ");
            sqlstr.AppendLine("       ,a.Item_No ");
            sqlstr.AppendLine(" 	  ,c.Item_Name ");
            sqlstr.AppendLine("       ,a.Option_No ");
            sqlstr.AppendLine(" 	  ,c.Option_Name ");
            sqlstr.AppendLine("   FROM [mes].[dbo].[nMES_Order_detail_OptionList] a  ");
            sqlstr.AppendLine("   left join nMES_order_master b on a.job_num=b.job_num and a.suffix=b.suffix ");
            sqlstr.AppendLine("   left join nMES_Style_OptionList c on b.style_no=c.style_no and a.Item_No =c.Item_No and a.Option_No=c.Option_No ");
            sqlstr.AppendLine("   where a.job_num='"+ job_num + "' AND a.suffix="+ suffix + " ");
            DataTable dt_OrderOptionList = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            return dt_OrderOptionList;
        }
        #endregion


        #region 新版-保存工单-主表-款号选项Insert
        /// <summary>
        /// 新版-保存订单选项
        /// </summary>
        /// <param name="OrderOptionList">订单选项</param>
        /// <returns>0不成功 1成功</returns>
        public int SaveOrderOptionList(DataTable dt_OrderOptionList)
        {
                ArrayList SQLList = new ArrayList();
            string sqlstrdel = "delete from nMES_Order_detail_OptionList  where job_num='" + dt_OrderOptionList.Rows[0]["job_num"].ToString().Trim() + "' AND suffix=" + Convert.ToInt16(dt_OrderOptionList.Rows[0]["suffix"].ToString().Trim());
            SQLList.Add(sqlstrdel);
            for (int j=0; j < dt_OrderOptionList.Rows.Count; j++)
                {
                    string Item_No = dt_OrderOptionList.Rows[j]["Item_No"].ToString().Trim();
                    int Opton_No = Convert.ToInt16(dt_OrderOptionList.Rows[j]["Option_No"].ToString().Trim());
                    string job_num= dt_OrderOptionList.Rows[j]["job_num"].ToString().Trim();
                    int suffix =Convert.ToInt16(dt_OrderOptionList.Rows[j]["suffix"].ToString().Trim());
                    StringBuilder sqlstr = new StringBuilder();
                    sqlstr.Clear();
                    sqlstr.AppendLine(" INSERT INTO nMES_Order_detail_OptionList ");
                    sqlstr.AppendLine("            (job_num ");
                    sqlstr.AppendLine("            ,suffix ");
                    sqlstr.AppendLine("            ,Item_No ");
                    sqlstr.AppendLine("            ,Option_No) ");
                    sqlstr.AppendLine("      VALUES ");
                    sqlstr.AppendLine("            ('"+ job_num + "' ");
                    sqlstr.AppendLine("            ,'" + suffix + "' ");
                    sqlstr.AppendLine("            ,'"+ Item_No + "' ");
                    sqlstr.AppendLine("            ,'" + Opton_No + "') ");
                    SQLList.Add(sqlstr.ToString());
                }    
                try
                {
                    DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;                    
                }

            
        }
        #endregion

        #region 新版-保存工单-主表-款号选项Update
        /// <summary>
        /// 新版-保存订单选项
        /// </summary>
        /// <param name="OrderOptionList">订单选项</param>
        /// <returns>0不成功 1成功</returns>
        public int UpdateOrderOptionList(DataTable dt_UpdateOption)
        {
                ArrayList SQLList = new ArrayList();
                for (int j = 0; j < dt_UpdateOption.Rows.Count; j++)
                {
                    int Combination_no = Convert.ToInt16(dt_UpdateOption.Rows[j]["Combination_no"].ToString().Trim());
                    string job_num = dt_UpdateOption.Rows[j]["job_num"].ToString().Trim();
                    int suffix = Convert.ToInt16(dt_UpdateOption.Rows[j]["suffix"].ToString().Trim());
                    string memo_no = dt_UpdateOption.Rows[j]["memo_no"].ToString().Trim();
                    string memo_name = dt_UpdateOption.Rows[j]["memo_name"].ToString().Trim();
                    StringBuilder cmd = new StringBuilder();
                    cmd.Clear();
                    cmd.AppendLine(" UPDATE nMES_order_master ");
                    cmd.AppendLine("    SET Combination_no = '" + Combination_no + "' ");
                    cmd.AppendLine("       ,memo_no =  '" + memo_no + "'  ");
                    cmd.AppendLine("       ,memo_name ='" + memo_name + "'  ");
                    cmd.AppendLine("  WHERE job_num= '" + job_num + "' and suffix=" + suffix + "");
                    SQLList.Add(cmd.ToString());
                }
                try
                {
                    DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }           
           
        }
        #endregion

        #region 新版-获取到没有保存产品编码明细的工单
        /// <summary>
        /// 新版-获取到没有保存产品编码明细的工单
        /// </summary>
        /// <returns>job_num ,suffix,job_qty,GetProductList</returns>
        public DataTable GetOrderNoProductList()
        {
            string strsqa = "SELECT job_num ,suffix,job_qty,GetProductList  FROM nMES_order_master where GetProductList=0";
            DataTable dt_ProductCode = DBConn.DataAcess.SqlConn.Query(strsqa).Tables[0];
            return dt_ProductCode;
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
        public int SaveProductList(string job_num, int suffix, int job_qty,DataTable dt)
        {
            string strsqa = "SELECT ProductCode  FROM nMES_Order_detail_ProductList WHERE job_num='" + job_num + "' and suffix=" + suffix + "";
            DataTable dt_ProductCode = DBConn.DataAcess.SqlConn.Query(strsqa).Tables[0];
            int ProductCodeCount = dt_ProductCode.Rows.Count;
            if (ProductCodeCount < job_qty)
            { //如果系统中清单数量小于工单数量，将没保存过的产品重新录入
                ArrayList SQLList = new ArrayList();
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    string ProductCode = dt.Rows[k]["ProductCode"].ToString().Trim();
                    if (dt != null)
                    {
                        //type列名，app是某个值  查询某个列所有的值
                        DataRow[] dr = dt_ProductCode.Select("ProductCode" + "='"+ ProductCode + "'");
                        if (dr.Length > 0)
                        {
                            //return true;
                        }
                        else
                        {
                            StringBuilder strsql = new StringBuilder();
                            strsql.Clear();
                            strsql.AppendLine(" INSERT INTO [dbo].[nMES_Order_detail_ProductList] ");
                            strsql.AppendLine("            ([job_num] ");
                            strsql.AppendLine("            ,[suffix] ");
                            strsql.AppendLine("            ,[ProductCode]) ");
                            strsql.AppendLine("      VALUES ");
                            strsql.AppendLine("            ('" + job_num + "' ");
                            strsql.AppendLine("            ," + suffix + " ");
                            strsql.AppendLine("            ,'" + ProductCode + "') ");
                            SQLList.Add(strsql.ToString());
                        }
                    }
                }
                try
                {
                    DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                    DataTable dt_ProductCode_final = DBConn.DataAcess.SqlConn.Query(strsqa).Tables[0];
                    if (dt_ProductCode_final.Rows.Count == job_qty) 
                    { 
                        UpdateOrderInfo("GetProductList", 1, job_num, suffix); 
                    }
                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            { return 1; }
     
        }
        #endregion



        #region 新版-保存工单-工序清单
        /// <summary>
        /// 保存工单对应的工序清单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <param name="OpListNo">工序清单号</param>
        /// <returns>0不成功 1成功 2已存在</returns>
        public int SaveOrderOperationList(string job_num, int suffix, int OpListNo)
        {            
            







            ArrayList SQLList = new ArrayList();
            string sqldelete = "delete from nMES_Order_detail_OperationList where job_num='"+ job_num + "' and suffix="+ suffix + " ";
            SQLList.Add(sqldelete);
            StringBuilder sqlstr = new StringBuilder();



            sqlstr.Clear();
            sqlstr.AppendLine(" insert into nMES_Order_detail_OperationList ");
            sqlstr.AppendLine(" select     '" + job_num + "' as job_num ");
            sqlstr.AppendLine(" 		   ," + suffix + " as suffix ");
            sqlstr.AppendLine(" 		   ,OpListNo ");
            sqlstr.AppendLine("            ,OperationNo ");
            sqlstr.AppendLine("            ,OperationDes ");
            sqlstr.AppendLine("            ,OperationType ");
            sqlstr.AppendLine("            ,manhour ");
            sqlstr.AppendLine("            ,GST_xh ");
            sqlstr.AppendLine(" 		   ,'' as EQ_ID ");
            sqlstr.AppendLine(" 		   ,'' as EQ_des ");
            sqlstr.AppendLine("  from nMES_OperationList_detail ");
            sqlstr.AppendLine(" where  OpListNo=" + OpListNo + " order by GST_XH");
            SQLList.Add(sqlstr.ToString());

            try
            {
                UpdateOrderInfo("OpListNo", OpListNo, job_num, suffix);
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region 新版-保存工单-方案
        /// <summary>
        /// 保存订单对应的生产路线
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <param name="SchemeNo">方案号</param>
        /// <returns>0失败 1 成功 2跳过</returns>
        public int SaveOrderSchemeList(string job_num, int suffix, int SchemeNo)
        {
            //string stringsql = "  select count(id) from nMES_order_master where job_num='" + job_num + "' and suffix=" + suffix + "";
            //int c = Convert.ToInt16( DBConn.DataAcess.SqlConn.GetSingle(stringsql));
            //if (c > 0) { return 2; }
            ArrayList SQLList = new ArrayList();
            string cmd = "delete  FROM nMES_Order_detail_SchemeList  where job_num='" + job_num + "' and suffix=" + suffix + "";
            SQLList.Add(cmd);
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine(" INSERT INTO nMES_Order_detail_SchemeList ");
            sqlstr.AppendLine(" SELECT '"+ job_num + "' as job_num ");
            sqlstr.AppendLine(" 		,"+ suffix + " as suffix ");
            sqlstr.AppendLine("       ,SchemeNo ");
            sqlstr.AppendLine("       ,Eton_Line ");
            sqlstr.AppendLine("       ,Eton_WorkStation ");
            sqlstr.AppendLine("       ,SchemeOperationNo ");
            sqlstr.AppendLine("       ,SchemeOperationDes ");
            sqlstr.AppendLine("       ,op_type ");
            sqlstr.AppendLine("   FROM nMES_Scheme_detail_Station ");
            sqlstr.AppendLine("   where SchemeNo="+ SchemeNo + " order by id");
            SQLList.Add(sqlstr.ToString());
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                UpdateOrderInfo("SchemeNo", SchemeNo, job_num, suffix);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion



        #region JSON新版-给敬元推送工单对应的生产路线
        /// <summary>
        /// JSON新版-给敬元推送工单对应的生产路线
        /// </summary>
        /// <param name="SchemeNo">方案号</param>
        /// <returns>Json</returns>
        public string GetJson_Order_Scheme(string SchemeNo)
        {
            string json = "";
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine(" SELECT SchemeNo ");
            sqlstr.AppendLine("       ,Eton_Line ");
            sqlstr.AppendLine("       ,Eton_WorkStation ");
            sqlstr.AppendLine("       ,SchemeOperationNo ");
            sqlstr.AppendLine("       ,SchemeOperationDes ");
            sqlstr.AppendLine("       ,op_type ");
            sqlstr.AppendLine("   FROM nMES_Scheme_detail_Station ");
            sqlstr.AppendLine("   where SchemeNo=" + SchemeNo + " ");
            sqlstr.AppendLine("   order by id ");

            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];

            MyContrals.JSON js = new MyContrals.JSON();
            json = js.DataTableToJson(dt);
            return json;
        }
        #endregion

        #region JSON新版-给敬元推送吊挂订单和ERP工单对应
        /// <summary>
        /// JSON新版-给敬元推送吊挂订单和ERP工单对应
        /// </summary>
        /// <param name="productUPS"></param>
        /// <returns></returns>
        public string GetJson_Order_Eton(DataTable productUPS)
        {
            string json = "";
            DataTable dt = new DataTable();
            dt.Columns.Add("JobNo");
            dt.Columns.Add("UpsNo");
            for (int k = 0; k < productUPS.Rows.Count; k++)
            {
                DataRow dr = dt.NewRow();
                dr["JobNo"] = productUPS.Rows[k]["ProductCode"];
                dr["UpsNo"] = productUPS.Rows[k]["UPS_prun"];
                dt.Rows.Add(dr);
            }
            MyContrals.JSON js = new MyContrals.JSON();
            json = js.DataTableToJson(dt);
            return json;
        }
        #endregion

        #region JSON新版-给吊挂推送吊挂工序和工单
        /// <summary>
        /// JSON新版-给吊挂推送吊挂工序和工单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns>json语句</returns>
        public string ToETON_Order(string job_num, int suffix)
        {
            DataTable dt = new DataTable();
            ArrayList SQLList = new ArrayList();
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine(" SELECT pivottable.schemeno as STYLE,RANK() over(order by PivotTable.id ) as LISTINDEX ");
            sqlstr.AppendLine(" ,isnull([1],0) as [RAIL0] ");
            sqlstr.AppendLine(" ,isnull([2],0) as [RAIL1] ");
            sqlstr.AppendLine(" ,isnull([3],0) as [RAIL2] ");
            sqlstr.AppendLine(" ,isnull([4],0) as [RAIL3] ");
            sqlstr.AppendLine(" ,isnull([5],0) as [RAIL4] ");
            sqlstr.AppendLine(" ,isnull([6],0) as [RAIL5] ");
            sqlstr.AppendLine(" ,isnull([7],0) as [RAIL6] ");
            sqlstr.AppendLine(" ,isnull([8],0) as [RAIL7] ");
            sqlstr.AppendLine(" ,MES_UPS_GST_operation.ETON_Opcodealphal as OPERATION ");
            sqlstr.AppendLine(" ,PivotTable.op_type as OPTYPE ");
            sqlstr.AppendLine(" ,GST_xh ");
            sqlstr.AppendLine(" ,PivotTable.SchemeOperationNo ");
            sqlstr.AppendLine(" ,PivotTable.id ");
            sqlstr.AppendLine("          from ");
            sqlstr.AppendLine("          (select convert(int, rank()over(partition by SchemeOperationNo order by Eton_Workstation)) as Num ");
            sqlstr.AppendLine("                , SchemeNo ");
            sqlstr.AppendLine("                , SchemeOperationNo ");
            sqlstr.AppendLine("                , Eton_Line ");
            sqlstr.AppendLine("                , Eton_Workstation ");
            sqlstr.AppendLine("                , op_type ");
            sqlstr.AppendLine("                , id as GST_xh ");
            sqlstr.AppendLine("                , id ");
            sqlstr.AppendLine("          from nMES_Order_detail_SchemeList ");
            sqlstr.AppendLine("          where job_num='"+ job_num + "'  and suffix="+ suffix + ")  aaa ");
            sqlstr.AppendLine("          PIVOT( ");
            sqlstr.AppendLine("          max(Eton_Workstation) ");
            sqlstr.AppendLine("          FOR num  IN( [0],[1],[2],[3],[4],[5],[6],[7],[8]) ");
            sqlstr.AppendLine("          ) as PivotTable ");
            sqlstr.AppendLine(" left join  MES_UPS_GST_operation on MES_UPS_GST_operation.OpCodeAlpha1 = PivotTable.SchemeOperationNo ");
            sqlstr.AppendLine(" order by LISTINDEX ");
            SQLList.Add(sqlstr.ToString());
            dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            MyContrals.JSON js = new MyContrals.JSON();
            string json = js.DataTableToJson(dt);
            return json;
        }

        /// <summary>
        /// 推送到吊挂线-生成方案
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns>json语句</returns>
        public string ToETON_SchemeList(string job_num, int suffix)
        {
            DataTable dt = new DataTable();
            ArrayList SQLList = new ArrayList();
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine(" select SchemeOperationNo as OpCodeAlpha1 ");
            sqlstr.AppendLine(" ,left(SchemeOperationDes, 16) 工序描述 ");
            sqlstr.AppendLine(" ,2 as 工序类型 from ");
            sqlstr.AppendLine(" 	( select SchemeOperationNo, SchemeOperationDes, op_type ");
            sqlstr.AppendLine(" 	  from nMES_Order_detail_SchemeList ");
            sqlstr.AppendLine(" 	  where job_num='"+ job_num + "' and suffix="+ suffix + " ");
            sqlstr.AppendLine(" 	  group by SchemeOperationNo,SchemeOperationDes, op_type) t1 ");
            sqlstr.AppendLine("  where  t1.SchemeOperationNo not in (select OpCodeAlpha1 from MES_UPS_GST_operation) ");
            SQLList.Add(sqlstr.ToString());
            dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            MyContrals.JSON js = new MyContrals.JSON();
            string json = js.DataTableToJson(dt);
            return json;
        }
        #endregion

        #region 获取到当前工单未推送至吊挂系统的产品清单
        /// <summary>
        /// 获取到当前工单未推送至吊挂系统的产品清单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public List<int> GetProductListNOTEton(string job_num, int suffix)
        {
            List<int> L_ProductCode = new List<int>();

            String sqlstr = "select id,ProductCode,case when UPS_prun is null then 0 else UPS_prun end UPS_prun from nMES_Order_detail_ProductList where job_num='" + job_num + "' and suffix=" + suffix + "";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (dt.Rows[k]["UPS_prun"].ToString().Trim() == "0")
                {
                    L_ProductCode.Add(Convert.ToInt32(dt.Rows[k]["id"].ToString().Trim()));
                }
            }
            return L_ProductCode;
        }
        #endregion

        #region 获取到当前工单的产品清单
        /// <summary>
        /// 获取到当前工单未推送至吊挂系统的产品清单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public DataTable GetProductList(string job_num, int suffix)
        {
            String sqlstr = "select id,ProductCode,case when UPS_prun is null then 0 else UPS_prun end UPS_prun , PushState_JINGYUAN,PushState_CAOBO from nMES_Order_detail_ProductList where job_num='" + job_num + "' and suffix=" + suffix + "";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            return dt;
        }
        #endregion

        #region 获取到当前工单未推送给敬元的产品清单
        /// <summary>
        /// 获取到当前工单未推送给敬元的产品清单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public DataTable GetProductList_NoJINGYUAN(string job_num, int suffix)
        {
            String sqlstr = "select id,ProductCode,case when UPS_prun is null then 0 else UPS_prun end UPS_prun from nMES_Order_detail_ProductList where job_num='" + job_num + "' and suffix=" + suffix + " and UPS_prun<>0 and PushState_JINGYUAN=0";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            return dt;
        }
        #endregion

        #region 获取到当前工单未推送给敬元的产品清单
        /// <summary>
        /// 获取到当前工单未推送给敬元的产品清单
        /// </summary>
        /// <param name="job_num">工单号</param>
        /// <param name="suffix">工单行号</param>
        /// <returns></returns>
        public DataTable GetProductList_NoCAOBO(string job_num, int suffix)
        {
            String sqlstr = "select id,ProductCode,case when UPS_prun is null then 0 else UPS_prun end UPS_prun from nMES_Order_detail_ProductList where job_num='" + job_num + "' and suffix=" + suffix + " and PushState_JINGYUAN=1 AND PushState_CAOBO=0";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            return dt;
        }
        #endregion

        #region 保存吊挂订单号
        /// <summary>
        /// 保存吊挂订单号
        /// </summary>
        /// <param name="id">产品id</param>
        /// <param name="UPS_prun">ETON订单号</param>
        /// <returns></returns>
        public int SaveUPS_purn(int id, int UPS_prun)
        {
            ArrayList SQLList = new ArrayList();
                StringBuilder productUPSsql = new StringBuilder();
                productUPSsql.Clear();
                productUPSsql.AppendLine(" update nMES_Order_detail_ProductList  ");
                productUPSsql.AppendLine(" 	Set UPS_prun=" + UPS_prun + " ");
                productUPSsql.AppendLine(" 	WHERE id="+ id + "  ");
                SQLList.Add(productUPSsql);

            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion 
    }
}

