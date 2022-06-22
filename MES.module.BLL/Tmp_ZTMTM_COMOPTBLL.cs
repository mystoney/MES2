using MES.module.DAL.Tmp_ZTMTM_COMCTRLDAL;
using MES.module.DAL.Tmp_ZTMTM_COMOPTDAL;
using MES.module.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.module.BLL
{

    /// <summary>
    /// Tmp_ZTMTM_COMOPT的业务逻辑层
    /// </summary>
    public class Tmp_ZTMTM_COMOPTBLL
    {
        /// <summary>
        /// 将从SAP中通过Web_service得到的表Tmp_ZTMTM_COMCTRL插入数据库
        /// </summary>
        /// <param name="_Tmp_ZTMTM_COMCTRL"> Tmp_ZTMTM_COMCTRL表的泛型</param>
        /// <returns>插入是否成功</returns>
        public bool InsertALL(List<Tmp_ZTMTM_COMOPT> _Tmp_ZTMTM_COMOPT)
        {


            Tmp_ZTMTM_COMOPTDAL TZTMTMCOMPTDAL = new Tmp_ZTMTM_COMOPTDAL();

            

            try
            {
                return TZTMTMCOMPTDAL.InsertALL(_Tmp_ZTMTM_COMOPT);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }



        }
    }
}
