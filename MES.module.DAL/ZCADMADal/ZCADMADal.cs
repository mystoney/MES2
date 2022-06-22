using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using System.Collections;

namespace MES.module.DAL.ZCADMADal
{
    public class ZCADMADal
    {
        /// <summary>
        /// 将泛型插入到指定表Tmp_ZCADMA并进行相关操作
        /// </summary>
        /// <param name="_ZBTDATA">要插入表的泛型</param>
        /// <returns>是否成功插入</returns>
        public bool InsertZCADMAALL(List<Tmp_ZCADMA> _ZCADMA)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZCADMA插入到Tmp_ZCADMA_history表的SQL
            cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZCADMA_history] ");
            cmd.AppendLine("           ([AUFNR] ");
            cmd.AppendLine("           ,[MATNR] ");
            cmd.AppendLine("           ,[MAKTX] ");
            cmd.AppendLine("           ,[ZZTEXTURE] ");
            cmd.AppendLine("           ,[ZZBREADTH] ");
            cmd.AppendLine("           ,[MEINS]) ");
            cmd.AppendLine("    select [AUFNR] ");
            cmd.AppendLine("           ,[MATNR] ");
            cmd.AppendLine("           ,[MAKTX] ");
            cmd.AppendLine("           ,[ZZTEXTURE] ");
            cmd.AppendLine("           ,[ZZBREADTH] ");
            cmd.AppendLine("           ,[MEINS] ");
            cmd.AppendLine("	from Tmp_ZCADMA ");

            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将Tmp_ZCADMA的老数据删除的SQL
            cmd.AppendLine("delete from Tmp_ZCADMA");
            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将List中的数据插入到Tmp_ZCADMA表的SQL
            for (int i = 0; i < _ZCADMA.Count; i++)
            {
                
                cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZCADMA] ");
                cmd.AppendLine("           ([AUFNR] ");
                cmd.AppendLine("           ,[MATNR] ");
                cmd.AppendLine("           ,[MAKTX] ");
                cmd.AppendLine("           ,[ZZTEXTURE] ");
                cmd.AppendLine("           ,[ZZBREADTH] ");
                cmd.AppendLine("           ,[MEINS]) ");
                cmd.AppendLine("    values ('" + _ZCADMA[i].AUFNR.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZCADMA[i].MATNR.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZCADMA[i].MAKTX.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZCADMA[i].ZZTEXTURE.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZCADMA[i].ZZBREADTH.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZCADMA[i].MEINS.ToString() + "')");

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
