using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.module.DAL.OperatorDal
{
    public class OperatorDAL
    {
        #region 获取员工-所有
        /// <summary>
        /// 获取员工-所有
        /// </summary>
        /// <returns></returns>
        public DataTable GetOperatorDT()
        {
            string sqlcmd = "SELECT id      ,OperatorID      ,OperatorName     ,OperatorPassword,OperatorState ,  CASE WHEN OperatorState = 0 THEN '启用' ELSE '已停用' END AS 员工状态 ,OperatorType ,CASE WHEN OperatorType = 'PF' THEN '平缝-PF' when OperatorType = 'FZ' then '辅助-FZ' when OperatorType = 'ZJ' then '质检-ZJ' when OperatorType = 'XX' then '信息-XX' when OperatorType is null then '未知' when OperatorType='' then '未知' else '其他' END AS 工种 FROM nMES_Operator_master order by id desc";
            return DBConn.DataAcess.SqlConn.Query(sqlcmd).Tables[0];
        }

        public List<OperatorInfo> GetOperatorList()
        {
            List<OperatorInfo> OperatorInfo = new List<OperatorInfo>();

            string sqlcmd = "SELECT id,OperatorID,OperatorName,OperatorPassword  FROM nMES_Operator_master";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlcmd).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OperatorInfo oi = new OperatorInfo();
                dt.Rows[i]["id"] = oi.id;
                dt.Rows[i]["OperatorID"] = oi.OperatorID;
                dt.Rows[i]["OperatorName"] = oi.OperatorName;
                dt.Rows[i]["OperatorPassword"] = oi.OperatorPassword;
                OperatorInfo.Add(oi);
            }
            return OperatorInfo;
        }
        #endregion

        #region 获取员工信息-单个
        /// <summary>
        /// 获取员工信息-单个
        /// </summary>
        /// <param name="OperatorID"></param>
        /// <returns></returns>
        public OperatorInfo GetOperatorSingle(string OperatorID)
        {
            List<OperatorInfo> OperatorInfo = new List<OperatorInfo>();
            string sqlcmd = "SELECT id,OperatorID,OperatorName,OperatorPassword  FROM nMES_Operator_master where OperatorID='" + OperatorID + "'";
            DataTable dt = DBConn.DataAcess.SqlConn.Query(sqlcmd).Tables[0];
            OperatorInfo oi = new OperatorInfo();
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["id"] = oi.id;
                dt.Rows[0]["OperatorID"] = oi.OperatorID;
                dt.Rows[0]["OperatorName"] = oi.OperatorName;
                dt.Rows[0]["OperatorPassword"] = oi.OperatorPassword;
            }
            return oi;
        }
        #endregion

        #region 员工-新建
        /// <summary>
        /// 员工-新建
        /// </summary>
        /// <param name="oi"></param>
        /// <returns></returns>
        public Return_Message OperatorInsert(OperatorInfo oi)
        {
            Return_Message rm = new Return_Message();

            string sqlselect = "SELECT count(OperatorID) FROM nMES_Operator_master where OperatorID='" + oi.OperatorID + "'";
            DataTable dtselect = DBConn.DataAcess.SqlConn.Query(sqlselect).Tables[0];
            
            if (Convert.ToInt32( dtselect.Rows[0][0].ToString().Trim()) > 0)
            {
                rm.State = Return_Message.Return_State.Error;
                rm.Message = "用户名重复，请重新输入";
                return rm;
            }
            string sqlstring = "INSERT INTO nMES_Operator_master (OperatorID,OperatorName,OperatorPassword,OperatorType) VALUES ('" + oi.OperatorID + "','" + oi.OperatorName + "','" + oi.OperatorPassword + "','"+ oi.OperatorType + "')";
            try
            {
                int i = DBConn.DataAcess.SqlConn.ExecuteSql(sqlstring);
                rm.State = Return_Message.Return_State.OK;
                rm.Return_Value = i.ToString();
                return rm;
            }
            catch (Exception ex)
            {
                rm.State = Return_Message.Return_State.Error;
                rm.Message = ex.ToString();
                return rm;
            }
        }
        #endregion

        #region 员工-更新密码
        /// <summary>
        /// 员工-更新密码
        /// </summary>
        /// <param name="oi"></param>
        /// <returns></returns>
        public Return_Message OperatorUpdatePassword(OperatorInfo oi)
        {
            Return_Message rm = new Return_Message();
            string sqlstring = "UPDATE nMES_Operator_master SET OperatorPassword = '" + oi.OperatorPassword + "'  WHERE OperatorID='" + oi.OperatorID + "'";
            try
            {
                int i = DBConn.DataAcess.SqlConn.ExecuteSql(sqlstring);
                rm.State = Return_Message.Return_State.OK;
                rm.Return_Value = i.ToString();
                return rm; ;
            }
            catch (Exception ex)
            {
                rm.State = Return_Message.Return_State.Error;
                rm.Return_Value = ex.ToString();
                return rm;
            }
        }
        #endregion


        #region 员工-更新密码
        /// <summary>
        /// 员工-更新密码
        /// </summary>
        /// <param name="oi"></param>
        /// <returns></returns>
        public Return_Message OperatorUpdateType(OperatorInfo oi)
        {
            Return_Message rm = new Return_Message();
            string sqlstring = "UPDATE nMES_Operator_master SET OperatorType = '" + oi.OperatorType + "'  WHERE OperatorID='" + oi.OperatorID + "'";
            try
            {
                int i = DBConn.DataAcess.SqlConn.ExecuteSql(sqlstring);
                rm.State = Return_Message.Return_State.OK;
                rm.Return_Value = i.ToString();
                return rm; ;
            }
            catch (Exception ex)
            {
                rm.State = Return_Message.Return_State.Error;
                rm.Return_Value = ex.ToString();
                return rm;
            }
        }
        #endregion



        #region 员工-更新密码
        /// <summary>
        /// 员工-更新密码
        /// </summary>
        /// <param name="oi"></param>
        /// <returns></returns>
        public Return_Message OperatorUpdateOperatorState(OperatorInfo oi)
        {
            Return_Message rm = new Return_Message();
            string sqlstring = "UPDATE nMES_Operator_master SET OperatorState = '" + oi.OperatorState + "'  WHERE OperatorID='" + oi.OperatorID + "'";
            try
            {
                int i = DBConn.DataAcess.SqlConn.ExecuteSql(sqlstring);
                rm.State = Return_Message.Return_State.OK;
                rm.Return_Value = i.ToString();
                return rm; ;
            }
            catch (Exception ex)
            {
                rm.State = Return_Message.Return_State.Error;
                rm.Return_Value = ex.ToString();
                return rm;
            }
        }
        #endregion



        #region 员工类
        /// <summary>
        /// 员工类
        /// </summary>
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


        #endregion

        #region 返回信息的类
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
        #endregion
    }
}
