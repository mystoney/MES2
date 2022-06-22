using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using System.Collections;

namespace MES.module.DAL.ZBTDATADal
{
    public class ZBTDATADal
    {
        /// <summary>
        /// 将泛型插入到指定表Tmp_ZBTDATA并进行相关操作
        /// </summary>
        /// <param name="_ZBTDATA">要插入表的泛型</param>
        /// <returns>是否成功插入</returns>
        public bool InsertZBTDATAALL(List<Tmp_ZBTDATA> _ZBTDATA)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZBTDATA插入到Tmp_ZBTDATA_history表的SQL
            cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZBTDATA_history] ");
            cmd.AppendLine("           ([AUFNR] ");
            cmd.AppendLine("           ,[ZPART] ");
            cmd.AppendLine("           ,[ZMMTS]) ");
            cmd.AppendLine("     select ([AUFNR] ");
            cmd.AppendLine("           ,[ZPART] ");
            cmd.AppendLine("           ,[ZMMTS] ");
            cmd.AppendLine("	from Tmp_ZBTDATA ");

            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将Tmp_ZBTDATA的老数据删除的SQL
            cmd.AppendLine("delete from Tmp_ZBTDATA");
            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将List中的数据插入到Tmp_ZBTDATA表的SQL
            for (int i = 0; i < _ZBTDATA.Count; i++)
            {

                cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZBTDATA] ");
                cmd.AppendLine("           ([AUFNR] ");
                cmd.AppendLine("           ,[ZPART] ");
                cmd.AppendLine("           ,[ZMMTS]) ");
                cmd.AppendLine("     values ('" + _ZBTDATA[i].AUFNR.ToString() + "'");
                cmd.AppendLine("            ,'" + _ZBTDATA[i].ZPART.ToString() + "'");
                cmd.AppendLine("            ,'" + _ZBTDATA[i].ZMMTS.ToString() + "')");
                

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
