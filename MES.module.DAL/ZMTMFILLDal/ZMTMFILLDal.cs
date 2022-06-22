using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using System.Collections;

namespace MES.module.DAL.ZMTMFILLDal
{
    public class ZMTMFILLDal
    {
        /// <summary>
        /// 将泛型插入到指定表Tmp_ZMTMFILL并进行相关操作
        /// </summary>
        /// <param name="_ZMTMFILL">要插入表的泛型</param>
        /// <returns>是否成功插入</returns>
        public bool InsertZMTMFILLALL(List<Tmp_ZMTMFILL> _ZMTMFILL)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZMTMFILL插入到Tmp_ZMTMFILL_history表的SQL


            cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZMTMFILL_history] ");
            cmd.AppendLine("           ([AUFNR] ");
            cmd.AppendLine("           ,[STYNU] ");
            cmd.AppendLine("           ,[CATCD] ");
            cmd.AppendLine("           ,[ZSIZE] ");
            cmd.AppendLine("           ,[ZSTUFNO] ");
            cmd.AppendLine("           ,[ZSTUF] ");
            cmd.AppendLine("           ,[ZPART] ");
            cmd.AppendLine("           ,[ZLINE] ");
            cmd.AppendLine("           ,[ZSQURE] ");
            cmd.AppendLine("           ,[ZGRAMS] ");
            cmd.AppendLine("           ,[ZQUANT] ");
            cmd.AppendLine("           ,[ZCUML]) ");
            cmd.AppendLine("    select [AUFNR] ");
            cmd.AppendLine("           ,[STYNU] ");
            cmd.AppendLine("           ,[CATCD] ");
            cmd.AppendLine("           ,[ZSIZE] ");
            cmd.AppendLine("           ,[ZSTUFNO] ");
            cmd.AppendLine("           ,[ZSTUF] ");
            cmd.AppendLine("           ,[ZPART] ");
            cmd.AppendLine("           ,[ZLINE] ");
            cmd.AppendLine("           ,[ZSQURE] ");
            cmd.AppendLine("           ,[ZGRAMS] ");
            cmd.AppendLine("           ,[ZQUANT] ");
            cmd.AppendLine("           ,[ZCUML] ");
            cmd.AppendLine("	from Tmp_ZMTMFILL ");

            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将Tmp_ZMTMFILL的老数据删除的SQL
            cmd.AppendLine("delete from Tmp_ZMTMFILL");
            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将List中的数据插入到Tmp_ZMTMFILL表的SQL
            for (int i = 0; i < _ZMTMFILL.Count; i++)
            {

                cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZMTMFILL] ");
                cmd.AppendLine("           ([AUFNR] ");
                cmd.AppendLine("           ,[STYNU] ");
                cmd.AppendLine("           ,[CATCD] ");
                cmd.AppendLine("           ,[ZSIZE] ");
                cmd.AppendLine("           ,[ZSTUFNO] ");
                cmd.AppendLine("           ,[ZSTUF] ");
                cmd.AppendLine("           ,[ZPART] ");
                cmd.AppendLine("           ,[ZLINE] ");
                cmd.AppendLine("           ,[ZSQURE] ");
                cmd.AppendLine("           ,[ZGRAMS] ");
                cmd.AppendLine("           ,[ZQUANT] ");
                cmd.AppendLine("           ,[ZCUML]) ");
                cmd.AppendLine("    values  ('" + _ZMTMFILL[i].AUFNR.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].STYNU.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].CATCD.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZSIZE.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZSTUFNO.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZSTUF.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZPART.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZLINE.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZSQURE.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZGRAMS.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZQUANT.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMFILL[i].ZCUML.ToString() + "')");
                


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
