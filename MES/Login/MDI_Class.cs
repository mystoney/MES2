using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace MES.form
{
    class MDI_Class
    {
        /// <summary>
        /// 人员的名字
        /// </summary>
        public static string rs_name = "";

        /// <summary>
        /// 人员ID
        /// </summary>
        public static int RS_ID = 0;

        /// <summary>
        /// 登录名
        /// </summary>
        public static string login_id = "";


  

        /// <summary>
        /// 存储权限树的函数
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string SaveCheck(TreeNode node)
        {
            string s;

            if (node.Checked)
            {
                s= "'" + node.Tag + "',";

            }
            else
            {
                s = "";
                return s;
            }

            if ( node.FirstNode!=null)
            {
                node = node.FirstNode;
                s=(s + SaveCheck(node));
            }

            while (!(node.NextNode ==null))
            {
                node = node.NextNode;
                s = s + SaveCheck(node);
            }

            return s;



        }


        ///// <summary>
        ///// 将水晶报表转成PDF存储在数据库中
        ///// </summary>
        ///// <param name="report">要存储的水晶报表</param>
        ///// <param name="billno">单据号</param>
        ///// <returns></returns>
        //public static Boolean Save_PDF(CrystalDecisions.CrystalReports.Engine.ReportDocument report,string billno)
        //{
        //    ArrayList AL = new ArrayList();

        //    string sql="";

        //    try
        //    {

            
        //    Stream PDFStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    BinaryReader PDFReader = new BinaryReader(PDFStream);
        //    byte[] PDFResult = PDFReader.ReadBytes((int)PDFStream.Length);




        //    sql = "INSERT INTO t_reportPDF(billno, b_no, pdf, print_man) " +
        //     "select '"+billno+ "',isnull(max(b_no), 0)+1,@pdf," + rs_name+" from mes_reportPDF where billno = '"+billno+"'";


        //    DBConn.DataAcess.SqlConn.ExecuteSqlInsertImg(sql, PDFResult);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw  new Exception(ex.Message+"["+sql+"]");
        //    }
        //    return true;

        //}
        
    }
}
