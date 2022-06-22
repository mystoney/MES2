using MES.module.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.module.DAL.Tmp_ZTMTM_COMRELDAL
{
    public class Tmp_ZTMTM_COMRELDAL
    {
        /// <summary>
        /// 将泛型插入到指定表Tmp_ZTMTM_COMREL并进行相关操作
        /// </summary>
        /// <param name="Tmp_ZTMTM_COMREL">要插入表的泛型</param>
        /// <returns></returns>
        public bool InsertALL(List<Tmp_ZTMTM_COMREL> _Tmp_ZTMTM_COMREL)
        {

            ArrayList ArraySql = new ArrayList();

            StringBuilder cmd = new StringBuilder();

            #region 
            for (int i = 0; i < _Tmp_ZTMTM_COMREL.Count; i++)
            {

                if (_Tmp_ZTMTM_COMREL[i].STATS.ToString().ToUpper() == "C")
                {

                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMREL_LOG  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[ZSIZE]  ");
                    cmd.AppendLine("           ,[ZADDATT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[MATCO]  ");
                    cmd.AppendLine("           ,[OPTDS]  ");
                    cmd.AppendLine("           ,[OPTED]  ");
                    cmd.AppendLine("           ,[KEYCOM]  ");
                    cmd.AppendLine("           ,[AMOUNT]  ");
                    cmd.AppendLine("           ,[OPTPR]  ");
                    cmd.AppendLine("           ,[INITOP]  ");
                    cmd.AppendLine("           ,[CUSTOM]  ");
                    cmd.AppendLine("           ,[DISPL]  ");
                    cmd.AppendLine("           ,[DISOD]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMREL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZSIZE + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZADDATT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].MATCO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].KEYCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].AMOUNT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTPR + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].INITOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CUSTOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISPL + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISOD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STATS + "',getdate(),'新建')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();




                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMREL  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[ZSIZE]  ");
                    cmd.AppendLine("           ,[ZADDATT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[MATCO]  ");
                    cmd.AppendLine("           ,[OPTDS]  ");
                    cmd.AppendLine("           ,[OPTED]  ");
                    cmd.AppendLine("           ,[KEYCOM]  ");
                    cmd.AppendLine("           ,[AMOUNT]  ");
                    cmd.AppendLine("           ,[OPTPR]  ");
                    cmd.AppendLine("           ,[INITOP]  ");
                    cmd.AppendLine("           ,[CUSTOM]  ");
                    cmd.AppendLine("           ,[DISPL]  ");
                    cmd.AppendLine("           ,[DISOD]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS])  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMREL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZSIZE + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZADDATT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].MATCO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].KEYCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].AMOUNT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTPR + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].INITOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CUSTOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISPL + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISOD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STATS + "')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();

                }
                else if (_Tmp_ZTMTM_COMREL[i].STATS.ToString().ToUpper() == "M")
                {
                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMREL_LOG  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[ZSIZE]  ");
                    cmd.AppendLine("           ,[ZADDATT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[MATCO]  ");
                    cmd.AppendLine("           ,[OPTDS]  ");
                    cmd.AppendLine("           ,[OPTED]  ");
                    cmd.AppendLine("           ,[KEYCOM]  ");
                    cmd.AppendLine("           ,[AMOUNT]  ");
                    cmd.AppendLine("           ,[OPTPR]  ");
                    cmd.AppendLine("           ,[INITOP]  ");
                    cmd.AppendLine("           ,[CUSTOM]  ");
                    cmd.AppendLine("           ,[DISPL]  ");
                    cmd.AppendLine("           ,[DISOD]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMREL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZSIZE + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZADDATT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].MATCO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].KEYCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].AMOUNT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTPR + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].INITOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CUSTOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISPL + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISOD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STATS + "',getdate(),'修改')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();


    



                    cmd.AppendLine("UPDATE ZTMTM_COMREL  ");
                    cmd.AppendLine("   SET [CATGY] = '" + _Tmp_ZTMTM_COMREL[i].CATGY + "'  ");
                    cmd.AppendLine("      ,[COMPT] = '" + _Tmp_ZTMTM_COMREL[i].COMPT + "'  ");
                    cmd.AppendLine("      ,[COMOP] = '" + _Tmp_ZTMTM_COMREL[i].COMOP + "'  ");
                    cmd.AppendLine("      ,[MATCO] = '" + _Tmp_ZTMTM_COMREL[i].MATCO + "'  ");
                    cmd.AppendLine("      ,[OPTDS] = '" + _Tmp_ZTMTM_COMREL[i].OPTDS + "'  ");
                    cmd.AppendLine("      ,[OPTED] = '" + _Tmp_ZTMTM_COMREL[i].OPTED + "'  ");
                    cmd.AppendLine("      ,[KEYCOM] = '" + _Tmp_ZTMTM_COMREL[i].KEYCOM + "'  ");
                    cmd.AppendLine("      ,[AMOUNT] = '" + _Tmp_ZTMTM_COMREL[i].AMOUNT + "'  ");
                    cmd.AppendLine("      ,[OPTPR] = '" + _Tmp_ZTMTM_COMREL[i].OPTPR + "'  ");
                    cmd.AppendLine("      ,[INITOP] = '" + _Tmp_ZTMTM_COMREL[i].INITOP + "'  ");
                    cmd.AppendLine("      ,[CUSTOM] = '" + _Tmp_ZTMTM_COMREL[i].CUSTOM + "'  ");
                    cmd.AppendLine("      ,[DISPL] = '" + _Tmp_ZTMTM_COMREL[i].DISPL + "'  ");
                    cmd.AppendLine("      ,[DISOD] = '" + _Tmp_ZTMTM_COMREL[i].DISOD + "'  ");
                    cmd.AppendLine("      ,[ERDAT] = '" + _Tmp_ZTMTM_COMREL[i].ERDAT + "'  ");
                    cmd.AppendLine("      ,[ERZET] = '" + _Tmp_ZTMTM_COMREL[i].ERZET + "'  ");
                    cmd.AppendLine("      ,[UNAME] = '" + _Tmp_ZTMTM_COMREL[i].UNAME + "'  ");
                    cmd.AppendLine("      ,[ZREFA] = '" + _Tmp_ZTMTM_COMREL[i].ZREFA + "'  ");
                    cmd.AppendLine("      ,[STATS] = '" + _Tmp_ZTMTM_COMREL[i].STATS + "'  ");
                    cmd.AppendLine(" WHERE [CATCD] = '" + _Tmp_ZTMTM_COMREL[i].CATCD + "'  ");
                    cmd.AppendLine("       [STYNU] = '" + _Tmp_ZTMTM_COMREL[i].STYNU + "' and  ");
                    cmd.AppendLine("       [COMCD] = '" + _Tmp_ZTMTM_COMREL[i].COMCD + "' and  ");
                    cmd.AppendLine("       [COMTY] = '" + _Tmp_ZTMTM_COMREL[i].COMTY + "' and  ");
                    cmd.AppendLine("       [OPTNO] = '" + _Tmp_ZTMTM_COMREL[i].OPTNO + "' and  ");
                    cmd.AppendLine("       [ZSIZE] = '" + _Tmp_ZTMTM_COMREL[i].ZSIZE + "' and  ");
                    cmd.AppendLine("       [ZADDATT] = '" + _Tmp_ZTMTM_COMREL[i].ZADDATT + "'  ");


                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();
                }
                else if (_Tmp_ZTMTM_COMREL[i].STATS.ToString().ToUpper() == "D")
                {
                    cmd.AppendLine("INSERT INTO Tmp_ZTMTM_COMREL_LOG  ");
                    cmd.AppendLine("           ([CATCD]  ");
                    cmd.AppendLine("           ,[STYNU]  ");
                    cmd.AppendLine("           ,[COMCD]  ");
                    cmd.AppendLine("           ,[COMTY]  ");
                    cmd.AppendLine("           ,[OPTNO]  ");
                    cmd.AppendLine("           ,[ZSIZE]  ");
                    cmd.AppendLine("           ,[ZADDATT]  ");
                    cmd.AppendLine("           ,[CATGY]  ");
                    cmd.AppendLine("           ,[COMPT]  ");
                    cmd.AppendLine("           ,[COMOP]  ");
                    cmd.AppendLine("           ,[MATCO]  ");
                    cmd.AppendLine("           ,[OPTDS]  ");
                    cmd.AppendLine("           ,[OPTED]  ");
                    cmd.AppendLine("           ,[KEYCOM]  ");
                    cmd.AppendLine("           ,[AMOUNT]  ");
                    cmd.AppendLine("           ,[OPTPR]  ");
                    cmd.AppendLine("           ,[INITOP]  ");
                    cmd.AppendLine("           ,[CUSTOM]  ");
                    cmd.AppendLine("           ,[DISPL]  ");
                    cmd.AppendLine("           ,[DISOD]  ");
                    cmd.AppendLine("           ,[ERDAT]  ");
                    cmd.AppendLine("           ,[ERZET]  ");
                    cmd.AppendLine("           ,[UNAME]  ");
                    cmd.AppendLine("           ,[ZREFA]  ");
                    cmd.AppendLine("           ,[STATS],INPUT_TIME,state)  ");
                    cmd.AppendLine("     VALUES  ");
                    cmd.AppendLine("           ('" + _Tmp_ZTMTM_COMREL[i].CATCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STYNU + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMCD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMTY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTNO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZSIZE + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZADDATT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CATGY + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMPT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].COMOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].MATCO + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTDS + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTED + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].KEYCOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].AMOUNT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].OPTPR + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].INITOP + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].CUSTOM + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISPL + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].DISOD + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERDAT + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ERZET + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].UNAME + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].ZREFA + "'  ");
                    cmd.AppendLine("           ,'" + _Tmp_ZTMTM_COMREL[i].STATS + "',getdate(),'删除')  ");

                    ArraySql.Add(cmd.ToString().Replace("\r", "").Replace("\n", ""));
                    cmd.Clear();






                    cmd.AppendLine("delete ZTMTM_COMREL  ");
                    cmd.AppendLine(" WHERE [CATCD] = '" + _Tmp_ZTMTM_COMREL[i].CATCD + "'  ");
                    cmd.AppendLine("       [STYNU] = '" + _Tmp_ZTMTM_COMREL[i].STYNU + "' and  ");
                    cmd.AppendLine("       [COMCD] = '" + _Tmp_ZTMTM_COMREL[i].COMCD + "' and  ");
                    cmd.AppendLine("       [COMTY] = '" + _Tmp_ZTMTM_COMREL[i].COMTY + "' and  ");
                    cmd.AppendLine("       [OPTNO] = '" + _Tmp_ZTMTM_COMREL[i].OPTNO + "' and  ");
                    cmd.AppendLine("       [ZSIZE] = '" + _Tmp_ZTMTM_COMREL[i].ZSIZE + "' and  ");
                    cmd.AppendLine("       [ZADDATT] = '" + _Tmp_ZTMTM_COMREL[i].ZADDATT + "'  ");


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
