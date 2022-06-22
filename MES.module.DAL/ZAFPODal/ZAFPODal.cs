using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using System.Collections;

namespace MES.module.DAL.ZAFPODal
{
    public class ZAFPODal
    {

        /// <summary>
        /// 将泛型插入到指定表Tmp_ZAFPO并进行相关操作
        /// </summary>
        /// <param name="_Zafpo">要插入表的泛型</param>
        /// <returns></returns>
        public bool InsertZAFPOALL(List<Tmp_ZAFPO> _Zafpo)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZAFPO插入到Tmp_ZAFPO_history表的SQL
            cmd.AppendLine("INSERT INTO [Tmp_ZAFPO_history] ");
            cmd.AppendLine("           ([AUFNR] ");
            cmd.AppendLine("           ,[KDAUF] ");
            cmd.AppendLine("           ,[KUPOS] ");
            cmd.AppendLine("           ,[AUART] ");
            cmd.AppendLine("           ,[STAT] ");
            cmd.AppendLine("           ,[ZGSTRP] ");
            cmd.AppendLine("           ,[PWERK] ");
            cmd.AppendLine("           ,[ZZSTYLE] ");
            cmd.AppendLine("           ,[MATNR] ");
            cmd.AppendLine("           ,[MAKTX] ");
            cmd.AppendLine("           ,[J_3ASIZE] ");
            cmd.AppendLine("           ,[MENGE] ");
            cmd.AppendLine("           ,[ZCODE] ");
            cmd.AppendLine("          ) ");
            cmd.AppendLine("    select [AUFNR] ");
            cmd.AppendLine("           ,[KDAUF] ");
            cmd.AppendLine("           ,[KUPOS] ");
            cmd.AppendLine("           ,[AUART] ");
            cmd.AppendLine("           ,[STAT] ");
            cmd.AppendLine("           ,[ZGSTRP] ");
            cmd.AppendLine("           ,[PWERK] ");
            cmd.AppendLine("           ,[ZZSTYLE] ");
            cmd.AppendLine("           ,[MATNR] ");
            cmd.AppendLine("           ,[MAKTX] ");
            cmd.AppendLine("           ,[J_3ASIZE] ");
            cmd.AppendLine("           ,[MENGE] ");
            cmd.AppendLine("           ,[ZCODE] ");
            cmd.AppendLine("	from Tmp_ZAFPO ");

            ArraySql.Add(cmd.ToString().Replace("\r","").Replace("\n",""));

            cmd.Clear();
            #endregion

            #region 将Tmp_ZAFPO的老数据删除的SQL
            cmd.AppendLine("delete from Tmp_ZAFPO");
            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将List中的数据插入到Tmp_ZAFPO表的SQL
            for (int i = 0; i < _Zafpo.Count; i++)
            {
                
                cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZAFPO] ");
                cmd.AppendLine("           ([AUFNR] ");
                cmd.AppendLine("           ,[KDAUF] ");
                cmd.AppendLine("           ,[KUPOS] ");
                cmd.AppendLine("           ,[AUART] ");
                cmd.AppendLine("           ,[STAT] ");
                cmd.AppendLine("           ,[ZGSTRP] ");
                cmd.AppendLine("           ,[PWERK] ");
                cmd.AppendLine("           ,[ZZSTYLE] ");
                cmd.AppendLine("           ,[MATNR] ");
                cmd.AppendLine("           ,[MAKTX] ");
                cmd.AppendLine("           ,[J_3ASIZE] ");
                cmd.AppendLine("           ,[MENGE] ");
                cmd.AppendLine("           ,[ZCODE] ");
                cmd.AppendLine("          ) ");
                cmd.AppendLine("     VALUES ");
                cmd.AppendLine("           ('" + _Zafpo[i].AUFNR.ToString() + "'") ;
                cmd.AppendLine("           ,'" + _Zafpo[i].KDAUF.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].KUPOS.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].AUART.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].STAT.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].ZGSTRP.ToShortDateString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].PWERK.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].ZZSTYLE.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].MATNR.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].MAKTX.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].J_3ASIZE.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].MENGE.ToString() + "'");
                cmd.AppendLine("           ,'" + _Zafpo[i].ZCODE.ToString() + "'");
                cmd.AppendLine("           ) ");

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
