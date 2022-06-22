using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.module.DAL.SchemeDal
{
    public class SchemeDal
    {


        /// <summary>
        /// 整理后的方案表数据
        /// </summary>
        /// <param name="DS_scheme">整理后的方案表数据</param>
        /// <returns>成功返回方案号 否则返回0</returns>
        public int NewOrder(string Style_No,string memo, DataTable dt_scheme)
        {
            //获取当前方案号最大值+1
            int n = 0;
            string sqlcmd = "SELECT max(SchemeNo) FROM MES_station_operation_master";
            n = Convert.ToInt16(DBConn.DataAcess.SqlConn.GetSingle(sqlcmd));
            int SchemeNo = n + 1;


            ArrayList SQLList = new ArrayList();

            StringBuilder sqlstr_SchemeMaster = new StringBuilder();
            sqlstr_SchemeMaster.Clear();
            sqlstr_SchemeMaster.AppendLine("  declare @style_no nvarchar(500)  ");
            sqlstr_SchemeMaster.AppendLine("  declare @memo nvarchar(500) ");
            sqlstr_SchemeMaster.AppendLine("  declare @SchemeNo int ");
            sqlstr_SchemeMaster.AppendLine("  declare @state int ");
            sqlstr_SchemeMaster.AppendLine("  set @style_no='"+Style_No+"'  ");
            sqlstr_SchemeMaster.AppendLine("  set @memo='"+ memo + "'  ");
            sqlstr_SchemeMaster.AppendLine("  set @SchemeNo='"+ SchemeNo + "' ");
            sqlstr_SchemeMaster.AppendLine("  set @state=-1 ");
            sqlstr_SchemeMaster.AppendLine("  INSERT INTO [dbo].[MES_station_operation_master] ");
            sqlstr_SchemeMaster.AppendLine("            ([style_no] ");
            sqlstr_SchemeMaster.AppendLine("            ,[SchemeDate] ");
            sqlstr_SchemeMaster.AppendLine("            ,[SchemeNo] ");
            sqlstr_SchemeMaster.AppendLine("            ,[memo] ");
            sqlstr_SchemeMaster.AppendLine("            ,[state] ");
            sqlstr_SchemeMaster.AppendLine("            ,[CompleteState]) ");
            sqlstr_SchemeMaster.AppendLine("      VALUES ");
            sqlstr_SchemeMaster.AppendLine("            (@style_no ");
            sqlstr_SchemeMaster.AppendLine("            ,CONVERT(varchar(12), getdate(), 112 ) ");
            sqlstr_SchemeMaster.AppendLine("            ,@SchemeNo ");
            sqlstr_SchemeMaster.AppendLine("            ,@memo ");
            sqlstr_SchemeMaster.AppendLine("            ,@state ");
            sqlstr_SchemeMaster.AppendLine("            ,1) ");
            SQLList.Add(sqlstr_SchemeMaster.ToString());
            for (int i = 0; i < dt_scheme.Rows.Count; i++)
            {
                StringBuilder sqlstr_SchemeDetail = new StringBuilder();
                sqlstr_SchemeDetail.Clear();
                sqlstr_SchemeDetail.AppendLine(" declare @SchemeNo int ");
                sqlstr_SchemeDetail.AppendLine(" declare @Eton_Line int ");
                sqlstr_SchemeDetail.AppendLine(" declare @Eton_WorkStation int ");
                sqlstr_SchemeDetail.AppendLine(" declare @OpCodeAlpha1 nvarchar(50) ");
                sqlstr_SchemeDetail.AppendLine(" declare @GST_xh int ");
                sqlstr_SchemeDetail.AppendLine(" declare @operation_addr nvarchar(500) ");
                sqlstr_SchemeDetail.AppendLine(" declare @op_type nvarchar(50) ");
                sqlstr_SchemeDetail.AppendLine("  ");
                sqlstr_SchemeDetail.AppendLine(" set @SchemeNo='" + SchemeNo + "' ");
                sqlstr_SchemeDetail.AppendLine(" set @Eton_Line='1' ");
                sqlstr_SchemeDetail.AppendLine(" set @Eton_WorkStation='" + dt_scheme.Rows[i]["站点"].ToString().Trim() + "' ");
                sqlstr_SchemeDetail.AppendLine(" set @OpCodeAlpha1='" + dt_scheme.Rows[i]["工序代码"].ToString().Trim() + "' ");
                sqlstr_SchemeDetail.AppendLine(" set @GST_xh ='" + dt_scheme.Rows[i]["工序序号"].ToString().Trim() + "' ");
                sqlstr_SchemeDetail.AppendLine(" set @operation_addr='" + dt_scheme.Rows[i]["工序简称"].ToString().Trim() + "' ");
                sqlstr_SchemeDetail.AppendLine(" set @op_type='' ");
                sqlstr_SchemeDetail.AppendLine("  ");
                sqlstr_SchemeDetail.AppendLine(" INSERT INTO [dbo].[MES_station_operation_detail] ");
                sqlstr_SchemeDetail.AppendLine("            (SchemeNo ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,Eton_Line ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,Eton_WorkStation ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,OpCodeAlpha1 ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,GST_xh ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,operation_addr ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,op_type) ");
                sqlstr_SchemeDetail.AppendLine("      VALUES ");
                sqlstr_SchemeDetail.AppendLine("            (@SchemeNo ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,@Eton_Line ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,@Eton_WorkStation ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,@OpCodeAlpha1 ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,@GST_xh ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,@operation_addr ");
                sqlstr_SchemeDetail.AppendLine(" 		   ,@op_type) ");

                StringBuilder sqlstr_op_type = new StringBuilder();
                sqlstr_op_type.Clear();
                sqlstr_op_type.AppendLine(" declare @SchemeNo int ");
                sqlstr_op_type.AppendLine(" declare @OpCodeAlpha1 varchar(50) ");
                sqlstr_op_type.AppendLine(" declare @op_type int ");
                sqlstr_op_type.AppendLine("  ");
                sqlstr_op_type.AppendLine(" set @SchemeNo='" + SchemeNo + "' ");
                sqlstr_op_type.AppendLine(" set @OpCodeAlpha1='" + dt_scheme.Rows[i]["工序代码"].ToString().Trim() + "' ");
                sqlstr_op_type.AppendLine(" set @op_type=(case  @OpCodeAlpha1 when '10000' then 1 when '10001' then 8 else 2 end)  ");
                sqlstr_op_type.AppendLine("  ");
                sqlstr_op_type.AppendLine(" INSERT INTO [dbo].[MES_operation_detail_type] ");
                sqlstr_op_type.AppendLine("            ([SchemeNo] ");
                sqlstr_op_type.AppendLine("            ,[OpCodeAlpha1] ");
                sqlstr_op_type.AppendLine("            ,[op_type]) ");
                sqlstr_op_type.AppendLine("      VALUES ");
                sqlstr_op_type.AppendLine("            (@SchemeNo ");
                sqlstr_op_type.AppendLine("            ,@OpCodeAlpha1 ");
                sqlstr_op_type.AppendLine("            ,@op_type) ");


                SQLList.Add(sqlstr_SchemeDetail.ToString());
                SQLList.Add(sqlstr_op_type.ToString());
            }
 
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return SchemeNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// 返回新生成的方案号码
        /// </summary>
        /// <param name="Combination_no">选项组号</param>
        /// <param name="nMES_Scheme_Station">工作站清单</param>
        /// <param name="state">0默认 1备用</param>
        /// <returns></returns>
        public int Scheme_Station_Add(int Combination_no, DataTable nMES_Scheme_Station,int state,string memo)
        {
            int SchemeNo = 0;


            //  获取一个新的方案号 nMES_Scheme_master.SchemeNo最大值+1
            string sqlstr = "select case when max(SchemeNo) is null then 10000 else max(SchemeNo) end SchemeNo from nMES_Scheme_master";
            int MaxSchemeNo =Convert.ToInt32( DBConn.DataAcess.SqlConn.GetSingle(sqlstr).ToString().Trim());
            SchemeNo = MaxSchemeNo + 1;

            

            //  主表
            //  nMES_Scheme_master.SchemeNo
            //  nMES_Scheme_master.Combination_no
            //  nMES_Scheme_master.app_time
            //  nMES_Scheme_master.state
            ArrayList SQLList = new ArrayList();

            //插入主表 
            if (state == 0)
            {
                //string sqlstring = "UPDATE nMES_Scheme_master SET app_time = getdate(),state = 1 WHERE Combination_no='" + Combination_no + "'";
                string sqlstring = "UPDATE nMES_Scheme_master SET state = 1 WHERE Combination_no='" + Combination_no + "'";
                SQLList.Add(sqlstring);
            }

            StringBuilder cmd = new StringBuilder();
            cmd.Clear();
            cmd.AppendLine(" INSERT INTO nMES_Scheme_master ");
            cmd.AppendLine("            (SchemeNo ");
            cmd.AppendLine("            ,Combination_no ");
            cmd.AppendLine("            ,app_time ");
            cmd.AppendLine("            ,memo ");
            cmd.AppendLine("            ,state) ");
            cmd.AppendLine("      VALUES ");
            cmd.AppendLine("            (" + SchemeNo + "");
            cmd.AppendLine("            ," + Combination_no + "");
            cmd.AppendLine("            ,getdate() ");
            cmd.AppendLine("            ,'" + memo + "'");
            cmd.AppendLine("            ," + state + ") ");//0默认 1备用
            SQLList.Add(cmd.ToString());


            //  子表
            //  nMES_Scheme_master.SchemeNo
            //  nMES_Scheme_master.Eton_Line
            //  nMES_Scheme_master.Eton_WorkStation
            //  nMES_Scheme_master.SchemeOperationNo
            //  nMES_Scheme_master.SchemeOperationDes
            //  nMES_Scheme_master.op_type         
            if (nMES_Scheme_Station.Rows.Count > 0)
            {
                for (int j = 0; j < nMES_Scheme_Station.Rows.Count; j++)
                {
                    StringBuilder cmd_station = new StringBuilder();
                    cmd_station.Clear();
                    cmd_station.AppendLine(" INSERT INTO [dbo].[nMES_Scheme_detail_Station] ");
                    cmd_station.AppendLine("            ([SchemeNo] ");
                    cmd_station.AppendLine("            ,[Eton_Line] ");
                    cmd_station.AppendLine("            ,[Eton_WorkStation] ");
                    cmd_station.AppendLine("            ,[SchemeOperationNo] ");
                    cmd_station.AppendLine("            ,[SchemeOperationDes] ");
                    cmd_station.AppendLine("            ,[op_type]) ");
                    cmd_station.AppendLine("      VALUES ");
                    cmd_station.AppendLine("            (" + SchemeNo + "");
                    cmd_station.AppendLine("            ," + Convert.ToInt32(nMES_Scheme_Station.Rows[j]["生产线"].ToString().Trim()) + " ");
                    cmd_station.AppendLine("            ," + Convert.ToInt32(nMES_Scheme_Station.Rows[j]["工作站"].ToString().Trim()) + "  ");
                    cmd_station.AppendLine("            ,'" + nMES_Scheme_Station.Rows[j]["工序代码"].ToString().Trim() + "'");
                    cmd_station.AppendLine("            ,'" + nMES_Scheme_Station.Rows[j]["描述"].ToString().Trim() + "'");
                    cmd_station.AppendLine("            ," + Convert.ToInt32(nMES_Scheme_Station.Rows[j]["工序类型代码"].ToString().Trim()) + ") ");
                    SQLList.Add(cmd_station.ToString());
                }
            }
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return SchemeNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 导入方案工序清单：返回1=成功
        /// </summary>
        /// <param name="Combination_no">选项组号</param>
        /// <param name="Scheme_operation">工序清单</param>
        /// <returns></returns>
        public int Scheme_Operation_Add(int Combination_no, DataTable Scheme_operation)
        {
            //返回结果 1=成功 0=不成功
            int i = 0;
            //  获取一个新的方案号 nMES_Scheme_master.SchemeNo最大值+1

            //  主表不用写
            //  nMES_Scheme_master.SchemeNo
            //  nMES_Scheme_master.Combination_no
            //  nMES_Scheme_master.app_time
            //  nMES_Scheme_master.state

            //  子表
            //  nMES_Scheme_operation.SchemeNo
            //  nMES_Scheme_operation.OpCodeAlpha1
            //  nMES_Scheme_operation.operation_addr
            //  nMES_Scheme_operation.standard_time
            //  nMES_Scheme_operation.GST_xh
            //  nMES_Scheme_operation.EQ_ID
            //  nMES_Scheme_operation.EQ_des
            return i;
        }





        /// <summary>
        /// 获取保存的关键选项清单
        /// </summary>
        /// <param name="Style_No">款号</param>
        /// <returns></returns>
        public DataTable GetSchemeList_detail(string SchemeNo)
        {
            DataTable dt = new DataTable();
            if (SchemeNo != "")
            {
                StringBuilder cmd = new StringBuilder();
                cmd.Clear();
                cmd.AppendLine(" SELECT a.SchemeNo,a.Eton_Line,a.Eton_WorkStation,a.SchemeOperationNo,a.SchemeOperationDes,a.op_type,b.op_des   ");
                cmd.AppendLine(" FROM nMES_Scheme_detail_Station  a ");
                cmd.AppendLine(" left join MES_OPERTYPE b ");
                cmd.AppendLine(" on b.op_type=a.op_type ");
                cmd.AppendLine(" where SchemeNo='"+ SchemeNo + "' order by a.id ");
                dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];
            }
            return dt;
        }
        /// <summary>
        /// 根据款号获取方案清单
        /// </summary>
        /// <param name="StyleNo">款号</param>
        /// <param name="Combination_no">选项组号</param>
        /// <returns></returns>
        public DataTable GetSchemeList_master(string StyleNo,int Combination_no)
        {
            DataTable dt = new DataTable();
            if (StyleNo != "")
            {
                StringBuilder cmd = new StringBuilder();
                cmd.Clear();
                cmd.AppendLine(" SELECT b.style_no  ");
                cmd.AppendLine("        ,a.SchemeNo  ");
                cmd.AppendLine("  	   ,b.memo_name  ");
                cmd.AppendLine("        ,a.Combination_no  ");
                cmd.AppendLine("        ,app_time  ");
                cmd.AppendLine("        ,(case when a.state=0 then '默认' else '备选' end) as SchemeState  ");
                cmd.AppendLine("        ,a.memo as SchemeMemo  ");
                cmd.AppendLine("  	   ,b.memo_no  ");
                cmd.AppendLine(" 	   ,c.Eton_Line ");
                cmd.AppendLine("    FROM nMES_Scheme_master a  ");
                cmd.AppendLine("    left join nMES_Style_Combination_master b  ");
                cmd.AppendLine("    on a.Combination_no=b.Combination_no  ");
                cmd.AppendLine("    left join (select Eton_Line,SchemeNo from nMES_Scheme_detail_Station group by SchemeNo,Eton_Line ) c ");
                cmd.AppendLine("    on a.SchemeNo=c.SchemeNo ");
                cmd.AppendLine("    where b.Combination_state=0 and b.Style_no='"+ StyleNo + "' and a.Combination_no="+ Combination_no + "  ");
                cmd.AppendLine("    order by a.state,a.SchemeNo desc ");
                dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];
            }
            return dt;
        }

        public int GetSchemeLineNum(string SchemeNo)
        {
            int LineNum = 0;
            if (SchemeNo != "")
            {
                string cmd = "SELECT case when max(Eton_Line) is null then 0 else max(Eton_Line) end  FROM nMES_Scheme_detail_Station where schemeno='" + SchemeNo + "'";
                LineNum = Convert.ToInt32( DBConn.DataAcess.SqlConn.GetSingle(cmd));
            }

            return LineNum;
        }

        public int UpdateSchemeMemo(int SchemeNo, string memo)
        {
            string sqlstr = "UPDATE nMES_Scheme_master   SET memo = '"+ memo + "' WHERE SchemeNo="+ SchemeNo;
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSql(sqlstr);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
