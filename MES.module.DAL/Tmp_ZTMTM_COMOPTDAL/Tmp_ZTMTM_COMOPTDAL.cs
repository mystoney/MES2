using MES.module.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.module.DAL.Tmp_ZTMTM_COMOPTDAL
{
    public class Tmp_ZTMTM_COMOPTDAL
    {

        /// <summary>
        /// 将泛型插入到指定表Tmp_ZTMTM_COMCTRL并进行相关操作
        /// </summary>
        /// <param name="_Tmp_ZTMTM_COMCTRL">要插入表的泛型</param>
        /// <returns></returns>
        public bool InsertALL(List<Tmp_ZTMTM_COMOPT> _Tmp_ZTMTM_COMOPT)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZAFPO插入到Tmp_ZAFPO_history表的SQL
            for (int i = 0; i < _Tmp_ZTMTM_COMOPT.Count; i++)
            {

                if (_Tmp_ZTMTM_COMOPT[i].STATS.ToString().ToUpper() == "C")
                {

                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMOPT_LOG ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[RCOMTY]  ");
                    cmd.AppendLine("           ,[BDCOM]  ");
                    cmd.AppendLine("           ,[BDOPT]  ");
                    cmd.AppendLine("           ,[ACOMTY]  ");
                    cmd.AppendLine("           ,[RJCOM]  ");
                    cmd.AppendLine("           ,[RJOPT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[BDCOMDS]  ");
                    cmd.AppendLine("           ,[BDXXMS]   ");
                    cmd.AppendLine("           ,[RJCOMDS]  ");
                    cmd.AppendLine("           ,[RJXXMS]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[ZREFA],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMOPT[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RCOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ACOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ZREFA + "',getdate(),'新建')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();




                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMOPT ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[RCOMTY]  ");
                    cmd.AppendLine("           ,[BDCOM]  ");
                    cmd.AppendLine("           ,[BDOPT]  ");
                    cmd.AppendLine("           ,[ACOMTY]  ");
                    cmd.AppendLine("           ,[RJCOM]  ");
                    cmd.AppendLine("           ,[RJOPT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[BDCOMDS]  ");
                    cmd.AppendLine("           ,[BDXXMS]   ");
                    cmd.AppendLine("           ,[RJCOMDS]  ");
                    cmd.AppendLine("           ,[RJXXMS]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[ZREFA])  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMOPT[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RCOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ACOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ZREFA + "')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();

                }
                else if (_Tmp_ZTMTM_COMOPT[i].STATS.ToString().ToUpper() == "M")
                {
                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMOPT_LOG ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[RCOMTY]  ");
                    cmd.AppendLine("           ,[BDCOM]  ");
                    cmd.AppendLine("           ,[BDOPT]  ");
                    cmd.AppendLine("           ,[ACOMTY]  ");
                    cmd.AppendLine("           ,[RJCOM]  ");
                    cmd.AppendLine("           ,[RJOPT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[BDCOMDS]  ");
                    cmd.AppendLine("           ,[BDXXMS]   ");
                    cmd.AppendLine("           ,[RJCOMDS]  ");
                    cmd.AppendLine("           ,[RJXXMS]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[ZREFA],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMOPT[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RCOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ACOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ZREFA + "',getdate(),'修改')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();



                    cmd.AppendLine("UPDATE Tmp_ZTMTM_COMOPT  ");
                    cmd.AppendLine("   SET [CATGY] = '" + _Tmp_ZTMTM_COMOPT[i].CATGY + "'  ");
                    cmd.AppendLine("      ,[COMPT] = '" + _Tmp_ZTMTM_COMOPT[i].COMPT + "'  ");
                    cmd.AppendLine("      ,[COMOP] = '" + _Tmp_ZTMTM_COMOPT[i].COMOP + "'  ");
                    cmd.AppendLine("      ,[BDCOMDS] = '" + _Tmp_ZTMTM_COMOPT[i].BDCOMDS + "'  ");
                    cmd.AppendLine("      ,[BDXXMS] = '" + _Tmp_ZTMTM_COMOPT[i].BDXXMS + "'  ");
                    cmd.AppendLine("      ,[RJCOMDS] = '" + _Tmp_ZTMTM_COMOPT[i].RJCOMDS + "'  ");
                    cmd.AppendLine("      ,[RJXXMS] = '" + _Tmp_ZTMTM_COMOPT[i].RJXXMS + "'  ");
                    cmd.AppendLine("      ,[ERDAT] = '" + _Tmp_ZTMTM_COMOPT[i].ERDAT + "'  ");
                    cmd.AppendLine("      ,[ERZET] = '" + _Tmp_ZTMTM_COMOPT[i].ERZET + "'  ");
                    cmd.AppendLine("      ,[UNAME] = '" + _Tmp_ZTMTM_COMOPT[i].UNAME + "'  ");
                    cmd.AppendLine("      ,[STATS] = '" + _Tmp_ZTMTM_COMOPT[i].STATS + "'  ");
                    cmd.AppendLine("      ,[ZREFA] = '" + _Tmp_ZTMTM_COMOPT[i].ZREFA + "'  ");
                    cmd.AppendLine(" WHERE [CATCD] = '" + _Tmp_ZTMTM_COMOPT[i].CATCD + "' and   ");
                    cmd.AppendLine("       [STYNU] = '" + _Tmp_ZTMTM_COMOPT[i].STYNU + "' and   ");
                    cmd.AppendLine("       [COMCD] = '" + _Tmp_ZTMTM_COMOPT[i].COMCD + "' and   ");
                    cmd.AppendLine("       [COMTY] = '" + _Tmp_ZTMTM_COMOPT[i].COMTY + "' and   ");
                    cmd.AppendLine("       [OPTNO] = '" + _Tmp_ZTMTM_COMOPT[i].OPTNO + "' and   ");
                    cmd.AppendLine("       [RCOMTY] = '" + _Tmp_ZTMTM_COMOPT[i].RCOMTY + "' and   ");
                    cmd.AppendLine("       [BDCOM] = '" + _Tmp_ZTMTM_COMOPT[i].BDCOM + "' and   ");
                    cmd.AppendLine("       [BDOPT] = '" + _Tmp_ZTMTM_COMOPT[i].BDOPT + "' and   ");
                    cmd.AppendLine("       [ACOMTY] = '" + _Tmp_ZTMTM_COMOPT[i].ACOMTY + "' and   ");
                    cmd.AppendLine("       [RJCOM] = '" + _Tmp_ZTMTM_COMOPT[i].RJCOM + "' and   ");
                    cmd.AppendLine("       [RJOPT] = '" + _Tmp_ZTMTM_COMOPT[i].RJOPT + "'");
                    

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();
                }
                else if (_Tmp_ZTMTM_COMOPT[i].STATS.ToString().ToUpper() == "D")
                {
                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMOPT_LOG ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[RCOMTY]  ");
                    cmd.AppendLine("           ,[BDCOM]  ");
                    cmd.AppendLine("           ,[BDOPT]  ");
                    cmd.AppendLine("           ,[ACOMTY]  ");
                    cmd.AppendLine("           ,[RJCOM]  ");
                    cmd.AppendLine("           ,[RJOPT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[BDCOMDS]  ");
                    cmd.AppendLine("           ,[BDXXMS]   ");
                    cmd.AppendLine("           ,[RJCOMDS]  ");
                    cmd.AppendLine("           ,[RJXXMS]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[ZREFA],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMOPT[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RCOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ACOMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJOPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].BDXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJCOMDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].RJXXMS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMOPT[i].ZREFA + "',getdate(),'删除')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();




                    cmd.AppendLine("delete  Tmp_ZTMTM_COMOPT ");
                    cmd.AppendLine(" WHERE [CATCD] = '" + _Tmp_ZTMTM_COMOPT[i].CATCD + "' and   ");
                    cmd.AppendLine("       [STYNU] = '" + _Tmp_ZTMTM_COMOPT[i].STYNU + "' and   ");
                    cmd.AppendLine("       [COMCD] = '" + _Tmp_ZTMTM_COMOPT[i].COMCD + "' and   ");
                    cmd.AppendLine("       [COMTY] = '" + _Tmp_ZTMTM_COMOPT[i].COMTY + "' and   ");
                    cmd.AppendLine("       [OPTNO] = '" + _Tmp_ZTMTM_COMOPT[i].OPTNO + "' and   ");
                    cmd.AppendLine("       [RCOMTY] = '" + _Tmp_ZTMTM_COMOPT[i].RCOMTY + "' and   ");
                    cmd.AppendLine("       [BDCOM] = '" + _Tmp_ZTMTM_COMOPT[i].BDCOM + "' and   ");
                    cmd.AppendLine("       [BDOPT] = '" + _Tmp_ZTMTM_COMOPT[i].BDOPT + "' and   ");
                    cmd.AppendLine("       [ACOMTY] = '" + _Tmp_ZTMTM_COMOPT[i].ACOMTY + "' and   ");
                    cmd.AppendLine("       [RJCOM] = '" + _Tmp_ZTMTM_COMOPT[i].RJCOM + "' and   ");
                    cmd.AppendLine("       [RJOPT] = '" + _Tmp_ZTMTM_COMOPT[i].RJOPT + "'");



                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();

                }

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
