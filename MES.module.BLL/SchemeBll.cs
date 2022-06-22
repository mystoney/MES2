using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.module.DAL;

namespace MES.module.BLL
{
    public class SchemeBll
    {
        /// <summary>
        /// 老版本
        /// </summary>
        /// <param name="Style_No"></param>
        /// <param name="memo"></param>
        /// <param name="dt_scheme"></param>
        /// <returns></returns>
        public int SaveScheme(string Style_No, string memo, DataTable dt_scheme)
        {
            DAL.SchemeDal.SchemeDal od = new DAL.SchemeDal.SchemeDal();
            int i = 0;
            i = od.NewOrder(Style_No, memo, dt_scheme);
            return i;
        }


        public DataTable DataGridViewToTable(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            // 循环列标题名称，处理了隐藏的行不显示
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                if (dgv.Columns[count].Visible == true)
                {
                    dt.Columns.Add(dgv.Columns[count].HeaderText.ToString());
                }
            }

            // 循环行，处理了隐藏的行不显示
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                int curr = 0;
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    if (dgv.Columns[countsub].Visible == true)
                    {
                        if (dgv.Rows[count].Cells[countsub].Value != null)
                        {
                            dr[curr] = dgv.Rows[count].Cells[countsub].Value.ToString();
                        }
                        else
                        {
                            dr[curr] = "";
                        }
                        curr++;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 传入选项组号，方案状态和生产路线
        /// </summary>
        /// <param name="Combination_no">选项组号</param>
        /// <param name="dgr">生产路线</param>
        /// <param name="state">0默认 1备用</param>
        /// <returns></returns>
        public int Scheme_Station_Add(int Combination_no, DataGridView dgr, int state, string memo)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DataGridViewToTable(dgr);
                DAL.SchemeDal.SchemeDal od = new DAL.SchemeDal.SchemeDal();
                int SchemeNo = 0;
                SchemeNo = od.Scheme_Station_Add(Combination_no, dt, state, memo);
                return SchemeNo;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }



        public DataTable GetSchemeList_detail(string SchemeNo)
        {
            DAL.SchemeDal.SchemeDal od = new DAL.SchemeDal.SchemeDal();
            return od.GetSchemeList_detail(SchemeNo);
        }

        public DataTable GetSchemeList_master(string StyleNo, int Combination_no)
        {
            DAL.SchemeDal.SchemeDal od = new DAL.SchemeDal.SchemeDal();
            return od.GetSchemeList_master(StyleNo, Combination_no);

        }


        public int GetSchemeLineNum(string SchemeNo)
        {
            DAL.SchemeDal.SchemeDal od = new DAL.SchemeDal.SchemeDal();
            return od.GetSchemeLineNum(SchemeNo);
        }

        public int UpdateSchemeMemo(int SchemeNo, string memo)
        {
            DAL.SchemeDal.SchemeDal od = new DAL.SchemeDal.SchemeDal();
            return od.UpdateSchemeMemo(SchemeNo, memo);
        }





    }
}
