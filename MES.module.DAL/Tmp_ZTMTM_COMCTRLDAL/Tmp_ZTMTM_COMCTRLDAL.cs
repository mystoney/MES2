using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;


namespace MES.module.DAL.Tmp_ZTMTM_COMCTRLDAL
{
    public class Tmp_ZTMTM_COMCTRLDAL
    {

        /// <summary>
        /// 将泛型插入到指定表Tmp_ZTMTM_COMCTRL并进行相关操作
        /// </summary>
        /// <param name="_Tmp_ZTMTM_COMCTRL">要插入表的泛型</param>
        /// <returns></returns>
        public bool InsertALL(List<Tmp_ZTMTM_COMCTRL> _Tmp_ZTMTM_COMCTRL)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 将Tmp_ZAFPO插入到Tmp_ZAFPO_history表的SQL
            for (int i = 0; i < _Tmp_ZTMTM_COMCTRL.Count; i++)
            {

                if (_Tmp_ZTMTM_COMCTRL[i].STATS.ToString().ToUpper() == "C")
                {

                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMCTRL_LOG  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[CATED]  ");
                    cmd.AppendLine("           ,[STYDS]  ");
                    cmd.AppendLine("           ,[STYED]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMES]  ");
                    cmd.AppendLine("           ,[BESPK]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[UNAME],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMCTRL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMES + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].BESPK + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].UNAME + "',getdate(),'新建')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();

                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMCTRL  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[CATED]  ");
                    cmd.AppendLine("           ,[STYDS]  ");
                    cmd.AppendLine("           ,[STYED]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMES]  ");
                    cmd.AppendLine("           ,[BESPK]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[UNAME])  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMCTRL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMES + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].BESPK + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].UNAME + "')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();
                }
                else if (_Tmp_ZTMTM_COMCTRL[i].STATS.ToString().ToUpper() == "M")
                {
                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMCTRL_LOG  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[CATED]  ");
                    cmd.AppendLine("           ,[STYDS]  ");
                    cmd.AppendLine("           ,[STYED]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMES]  ");
                    cmd.AppendLine("           ,[BESPK]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[UNAME],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMCTRL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMES + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].BESPK + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].UNAME + "',getdate(),'修改')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();



                    cmd.AppendLine("UPDATE Tmp_ZTMTM_COMCTRL  ");
                    cmd.AppendLine("   SET [CATGY] = '" + _Tmp_ZTMTM_COMCTRL[i].CATGY + "'  ");
                    cmd.AppendLine("      ,[CATED] = '" + _Tmp_ZTMTM_COMCTRL[i].CATED + "'  ");
                    cmd.AppendLine("      ,[STYDS] = '" + _Tmp_ZTMTM_COMCTRL[i].STYDS + "'  ");
                    cmd.AppendLine("      ,[STYED] = '" + _Tmp_ZTMTM_COMCTRL[i].STYED + "'  ");
                    cmd.AppendLine("      ,[COMPT] = '" + _Tmp_ZTMTM_COMCTRL[i].COMPT + "'  ");
                    cmd.AppendLine("      ,[COMES] = '" + _Tmp_ZTMTM_COMCTRL[i].COMES + "'  ");
                    cmd.AppendLine("      ,[BESPK] = '" + _Tmp_ZTMTM_COMCTRL[i].BESPK + "'  ");
                    cmd.AppendLine("      ,[ERDAT] = '" + _Tmp_ZTMTM_COMCTRL[i].ERDAT + "'  ");
                    cmd.AppendLine("      ,[ERZET] = '" + _Tmp_ZTMTM_COMCTRL[i].ERZET + "'  ");
                    cmd.AppendLine("      ,[ZREFA] = '" + _Tmp_ZTMTM_COMCTRL[i].ZREFA + "'  ");
                    cmd.AppendLine("      ,[STATS] = '" + _Tmp_ZTMTM_COMCTRL[i].STATS + "'  ");
                    cmd.AppendLine("      ,[UNAME] = '" + _Tmp_ZTMTM_COMCTRL[i].UNAME + "'  ");
                    cmd.AppendLine(" WHERE [CATCD] = '" + _Tmp_ZTMTM_COMCTRL[i].CATCD + "' AND  ");
                    cmd.AppendLine("       [STYNU] = '" + _Tmp_ZTMTM_COMCTRL[i].STYNU + "' AND  ");
                    cmd.AppendLine("       [COMCD] = '" + _Tmp_ZTMTM_COMCTRL[i].COMCD + "' AND  ");
                    cmd.AppendLine("       [COMTY] = '" + _Tmp_ZTMTM_COMCTRL[i].COMTY + "' " );



                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();
                }
                else if (_Tmp_ZTMTM_COMCTRL[i].STATS.ToString().ToUpper() == "D")
                {
                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMCTRL_LOG  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[CATED]  ");
                    cmd.AppendLine("           ,[STYDS]  ");
                    cmd.AppendLine("           ,[STYED]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMES]  ");
                    cmd.AppendLine("           ,[BESPK]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS]  ");
                    cmd.AppendLine("           ,[UNAME],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMCTRL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].CATED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STYED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].COMES + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].BESPK + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].STATS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMCTRL[i].UNAME + "',getdate(),'删除')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();


                    cmd.AppendLine("Delete Tmp_ZTMTM_COMCTRL  ");
                    cmd.AppendLine(" WHERE [CATCD] = '" + _Tmp_ZTMTM_COMCTRL[i].CATCD + "' AND  ");
                    cmd.AppendLine("       [STYNU] = '" + _Tmp_ZTMTM_COMCTRL[i].STYNU + "' AND  ");
                    cmd.AppendLine("       [COMCD] = '" + _Tmp_ZTMTM_COMCTRL[i].COMCD + "' AND  ");
                    cmd.AppendLine("       [COMTY] = '" + _Tmp_ZTMTM_COMCTRL[i].COMTY + "' ");



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
