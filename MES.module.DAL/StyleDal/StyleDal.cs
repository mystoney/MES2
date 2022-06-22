using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES.module.model;
using MES.module.Base.PublicClass;
using System.Collections;
using System.Reflection;


namespace MES.module.DAL.StyleDal
{
    public class StyleDal
    {


        #region 不需要的代码

        /// <summary>
        /// 已保存的选项清单
        /// </summary>
        /// <param name="Style_no">款号</param>
        /// <returns></returns>
        public DataTable GetSQLOptionList(string Style_no)
        {
            //string strsql = "SELECT id,Style_No,Item_No,Item_ID,Item_Name,convert(varchar(50),Item_ID)+'|'+rtrim(Item_Name) as Item_List,Option_No,Option_Name,convert(varchar(50),Option_No)+'|'+rtrim(Option_Name) as Option_List,Item_Name+'|'+rtrim(Option_Name) as ItemOption_List,sync_time FROM nMES_Style_OptionList where Style_No='" + Style_no + "' Order by Item_No,Option_No";
            string strsql = "SELECT rtrim(Option_Name)+'|'+rtrim(Item_Name)+'|'+convert(varchar(50),Item_ID)+'|'+convert(varchar(50),Option_No) as ItemOption_List FROM nMES_Style_OptionList where Style_No='" + Style_no + "' Order by Item_No,Option_No";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            return dt;
        }


        /// <summary>
        /// 加载选项清单
        /// </summary>
        /// <param name="Style_no">款号</param>
        /// <returns>选项清单</returns>
        public DataTable getItemList(string Style_no)
        {
            DataTable dt = new DataTable();
            if (Style_no != "")
            {
                string strsql = "SELECT[Item_No],[Id] as Item_ID ,[Name] as Item_Name ,Item_No + '|' + rtrim(Name) as Item_List  FROM[mes].[dbo].[nMES_Option_FromZYQ_2$]  where Style_no = '" + Style_no + "' and name<>'' Order by Item_No ";
                //string strsql = "select distinct Item_No,Item_ID,Item_Name,Item_No+'|'+rtrim(Item_Name) as Item_List  from nMES_Style_OptionList where Style_no='" + Style_no + "'";

                dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Item_No");
                dt.Columns.Add("Item_ID");
                dt.Columns.Add("Item_Name");
                dt.Columns.Add("Item_List");
            }
            return dt;
        }
        /// <summary>
        /// 加载选项值
        /// </summary>
        /// <param name="Style_no">款号</param>
        /// <param name="Item_No">选项</param>
        /// <returns>选项值</returns>
        public DataTable getOptionList(string Style_no, string Item_No)
        {
            DataTable dt = new DataTable();
            if (Style_no != "" && Item_No != "")
            {
                string strsql = "SELECT Style_No,Item_No,Option_No,Id as Option_ID,Name as Option_Name,convert(varchar(50),Option_No)+'|'+rtrim(Name) as Option_List FROM nMES_Option_FromZYQ_3$ where Style_No='" + Style_no + "' AND Item_No='" + Item_No + "' Order by Item_No,Option_No";
                dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Option_No");
                dt.Columns.Add("Option_Name");
                dt.Columns.Add("Option_List");
            }
            return dt;
        }

        #endregion

        /// <summary>
        /// 获取保存的关键选项清单
        /// </summary>
        /// <param name="Style_No">款号</param>
        /// <returns></returns>
        public DataTable GetKeyOptionList(string Style_No)
        {
            DataTable dt = new DataTable();
            if (Style_No != "")
            {
                string strsql = "SELECT Style_No,Item_No ,Item_Name,Option_No,Option_Name,sync_time  FROM nMES_Style_OptionList where Style_No='" + Style_No + "' order by Item_No,Option_No";
                dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            }
            return dt;
        }



        ///   <summary>
        ///   比较两个DataTable内容是否相等，先是比数量，数量相等就比内容
        ///   </summary>
        ///   <param   name= "dtA "> </param>
        ///   <param   name= "dtB "> </param>
        public bool CompareDataTable(DataTable dtA, DataTable dtB)
        {
            if (dtA.Rows.Count == dtB.Rows.Count)
            {
                if (CompareColumn(dtA.Columns, dtB.Columns))
                {
                    //比内容
                    for (int i = 0; i < dtA.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtA.Columns.Count; j++)
                        {
                            if (!dtA.Rows[i][j].Equals(dtB.Rows[i][j]))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public DataTable DTDifference(DataTable dtA, DataTable dtB)
        {

            //获取两个数据源的差集
            IEnumerable<DataRow> query2 = dtB.AsEnumerable().Except(dtA.AsEnumerable(), DataRowComparer.Default);
            //两个数据源的差集集合
            DataTable dt3 = query2.CopyToDataTable();
            return dt3;
        }



        ///   <summary>
        ///   比较两个字段集合是否名称,数据类型一致
        ///   </summary>
        ///   <param   name= "dcA "> </param>
        ///   <param   name= "dcB "> </param>
        ///   <returns> </returns>
        private bool CompareColumn(System.Data.DataColumnCollection dcA, System.Data.DataColumnCollection dcB)
        {
            if (dcA.Count == dcB.Count)
            {
                foreach (DataColumn dc in dcA)
                {
                    //找相同字段名称
                    if (dcB.IndexOf(dc.ColumnName) > -1)
                    {
                        //测试数据类型
                        if (dc.DataType != dcB[dcB.IndexOf(dc.ColumnName)].DataType)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">关键选项清单nMES_Style_OptionList</param>
        /// <param name="ds">选项组合nMES_Style_Combination</param>
        /// <param name="Style_No">款号</param>
        /// <returns></returns>
        public int NewStyleOption(DataTable dt, DataSet ds, string Style_No)
        {
            ArrayList SQLList = new ArrayList();
            //删除原款号对应的选项
            SQLList.Add("DELETE FROM [dbo].[nMES_Style_OptionList] WHERE Style_No='" + Style_No + "'");

            if (dt.Rows.Count > 0)
            {

                //插入此款号需要的选项
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    StringBuilder cmd = new StringBuilder();
                    cmd.Clear();
                    cmd.AppendLine(" INSERT INTO [dbo].[nMES_Style_OptionList] ");
                    cmd.AppendLine("            ([Style_No] ");
                    cmd.AppendLine("            ,[Item_No] ");
                    cmd.AppendLine("            ,[Item_Name] ");
                    cmd.AppendLine("            ,[Option_No] ");
                    cmd.AppendLine("            ,[Option_Name] ");
                    cmd.AppendLine("            ,[sync_time]) ");
                    cmd.AppendLine("      VALUES ");
                    cmd.AppendLine("            ('" + dt.Rows[j]["Style_No"].ToString() + "' ");
                    cmd.AppendLine("            ,'" + dt.Rows[j]["Item_No"].ToString() + "' ");
                    cmd.AppendLine("            ,'" + dt.Rows[j]["Item_Name"].ToString() + "' ");
                    cmd.AppendLine("            ,'" + dt.Rows[j]["Option_No"].ToString() + "' ");
                    cmd.AppendLine("            ,'" + dt.Rows[j]["Option_Name"].ToString() + "' ");
                    cmd.AppendLine("            , GETDATE()) ");
                    SQLList.Add(cmd.ToString());
                }
            }








            List<int> NoInsert_Combination_no = new List<int>();

            if (ds.Tables["dt_ItemCombination_master"].Rows.Count > 0)
            {
                //将此款号原有的方案状态设置为停用 停用：1 现用：0
                StringBuilder ChangeStateStringTo1 = new StringBuilder();
                ChangeStateStringTo1.Clear();
                ChangeStateStringTo1.AppendLine(" UPDATE nMES_Style_Combination_master ");
                ChangeStateStringTo1.AppendLine("    SET Combination_state = 1 ");
                ChangeStateStringTo1.AppendLine("       ,ChangeStateTime = getdate() ");
                ChangeStateStringTo1.AppendLine("  WHERE Style_no='" + ds.Tables["dt_ItemCombination_master"].Rows[0]["Style_no"].ToString() + "' ");
                SQLList.Add(ChangeStateStringTo1.ToString());




                for (int j = 0; j < ds.Tables["dt_ItemCombination_master"].Rows.Count; j++)
                {
                    //查找一下数据库表中，是否有一样的行 有则记录Combination_no 没有则生成insert语句
                    string str = "SELECT Combination_no FROM nMES_Style_Combination_master where Style_no='" + ds.Tables["dt_ItemCombination_master"].Rows[j]["Style_no"].ToString() + "' and memo_no='" + ds.Tables["dt_ItemCombination_master"].Rows[j]["memo_no"].ToString() + "'";
                    DataSet ds_Combination_no = new DataSet();
                    ds_Combination_no = DBConn.DataAcess.SqlConn.Query(str);
                    if (ds_Combination_no.Tables[0].Rows.Count > 0)
                    {
                        //如果有相同的，则update数据库中Combination_state的值为0  停用：1 现用：0 
                        StringBuilder ChangeStateStringTo0 = new StringBuilder();
                        ChangeStateStringTo0.Clear();
                        ChangeStateStringTo0.AppendLine(" UPDATE nMES_Style_Combination_master ");
                        ChangeStateStringTo0.AppendLine("    SET Combination_state = 0 ");
                        ChangeStateStringTo0.AppendLine("       ,ChangeStateTime = getdate() ");
                        ChangeStateStringTo0.AppendLine("  WHERE Combination_no='" + ds_Combination_no.Tables[0].Rows[0][0] + "' ");
                        SQLList.Add(ChangeStateStringTo0.ToString());



                        //记录不插入detail表格
                        NoInsert_Combination_no.Add(Convert.ToInt32(ds.Tables["dt_ItemCombination_master"].Rows[j]["Combination_no"].ToString()));


                    }
                    else
                    {
                        StringBuilder cmd = new StringBuilder();
                        cmd.Clear();
                        cmd.AppendLine(" INSERT INTO nMES_Style_Combination_master ");
                        cmd.AppendLine("            (Style_no ");
                        cmd.AppendLine("            ,Combination_no ");
                        cmd.AppendLine("            ,memo_no ");
                        cmd.AppendLine("            ,memo_name ");
                        cmd.AppendLine("            ,Combination_state ");
                        cmd.AppendLine("            ,Create_time) ");
                        cmd.AppendLine("      VALUES ");
                        cmd.AppendLine("            ('" + ds.Tables["dt_ItemCombination_master"].Rows[j]["Style_no"].ToString() + "'");
                        cmd.AppendLine("            ," + ds.Tables["dt_ItemCombination_master"].Rows[j]["Combination_no"].ToString() + "");
                        cmd.AppendLine("            ,'" + ds.Tables["dt_ItemCombination_master"].Rows[j]["memo_no"].ToString() + "'  ");
                        cmd.AppendLine("            ,'" + ds.Tables["dt_ItemCombination_master"].Rows[j]["memo_name"].ToString() + "'  ");
                        cmd.AppendLine("            ,0");
                        cmd.AppendLine("            ,getdate()) ");

                        SQLList.Add(cmd.ToString());
                    }
                }

            }
            if (ds.Tables["dt_ItemCombination_detail"].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables["dt_ItemCombination_detail"].Rows.Count; j++)
                {
                    int Combination_no = Convert.ToInt32(ds.Tables["dt_ItemCombination_detail"].Rows[j]["Combination_no"].ToString());
                    if (NoInsert_Combination_no.Contains(Combination_no) == false)
                    {
                        StringBuilder cmd = new StringBuilder();
                        cmd.Clear();
                        cmd.AppendLine(" INSERT INTO nMES_Style_Combination_detail ");
                        cmd.AppendLine("            (Combination_no ");
                        cmd.AppendLine("            ,Item_No");
                        cmd.AppendLine("            ,Item_Name");
                        cmd.AppendLine("            ,Option_No ");
                        cmd.AppendLine("            ,Option_Name) ");
                        cmd.AppendLine("      VALUES ");
                        cmd.AppendLine("            ('" + ds.Tables["dt_ItemCombination_detail"].Rows[j]["Combination_no"].ToString() + "'");
                        cmd.AppendLine("            ,'" + ds.Tables["dt_ItemCombination_detail"].Rows[j]["Item_No"].ToString() + "' ");
                        cmd.AppendLine("            ,'" + ds.Tables["dt_ItemCombination_detail"].Rows[j]["Item_Name"].ToString() + "' ");
                        cmd.AppendLine("            ,'" + ds.Tables["dt_ItemCombination_detail"].Rows[j]["Option_No"].ToString() + "' ");
                        cmd.AppendLine("            ,'" + ds.Tables["dt_ItemCombination_detail"].Rows[j]["Option_Name"].ToString() + "') ");
                        SQLList.Add(cmd.ToString());
                    }
                }
            }

            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(SQLList);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }


        public class GeStyleModel
        {
            #region 字段信息

            /// <summary>
            /// 款号
            /// </summary>
            public string style_no { get; set; }

            /// <summary>
            /// 选项
            /// </summary>
            public string Item_No { get; set; }

            /// <summary>
            /// 选项说明
            /// </summary>
            public string Item_Name { get; set; }

            /// <summary>
            /// 选项值
            /// </summary>
            public int Option_No { get; set; }

            /// <summary>
            /// 选项值说明
            /// </summary>
            public string Option_Name { get; set; }

            #endregion
        }


        #region 生成选项及选项值的组合
        /// <summary>
        /// 传入选项及选项值 得到组合清单
        /// </summary>
        /// <param name="dt_style">款式选项对照表</param>
        /// <returns></returns>
        public DataSet GetItemCombination(DataTable dt_style)
        {


            DataSet ds = new DataSet();

            DataTable dt_ItemCombination_master = new DataTable();
            dt_ItemCombination_master.TableName = "dt_ItemCombination_master";
            dt_ItemCombination_master.Columns.Add("style_no");
            dt_ItemCombination_master.Columns.Add("Combination_no");
            dt_ItemCombination_master.Columns.Add("memo_no");
            dt_ItemCombination_master.Columns.Add("memo_name");

            DataTable dt_ItemCombination_detail = new DataTable();
            dt_ItemCombination_detail.TableName = "dt_ItemCombination_detail";
            dt_ItemCombination_detail.Columns.Add("Combination_no");
            dt_ItemCombination_detail.Columns.Add("Item_No");
            dt_ItemCombination_detail.Columns.Add("Item_Name");
            dt_ItemCombination_detail.Columns.Add("Option_No");
            dt_ItemCombination_detail.Columns.Add("Option_Name");

            if (dt_style.Rows.Count == 0)
            {
                return ds;
            }
            string style_no = dt_style.Rows[0]["style_no"].ToString().Trim();

            int Max_Combination_no = Convert.ToInt32(DBConn.DataAcess.SqlConn.GetSingle("SELECT case when max(Combination_no) is null then 0 else max(Combination_no) end as Combination_no FROM nMES_Style_Combination_master"));


            //itemlist是不同Item_No的Option_No的集合
            List<List<string>> itemlist = new List<List<string>>();

            //获取共有几个item_no
            DataTable dt_item = dt_style.DefaultView.ToTable(true, new string[] { "Item_No" }) ;
            DataTable dt_Item_Name = dt_style.DefaultView.ToTable(true, new string[] { "Item_Name" });

            DataTable dt_item1 = dt_style.DefaultView.ToTable("dt_item1",true, new string[] { "Item_No", "Item_Name"});





            for (int i = 0; i < dt_item1.Rows.Count; i++)
            {
                //此Item_No对应的Option_No
                List<string> optionlist = new List<string>();

                DataRow[] drs2 = dt_style.Select("Item_No = '" + dt_item1.Rows[i]["Item_No"] + "'");

                for (int j = 0; j < drs2.Length; j++)
                {
                    optionlist.Add(dt_item1.Rows[i]["Item_No"].ToString().Trim() + "=" + drs2[j]["Option_No"].ToString().Trim() + " ");
                }
                itemlist.Add(optionlist);

            }

            //中文
            List<List<string>> itemnamelist = new List<List<string>>();
            for (int i = 0; i < dt_item1.Rows.Count; i++)
            {
                //此Item_No对应的Option_No
                List<string> Option_Name_List = new List<string>();
                DataRow[] drs2 = dt_style.Select("Item_No = '" + dt_item1.Rows[i]["Item_No"] + "'");

                for (int j = 0; j < drs2.Length; j++)
                {
                   Option_Name_List.Add(dt_item1.Rows[i]["Item_Name"].ToString().Trim() + "=" + drs2[j]["Option_Name"].ToString().Trim() + " ");
                }
                itemnamelist.Add(Option_Name_List);
            }



            //获取所有组合 ResultList
            List<string> ResultList = new List<string>();
            run(itemlist, ResultList, 0, "");
            List<string> result = new List<string>();
            result = ResultList.Distinct().ToList();


            //获取所有组合 ResultList
            List<string> ResultList_name = new List<string>();
            run(itemnamelist, ResultList_name, 0, "");
            List<string> result_name = new List<string>();
            result_name = ResultList_name.Distinct().ToList();





            for (int i = 0; i < ResultList.Count; i++)
            {
                DataRow dr_master = dt_ItemCombination_master.NewRow();
                dr_master["style_no"] = dt_style.Rows[0]["style_no"];
                Max_Combination_no = Max_Combination_no + 1;
                dr_master["Combination_no"] = Max_Combination_no;
                dr_master["memo_no"] = ResultList[i].Trim();
                //[memo_name]拼中文描述
                dr_master["memo_name"] = ResultList_name[i].Trim();



                dt_ItemCombination_master.Rows.Add(dr_master);


                //将不同选项分割为不同行
                string[] s = ResultList[i].Trim().Split(' ');
                string[] s_name = ResultList_name[i].Trim().Split(' ');

                for (int j = 0; j < s.Length; j++)
                {
                    string[] item = s[j].Split('=');

                    string[] name = s_name[j].Split('=');

                    List<DataRow> detail = new List<DataRow>();
                    DataRow dr = dt_ItemCombination_detail.NewRow();
                    dr["Combination_no"] = Max_Combination_no;
                    dr["Item_No"] = item[0];
                    dr["Item_Name"] = name[0];
                    dr["Option_No"] = item[1];
                    dr["Option_Name"] = name[1];

                    List<string> detail_column = new List<string>();
                    dt_ItemCombination_detail.Rows.Add(dr);
                }





            }

            ds.Tables.Add(dt_ItemCombination_master);
            ds.Tables.Add(dt_ItemCombination_detail);


            return ds;
        }
        #endregion

        #region 笛卡尔积



        /// <summary> 
        /// 利用反射将DataTable转换为List<T>对象
        /// </summary> 
        /// <param name="dt">DataTable 对象</param> 
        /// <returns>List<T>集合</returns> 
        public static List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            // 定义集合 
            List<T> ts = new List<T>();
            //定义一个临时变量 
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行 
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性 
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性 
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量 
                                       //检查DataTable是否包含此列（列名==对象的属性名）  
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值 
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性 
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中 
                ts.Add(t);
            }
            return ts;
        }

        /// <summary>
        /// 笛卡尔积
        /// </summary>
        /// <param name="dimvalue">将每个维度的集合的元素视为List<string>,多个集合构成List<List<string>> dimvalue作为输入</param>
        /// <param name="result">将多维笛卡尔乘积的结果放到List<string> result之中作为输出</param>
        /// <param name="layer">int layer 只是两个中间过程的参数携带变量</param>
        /// <param name="curstring"> string curstring只是两个中间过程的参数携带变量,传递""就行</param>
        public static void run(List<List<string>> dimvalue, List<string> result, int layer = 0, string curstring = "")
        {
            if (layer < dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0)
                    run(dimvalue, result, layer + 1, curstring);
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        StringBuilder s1 = new StringBuilder();
                        s1.Append(curstring);
                        s1.Append(dimvalue[layer][i]);
                        run(dimvalue, result, layer + 1, s1.ToString());
                    }
                }
            }
            else if (layer == dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0) result.Add(curstring);
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        result.Add(curstring + dimvalue[layer][i] + " ");
                    }
                }
            }
        }

        #endregion


        /// <summary>
        /// 加载款号清单-MES
        /// </summary>
        /// <returns>款号清单</returns>
        public DataTable getStyleList()
        {
            //string strsql = "select distinct Style_No from nMES_Style_OptionList group by Style_No";
            string strsql = "SELECT style_no  FROM nMES_Style_OptionList  group by style_no";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(strsql).Tables[0];
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            //DataToClass.DataToList<StationInh>(dt)
            return dt;
        }

        /// <summary>
        /// 获取款号清单
        /// </summary>
        /// <param name="style_no">款号</param>
        /// <param name="needspacerow">0=ComboBox需要空行 1=Datagridview不需要空行</param>
        /// <returns></returns>
        public DataTable getCombinationList(string style_no, int needspacerow)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.Clear();
            cmd.AppendLine(" SELECT Style_no ");
            cmd.AppendLine("       ,Combination_no ");
            cmd.AppendLine("       ,memo_no ");
            cmd.AppendLine("       ,memo_name ");
            cmd.AppendLine("       ,case when ChangeStateTime is null then Create_time else ChangeStateTime end as app_time ");
            cmd.AppendLine("   FROM nMES_Style_Combination_master ");
            cmd.AppendLine("   where Style_no='" + style_no + "' and Combination_state=0 ");
            DataTable dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];
            if (needspacerow == 0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
            }
            //DataToClass.DataToList<StationInh>(dt)
            return dt;
        }


        public DataTable GetStyleItemList(string Style_no)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine(" SELECT Item_No ");
            sqlstr.AppendLine("   FROM nMES_Style_Combination_detail ");
            sqlstr.AppendLine("   left join nMES_Style_Combination_master ");
            sqlstr.AppendLine("   on nMES_Style_Combination_detail.Combination_no =nMES_Style_Combination_master.Combination_no ");
            sqlstr.AppendLine("   where style_no='"+ Style_no+ "' and Combination_state=0 ");
            sqlstr.AppendLine("   GROUP BY Item_No ");

            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlstr.ToString()).Tables[0];
            return dt;
        }

        /// <summary>
        /// 先判断ItemList.Count不等于0再调用
        /// 根据订单的选项值取得符合条件的组合
        /// </summary>
        /// <param name="Style_no"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public DataTable GetOrderCombination(String Style_no, List<string> ItemOptionList)
        {

            DataTable dt = new DataTable();
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine("   SELECT Combination_no,Style_no,memo_no,memo_name ");
            sqlstr.AppendLine("   FROM nMES_Style_Combination_master ");
            sqlstr.AppendLine("   where Style_no='" + Style_no + "'   ");//and Combination_state=0

            string wheresqlB = "%' )";
            string wheresql2 = "%' and memo_no like '%";
            string sqlstr_final = sqlstr.ToString() + "and ( memo_no like '%" + ItemOptionList[0].ToString().Trim();

            for (int i = 1; i < ItemOptionList.Count; i++)
            {
                sqlstr_final = sqlstr_final + wheresql2 + ItemOptionList[i].ToString().Trim(); 
            }

            sqlstr_final = sqlstr_final + wheresqlB;
            dt = DBConn.DataAcess.SqlConn.Query(sqlstr_final.ToString()).Tables[0];
            return dt;
        }

        /// <summary>
        /// 先判断ItemList.Count不等于0再调用
        /// 根据订单的选项值取得符合条件的组合
        /// </summary>
        /// <param name="Style_no">款号</param>
        /// <param name="memo_no">选项组合</param>
        /// <returns></returns>
        public int GetOrderCombination(String Style_no, string memo_no)
        {

            int Combination = 0;
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Clear();
            sqlstr.AppendLine("   SELECT Combination_no,Style_no,memo_no,memo_name ");
            sqlstr.AppendLine("   FROM nMES_Style_Combination_master ");
            sqlstr.AppendLine("   where Style_no='" + Style_no + "' and Combination_state=0 and memo_no='"+ memo_no + "' and Combination_state=0  ");//and Combination_state=0          

            Combination = Convert.ToInt16(DBConn.DataAcess.SqlConn.GetSingle(sqlstr.ToString()).ToString());
            return Combination;
        }


    }
}

