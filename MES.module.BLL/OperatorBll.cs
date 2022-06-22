using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES.module.DAL.OperatorDal;

namespace MES.module.BLL
{
    public class OperatorBll
    {
        public DataTable GetOperatorDT()
        {
            OperatorDAL od = new OperatorDAL();
            return od.GetOperatorDT();
        }

        public int OperatorAdd(OperatorDAL.OperatorInfo oi)
        {
            int i = 0;
            OperatorDAL od = new OperatorDAL();
            return i;
        }

        public List<OperatorInfo> GetOperatorList()
        {
            OperatorDAL od = new OperatorDAL();
            List<OperatorDAL.OperatorInfo> ListDAL = new List<OperatorDAL.OperatorInfo>();
            ListDAL= od.GetOperatorList();

            List<OperatorInfo> List_this = new List<OperatorInfo>();

            for (int i = 0; i < ListDAL.Count; i++)
            {
                OperatorInfo oi_this = new OperatorInfo();
                oi_this.id = ListDAL[i].id;
                oi_this.OperatorID = ListDAL[i].OperatorID;
                oi_this.OperatorName = ListDAL[i].OperatorName;
                oi_this.OperatorPassword = ListDAL[i].OperatorPassword;
                oi_this.OperatorType = ListDAL[i].OperatorType;
                List_this.Add(oi_this);
            }
            return List_this;
        }
        public OperatorInfo GetOperatorSingle(string OperatorID)
        {
            OperatorDAL od = new OperatorDAL();
            OperatorDAL.OperatorInfo oiDAL = new OperatorDAL.OperatorInfo();
            oiDAL = od.GetOperatorSingle(OperatorID);

            OperatorInfo oi_this = new OperatorInfo();
            oi_this.id = oiDAL.id;
            oi_this.OperatorID = oiDAL.OperatorID;
            oi_this.OperatorName= oiDAL.OperatorName;
            oi_this.OperatorPassword = oiDAL.OperatorPassword;

            return oi_this;
        }

        public Return_Message OperatorInsert(OperatorInfo oi)
        {
            OperatorDAL.OperatorInfo oiDAL = new OperatorDAL.OperatorInfo();
            oiDAL.id = oi.id;
            oiDAL.OperatorID= oi.OperatorID;
            oiDAL.OperatorName= oi.OperatorName;
            oiDAL.OperatorPassword = oi.OperatorPassword;
            oiDAL.OperatorType = oi.OperatorType;
            OperatorDAL od = new OperatorDAL();
            OperatorDAL.Return_Message rm = new OperatorDAL.Return_Message();
            rm = od.OperatorInsert(oiDAL);

            Return_Message rm_this = new Return_Message();
            rm_this.State = (Return_Message.Return_State)rm.State;
            rm_this.Return_Value = rm.Return_Value;
            rm_this.Message = rm.Message;
            return rm_this;
        }

        public Return_Message OperatorUpdatePassword(OperatorInfo oi)
        {
            OperatorDAL.OperatorInfo oiDAL = new OperatorDAL.OperatorInfo();
            oiDAL.id = oi.id;
            oiDAL.OperatorID = oi.OperatorID;
            oiDAL.OperatorName = oi.OperatorName;
            oiDAL.OperatorPassword = oi.OperatorPassword;
            oiDAL.OperatorState = oi.OperatorState;
            oiDAL.OperatorType = oi.OperatorType;
            OperatorDAL od = new OperatorDAL();
            OperatorDAL.Return_Message rm = new OperatorDAL.Return_Message();
            rm = od.OperatorUpdatePassword(oiDAL);
            Return_Message rm_this = new Return_Message();
            rm_this.State = (Return_Message.Return_State)rm.State;
            rm_this.Return_Value = rm.Return_Value;
            rm_this.Message = rm.Message;
            return rm_this;    
        }

        public Return_Message OperatorUpdateType(OperatorInfo oi)
        {
            OperatorDAL.OperatorInfo oiDAL = new OperatorDAL.OperatorInfo();
            oiDAL.id = oi.id;
            oiDAL.OperatorID = oi.OperatorID;
            oiDAL.OperatorName = oi.OperatorName;
            oiDAL.OperatorPassword = oi.OperatorPassword;
            oiDAL.OperatorState = oi.OperatorState;
            oiDAL.OperatorType = oi.OperatorType;
            OperatorDAL od = new OperatorDAL();
            OperatorDAL.Return_Message rm = new OperatorDAL.Return_Message();
            rm = od.OperatorUpdateType(oiDAL);
            Return_Message rm_this = new Return_Message();
            rm_this.State = (Return_Message.Return_State)rm.State;
            rm_this.Return_Value = rm.Return_Value;
            rm_this.Message = rm.Message;
            return rm_this;
        }



        public Return_Message OperatorUpdateOperatorState(OperatorInfo oi)
        {
            OperatorDAL.OperatorInfo oiDAL = new OperatorDAL.OperatorInfo();
            oiDAL.id = oi.id;
            oiDAL.OperatorID = oi.OperatorID;
            oiDAL.OperatorName = oi.OperatorName;
            oiDAL.OperatorPassword = oi.OperatorPassword;
            oiDAL.OperatorState = oi.OperatorState;
            OperatorDAL od = new OperatorDAL();
            OperatorDAL.Return_Message rm = new OperatorDAL.Return_Message();
            rm = od.OperatorUpdateOperatorState(oiDAL);
            Return_Message rm_this = new Return_Message();
            rm_this.State = (Return_Message.Return_State)rm.State;
            rm_this.Return_Value = rm.Return_Value;
            rm_this.Message = rm.Message;
            return rm_this;
        }
        public enum OperatorState
        {
            /// <summary>
            /// OK
            /// </summary>
            停用 = 1,
            /// <summary>
            /// Error
            /// </summary>
            启用 = 0
        }





        public class OperatorInfo
        {
            /// <summary>
            /// id
            /// </summary>
            public int id { get; set; }
            public string OperatorID { get; set; }
            public string OperatorName { get; set; }
            public string OperatorPassword { get; set; }
            public int OperatorState { get; set; }
            public string OperatorType { get; set; }
        }
        /// <summary>
        /// 返回信息的类
        /// </summary>
        public class Return_Message
        {
            /// <summary>
            /// 构造函数
            /// </summary>
            public Return_Message()
            {
            }


            /// <summary>
            /// 返回的状态
            /// </summary>
            public Return_State State { get; set; }

            /// <summary>
            /// 返回的值的JSON对象
            /// </summary>
            public string Return_Value { get; set; }
            /// <summary>
            /// 返回的信息
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// 返回信息类中信息状态用的枚举
            /// </summary>
            public enum Return_State
            {
                /// <summary>
                /// OK
                /// </summary>
                OK = 1,
                /// <summary>
                /// Error
                /// </summary>
                Error = 2
            }

        }


    }
}
