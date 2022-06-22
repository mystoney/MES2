using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES.module.model;
using MES.module.Base.PublicClass;
using System.Collections;

namespace MES.module.DAL.StationDal
{
    public class StationDal
    {
        /// <summary>
        /// 初始化查询
        /// </summary>
        /// <returns></returns>
        public DataTable getStation()
        {

            //string strsql = "SELECT [id],[Eton_WorkStation],[Eton_Line],[EQLock],[state],0 as Edit,CASE WHEN state = '0' then '停用' else '启用' end  ZT  FROM [dbo].[Station] Order by Eton_Line,Eton_WorkStation";
            string strsql = "SELECT [Eton_Line],[Eton_WorkStation] FROM MES_station";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            //DataToClass.DataToList<StationInh>(dt)
            return dt;
        }


        public DataTable getStation(string Eton_Line)
        {
            //string strsql = "SELECT [id],[Eton_WorkStation],[Eton_Line],[EQLock],[state],0 as Edit,CASE WHEN state = '0' then '停用' else '启用' end  ZT  FROM [dbo].[Station] Order by Eton_Line,Eton_WorkStation";
            string strsql = "SELECT [Eton_Line],[Eton_WorkStation] FROM MES_station where Eton_Line='" + Eton_Line + "'";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            //DataToClass.DataToList<StationInh>(dt)
            return dt;
        }
        /// <summary>
        /// 获取生产线
        /// </summary>
        /// <returns></returns>
        public DataTable getLine()
        {
            string strsql = "select eton_line from MES_Line group by eton_line";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            DataRow dr = dt.NewRow() ;
            dt.Rows.InsertAt(dr,0);
            //DataToClass.DataToList<StationInh>(dt)
            return dt;
        }

        public void DelGridTran(DataTable dt)
        {
            ArrayList al = new ArrayList();
            DBConn.DataAcess.SqlConn.ExecuteSqlTran(al);
        }

        /// <summary>
        /// 删除工作站
        /// </summary>
        /// <param name="Eton_WorkStation">工作站</param>
        /// <param name="Eton_Line">生产线</param>
        /// <returns>影响行数</returns>
        public int DelGrid(int Eton_WorkStation,int Eton_Line)
        {
            string strsql = "  delete MES_station where  Eton_WorkStation = " + Eton_WorkStation + " and Eton_Line = "+ Eton_Line + " ";
            int i = DBConn.DataAcess.SqlConn.ExecuteSql(strsql);
            return i;
        }

        /// <summary>
        /// 删除生产线
        /// </summary>
        /// <param name="Eton_Line">生产线</param>
        /// <returns>影响行数</returns>
        public int DelAllGrid(int Eton_Line)
        {
            string strsql = "  delete MES_station where Eton_Line = " + Eton_Line + "";
            int i = DBConn.DataAcess.SqlConn.ExecuteSql(strsql);
            return i;
        }

        /// <summary>
        /// 停用生产线
        /// </summary>
        /// <param name="Eton_Line">生产线号</param>
        /// <returns>影响的行数</returns>
        public int Stop_line(int Eton_Line)
        {
            string cmd= "update MES_station set state=0 where Eton_Line = " + Eton_Line + "";
            int i = DBConn.DataAcess.SqlConn.ExecuteSql(cmd);
            return i;
        }

        /// <summary>
        /// 启用生产线
        /// </summary>
        /// <param name="Eton_Line">生产线号</param>
        /// <returns>影响的行数</returns>
        public int Start_line(int Eton_Line)
        {
            string cmd = "update MES_station set state=1 where Eton_Line = " + Eton_Line + "";
            int i = DBConn.DataAcess.SqlConn.ExecuteSql(cmd);
            return i;
        }

    }
}
