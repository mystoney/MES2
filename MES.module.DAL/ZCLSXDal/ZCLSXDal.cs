using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using System.Collections;

namespace MES.module.DAL.ZCLSXDal
{
    public class ZCLSXDal
    {
        /// <summary>
        /// 将泛型插入到指定表Tmp_ZCLSX并进行相关操作
        /// </summary>
        /// <param name="_ZCLSX">要插入表的泛型</param>
        /// <returns>是否成功插入</returns>
        public bool InsertZCLSXALL(List<Tmp_ZCLSX> _ZCLSX)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZCLSX插入到Tmp_ZCLSX_history表的SQL


            cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZCLSX_history] ");
            cmd.AppendLine("           ([AUFNR] ");
            cmd.AppendLine("           ,[MATNR] ");
            cmd.AppendLine("           ,[MAKTX] ");
            cmd.AppendLine("           ,[MTART] ");
            cmd.AppendLine("           ,[MTBEZ] ");
            cmd.AppendLine("           ,[MATKL] ");
            cmd.AppendLine("           ,[WGBEZ] ");
            cmd.AppendLine("           ,[MENGE] ");
            cmd.AppendLine("           ,[BDMNG]) ");
            cmd.AppendLine("     select [AUFNR] ");
            cmd.AppendLine("           ,[MATNR] ");
            cmd.AppendLine("           ,[MAKTX] ");
            cmd.AppendLine("           ,[MTART] ");
            cmd.AppendLine("           ,[MTBEZ] ");
            cmd.AppendLine("           ,[MATKL] ");
            cmd.AppendLine("           ,[WGBEZ] ");
            cmd.AppendLine("           ,[MENGE] ");
            cmd.AppendLine("           ,[BDMNG] ");
            cmd.AppendLine("	from Tmp_ZCLSX ");

            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将Tmp_ZCLSX的老数据删除的SQL
            cmd.AppendLine("delete from Tmp_ZCLSX");
            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将List中的数据插入到Tmp_ZCLSX表的SQL
            for (int i = 0; i < _ZCLSX.Count; i++)
            {

                cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZCLSX] ");
                cmd.AppendLine("           ([AUFNR] ");
                cmd.AppendLine("           ,[MATNR] ");
                cmd.AppendLine("           ,[MAKTX] ");
                cmd.AppendLine("           ,[MTART] ");
                cmd.AppendLine("           ,[MTBEZ] ");
                cmd.AppendLine("           ,[MATKL] ");
                cmd.AppendLine("           ,[WGBEZ] ");
                cmd.AppendLine("           ,[MENGE] ");
                cmd.AppendLine("           ,[BDMNG]) ");
                cmd.AppendLine("    values ('" + _ZCLSX[i].AUFNR.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].MATNR.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].MAKTX.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].MTART.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].MTBEZ.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].MATKL.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].WGBEZ.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].MENGE.ToString() + "'");
                cmd.AppendLine("          ,'" + _ZCLSX[i].BDMNG.ToString() + "')");
                


                ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

                cmd.Clear();
            }
            #endregion

            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(ArraySql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

            return true;
        }
    }
}
