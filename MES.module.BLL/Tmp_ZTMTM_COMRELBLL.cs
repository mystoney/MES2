using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.module.model;
using MES.module.DAL.Tmp_ZTMTM_COMRELDAL;

namespace MES.module.BLL
{

    /// <summary>
    /// Tmp_ZTMTM_COMREL的业务逻辑层
    /// </summary>
    public class Tmp_ZTMTM_COMRELBLL
    {
        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZTMTM_COMCTRL插入数据库
        /// </summary>
        /// <param name="_Tmp_ZTMTM_COMCTRL"> Tmp_ZTMTM_COMCTRL表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertALL(List<Tmp_ZTMTM_COMREL> _Tmp_ZTMTM_COMREL)
        {


            Tmp_ZTMTM_COMRELDAL TZTMTMCOMRELDAL = new Tmp_ZTMTM_COMRELDAL();





            try
            {
                return TZTMTMCOMRELDAL.InsertALL(_Tmp_ZTMTM_COMREL);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }



        }
    }
}
