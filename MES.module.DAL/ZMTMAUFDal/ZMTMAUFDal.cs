using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using System.Collections;

namespace MES.module.DAL.ZMTMAUFDal
{
    public class ZMTMAUFDal
    {
        /// <summary>
        /// 将泛型插入到指定表Tmp_ZMTMAUF并进行相关操作
        /// </summary>
        /// <param name="_ZMTMAUF">要插入表的泛型</param>
        /// <returns>是否成功插入</returns>
        public bool InsertZMTMAUFALL(List<Tmp_ZMTMAUF> _ZMTMAUF)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZMTMAUF插入到Tmp_ZMTMAUF_history表的SQL


            cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZMTMAUF_history] ");
            cmd.AppendLine("           ([AUFNR] ");
            cmd.AppendLine("           ,[CATCD] ");
            cmd.AppendLine("           ,[COMCD] ");
            cmd.AppendLine("           ,[COMTY] ");
            cmd.AppendLine("           ,[OPTNO] ");
            cmd.AppendLine("           ,[MATCO] ");
            cmd.AppendLine("           ,[NOTEP]) ");
            cmd.AppendLine("    select [AUFNR] ");
            cmd.AppendLine("           ,[CATCD] ");
            cmd.AppendLine("           ,[COMCD] ");
            cmd.AppendLine("           ,[COMTY] ");
            cmd.AppendLine("           ,[OPTNO] ");
            cmd.AppendLine("           ,[MATCO] ");
            cmd.AppendLine("           ,[NOTEP] ");
            cmd.AppendLine("	from Tmp_ZMTMAUF ");

            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将Tmp_ZMTMAUF的老数据删除的SQL
            cmd.AppendLine("delete from Tmp_ZMTMAUF");
            ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));

            cmd.Clear();
            #endregion

            #region 将List中的数据插入到Tmp_ZMTMAUF表的SQL
            for (int i = 0; i < _ZMTMAUF.Count; i++)
            {


                cmd.AppendLine("INSERT INTO [dbo].[Tmp_ZMTMAUF] ");
                cmd.AppendLine("           ([AUFNR] ");
                cmd.AppendLine("           ,[CATCD] ");
                cmd.AppendLine("           ,[COMCD] ");
                cmd.AppendLine("           ,[COMTY] ");
                cmd.AppendLine("           ,[OPTNO] ");
                cmd.AppendLine("           ,[MATCO] ");
                cmd.AppendLine("           ,[NOTEP]) ");
                cmd.AppendLine("    values ('" + _ZMTMAUF[i].AUFNR.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMAUF[i].CATCD.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMAUF[i].COMCD.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMAUF[i].COMTY.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMAUF[i].OPTNO.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMAUF[i].MATCO.ToString() + "'");
                cmd.AppendLine("           ,'" + _ZMTMAUF[i].NOTEP.ToString() + "')");
                

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
