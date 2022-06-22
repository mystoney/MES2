using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.module.DAL;


namespace MES.module.BLL
{
    public class OperationBLL
    {
        /// <summary>
        /// 新版MES-导入工序清单
        /// </summary>
        /// <param name="Combination_no">组合号</param>
        /// <param name="memo">清单备注</param>
        /// <param name="dt_OperationList">清单明细</param>
        /// <returns></returns>
        public int NewOperationList(int Combination_no, string memo, DataGridView OperationList)
        {
            try
            {
                DataTable dt = new DataTable();
                SchemeBll  sd = new SchemeBll();
                
                dt = sd.DataGridViewToTable(OperationList);
                DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
                return od.NewOperationList(Combination_no, memo, dt);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        public Int64 GetMaxOperationNo()
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            return od.GetMaxOperationNo();
        }

        public DataTable GetOpList(int OpListNo)
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();

            DataTable dt_OpListNo = od.GetOpList(OpListNo);
            return dt_OpListNo;
        }

        public DataTable GetAllOperationList()
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            DataTable dt = od.GetAllOperationList();
            return dt;
        }
        public DataTable GetOperationListSingle(int Combination_no)
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            DataTable dt = od.GetOperationListSingle(Combination_no);
            return dt;
        }

        public int GetOpListNo(int Combination_no)
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            int i = od.GetOpListNo(Combination_no);
            return i;
        }


        #region 曹博接口


        public string OperationToCaobo(int OpListNo)
        {
            DAL.OperationDal.OperationDAL  od = new DAL.OperationDal.OperationDAL();
            string json_OperationList = od.GetJson_OperationList(OpListNo);
            string url = "http://172.16.1.39:8005/api/TongBuGongXu";
            string content = json_OperationList;
            string response = HttpPost(url, content);
            ApiResonse apiResonse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResonse>(response);
            if (apiResonse.state == 1)
            {
                od.UpdatePushState(OpListNo);
                return "1";
            }
            else
            {
                return apiResonse.message;
            }
            
        }


        

       public string OperationToJingYuan(int OpListNo)
        {
            DAL.OperationDal.OperationDAL od = new DAL.OperationDal.OperationDAL();
            string json_OperationList = od.GetJson_OpList(OpListNo);
            string url = "http://172.16.1.34:7802/GXBasics";
            string content = json_OperationList;
            string response = HttpPost(url, content);
            ApiResonse apiResonse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResonse>(response);
            if (apiResonse.state == 1)
            {
                od.UpdatePushState_JingYuan(OpListNo);
                return "1";
            }
            else
            {
                return apiResonse.message;
            }

        }



        public class ApiResonse
        {
            public int state { get; set; }
            public string return_Value { get; set; }
            public string message { get; set; }
        }
        public class GongXu_Src
        {
            public int OpListNo { get; set; }
            public string OperationNo { get; set; }
            public string OperationDes { get; set; }
            public int GST_xh { get; set; }
            public int manhour { get; set; }
            public string OperationType { get; set; }
        }

        public static string HttpPost(string url, string content)
        {
            try
            {
                //获取提交的字节
                byte[] bs = Encoding.UTF8.GetBytes(content);
                //设置提交的相关参数
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/json";
                req.ContentLength = bs.Length;
                //提交请求数据
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }
                //接收返回的页面，必须的，不能省略
                WebResponse wr = req.GetResponse();
                string responsestr = string.Empty;
                using (System.IO.Stream respStream = wr.GetResponseStream())
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("utf-8"));
                    responsestr = reader.ReadToEnd();
                    wr.Close();
                }
                return responsestr;
            }
            catch (Exception ex)
            {
                return ex.Message + ex.StackTrace;
            }
        }




        #endregion

    }
}
