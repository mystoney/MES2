using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using MES.module.DAL.Tmp_ZTMTM_COMCTRLDAL;

namespace MES.module.BLL
{
    /// <summary>
    /// Tmp_ZTMTM_COMCTRL的业务逻辑层
    /// </summary>
    public class Tmp_ZTMTM_COMCTRLBLL
    {
        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZTMTM_COMCTRL插入数据库
        /// </summary>
        /// <param name="_Tmp_ZTMTM_COMCTRL"> Tmp_ZTMTM_COMCTRL表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertALL(List<Tmp_ZTMTM_COMCTRL> _Tmp_ZTMTM_COMCTRL)
        {


            Tmp_ZTMTM_COMCTRLDAL TZTMTMCDAL = new Tmp_ZTMTM_COMCTRLDAL();





            try
            {
                return TZTMTMCDAL.InsertALL(_Tmp_ZTMTM_COMCTRL);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }



        }
    }
}
